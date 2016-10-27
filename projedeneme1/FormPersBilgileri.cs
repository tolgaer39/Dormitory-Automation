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
    public partial class FormPersBilgileri : Form
    {
        public FormPersBilgileri()
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Güncelle")
            {
                groupBox1.Enabled = true;
                button1.Enabled = true;
                groupBox3.Enabled = true;
                tbTCNo.Enabled = false;
                groupBox5.Enabled = true;
                button3.Enabled = false;
                button2.Text = "Kaydet";
            }
            else if (button2.Text == "Kaydet")
            {
                OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=YurtVeriTabani.mdb;");
                baglan.Open();
                OleDbCommand veri = new OleDbCommand("SELECT * FROM personel WHERE TC='" + tbTCNo.Text + "'", baglan);
                OleDbDataReader oku;
                oku = veri.ExecuteReader();
                if (oku.Read())
                {
                    OleDbCommand yenile = new OleDbCommand("UPDATE personel SET Ad='" + tbAd.Text + "', Soyad='" + tbSoyad.Text + "', CepNumarasi='" + tbCepNo.Text + "', Email='" + tbEmail.Text + "', HakkindaBilgi='" + tbKendiHakkinda.Text + "', TC='" + tbTCNo.Text + "', AnneAdi='" + tbAnneAdi.Text + "', BabaAdi='" + tbBabaAdi.Text + "', DogumYeri='" + tbDogumYeri.Text + "', DogumTarihi='" + dtpDogumTarihi.Text + "', Dini='" + tbDini.Text + "', Il='" + tbIl.Text + "', Ilce='" + tbIlce.Text + "', MahalleKoy='" + tbMahalleKoy.Text + "', KimliginVerildigiYer='" + tbVerildigiYer.Text + "', MedeniDurum='" + cbMedeniDurumu.Text + "', KanGrubu='" +
                        cbKanGrubu.Text + "',Ozur='" + tbOzurDurumu.Text + "', Hastalik='" + tbHastalikDurumu.Text + "', SaglikRaporuDurumu='" + cbSaglikRaporu.Text + "'", baglan);
                    yenile.ExecuteNonQuery();
                    baglan.Close();
                    groupBox1.Enabled = false;
                    button1.Enabled = false;
                    groupBox3.Enabled = false;
                    groupBox5.Enabled = false;
                    button3.Enabled = true;
                    button2.Text = "Güncelle";
                }
                MessageBox.Show("Güncelledik, mutlu musun!");
            }
        }

        public bool bl = false;
        private void FormPersBilgileri_Load(object sender, EventArgs e)
        {
            if (!bl)
                FormPersonelListele.ActiveForm.Hide();
        }

        internal void PersonelBagla(Personel bulunan)
        {
            tbAd.Text = bulunan.kisiselBilgiler.Ad;
            tbSoyad.Text = bulunan.kisiselBilgiler.Soyad;
            tbCepNo.Text = bulunan.kisiselBilgiler.CepNumarasi;
            tbEmail.Text = bulunan.kisiselBilgiler.Email;
            tbKendiHakkinda.Text = bulunan.kisiselBilgiler.HakkindaBilgi;
            tbTCNo.Text = bulunan.kimlikBilgileri.TC;
            tbAnneAdi.Text = bulunan.kimlikBilgileri.AnneAdi;
            tbBabaAdi.Text = bulunan.kimlikBilgileri.BabaAdi;
            tbDogumYeri.Text = bulunan.kimlikBilgileri.DogumYeri;
            dtpDogumTarihi.Text = bulunan.kimlikBilgileri.DogumTarihi;
            tbDini.Text = bulunan.kimlikBilgileri.Dini;
            tbIl.Text = bulunan.kimlikBilgileri.Il;
            tbIlce.Text = bulunan.kimlikBilgileri.Ilce;
            tbMahalleKoy.Text = bulunan.kimlikBilgileri.MahalleKoy;
            tbVerildigiYer.Text = bulunan.kimlikBilgileri.KimliginVerildigiYer;
            cbMedeniDurumu.Text = bulunan.kimlikBilgileri.MedeniDurum;
            cbKanGrubu.Text = bulunan.kimlikBilgileri.KanGrubu;
            tbOzurDurumu.Text = bulunan.saglikBilgileri.Ozur;
            tbHastalikDurumu.Text = bulunan.saglikBilgileri.Hastalik;
            cbSaglikRaporu.Text = bulunan.saglikBilgileri.SaglikRaporuDurumu;
            string fl = FormOgrenciKayit.path + @"\personel\" + bulunan.kimlikBilgileri.TC.ToString() + ".jpg";
            if (File.Exists(fl))
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Load(fl);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            DialogResult msgbx;
            msgbx = MessageBox.Show("Personeli kayıttan düşmek istediğinize emin misiniz?", "Silinsin mi?", MessageBoxButtons.YesNo);
            if (msgbx == DialogResult.Yes)
            {

                OleDbConnection baglam = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=YurtVeriTabani.mdb;");
                baglam.Open();
                OleDbCommand sil = new OleDbCommand("DELETE FROM personel where TC='" + tbTCNo.Text + "'", baglam);
                sil.ExecuteNonQuery();
                MessageBox.Show("Personel kaydı silinmiştir.");
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("provider=Microsoft.jet.oledb.4.0; Data Source=YurtVeriTabani.mdb;");
            baglanti.Open();
            OleDbCommand veri = new OleDbCommand();
            veri.Connection = baglanti;
            veri.CommandText = "select * from personel";
            OleDbDataReader oku = veri.ExecuteReader();
            Personel bulunanPersonel = null;
            if (oku.Read())
            {
                bulunanPersonel = new Personel(oku);
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
            baglanti.Close();
        }
    }
}