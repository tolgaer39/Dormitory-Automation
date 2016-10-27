using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WebCam_Capture;
using System.IO;

namespace projedeneme1
{
    public partial class FormFotoCek : Form
    {
        public FormFotoCek()
        {
            InitializeComponent();
        }

        private void btnCek_Click(object sender, EventArgs e)
        {
            if (btnCek.Text == "Yeni")
            {
                btnCek.Text = "Çek";
                cam.TimeToCapture_milliseconds = 20;
                cam.Start(0);
            }
            else if (btnCek.Text == "Çek")
            {
                btnCek.Text = "Yeni";
                cam.Stop();
            }
        }

        private void FormFotoCek_Load(object sender, EventArgs e)
        {
            btnCek.Text = "Yeni";
            cam.CaptureHeight = resim.Height;
            cam.CaptureWidth = resim.Width;
        }

        private void FormFotoCek_Shown(object sender, EventArgs e)
        {
            btnCek_Click(null, null);
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            cam.Stop();
            this.Hide();
        }
        private void cam_ImageCaptured(object source, WebcamEventArgs e)
        {
            resim.Image = e.WebCamImage;
        }

        private void FormFotoCek_FormClosing(object sender, FormClosingEventArgs e)
        {
            cam.Stop();
            FormOgrBilgileri frmOgrBilgileri = new FormOgrBilgileri();

            Ogrenci bulunan = new Ogrenci();
            string fl = null;
            if (File.Exists(fl))
            {
                fl = FormOgrenciKayit.path + @"\img\" + bulunan.siraKimlik.sirasi.ToString() + ".jpg";
                frmOgrBilgileri.pictureBox1.Load(fl);
            }
        }

    }
}
