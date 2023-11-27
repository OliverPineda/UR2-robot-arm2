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
            this.VideoPictureBox = new System.Windows.Forms.PictureBox();
            this.GrayPictureBox = new System.Windows.Forms.PictureBox();
            this.DecoratedPictureBox = new System.Windows.Forms.PictureBox();
            this.BrowseBtn = new System.Windows.Forms.Button();
            this.GrayMin = new System.Windows.Forms.TrackBar();
            this.GrayMax = new System.Windows.Forms.TrackBar();
            this.GrayMinLabel = new System.Windows.Forms.TextBox();
            this.GrayMaxLabel = new System.Windows.Forms.TextBox();
            this.CoordsTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ArduinoDataTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.VideoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DecoratedPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayMax)).BeginInit();
            this.SuspendLayout();
            // 
            // VideoPictureBox
            // 
            this.VideoPictureBox.Location = new System.Drawing.Point(12, 12);
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
            // BrowseBtn
            // 
            this.BrowseBtn.Location = new System.Drawing.Point(1638, 484);
            this.BrowseBtn.Name = "BrowseBtn";
            this.BrowseBtn.Size = new System.Drawing.Size(94, 29);
            this.BrowseBtn.TabIndex = 8;
            this.BrowseBtn.Text = "BrowseBtn";
            this.BrowseBtn.UseVisualStyleBackColor = true;
            this.BrowseBtn.Click += new System.EventHandler(this.BrowseBtn_Click);
            // 
            // GrayMin
            // 
            this.GrayMin.Location = new System.Drawing.Point(46, 472);
            this.GrayMin.Maximum = 255;
            this.GrayMin.Minimum = 1;
            this.GrayMin.Name = "GrayMin";
            this.GrayMin.Size = new System.Drawing.Size(360, 56);
            this.GrayMin.TabIndex = 9;
            this.GrayMin.Value = 1;
            this.GrayMin.Scroll += new System.EventHandler(this.GrayMin_Scroll);
            // 
            // GrayMax
            // 
            this.GrayMax.Location = new System.Drawing.Point(565, 472);
            this.GrayMax.Maximum = 255;
            this.GrayMax.Minimum = 1;
            this.GrayMax.Name = "GrayMax";
            this.GrayMax.Size = new System.Drawing.Size(495, 56);
            this.GrayMax.TabIndex = 10;
            this.GrayMax.Value = 1;
            this.GrayMax.Scroll += new System.EventHandler(this.GrayMax_Scroll);
            // 
            // GrayMinLabel
            // 
            this.GrayMinLabel.Location = new System.Drawing.Point(412, 472);
            this.GrayMinLabel.Name = "GrayMinLabel";
            this.GrayMinLabel.Size = new System.Drawing.Size(77, 27);
            this.GrayMinLabel.TabIndex = 11;
            // 
            // GrayMaxLabel
            // 
            this.GrayMaxLabel.Location = new System.Drawing.Point(1066, 470);
            this.GrayMaxLabel.Name = "GrayMaxLabel";
            this.GrayMaxLabel.Size = new System.Drawing.Size(65, 27);
            this.GrayMaxLabel.TabIndex = 12;
            // 
            // CoordsTextBox
            // 
            this.CoordsTextBox.Location = new System.Drawing.Point(1363, 524);
            this.CoordsTextBox.Name = "CoordsTextBox";
            this.CoordsTextBox.Size = new System.Drawing.Size(125, 27);
            this.CoordsTextBox.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1304, 527);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Found:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1296, 566);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Arduino:";
            // 
            // ArduinoDataTextBox
            // 
            this.ArduinoDataTextBox.Location = new System.Drawing.Point(1363, 557);
            this.ArduinoDataTextBox.Name = "ArduinoDataTextBox";
            this.ArduinoDataTextBox.Size = new System.Drawing.Size(123, 27);
            this.ArduinoDataTextBox.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(196, 508);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "GrayMin";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(780, 508);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 20);
            this.label5.TabIndex = 19;
            this.label5.Text = "GrayMax";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1777, 708);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ArduinoDataTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CoordsTextBox);
            this.Controls.Add(this.GrayMaxLabel);
            this.Controls.Add(this.GrayMinLabel);
            this.Controls.Add(this.GrayMax);
            this.Controls.Add(this.GrayMin);
            this.Controls.Add(this.BrowseBtn);
            this.Controls.Add(this.DecoratedPictureBox);
            this.Controls.Add(this.GrayPictureBox);
            this.Controls.Add(this.VideoPictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
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
        private PictureBox VideoPictureBox;
        private PictureBox GrayPictureBox;
        private PictureBox DecoratedPictureBox;
        private Button BrowseBtn;
        private TrackBar GrayMin;
        private TrackBar GrayMax;
        private TextBox GrayMinLabel;
        private TextBox GrayMaxLabel;
        private TextBox CoordsTextBox;
        private Label label1;
        private Label label2;
        private TextBox ArduinoDataTextBox;
        private Label label4;
        private Label label5;
    }
}