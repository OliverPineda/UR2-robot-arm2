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
            this.arduinoLED = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.VideoPictureBox)).BeginInit();
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
            this.VideoPictureBox.Location = new System.Drawing.Point(233, 95);
            this.VideoPictureBox.Name = "VideoPictureBox";
            this.VideoPictureBox.Size = new System.Drawing.Size(298, 196);
            this.VideoPictureBox.TabIndex = 1;
            this.VideoPictureBox.TabStop = false;
            // 
            // arduinoLED
            // 
            this.arduinoLED.Location = new System.Drawing.Point(401, 315);
            this.arduinoLED.Name = "arduinoLED";
            this.arduinoLED.Size = new System.Drawing.Size(151, 29);
            this.arduinoLED.TabIndex = 2;
            this.arduinoLED.Text = "ArduinoLED";
            this.arduinoLED.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.arduinoLED);
            this.Controls.Add(this.VideoPictureBox);
            this.Controls.Add(this.StartStopBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VideoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button StartStopBtn;
        private PictureBox VideoPictureBox;
        private Button arduinoLED;
    }
}