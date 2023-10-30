namespace UR2_robot_arm2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.StartStopBtn = new System.Windows.Forms.Button();
            this.VideoPictureBox = new System.Windows.Forms.PictureBox();
            this.arduinoLEDon = new System.Windows.Forms.Button();
            this.arduinoLEDoff = new System.Windows.Forms.Button();
            this.SerialDataChar = new System.Windows.Forms.Button();
            this.sourcePictureBox = new System.Windows.Forms.PictureBox();
            this.blurredPictureBox = new System.Windows.Forms.PictureBox();
            this.contourPictureBox = new System.Windows.Forms.PictureBox();
            this.BrowseBtn = new System.Windows.Forms.Button();
            this.CoordsTextBox = new System.Windows.Forms.TextBox();
            this.blurX = new System.Windows.Forms.TrackBar();
            this.blurY = new System.Windows.Forms.TrackBar();
            this.cannyMin = new System.Windows.Forms.TrackBar();
            this.cannyMax = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.VideoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blurredPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contourPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blurX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blurY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cannyMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cannyMax)).BeginInit();
            this.SuspendLayout();
            // 
            // StartStopBtn
            // 
            this.StartStopBtn.Location = new System.Drawing.Point(265, 335);
            this.StartStopBtn.Name = "StartStopBtn";
            this.StartStopBtn.Size = new System.Drawing.Size(112, 29);
            this.StartStopBtn.TabIndex = 0;
            this.StartStopBtn.Text = "Start";
            this.StartStopBtn.UseVisualStyleBackColor = true;
            this.StartStopBtn.Click += new System.EventHandler(this.StartStopBtn_Click);
            // 
            // VideoPictureBox
            // 
            this.VideoPictureBox.Location = new System.Drawing.Point(1, 260);
            this.VideoPictureBox.Name = "VideoPictureBox";
            this.VideoPictureBox.Size = new System.Drawing.Size(258, 180);
            this.VideoPictureBox.TabIndex = 1;
            this.VideoPictureBox.TabStop = false;
            // 
            // arduinoLEDon
            // 
            this.arduinoLEDon.Location = new System.Drawing.Point(265, 260);
            this.arduinoLEDon.Name = "arduinoLEDon";
            this.arduinoLEDon.Size = new System.Drawing.Size(151, 29);
            this.arduinoLEDon.TabIndex = 2;
            this.arduinoLEDon.Text = "ArduinoLEDon";
            this.arduinoLEDon.UseVisualStyleBackColor = true;
            this.arduinoLEDon.Click += new System.EventHandler(this.arduinoLEDon_Click);
            // 
            // arduinoLEDoff
            // 
            this.arduinoLEDoff.Location = new System.Drawing.Point(265, 295);
            this.arduinoLEDoff.Name = "arduinoLEDoff";
            this.arduinoLEDoff.Size = new System.Drawing.Size(136, 34);
            this.arduinoLEDoff.TabIndex = 3;
            this.arduinoLEDoff.Text = "ArduinoLEDoff";
            this.arduinoLEDoff.UseVisualStyleBackColor = true;
            this.arduinoLEDoff.Click += new System.EventHandler(this.arduinoLEDoff_Click);
            // 
            // SerialDataChar
            // 
            this.SerialDataChar.Location = new System.Drawing.Point(265, 370);
            this.SerialDataChar.Name = "SerialDataChar";
            this.SerialDataChar.Size = new System.Drawing.Size(94, 29);
            this.SerialDataChar.TabIndex = 4;
            this.SerialDataChar.Text = "SerialData";
            this.SerialDataChar.UseVisualStyleBackColor = true;
            // 
            // sourcePictureBox
            // 
            this.sourcePictureBox.Location = new System.Drawing.Point(1, 10);
            this.sourcePictureBox.Name = "sourcePictureBox";
            this.sourcePictureBox.Size = new System.Drawing.Size(235, 244);
            this.sourcePictureBox.TabIndex = 5;
            this.sourcePictureBox.TabStop = false;
            // 
            // blurredPictureBox
            // 
            this.blurredPictureBox.Location = new System.Drawing.Point(242, 12);
            this.blurredPictureBox.Name = "blurredPictureBox";
            this.blurredPictureBox.Size = new System.Drawing.Size(270, 242);
            this.blurredPictureBox.TabIndex = 6;
            this.blurredPictureBox.TabStop = false;
            // 
            // contourPictureBox
            // 
            this.contourPictureBox.Location = new System.Drawing.Point(518, -1);
            this.contourPictureBox.Name = "contourPictureBox";
            this.contourPictureBox.Size = new System.Drawing.Size(270, 255);
            this.contourPictureBox.TabIndex = 7;
            this.contourPictureBox.TabStop = false;
            // 
            // BrowseBtn
            // 
            this.BrowseBtn.Location = new System.Drawing.Point(694, 249);
            this.BrowseBtn.Name = "BrowseBtn";
            this.BrowseBtn.Size = new System.Drawing.Size(94, 29);
            this.BrowseBtn.TabIndex = 8;
            this.BrowseBtn.Text = "Browse";
            this.BrowseBtn.UseVisualStyleBackColor = true;
            this.BrowseBtn.Click += new System.EventHandler(this.BrowseBtn_Click);
            // 
            // CoordsTextBox
            // 
            this.CoordsTextBox.Location = new System.Drawing.Point(419, 249);
            this.CoordsTextBox.Name = "CoordsTextBox";
            this.CoordsTextBox.Size = new System.Drawing.Size(269, 27);
            this.CoordsTextBox.TabIndex = 9;
            // 
            // blurX
            // 
            this.blurX.Location = new System.Drawing.Point(422, 281);
            this.blurX.Name = "blurX";
            this.blurX.Size = new System.Drawing.Size(330, 56);
            this.blurX.TabIndex = 10;
            // 
            // blurY
            // 
            this.blurY.Location = new System.Drawing.Point(422, 323);
            this.blurY.Name = "blurY";
            this.blurY.Size = new System.Drawing.Size(330, 56);
            this.blurY.TabIndex = 11;
            // 
            // cannyMin
            // 
            this.cannyMin.Location = new System.Drawing.Point(422, 360);
            this.cannyMin.Name = "cannyMin";
            this.cannyMin.Size = new System.Drawing.Size(330, 56);
            this.cannyMin.TabIndex = 12;
            // 
            // cannyMax
            // 
            this.cannyMax.Location = new System.Drawing.Point(422, 401);
            this.cannyMax.Name = "cannyMax";
            this.cannyMax.Size = new System.Drawing.Size(330, 56);
            this.cannyMax.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cannyMax);
            this.Controls.Add(this.cannyMin);
            this.Controls.Add(this.blurY);
            this.Controls.Add(this.blurX);
            this.Controls.Add(this.CoordsTextBox);
            this.Controls.Add(this.BrowseBtn);
            this.Controls.Add(this.contourPictureBox);
            this.Controls.Add(this.blurredPictureBox);
            this.Controls.Add(this.sourcePictureBox);
            this.Controls.Add(this.SerialDataChar);
            this.Controls.Add(this.arduinoLEDoff);
            this.Controls.Add(this.arduinoLEDon);
            this.Controls.Add(this.VideoPictureBox);
            this.Controls.Add(this.StartStopBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VideoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blurredPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contourPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blurX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blurY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cannyMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cannyMax)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button StartStopBtn;
        private PictureBox VideoPictureBox;
        private Button arduinoLEDon;
        private Button arduinoLEDoff;
        private Button SerialDataChar;
        private PictureBox sourcePictureBox;
        private PictureBox blurredPictureBox;
        private PictureBox contourPictureBox;
        private Button BrowseBtn;
        private TextBox CoordsTextBox;
        private TrackBar blurX;
        private TrackBar blurY;
        private TrackBar cannyMin;
        private TrackBar cannyMax;
    }
}