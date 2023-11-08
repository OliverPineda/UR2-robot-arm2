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

        int mGrayMin = 70;
        int mGrayMax = 220;




        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try

            {
                GrayMinLabel.Text = mGrayMin.ToString();
                GrayMaxLabel.Text = mGrayMax.ToString();

                GrayMin.Value = mGrayMin;
                GrayMax.Value = mGrayMax;

                //initialize with ifany plugged camera
                mCapture = new VideoCapture(0, VideoCapture.API.DShow); //0 means default , 1 means webcam

                if (mCapture.Height == 0) //must match what mCapture is on above line
                    throw new Exception("No Camera Found");
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
                Mat frame = mCapture.QueryFrame(); // grab a new frame













                //
                // process
                //
                Mat lVideoImageDisplay = frame.Clone();

                //resize
                Size newSize = new Size(VideoPictureBox.Size.Width, VideoPictureBox.Height);
                CvInvoke.Resize(frame, lVideoImageDisplay, newSize);

                //display original
                VideoPictureBox.Image = lVideoImageDisplay.ToBitmap();

                //convert binary gray image
                var lGrayImage = lVideoImageDisplay.ToImage<Gray, byte>().ThresholdBinary(new Gray(mGrayMin), new Gray(mGrayMax)).Mat;

                GrayPictureBox.Image = lGrayImage.ToBitmap();

                //grab rgb copy
                var decoratedImage = lGrayImage.ToImage<Rgb, byte>();

                //find contours:
                using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
                {
                    //build list of contours on the gray image
                    CvInvoke.FindContours(lGrayImage, contours, null, RetrType.List,
                        ChainApproxMethod.ChainApproxSimple);

                    List<Bgr> lColors = new List<Bgr> { new Bgr(Color.Red), new Bgr(Color.Green), new Bgr(Color.Blue),
                        new Bgr(Color.Yellow), new Bgr(Color.Orange), new Bgr(Color.Pink), new Bgr(Color.Purple) };



                    //draw on the rgb image
                    for (int i = 0; i < contours.Size; i++)
                    {
                        if (contours.Size > 7)
                        {
                            break;
                        }

                        VectorOfPoint contour = contours[i];
                        CvInvoke.Polylines(decoratedImage, contour, true, lColors[i % 7].MCvScalar, 5);
                        CvInvoke.Circle(decoratedImage, contour[0], 5, lColors[i % 7].MCvScalar, 4);

                    }
                    // CoordsTextBox.Text = $"{contours.Size} contours dectected";
                }


                // ~60 fps -> 1000ms/60 = 16.6
                Task.Delay(16);













                // result
                DecoratedPictureBox.Image = decoratedImage.ToBitmap();


            }

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

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (mIsCapturing)
            {
                mCancellationToken.Cancel();
            }
            mCapture.Dispose();
            mCancellationToken.Dispose();
        }

        private void GrayMin_Scroll(object sender, EventArgs e)
        {
            mGrayMin = GrayMin.Value; //int member GrayMin = name of trackbar
            GrayMinLabel.Text = mGrayMin.ToString();
        }

        private void GrayMax_Scroll(object sender, EventArgs e)
        {
            mGrayMax = GrayMax.Value;
            GrayMaxLabel.Text = mGrayMax.ToString();
        }


    }

}