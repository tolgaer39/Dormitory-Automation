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
    public partial class FormPersonelListele : Form
    {
        public FormPersonelListele()
        {
            InitializeComponent();
        }

        private void FormPersonelListele_Load(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("provider=Microsoft.jet.oledb.4.0; Data Source=YurtVeriTabani.mdb;");
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = "select * from personel";
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku["Ad"].ToString() + " " + oku["Soyad"].ToString().ToUpper() + " " + oku["TC"].ToString());
            }
            baglanti.Close();
        }


        private void comboBox1_TextChanged(object sender, EventArgs e)
        {

            OleDbConnection baglanti = new OleDbConnection("provider=Microsoft.jet.oledb.4.0; Data Source=YurtVeriTabani.mdb;");
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = "select * from personel";
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                if (comboBox1.Text == oku["Ad"].ToString() + " " + oku["Soyad"].ToString().ToUpper() + " " + oku["TC"].ToString())
                {
                    string fl = FormOgrenciKayit.path + @"\personel\" + oku["TC"].ToString() + ".jpg";
                    if (File.Exists(fl))
                    {
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox1.Load(fl);
                    }
                    button1.Visible = true;
                }
            }
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("provider=Microsoft.jet.oledb.4.0; Data Source=YurtVeriTabani.mdb;");
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = "select * from personel";
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                if (comboBox1.Text == oku["Ad"].ToString() + " " + oku["Soyad"].ToString().ToUpper() + " " + oku["TC"].ToString())
                {
                    Personel bulunan = Personel.TCyeGoreOgrenciGetir(oku["TC"].ToString());
                    if (bulunan != null)
                    {
                        FormPersBilgileri frmPersBilgileri = new FormPersBilgileri();
                        frmPersBilgileri.PersonelBagla(bulunan);
                        frmPersBilgileri.ShowDialog();
                        break;
                    }
                }
            }
            baglanti.Close();
        }
    }
}
