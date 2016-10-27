using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace projedeneme1
{
    public partial class FormYataklar : Form
    {
        public FormYataklar()
        {
            InitializeComponent();
        }

        private void FormYataklar_Load(object sender, EventArgs e)
        {
            if (label1.Text == "1. Yatak: Boş" && label2.Text == "2. Yatak: Boş" && label3.Text == "3. Yatak: Boş" && label4.Text == "4. Yatak: Boş")
            {
                timer1.Enabled = false;
            }
            else
            {
                timer1.Enabled = true;
                timer1.Interval = 500;
            }
        }

        Bitmap[] bt = { projedeneme1.Properties.Resources.Yatak2dolu, projedeneme1.Properties.Resources.Yatak2doluz, projedeneme1.Properties.Resources.Yatak2doluzZ, projedeneme1.Properties.Resources.Yatak2doluzZz };
        int x = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            x %= 4;
            if (label1.Text == "1. Yatak: Dolu")
            {
                pictureBox1.BackgroundImage = bt[x];
            }
            if (label2.Text == "2. Yatak: Dolu")
            {
                pictureBox2.BackgroundImage = bt[x];
            }
            if (label3.Text == "3. Yatak: Dolu")
            {
                pictureBox3.BackgroundImage = bt[x];
            }
            if (label4.Text == "4. Yatak: Dolu")
            {
                pictureBox4.BackgroundImage = bt[x];
            }
            x++;
        }

        public void cagirFonk(string x,string y)
        {
            OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=YurtVeriTabani.mdb;");
            baglan.Open();
            OleDbCommand veriz = new OleDbCommand("SELECT * FROM oda_yatak_" + labelBlok.Text + " WHERE Oda_No='" + labelOda.Text + "'", baglan);
            OleDbDataReader oku2;
            oku2 = veriz.ExecuteReader();
            if (oku2.Read())
            {
                FormOgrBilgileri frmOgrBilg = new FormOgrBilgileri();
                frmOgrBilg.bl = true;
                Ogrenci bulunanx = Ogrenci.TCyeGoreOgrenciGetir(x);
                if (y.ToString().Split(' ').Last()=="Dolu"&&bulunanx!=null)
                {
                    frmOgrBilg.button1.Visible = false;
                    frmOgrBilg.button2.Visible = false;
                    frmOgrBilg.button3.Visible = false;
                    frmOgrBilg.OgrenciBagla(bulunanx);
                    frmOgrBilg.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Yatak boş...");
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            cagirFonk(labelYatak1.Text,label1.Text);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            cagirFonk(labelYatak2.Text, label2.Text);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            cagirFonk(labelYatak3.Text, label3.Text);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            cagirFonk(labelYatak4.Text, label4.Text);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=YurtVeriTabani.mdb;");
            baglan.Open();
            OleDbCommand veriz = new OleDbCommand("SELECT * FROM oda_yatak_" + labelBlok.Text + " WHERE Oda_No='" + labelOda.Text + "'", baglan);
            OleDbDataReader oku2;
            oku2 = veriz.ExecuteReader();
            if (oku2.Read())
            {
                if (oku2["1"].ToString() != "boş")
                {
                    string fl = FormOgrenciKayit.path + @"\ogrenci\" + oku2["1"].ToString() + ".jpg";
                    if (File.Exists(fl))
                    {
                        pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox5.Load(fl);
                    }
                    else
                        pictureBox5.Image = projedeneme1.Properties.Resources.boşRenk;
                }
                else
                    pictureBox5.Image = projedeneme1.Properties.Resources.boşRenk;
            }
            baglan.Close();
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=YurtVeriTabani.mdb;");
            baglan.Open();
            OleDbCommand veriz = new OleDbCommand("SELECT * FROM oda_yatak_" + labelBlok.Text + " WHERE Oda_No='" + labelOda.Text + "'", baglan);
            OleDbDataReader oku2;
            oku2 = veriz.ExecuteReader();
            if (oku2.Read())
            {
                if (oku2["2"].ToString() != "boş")
                {
                    string fl = FormOgrenciKayit.path + @"\ogrenci\" + oku2["2"].ToString() + ".jpg";
                    if (File.Exists(fl))
                    {
                        pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox5.Load(fl);
                    }
                    else
                        pictureBox5.Image = projedeneme1.Properties.Resources.boşRenk;
                }
                else
                    pictureBox5.Image = projedeneme1.Properties.Resources.boşRenk;
            }
            baglan.Close();
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=YurtVeriTabani.mdb;");
            baglan.Open();
            OleDbCommand veriz = new OleDbCommand("SELECT * FROM oda_yatak_" + labelBlok.Text + " WHERE Oda_No='" + labelOda.Text + "'", baglan);
            OleDbDataReader oku2;
            oku2 = veriz.ExecuteReader();
            if (oku2.Read())
            {
                if (oku2["3"].ToString() != "boş")
                {
                    string fl = FormOgrenciKayit.path + @"\ogrenci\" + oku2["3"].ToString() + ".jpg";
                    if (File.Exists(fl))
                    {
                        pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox5.Load(fl);
                    }
                    else
                        pictureBox5.Image = projedeneme1.Properties.Resources.boşRenk;
                }
                else
                    pictureBox5.Image = projedeneme1.Properties.Resources.boşRenk;
            }
            baglan.Close();
        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=YurtVeriTabani.mdb;");
            baglan.Open();
            OleDbCommand veriz = new OleDbCommand("SELECT * FROM oda_yatak_" + labelBlok.Text + " WHERE Oda_No='" + labelOda.Text + "'", baglan);
            OleDbDataReader oku2;
            oku2 = veriz.ExecuteReader();
            if (oku2.Read())
            {
                if (oku2["4"].ToString() != "boş")
                {
                    string fl = FormOgrenciKayit.path + @"\ogrenci\" + oku2["4"].ToString() + ".jpg";
                    if (File.Exists(fl))
                    {
                        pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox5.Load(fl);
                    }
                    else
                        pictureBox5.Image = projedeneme1.Properties.Resources.boşRenk;
                }
                else
                    pictureBox5.Image = projedeneme1.Properties.Resources.boşRenk;
            }
            baglan.Close();
        }

        private void FormYataklar_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox5.Image = projedeneme1.Properties.Resources.boşRenk;
        }
    }
}