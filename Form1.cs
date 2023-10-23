using Emgu.CV;
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
                mCapture = new VideoCapture(0);

                if (mCapture.Height == 0)
                    throw new Exception("No Camera Found");
            }
            catch (Exception ex)
            
               {
                    MessageBox.Show(ex.Message);
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
    }
}