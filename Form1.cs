using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Has2BeSameNameSpace;
using System.Diagnostics;
using System.Drawing;
using System.IO.Pipes;
using System.IO.Ports;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using static UR2_robot_arm2.Form1;

namespace UR2_robot_arm2
{
    public partial class Form1 : Form
    {
        List<Shape> mShapes = new List<Shape>();


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

        int mGrayMin = 1;
        int mGrayMax = 255;

        Mat mOriginalImage;
        Mat lOriginalImageDisplay = new Mat(); // grab a new frame
        Image<Gray, byte> grayImg;
        Image<Bgr, byte> sourceFrameWarped;
        Mat sourceFrameWithArt;

        //Serial Communication
        SerialPort mArduinoSerial = new SerialPort();
        Thread mSerialMonitoringThread;
        CancellationTokenSource mSerialCancellationToken = new();
        int mContoursCount = 0;
        bool mFoundIsValid = false;
        bool mReplyIsReady = false;

        //SerialPort inputSerial;

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Dispose all processing threads to avoid orphaned processes
            if (mIsCapturing)
            {
                mCancellationToken.Cancel();
            }
            mCapture.Dispose();
            mCancellationToken.Dispose();

            mSerialCancellationToken.Cancel();
            mSerialCancellationToken.Dispose();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try

            {
                //initialize with ifany plugged camera
                mCapture = new VideoCapture(0, VideoCapture.API.DShow); //0 means webcam , 1 means default??

                if (mCapture.Height == 0) //must match what mCapture is on above line
                    throw new Exception("No Camera Found");

                //initalize new thread
                mCaptureThread = new Thread(() => DisplayWebcam(mCancellationToken.Token));

                // Start the thread
                mCaptureThread.Start();

                // Indicate new state
                mIsCapturing = true;



                try
                {

                    // Initialize serial port
                    mArduinoSerial.PortName = "COM6";
                    mArduinoSerial.BaudRate = 9600;
                    mArduinoSerial.DataReceived += SerialPort_DataReceived;

                    // Open the serial port
                    mArduinoSerial.Open();

                    // ...
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error initializing serial port: {ex.Message}");
                    Close();
                }

            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.Message);
                Close();

            }

        }

        private void SendDataToArduino(string data)
        {

            try
            {
                if (mArduinoSerial.IsOpen)
                {
                    mArduinoSerial.WriteLine(data);
                }
                else
                {
                    // Handle the case where the serial port is not open
                    MessageBox.Show("Serial port is not open.");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during serial communication
                MessageBox.Show($"Error sending data to Arduino: {ex.Message}");
            }
        }

        private void SendCoordsToArduino(string Coords)
        {

            try
            {
                if (mArduinoSerial.IsOpen)
                {
                    mArduinoSerial.WriteLine(Coords);
                }
                else
                {
                    // Handle the case where the serial port is not open
                    MessageBox.Show("Serial port is not open.");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during serial communication
                MessageBox.Show($"Error sending data to Arduino: {ex.Message}");
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string receivedData = mArduinoSerial.ReadLine();
                DisplayReceivedData(receivedData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error receiving data from Arduino: {ex.Message}");
            }
        }

        private void SerialPort_CoordsReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string receivedCoords = mArduinoSerial.ReadLine();
                DisplayReceivedData(receivedCoords);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error receiving data from Arduino: {ex.Message}");
            }
        }

        private void DisplayReceivedData(string data)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(DisplayReceivedData), data);
            }
            else
            {
                UpdateArduinoDataTextBox(data);
            }
        }

        private void DisplayReceivedCoords(string coords)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(DisplayReceivedCoords), coords);
            }
            else
            {
                UpdateArduinoDataTextBox(coords);
            }
        }

        private void UpdateArduinoDataTextBox(string data)
        {
            if (ArduinoDataTextBox.InvokeRequired)
            {
                // If the current thread is not the UI thread, invoke the update
                ArduinoDataTextBox.Invoke(new Action(() => UpdateArduinoDataTextBox(data)));
            }
            else
            {
                // Update the UI control
                ArduinoDataTextBox.Text = data;
            }
        }
        private void UpdateCTextBox(string Coords)
        {
            if (CtextBox.InvokeRequired)
            {
                // If the current thread is not the UI thread, invoke the update
                CtextBox.Invoke(new Action(() => UpdateCTextBox(Coords)));
            }
            else
            {
                // Update the UI control
                CtextBox.Text = Coords;
            }
        }

        public void SendShapeDataToArduino()
        {
            try
            {

                // Iterate through each shape in the list
                foreach (var shape in mShapes)
                {
                    // Access properties of the shape
                    int centerX = shape.CenterX;
                    int centerY = shape.CenterY;

                    // Convert the integer values to strings for sending over Serial
                    string centerXString = centerX.ToString();
                    string centerYString = centerY.ToString();

                    // Send the data to Arduino over Serial
                    mArduinoSerial.WriteLine($"X:{centerXString},Y:{centerYString}");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions as needed
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public class Shape
        {
            public int Type { get; set; }
            public int CenterX { get; set; }
            public int CenterY { get; set; }
        }

        private int GetShapeType(int vertices)
        {
            switch (vertices)
            {
                case 3:
                    return 0; // Triangle
                case 4:
                    return 1; // Square or Rectangle
                case 5:
                    return 2; // Pentagon
                case 6:
                    return 3; // Hexagon
                default:
                    return 4; // Circle or other shapes
            }
        }

        private void DisplayWebcam(CancellationToken token)
        {
            while (!token.IsCancellationRequested) //while no requested cancellation
            {
                // input
                mOriginalImage = mCapture.QueryFrame(); // set mOriginalImage to queryframe


                // resize to PictureBox aspect ratio
                int newHeight = (mOriginalImage.Size.Height * VideoPictureBox.Size.Width) / mOriginalImage.Size.Width;
                Size newSize = new Size(VideoPictureBox.Size.Width, newHeight);
                CvInvoke.Resize(mOriginalImage, lOriginalImageDisplay, newSize);


                // copy the source image so we can display a copy with artwork without editing the original:
                sourceFrameWithArt = lOriginalImageDisplay.Clone();

                // create an image version of the source frame, will be used when warping the image
                sourceFrameWarped = lOriginalImageDisplay.ToImage<Bgr, byte>();

                // Isolating the ROI: convert to a gray, apply binary threshold:
                grayImg = lOriginalImageDisplay.ToImage<Gray, byte>().ThresholdBinary(new Gray(mGrayMin), new
                Gray(mGrayMax));

                // display the image in the source PictureBox
                VideoPictureBox.Image = lOriginalImageDisplay.ToBitmap();

                // convert to binary gray image
                var lGrayImage = lOriginalImageDisplay.ToImage<Gray, byte>()
                                    .ThresholdBinary(new Gray(mGrayMin), new Gray(mGrayMax)).Mat;

                //flickering ???
                //GrayPictureBox.Image = lGrayImage.ToBitmap();




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

        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            mCancellationToken.Cancel(); //request a stop
            mIsCapturing = false; //indicate new state

            OpenFileDialog lFile = new OpenFileDialog();

            if (lFile.ShowDialog() == DialogResult.OK)
            {

                mOriginalImage = CvInvoke.Imread(lFile.FileName,
                                        Emgu.CV.CvEnum.ImreadModes.AnyColor);

                //ProcessImage();
                //SendDataToArduino();
            }
        }

        private void GrayMin_Scroll(object sender, EventArgs e)
        {
            mGrayMin = GrayMin.Value; //int member GrayMin = name of trackbar
            GrayMinLabel.Text = mGrayMin.ToString();
            ProcessImage();
            //SendDataToArduino(mContoursCount.ToString());
        }

        private void GrayMax_Scroll(object sender, EventArgs e)
        {
            mGrayMax = GrayMax.Value;
            GrayMaxLabel.Text = mGrayMax.ToString();
            ProcessImage();
            //SendDataToArduino(mContoursCount.ToString());
        }

        void ProcessImage()
        {

            // find lContours:
            using (VectorOfVectorOfPoint lContours = new VectorOfVectorOfPoint())
            {
                mFoundIsValid = false;


                // Build list of lContours on the gray image
                CvInvoke.FindContours(grayImg, lContours, null, RetrType.List,
                                        ChainApproxMethod.ChainApproxSimple);

                // Selecting largest contour NEW-> DO process only if found count is logical
                if (lContours.Size > 0 && lContours.Size < 20)
                {
                    mFoundIsValid = true;
                    //Find largest contour
                    double maxArea = 0;
                    int chosen = 0;



                    for (int i = 0; i < lContours.Size; i++)
                    {
                        VectorOfPoint contour = lContours[i];
                        double area = CvInvoke.ContourArea(contour);
                        if (area > maxArea)
                        {
                            maxArea = area;
                            chosen = i;
                        }
                    }


                    // Getting minimal rectangle which contains the contour
                    Rectangle boundingBox = CvInvoke.BoundingRectangle(lContours[chosen]);

                    // Draw on the display frame
                    MarkDetectedObject(sourceFrameWithArt, lContours[chosen], boundingBox, maxArea);

                    // Create a slightly larger bounding rectangle, we'll set it as the ROI for later warping
                    sourceFrameWarped.ROI = new Rectangle((int)Math.Min(0, boundingBox.X - 30),
                    (int)Math.Min(0, boundingBox.Y - 30),
                    (int)Math.Max(sourceFrameWarped.Width - 1, boundingBox.X +
                    boundingBox.Width + 30),
                    (int)Math.Max(sourceFrameWarped.Height - 1, boundingBox.Y +
                    boundingBox.Height + 30));

                    // Display the version of the source image with the added artwork, simulating ROI focus:
                    //lDecoratedImage.ToBitmap is for AREA AND POS., .sourseFrameWithArt.TopBitmap is for grayscale adjusting.
                    //GrayPictureBox.Image = lDecoratedImage.ToBitmap();    // was....   GrayPictureBox.Image = sourceFrameWithArt.ToBitmap();

                    GrayPictureBox.Image = sourceFrameWithArt.ToBitmap();

                    Image<Bgr, Byte> warpedFrame = WarpImage(sourceFrameWarped, lContours[chosen]);
                    Image<Gray, Byte> grayWarpedFrame = warpedFrame.Convert<Gray, Byte>();


                    // Warp the image, output it
                    //DecoratedPictureBox.Image = WarpImage(sourceFrameWarped, lContours[chosen]).ToBitmap();

                    List<Bgr> lColors = new List<Bgr>{ new Bgr(Color.Red),
                                                        new Bgr(Color.Green),
                                                        new Bgr(Color.Blue),
                                                        new Bgr(Color.Yellow),
                                                        new Bgr(Color.Orange),
                                                        new Bgr(Color.Pink),
                                                        new Bgr(Color.Purple)};

                    for (int i = 0; i < lContours.Size; i++)
                    {

                        double lCurPerimeter = CvInvoke.ArcLength(lContours[i], true);
                        VectorOfPoint lCurApprox = new VectorOfPoint();
                        CvInvoke.ApproxPolyDP(lContours[i], lCurApprox, 0.04 * lCurPerimeter, true);

                        CvInvoke.DrawContours(grayWarpedFrame, lContours, i, new MCvScalar(0, 0, 255), 2);

                        //lMoments  center of the shape
                        var lMoments = CvInvoke.Moments(lContours[i]);
                        int lCenterX = (int)(lMoments.M10 / lMoments.M00);
                        int lCenterY = (int)(lMoments.M01 / lMoments.M00);


                        // Use different variable for text position
                        int textCenterXSquare = lCenterX;
                        int textCenterYSquare = lCenterY;
                        int textCenterTriX = lCenterX;
                        int textCenterTriY = lCenterY;                        //position of text of shape
                        int textCenterRecX = lCenterX;
                        int textCenterRecY = lCenterY;

                        var lMomentsAll = CvInvoke.Moments(lContours[i]);
                        int lCenterAllX = (int)(lMomentsAll.M10 / lMomentsAll.M00);
                        int lCenterAllY = (int)(lMomentsAll.M01 / lMomentsAll.M00);

                        string positionMin = lCenterX.ToString() + "," + lCenterY.ToString();
                        string positionAll = lCenterAllX.ToString() + "," + lCenterAllY.ToString();

                        Shape currentShape = new Shape();


                        if (lCurApprox.Size == 3)
                        {
                            // Set the properties of the current shape
                            currentShape.Type = GetShapeType(lCurApprox.Size);  // You need to implement GetShapeType method
                            currentShape.CenterX = lCenterX;
                            currentShape.CenterY = lCenterY;

                            //Add the current shape to the list
                            mShapes.Add(currentShape);


                            CvInvoke.PutText(warpedFrame, $"Triangle {lCenterX}, {lCenterY}", new Point(textCenterTriX, textCenterTriY),
                                Emgu.CV.CvEnum.FontFace.HersheySimplex, 0.5, new MCvScalar(0, 0, 255), 2);
                            //CvInvoke.PutText(sourceFrameWarped, positionMin, new Point(lCenterX, lCenterY),
                            //    Emgu.CV.CvEnum.FontFace.HersheySimplex, 1.0, new MCvScalar(255, 0, 255), 2);

                            // Use Invoke to update the UI control from the UI thread
                            shapesTextBox.Invoke(new Action(() =>
                            {
                                shapesTextBox.AppendText($"Triangle: X={lCenterX}, Y={lCenterY}\r\n");
                            }));

                        }

                        if (lCurApprox.Size == 4)
                        {

                            currentShape.Type = GetShapeType(lCurApprox.Size);  // You need to implement GetShapeType method
                            currentShape.CenterX = lCenterX;
                            currentShape.CenterY = lCenterY;

                            //Add the current shape to the list
                            mShapes.Add(currentShape);

                            Rectangle rect = CvInvoke.BoundingRectangle(lContours[i]);
                            double ar = (double)rect.Width / rect.Height;


                            if (ar >= 0.95 && ar <= 1.05)
                            {
                                CvInvoke.PutText(warpedFrame, $"Square {lCenterX}, {lCenterY}", new Point(textCenterXSquare, textCenterYSquare),
                                Emgu.CV.CvEnum.FontFace.HersheySimplex, 0.5, new MCvScalar(0, 0, 255), 2);


                                // Use Invoke to update the UI control from the UI thread
                                shapesTextBox.Invoke(new Action(() =>
                                {
                                    shapesTextBox.AppendText($"Square: X={lCenterX}, Y={lCenterY}\r\n");
                                }));

                            }
                            else
                            {
                                CvInvoke.PutText(warpedFrame, $"Rectangle {lCenterX}, {lCenterY}", new Point(textCenterRecX, textCenterRecY),
                                Emgu.CV.CvEnum.FontFace.HersheySimplex, 0.5, new MCvScalar(0, 0, 255), 2);

                                // Use Invoke to update the UI control from the UI thread
                                shapesTextBox.Invoke(new Action(() =>
                                {
                                    shapesTextBox.AppendText($"Rectangle: X={lCenterX}, Y={lCenterY}\r\n");
                                }));

                            }

                        }

                    }


                    //DecoratedPictureBox.Image = WarpImage(sourceFrameWarped, lContours[chosen]).ToBitmap();
                    CoordsTextBox.Invoke(new Action(() =>
                    {
                        CoordsTextBox.Text = $"{lContours.Size} lContours detected.";
                    }));
                    // display decorated image
                    DecoratedPictureBox.Image = warpedFrame.ToBitmap();

                    mContoursCount = lContours.Size;



                    // Process contours excluding the largest one
                    for (int i = 0; i < lContours.Size; i++)
                    {
                        if (i == chosen) // Skip the largest contour
                            continue;

                        VectorOfPoint contour = lContours[i];
                        // ... (rest of your code for processing each contour)
                    }

                    mContoursCount = lContours.Size - 1; // Exclude the largest contour

                }


            }
        }

        private void SendSerial_Click_1(object sender, EventArgs e)
        {
            SendDataToArduino(mContoursCount.ToString());
        }
    }
}

