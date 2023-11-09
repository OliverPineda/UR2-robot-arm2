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
            ((System.ComponentModel.ISupportInitialize)(this.VideoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DecoratedPictureBox)).BeginInit();
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1777, 708);
            this.Controls.Add(this.DecoratedPictureBox);
            this.Controls.Add(this.GrayPictureBox);
            this.Controls.Add(this.VideoPictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VideoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DecoratedPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private PictureBox VideoPictureBox;
        private PictureBox GrayPictureBox;
        private PictureBox DecoratedPictureBox;
    }
}