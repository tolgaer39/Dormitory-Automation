using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;

namespace projedeneme1
{
    public partial class FormPersonelKayit : Form
    {
        public FormPersonelKayit()
        {
            InitializeComponent();
        }
        internal void resimekle(string resimID, Bitmap rsm)
        {
            string imgfl = @"\personel\";
            Directory.CreateDirectory(FormOgrenciKayit.path + imgfl);
            imgfl = imgfl + resimID + ".jpg";
            rsm.Save(FormOgrenciKayit.path + imgfl);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FormFotoCek frmFotoCek = new FormFotoCek();
            frmFotoCek.resim.Image = pictureBox1.Image;
            Bitmap BT = null;
            if (frmFotoCek.ShowDialog() == DialogResult.OK)
            {
                BT = new Bitmap((Bitmap)frmFotoCek.resim.Image);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = frmFotoCek.resim.Image;
                if (tbTCNo.Text != "") resimekle(tbTCNo.Text, BT);
                else MessageBox.Show("TC alanı boş bırakılamaz!");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=YurtVeriTabani.mdb;");
            baglan.Open();
            string ekle, ekleSifreler;
            ekle = "INSERT INTO personel (Ad, Soyad, CepNumarasi, Email, HakkindaBilgi, TC, AnneAdi, BabaAdi, DogumYeri, DogumTarihi, Dini, Il, Ilce, MahalleKoy, KimliginVerildigiYer, MedeniDurum, KanGrubu, Ozur, Hastalik, SaglikRaporuDurumu) VALUES ('" +
                tbAd.Text + "','" + tbSoyad.Text + "','" + tbCepNo.Text + "','" + tbEmail.Text + "','" + tbKendiHakkinda.Text +
                "','" + tbTCNo.Text + "','" + tbAnneAdi.Text + "','" + tbBabaAdi.Text + "','" + tbDogumYeri.Text + "','" + dtpDogumTarihi.Text + "','" + tbDini.Text + "','" + tbIl.Text + "','" + tbIlce.Text + "','" + tbMahalleKoy.Text + "','" + tbVerildigiYer.Text + "','" + cbMedeniDurumu.Text + "','" + cbKanGrubu.Text +
                "','" + tbOzurDurumu.Text + "','" + tbHastalikDurumu.Text + "','" + cbSaglikRaporu.Text + "');";

            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglan;
            komut.CommandText = ekle;
            komut.ExecuteNonQuery();
            if (tbKullaniciAd.Text == tbAdTekrari.Text && tbGirisSifre.Text == tbSifreTekrari.Text)
            {
                OleDbCommand komutPersonelSifreleri = new OleDbCommand();
                ekleSifreler = "INSERT INTO personel_girisi (kullanici_ad, kullanici_sifre, pTC) VALUES ('" + tbKullaniciAd.Text + "','" + tbGirisSifre.Text + "','" +tbTCNo.Text+ "');";
                komutPersonelSifreleri.Connection = baglan;
                komutPersonelSifreleri.CommandText = ekleSifreler;
                komutPersonelSifreleri.ExecuteNonQuery();
                this.Close();
            }
            MessageBox.Show("Başarıyla kaydedildi");
        }

        private void tbTCNo_TextChanged(object sender, EventArgs e)
        {
            if (tbTCNo.Text != "")
                button1.Enabled = true;
            if (tbTCNo.Text == "")
                button1.Enabled = false;
        }
    }
}
