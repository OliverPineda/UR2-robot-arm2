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
            this.GrayPictureBox = new System.Windows.Forms.PictureBox();
            this.DecoratedPictureBox = new System.Windows.Forms.PictureBox();
            this.GrayMin = new System.Windows.Forms.TrackBar();
            this.GrayMax = new System.Windows.Forms.TrackBar();
            this.GrayMinLabel = new System.Windows.Forms.TextBox();
            this.GrayMaxLabel = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.CoordsTextBox = new System.Windows.Forms.TextBox();
            this.BrowseBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.VideoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DecoratedPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayMax)).BeginInit();
            this.SuspendLayout();
            // 
            // StartStopBtn
            // 
            this.StartStopBtn.Location = new System.Drawing.Point(1210, 523);
            this.StartStopBtn.Name = "StartStopBtn";
            this.StartStopBtn.Size = new System.Drawing.Size(92, 44);
            this.StartStopBtn.TabIndex = 0;
            this.StartStopBtn.Text = "Start";
            this.StartStopBtn.UseVisualStyleBackColor = true;
            this.StartStopBtn.Click += new System.EventHandler(this.StartStopBtn_Click);
            // 
            // VideoPictureBox
            // 
            this.VideoPictureBox.Location = new System.Drawing.Point(12, 10);
            this.VideoPictureBox.Name = "VideoPictureBox";
            this.VideoPictureBox.Size = new System.Drawing.Size(514, 454);
            this.VideoPictureBox.TabIndex = 1;
            this.VideoPictureBox.TabStop = false;
            // 
            // GrayPictureBox
            // 
            this.GrayPictureBox.Location = new System.Drawing.Point(532, 12);
            this.GrayPictureBox.Name = "GrayPictureBox";
            this.GrayPictureBox.Size = new System.Drawing.Size(608, 452);
            this.GrayPictureBox.TabIndex = 6;
            this.GrayPictureBox.TabStop = false;
            // 
            // DecoratedPictureBox
            // 
            this.DecoratedPictureBox.Location = new System.Drawing.Point(1146, 10);
            this.DecoratedPictureBox.Name = "DecoratedPictureBox";
            this.DecoratedPictureBox.Size = new System.Drawing.Size(619, 454);
            this.DecoratedPictureBox.TabIndex = 7;
            this.DecoratedPictureBox.TabStop = false;
            // 
            // GrayMin
            // 
            this.GrayMin.Location = new System.Drawing.Point(92, 534);
            this.GrayMin.Maximum = 255;
            this.GrayMin.Minimum = 1;
            this.GrayMin.Name = "GrayMin";
            this.GrayMin.Size = new System.Drawing.Size(386, 56);
            this.GrayMin.TabIndex = 14;
            this.GrayMin.Value = 1;
            this.GrayMin.Scroll += new System.EventHandler(this.GrayMin_Scroll);
            // 
            // GrayMax
            // 
            this.GrayMax.Location = new System.Drawing.Point(92, 582);
            this.GrayMax.Maximum = 255;
            this.GrayMax.Minimum = 1;
            this.GrayMax.Name = "GrayMax";
            this.GrayMax.Size = new System.Drawing.Size(386, 56);
            this.GrayMax.TabIndex = 15;
            this.GrayMax.Value = 1;
            this.GrayMax.Scroll += new System.EventHandler(this.GrayMax_Scroll);
            // 
            // GrayMinLabel
            // 
            this.GrayMinLabel.Location = new System.Drawing.Point(484, 540);
            this.GrayMinLabel.Name = "GrayMinLabel";
            this.GrayMinLabel.Size = new System.Drawing.Size(33, 27);
            this.GrayMinLabel.TabIndex = 16;
            // 
            // GrayMaxLabel
            // 
            this.GrayMaxLabel.Location = new System.Drawing.Point(484, 590);
            this.GrayMaxLabel.Name = "GrayMaxLabel";
            this.GrayMaxLabel.Size = new System.Drawing.Size(33, 27);
            this.GrayMaxLabel.TabIndex = 17;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 540);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(74, 27);
            this.textBox1.TabIndex = 18;
            this.textBox1.Text = "Gray Min";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 590);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(74, 27);
            this.textBox2.TabIndex = 19;
            this.textBox2.Text = "Gray Max";
            // 
            // CoordsTextBox
            // 
            this.CoordsTextBox.Location = new System.Drawing.Point(1325, 540);
            this.CoordsTextBox.Name = "CoordsTextBox";
            this.CoordsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.CoordsTextBox.Size = new System.Drawing.Size(276, 27);
            this.CoordsTextBox.TabIndex = 20;
            // 
            // BrowseBtn
            // 
            this.BrowseBtn.Location = new System.Drawing.Point(811, 523);
            this.BrowseBtn.Name = "BrowseBtn";
            this.BrowseBtn.Size = new System.Drawing.Size(94, 29);
            this.BrowseBtn.TabIndex = 21;
            this.BrowseBtn.Text = "BrowseBtn";
            this.BrowseBtn.UseVisualStyleBackColor = true;
            this.BrowseBtn.Click += new System.EventHandler(this.BrowseBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1777, 708);
            this.Controls.Add(this.BrowseBtn);
            this.Controls.Add(this.CoordsTextBox);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.GrayMaxLabel);
            this.Controls.Add(this.GrayMinLabel);
            this.Controls.Add(this.GrayMax);
            this.Controls.Add(this.GrayMin);
            this.Controls.Add(this.DecoratedPictureBox);
            this.Controls.Add(this.GrayPictureBox);
            this.Controls.Add(this.VideoPictureBox);
            this.Controls.Add(this.StartStopBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VideoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DecoratedPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayMax)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button StartStopBtn;
        private PictureBox VideoPictureBox;
        private PictureBox GrayPictureBox;
        private PictureBox DecoratedPictureBox;
        private TrackBar GrayMin;
        private TrackBar GrayMax;
        private TextBox GrayMinLabel;
        private TextBox GrayMaxLabel;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox CoordsTextBox;
        private Button BrowseBtn;
    }
}