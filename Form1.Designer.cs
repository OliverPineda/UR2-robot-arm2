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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.BrowseBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.VideoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // StartStopBtn
            // 
            this.StartStopBtn.Location = new System.Drawing.Point(233, 315);
            this.StartStopBtn.Name = "StartStopBtn";
            this.StartStopBtn.Size = new System.Drawing.Size(112, 29);
            this.StartStopBtn.TabIndex = 0;
            this.StartStopBtn.Text = "Start";
            this.StartStopBtn.UseVisualStyleBackColor = true;
            this.StartStopBtn.Click += new System.EventHandler(this.StartStopBtn_Click);
            // 
            // VideoPictureBox
            // 
            this.VideoPictureBox.Location = new System.Drawing.Point(131, 360);
            this.VideoPictureBox.Name = "VideoPictureBox";
            this.VideoPictureBox.Size = new System.Drawing.Size(112, 66);
            this.VideoPictureBox.TabIndex = 1;
            this.VideoPictureBox.TabStop = false;
            // 
            // arduinoLEDon
            // 
            this.arduinoLEDon.Location = new System.Drawing.Point(401, 315);
            this.arduinoLEDon.Name = "arduinoLEDon";
            this.arduinoLEDon.Size = new System.Drawing.Size(151, 29);
            this.arduinoLEDon.TabIndex = 2;
            this.arduinoLEDon.Text = "ArduinoLEDon";
            this.arduinoLEDon.UseVisualStyleBackColor = true;
            this.arduinoLEDon.Click += new System.EventHandler(this.arduinoLEDon_Click);
            // 
            // arduinoLEDoff
            // 
            this.arduinoLEDoff.Location = new System.Drawing.Point(401, 360);
            this.arduinoLEDoff.Name = "arduinoLEDoff";
            this.arduinoLEDoff.Size = new System.Drawing.Size(136, 34);
            this.arduinoLEDoff.TabIndex = 3;
            this.arduinoLEDoff.Text = "ArduinoLEDoff";
            this.arduinoLEDoff.UseVisualStyleBackColor = true;
            this.arduinoLEDoff.Click += new System.EventHandler(this.arduinoLEDoff_Click);
            // 
            // SerialDataChar
            // 
            this.SerialDataChar.Location = new System.Drawing.Point(578, 360);
            this.SerialDataChar.Name = "SerialDataChar";
            this.SerialDataChar.Size = new System.Drawing.Size(94, 29);
            this.SerialDataChar.TabIndex = 4;
            this.SerialDataChar.Text = "SerialData";
            this.SerialDataChar.UseVisualStyleBackColor = true;
            // 
            // sourcePictureBox
            // 
            this.sourcePictureBox.Location = new System.Drawing.Point(12, 23);
            this.sourcePictureBox.Name = "sourcePictureBox";
            this.sourcePictureBox.Size = new System.Drawing.Size(198, 244);
            this.sourcePictureBox.TabIndex = 5;
            this.sourcePictureBox.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(250, 23);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(211, 244);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(537, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(212, 255);
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // BrowseBtn
            // 
            this.BrowseBtn.Location = new System.Drawing.Point(633, 322);
            this.BrowseBtn.Name = "BrowseBtn";
            this.BrowseBtn.Size = new System.Drawing.Size(94, 29);
            this.BrowseBtn.TabIndex = 8;
            this.BrowseBtn.Text = "Browse";
            this.BrowseBtn.UseVisualStyleBackColor = true;
            this.BrowseBtn.Click += new System.EventHandler(this.BrowseBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BrowseBtn);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button StartStopBtn;
        private PictureBox VideoPictureBox;
        private Button arduinoLEDon;
        private Button arduinoLEDoff;
        private Button SerialDataChar;
        private PictureBox sourcePictureBox;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Button BrowseBtn;
    }
}