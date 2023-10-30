using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Has2BeSameNameSpace;
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

        private SerialCom SerialCommunication; //this is needed created class LINKS UP TO CLASS calls it

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try

            {
                //initialize with ifany plugged camera
                mCapture = new VideoCapture(0);

                if (mCapture.Height == 0)
                    throw new Exception("No Camera Found");
            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.Message);
            }
            SerialCommunication = new SerialCom ("COM6"); // serial port that communicates with arduino

       }

        private void StartStopBtn_Click(object sender, EventArgs e)
        {
            if (mIsCapturing) //if live, stop it
            {
                mCancellationToken.Cancel(); //request a stop
                mIsCapturing = false; //indicate new state
                StartStopBtn.Text = "Start"; //inform accordingly
            }
            else // if dead, start it
            {
                mCancellationToken = new(); //reinitialize

                //initilize new thread
                mCaptureThread = new(() => DisplayWebcam(mCancellationToken.Token));

                mCaptureThread.Start(); //start it

                mIsCapturing = true; //indicate new state
                StartStopBtn.Text = "Stop"; //inform accordingly
            }
        }
        private void DisplayWebcam(CancellationToken token)
        {
            while (!token.IsCancellationRequested) //while no requested cancellation
            {
                Mat frame = mCapture.QueryFrame(); // grab a new frame

                //resize to PictureBox aspect ratio
                int newHeight = (frame.Size.Height * VideoPictureBox.Size.Width) / frame.Size.Width;
                Size newSize = new Size(VideoPictureBox.Size.Width, newHeight);
                CvInvoke.Resize(frame, frame, newSize);

                // ~60 fps -> 1000ms/60 = 16.6
                Task.Delay(16);

                VideoPictureBox.Image = frame.ToBitmap(); //display current frame
            }

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //DIspose all processing threads to avoid orphaned processes
            mCapture.Dispose();
            mCancellationToken.Dispose();
        }

        private void arduinoLEDon_Click(object sender, EventArgs e)
        {
            int serialData = 0;
            if (mIsCapturing)
                SerialCommunication.Move(1); //1 for LED on
            serialData = 1;

            //set up label to output the serial input
            Invoke(new Action(() =>
            {
               SerialDataChar.Text = $"{serialData}";

            }));
        }

        private void arduinoLEDoff_Click(object sender, EventArgs e)
        {
            int serialData = 0;
            if (mIsCapturing)
                SerialCommunication.Move(0); //0 for lead off
            serialData = 0;

            //set up label to output the serial input
            Invoke(new Action(() =>
            {
                SerialDataChar.Text = $"{serialData}";

            }));
        }

        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog lFile = new OpenFileDialog();

            if (lFile.ShowDialog() == DialogResult.OK)
            {
                // MessageBox.Show(lFile.FileName, "file to open.."

                Mat workingImage = CvInvoke.Imread(lFile.FileName, Emgu.CV.CvEnum.ImreadModes.AnyColor);

                //resize to PictureBox aspect ratio
                int newHeight = (workingImage.Size.Height * sourcePictureBox.Size.Width) / workingImage.Size.Width;
                Size newSize = new Size(sourcePictureBox.Size.Width, newHeight);
                CvInvoke.Resize(workingImage, workingImage, newSize);

                //as a test for comparison, create a copy of the image with a binary file
                var binaryImage = workingImage.ToImage<Gray, byte>().ThresholdBinary(new Gray(125), new Gray(255)).Mat;

                //Sample for gaussian blur;
                var blurredImage = new Mat();
                var cannyImage = new Mat();
                var decoratedImage = new Mat();
                CvInvoke.GaussianBlur(workingImage, blurredImage, new Size(3, 3), 0);

                //convert to B/W
                CvInvoke.CvtColor(blurredImage, blurredImage, typeof(Bgr), typeof(Gray));

                // apply canny:
                // NOTE: Canny function can frequently create duplicate lines on the same shape
                //       depending on blur amount and threshold values, some tweaking might be needed.
                //       You might also find that not using Canny and instead using FindContours on
                //       a binary-threshold image is more accurate. 
                CvInvoke.Canny(blurredImage, cannyImage, 150, 255);

                // make a copy of the canny image, convert it to color for decorating:
                CvInvoke.CvtColor(cannyImage, decoratedImage, typeof(Gray), typeof(Bgr));

                // find contours:
                using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
                {
                    // Build list of contours
                    CvInvoke.FindContours(cannyImage, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);

                    List<Bgr> lColors = new List<Bgr>{ new Bgr(Color.Red),
                                                        new Bgr(Color.Green),
                                                        new Bgr(Color.Blue),
                                                        new Bgr(Color.Pink),
                                                        new Bgr(Color.Yellow),
                                                        new Bgr(Color.Orange),
                                                        new Bgr(Color.Purple)};
                    // remove duplicate contours
                    //List<bool> lIsDuplicateFlags = Enumerable.Repeat(false, contours.Size).ToList(); ;

                    //var PositionThreshold = 10;

                    //for (int i = 0; i < contours.Size - 1; i++)
                    //{
                    //    var lCurPosition = contours[i][0];

                    //    for (int j = i + 1; j < contours.Size; j++)
                    //    {
                    //        var lNextPosition = contours[j][0];

                    //        var lDistance = Math.Sqrt((Math.Pow(lCurPosition.X - lNextPosition.X, 2) + Math.Pow(lCurPosition.Y - lNextPosition.Y, 2)));

                    //        if (lDistance < PositionThreshold)
                    //        {
                    //            lIsDuplicateFlags[i] = true;
                    //            break;
                    //        }
                    //    }
                    //}

                    var lKeptCount = 0;
                    for (int i = 0; i < contours.Size; i++)
                    {
                        //if (lIsDuplicateFlags[i] == true)
                        //{
                        //    continue;
                        //}
                        lKeptCount++;

                        VectorOfPoint contour = contours[i];
                        CvInvoke.Polylines(decoratedImage, contour, true, lColors[i].MCvScalar);
                        CvInvoke.Circle(decoratedImage, contour[0], 5, lColors[i].MCvScalar);

                    }

                    //MessageBox.Show($"There are {contours.Size} contours detected");
                    CoordsTextBox.Text = $"{contours.Size} contours detected, {lKeptCount} kept";
                }

                // output images:
                sourcePictureBox.Image = workingImage.ToBitmap();
                blurredPictureBox.Image = blurredImage.ToBitmap();
                contourPictureBox.Image = decoratedImage.ToBitmap();
            }
        }
    }
}