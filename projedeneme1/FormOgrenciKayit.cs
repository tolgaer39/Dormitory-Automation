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
    public partial class FormOgrenciKayit : Form
    {
        public static string path = Path.GetDirectoryName(Application.ExecutablePath) + @"\Resimler";
        public FormOgrenciKayit()
        {
            InitializeComponent();
        }

        internal void resimekle(string resimID, Bitmap rsm)
        {
            string imgfl = @"\ogrenci\";
            Directory.CreateDirectory(FormOgrenciKayit.path + imgfl);
            imgfl = imgfl + resimID + ".jpg";
            rsm.Save(FormOgrenciKayit.path + imgfl);
        }

        internal string uygunluk_blok(string blok)
        {
                BlokMlok bulunanx = BlokMlok.bloguGetir(blok);
                if (bulunanx.blok_Oda.oda1 == "uygun" || bulunanx.blok_Oda.oda2 == "uygun" || bulunanx.blok_Oda.oda3 == "uygun" || bulunanx.blok_Oda.oda4 == "uygun" || bulunanx.blok_Oda.oda5 == "uygun" ||
                    bulunanx.blok_Oda.oda6 == "uygun" || bulunanx.blok_Oda.oda7 == "uygun" || bulunanx.blok_Oda.oda8 == "uygun" || bulunanx.blok_Oda.oda9 == "uygun" || bulunanx.blok_Oda.oda10 == "uygun" ||
                    bulunanx.blok_Oda.oda11 == "uygun" || bulunanx.blok_Oda.oda12 == "uygun" || bulunanx.blok_Oda.oda13 == "uygun" || bulunanx.blok_Oda.oda14 == "uygun" || bulunanx.blok_Oda.oda15 == "uygun" ||
                    bulunanx.blok_Oda.oda16 == "uygun" || bulunanx.blok_Oda.oda17 == "uygun" || bulunanx.blok_Oda.oda18 == "uygun" || bulunanx.blok_Oda.oda19 == "uygun" || bulunanx.blok_Oda.oda20 == "uygun" ||
                    bulunanx.blok_Oda.oda21 == "uygun" || bulunanx.blok_Oda.oda22 == "uygun" || bulunanx.blok_Oda.oda23 == "uygun" || bulunanx.blok_Oda.oda24 == "uygun" || bulunanx.blok_Oda.oda25 == "uygun" ||
                    bulunanx.blok_Oda.oda26 == "uygun" || bulunanx.blok_Oda.oda27 == "uygun" || bulunanx.blok_Oda.oda28 == "uygun" || bulunanx.blok_Oda.oda29 == "uygun" || bulunanx.blok_Oda.oda30 == "uygun")
                    return "olumlu";
                else
                    return "olumsuz";
        }

        public void blokxxx()
        {
            for (int i = 1; i <= 5; i++)
            {
                if (uygunluk_blok(i.ToString()) == "olumlu")
                    cbBlokNo.Items.Add(i.ToString());
            }
        }

        internal string uygunluk_oda(string oda)
        {
            OdaModa bulunany = OdaModa.odayiGetir(oda, cbBlokNo.Text);
            if (bulunany.oda_Yatak.yatak1 == "boş" || bulunany.oda_Yatak.yatak2 == "boş" || bulunany.oda_Yatak.yatak3 == "boş" || bulunany.oda_Yatak.yatak4 == "boş")
                return "uygun";
            else
                return "uygun değil";
        }

        public void odaxxx()
        {
            for (int j = 1; j <= 30; j++)
            {
                if (uygunluk_oda(j.ToString()) == "uygun")
                    cbOdaNo.Items.Add(j.ToString());
            }
        }
        public void yatakxxx()
        {
            OleDbConnection baglantiz = new OleDbConnection("provider=Microsoft.jet.oledb.4.0; Data Source=YurtVeriTabani.mdb;");
            baglantiz.Open();
            OleDbCommand veriz = new OleDbCommand("select * from oda_yatak_" + cbBlokNo.Text + " where Oda_No='" + cbOdaNo.Text + "'",baglantiz);
            OleDbDataReader okuz; 
            okuz=veriz.ExecuteReader();
            if (okuz.Read())
            {
                for (int k = 1; k <= 4; k++)
                {
                    if (okuz[k.ToString()].ToString() == "boş")
                    {
                        cbYatakNo.Items.Add(k.ToString());
                    }
                }
            }
            baglantiz.Close();
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

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=YurtVeriTabani.mdb;");
            baglan.Open();
            string ekle;
            ekle = "INSERT INTO ogrenciler (Ad, Soyad, CepNumarasi, Email, HakkindaBilgi, KardesSayisi, AileDurumu, Okul, Bolum, Sinif, OgrenimTuru, OgrenciNo, BlokNo, OdaNo, KatNo, YatakNo, KayitTarih," +
                "TC, AnneAdi, BabaAdi, DogumYeri, DogumTarihi, Dini, Il, Ilce, MahalleKoy, KimliginVerildigiYer, MedeniDurum, KanGrubu," +
                "VeliAd, VeliSoyad, VeliYakinlikDerecesi, VeliTelefon, VeliCepTelefonu, VeliAdres,Ozur, Hastalik, SaglikRaporuDurumu) VALUES ('" +
                tbAd.Text + "','" + tbSoyad.Text + "','" + tbCepNo.Text + "','" + tbEmail.Text + "','" + tbKendiHakkinda.Text + "','" + tbKardesSay.Text + "','" + cbAileDurumu.Text +
                "','" + tbOkul.Text + "','" + tbBolum.Text + "','" + tbSinif.Text + "','" + cbOgrenimTuru.Text + "','" + tbOgrenciNo.Text + "','" + cbBlokNo.Text + "','" + cbOdaNo.Text + "','" + lbKatNo.Text + "','" + cbYatakNo.Text + "','" + dtpKayitTarihi.Text +
                "','" + tbTCNo.Text + "','" + tbAnneAdi.Text + "','" + tbBabaAdi.Text + "','" + tbDogumYeri.Text + "','" + dtpDogumTarihi.Text + "','" + tbDini.Text + "','" + tbIl.Text + "','" + tbIlce.Text + "','" + tbMahalleKoy.Text + "','" + tbVerildigiYer.Text + "','" + cbMedeniDurumu.Text + "','" + cbKanGrubu.Text +
                "','" + tbVeliAd.Text + "','" + tbVeliSoyad.Text + "','" + tbYakinlikDerecesi.Text + "','" + tbVeliEvTel.Text + "','" + tbVeliCepTel.Text + "','" + tbAdres.Text + "','" + tbOzurDurumu.Text + "','" + tbHastalikDurumu.Text + "','" + cbSaglikRaporu.Text + "');";

            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglan;
            komut.CommandText = ekle;
            komut.ExecuteNonQuery();
            baglan.Close();

            OleDbConnection baglan2 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=YurtVeriTabani.mdb;");
            baglan2.Open();
            OleDbCommand veriz = new OleDbCommand("SELECT * FROM oda_yatak_" + cbBlokNo.Text + " WHERE Oda_No='" + cbOdaNo.Text + "'", baglan2);
            OleDbDataReader oku2;
            oku2 = veriz.ExecuteReader();
            if (oku2.Read())
            {
                if (oku2["1"].ToString() == "boş" || oku2["2"].ToString() == "boş" || oku2["3"].ToString() == "boş" || oku2["4"].ToString() == "boş")
                {
                    OleDbCommand ekleYataga = new OleDbCommand("UPDATE oda_yatak_" + cbBlokNo.Text + " SET " + cbYatakNo.Text + "='" + tbTCNo.Text + "' WHERE Oda_No='" + cbOdaNo.Text + "'", baglan2);
                    ekleYataga.ExecuteNonQuery();
                    oku2.Close();
                    oku2 = veriz.ExecuteReader();
                    oku2.Read();
                    if (oku2["1"].ToString() != "boş" && oku2["2"].ToString() != "boş" && oku2["3"].ToString() != "boş" && oku2["4"].ToString() != "boş")
                    {
                        OleDbCommand odaUygunluk = new OleDbCommand("UPDATE oda_yatak_" + cbBlokNo.Text + " SET Oda_Uygunluk='uygun değil'  WHERE Oda_No='" + cbOdaNo.Text + "'", baglan2);
                        OleDbCommand odaUygunluk2 = new OleDbCommand("UPDATE blok_oda SET "+cbOdaNo.Text+"='uygun değil' WHERE Blok_No='"+cbBlokNo.Text+"'", baglan2);
                        odaUygunluk.ExecuteNonQuery();
                        odaUygunluk2.ExecuteNonQuery();
                    }
                    else
                    {
                        OleDbCommand odaUygunluk = new OleDbCommand("UPDATE oda_yatak_" + cbBlokNo.Text + " SET Oda_Uygunluk='uygun'  WHERE Oda_No='" + cbOdaNo.Text + "'", baglan2);
                        OleDbCommand odaUygunluk2 = new OleDbCommand("UPDATE blok_oda SET " + cbOdaNo.Text + "='uygun' WHERE Blok_No='" + cbBlokNo.Text + "'", baglan2);
                        odaUygunluk.ExecuteNonQuery();
                        odaUygunluk2.ExecuteNonQuery();
                    }
                    this.Close();
                    MessageBox.Show("Başarıyla kaydedildi");
                }
                else
                    MessageBox.Show("Fazla zorlama!", "Oda dolu!");
            }
            baglan2.Close();
        }


        private void FormOgrenciKayit_Load(object sender, EventArgs e)
        {
            DateTime tarih = DateTime.Today;
            dtpKayitTarihi.Text = (tarih).ToString();
            dtpDogumTarihi.Text = (tarih).ToString();
            if (tbTCNo.Text != "")
                button1.Enabled = true;
        }

        private void tbTCNo_TextChanged(object sender, EventArgs e)
        {
            if (tbTCNo.Text != "")
                button1.Enabled = true;
            if (tbTCNo.Text == "")
                button1.Enabled = false;
        }

        private void cbOdaNo_SelectedValueChanged(object sender, EventArgs e)
        {
            lbKatNo.Text = ((((Convert.ToInt32(cbOdaNo.Text)) - 1) / 10) + 1).ToString();
            cbYatakNo.Items.Clear();
            yatakxxx();
        }

        private void cbBlokNo_SelectedValueChanged(object sender, EventArgs e)
        {
            cbOdaNo.Items.Clear();
            odaxxx();
        }
    }
}