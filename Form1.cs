using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Has2BeSameNameSpace;
using System.Diagnostics;
using System.Linq.Expressions;

namespace UR2_robot_arm2
{
    public partial class Form1 : Form
    {

        //main capture object from Emgu.Cv MAIN CODE THAT COMMUNICATES WITH CAMERA. TELLS TO COMMUNICATE WITH CAMERA
        VideoCapture mCapture;

        //video thread for multi-threading THIS IS THE THREAD. THIS IS A WORKER THAT WORKS WITH PARRELLEL WITH OTHER APPLICATIONS.
        //DO THINGS ON SCREEN AT THE SAME TIME HAVE MULTIPLE TASKS RUNNING. ANY JOB GOES THROUGH THIS THREAD. KEEP CAMERA RUNNING WHILE DOING A TASK
        Thread mCaptureThread;

        //for requesting thread termination THIS IS A MODERN WAY OF STOPPING A THREAD. START STOP THREAD MCANCELLATION REQUEST TO CANCELL.
        //IF CANCEL REQUESTED..STOP.
        CancellationTokenSource mCancellationToken = new();

        //capturing state indicator I WANT TO KNOW THE STATE. IS THE CAMERA CAPTURING OR NOT
        bool mIsCapturing = false;




        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try

            {
                //initialize with ifany plugged camera
                mCapture = new VideoCapture(0, VideoCapture.API.DShow); //0 means default , 1 means webcam

                if (mCapture.Height == 1) //must match what mCapture is on above line
                    throw new Exception("No Camera Found");

                //initalize new thread
                mCaptureThread = new Thread(() => DisplayWebcam(mCancellationToken.Token));

                // Start the thread
                mCaptureThread.Start();

                // Indicate new state
                mIsCapturing = true;

                // Optional: Update UI or perform any other initialization

                // The picture boxes will be updated in the DisplayWebcam method
            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.Message);
            }


        }

        private void DisplayWebcam(CancellationToken token)
        {
            while (!token.IsCancellationRequested) //while no requested cancellation
            {
                // input
                Mat sourceFrame = mCapture.QueryFrame(); // grab a new frame

                // resize to PictureBox aspect ratio
                int newHeight = (sourceFrame.Size.Height * VideoPictureBox.Size.Width) / sourceFrame.Size.Width;

                Size newSize = new Size(VideoPictureBox.Size.Width, newHeight);

                CvInvoke.Resize(sourceFrame, sourceFrame, newSize);

                // display the image in the source PictureBox
                VideoPictureBox.Image = sourceFrame.ToBitmap();

                // copy the source image so we can display a copy with artwork without editing the original:
                Mat sourceFrameWithArt = sourceFrame.Clone();

                // create an image version of the source frame, will be used when warping the image
                Image<Bgr, byte> sourceFrameWarped = sourceFrame.ToImage<Bgr, byte>();

                // Isolating the ROI: convert to a gray, apply binary threshold:
                Image<Gray, byte> grayImg = sourceFrame.ToImage<Gray, byte>().ThresholdBinary(new Gray(125), new
                Gray(255));

                using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
                {
                    // Build list of contours
                    CvInvoke.FindContours(grayImg, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);

                    // Selecting largest contour
                    if (contours.Size > 0)
                    {
                        double maxArea = 0;
                        int chosen = 0;

                        for (int i = 0; i < contours.Size; i++)
                        {
                            VectorOfPoint contour = contours[i];
                            double area = CvInvoke.ContourArea(contour);
                            if (area > maxArea)
                            {
                                maxArea = area;
                                chosen = i;
                            }
                        }

                        // Getting minimal rectangle which contains the contour
                        Rectangle boundingBox = CvInvoke.BoundingRectangle(contours[chosen]);

                        // Draw on the display frame
                        MarkDetectedObject(sourceFrameWithArt, contours[chosen], boundingBox, maxArea);

                        // Create a slightly larger bounding rectangle, we'll set it as the ROI for later warping
                        sourceFrameWarped.ROI = new Rectangle((int)Math.Min(0, boundingBox.X - 30),

                        (int)Math.Min(0, boundingBox.Y - 30),

                        (int)Math.Max(sourceFrameWarped.Width - 1, boundingBox.X + boundingBox.Width + 30),

                        (int)Math.Max(sourceFrameWarped.Height - 1, boundingBox.Y + boundingBox.Height + 30));
                        // Display the version of the source image with the added artwork, simulating ROI focus:

                        GrayPictureBox.Image = sourceFrameWithArt.ToBitmap();
                        // Warp the image, output it

                        DecoratedPictureBox.Image = WarpImage(sourceFrameWarped, contours[chosen]).ToBitmap();

                    }
                }
            }
        }
        private static Image<Bgr, Byte> WarpImage(Image<Bgr, byte> frame, VectorOfPoint contour)
        {
            // set the output size:
            var size = new Size(frame.Width, frame.Height);

            using (VectorOfPoint approxContour = new VectorOfPoint())
            {
                CvInvoke.ApproxPolyDP(contour, approxContour, CvInvoke.ArcLength(contour, true) * 0.05, true);

                // get an array of points in the contour
                Point[] points = approxContour.ToArray();

                // if array length isn't 4, something went wrong, abort warping process (for demo, draw points instead)
                if (points.Length != 4)
                {
                    for (int i = 0; i < points.Length; i++)
                    {
                        frame.Draw(new CircleF(points[i], 5), new Bgr(Color.Red), 5);
                    }
                    return frame;
                }
                IEnumerable<Point> query = points.OrderBy(point => point.Y).ThenBy(point => point.X);

                PointF[] ptsSrc = new PointF[4];

                PointF[] ptsDst = new PointF[] { new PointF(0, 0), new PointF(size.Width - 1, 0), new PointF(0, size.Height - 1),
                new PointF(size.Width - 1, size.Height - 1) };

                for (int i = 0; i < 4; i++)
                {
                    ptsSrc[i] = new PointF(query.ElementAt(i).X, query.ElementAt(i).Y);
                }

                using (var matrix = CvInvoke.GetPerspectiveTransform(ptsSrc, ptsDst))
                {
                    using (var cutImagePortion = new Mat())
                    {
                        CvInvoke.WarpPerspective(frame, cutImagePortion, matrix, size, Inter.Cubic);
                        return cutImagePortion.ToImage<Bgr, Byte>();
                    }
                }
            }
        }
        private static void MarkDetectedObject(Mat frame, VectorOfPoint contour, Rectangle boundingBox, double area)
        {
            // Drawing contour and box around it
            CvInvoke.Polylines(frame, contour, true, new Bgr(Color.Red).MCvScalar);

            CvInvoke.Rectangle(frame, boundingBox, new Bgr(Color.Red).MCvScalar);

            // Write information next to marked object
            Point center = new Point(boundingBox.X + boundingBox.Width / 2, boundingBox.Y + boundingBox.Height / 2);

            var info = new string[] 
            {
                   $"Area: {area}",
            $"Position: {center.X}, {center.Y}"
            };

            WriteMultilineText(frame, info, new Point(center.X, boundingBox.Bottom + 12));
        }
        private static void WriteMultilineText(Mat frame, string[] lines, Point origin)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                int y = i * 10 + origin.Y; // Moving down on each line

                CvInvoke.PutText(frame, lines[i], new Point(origin.X, y),

                FontFace.HersheyPlain, 0.8, new Bgr(Color.Red).MCvScalar);
            }


        }

    }
}
