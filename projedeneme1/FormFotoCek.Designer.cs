namespace projedeneme1
{
    partial class FormFotoCek
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.resim = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnCek = new System.Windows.Forms.Button();
            this.btnTamam = new System.Windows.Forms.Button();
            this.cam = new WebCam_Capture.WebCamCapture();
            ((System.ComponentModel.ISupportInitialize)(this.resim)).BeginInit();
            this.SuspendLayout();
            // 
            // resim
            // 
            this.resim.BackColor = System.Drawing.SystemColors.Control;
            this.resim.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.resim.Location = new System.Drawing.Point(79, 25);
            this.resim.Name = "resim";
            this.resim.Size = new System.Drawing.Size(362, 344);
            this.resim.TabIndex = 0;
            this.resim.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnCek
            // 
            this.btnCek.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCek.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCek.Location = new System.Drawing.Point(79, 375);
            this.btnCek.Name = "btnCek";
            this.btnCek.Size = new System.Drawing.Size(108, 34);
            this.btnCek.TabIndex = 1;
            this.btnCek.Text = "Çek";
            this.btnCek.UseVisualStyleBackColor = true;
            this.btnCek.Click += new System.EventHandler(this.btnCek_Click);
            // 
            // btnTamam
            // 
            this.btnTamam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTamam.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnTamam.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTamam.Location = new System.Drawing.Point(333, 375);
            this.btnTamam.Name = "btnTamam";
            this.btnTamam.Size = new System.Drawing.Size(108, 34);
            this.btnTamam.TabIndex = 2;
            this.btnTamam.Text = "Tamam";
            this.btnTamam.UseVisualStyleBackColor = true;
            this.btnTamam.Click += new System.EventHandler(this.btnTamam_Click);
            // 
            // cam
            // 
            this.cam.CaptureHeight = 240;
            this.cam.CaptureWidth = 320;
            this.cam.FrameNumber = ((ulong)(0ul));
            this.cam.Location = new System.Drawing.Point(47, 9);
            this.cam.Name = "WebCamCapture";
            this.cam.Size = new System.Drawing.Size(342, 252);
            this.cam.TabIndex = 0;
            this.cam.TimeToCapture_milliseconds = 20;
            this.cam.ImageCaptured += new WebCam_Capture.WebCamCapture.WebCamEventHandler(this.cam_ImageCaptured);
            // 
            // FormFotoCek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(512, 462);
            this.Controls.Add(this.btnTamam);
            this.Controls.Add(this.btnCek);
            this.Controls.Add(this.resim);
            this.MaximizeBox = false;
            this.Name = "FormFotoCek";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fotoğraf";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormFotoCek_FormClosing);
            this.Load += new System.EventHandler(this.FormFotoCek_Load);
            this.Shown += new System.EventHandler(this.FormFotoCek_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.resim)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnCek;
        private System.Windows.Forms.Button btnTamam;
        private WebCam_Capture.WebCamCapture cam;
        public System.Windows.Forms.PictureBox resim;
    }
}