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
    public partial class FormOgrBilgileri : Form
    {
        public FormOgrBilgileri()
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
            OleDbCommand veriz = new OleDbCommand("select * from oda_yatak_" + cbBlokNo.Text + " where Oda_No='" + cbOdaNo.Text + "'", baglantiz);
            OleDbDataReader okuz;
            okuz = veriz.ExecuteReader();
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
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Güncelle")
            {
                ArayuzuDuzenle();
                button2.Text = "Kaydet";
            }
            else if (button2.Text == "Kaydet")
            {
                OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=YurtVeriTabani.mdb;");
                baglan.Open();
                OleDbCommand veri = new OleDbCommand("SELECT * FROM ogrenciler WHERE TC='" + tbTCNo.Text + "'", baglan);
                OleDbDataReader oku;
                oku = veri.ExecuteReader();
                if (oku.Read())
                {
                    OleDbCommand yenile = new OleDbCommand("UPDATE ogrenciler SET Ad='" + tbAd.Text + "', Soyad='" + tbSoyad.Text + "', CepNumarasi='" + tbCepNo.Text + "', Email='" + tbEmail.Text + "', HakkindaBilgi='" + tbKendiHakkinda.Text + "', KardesSayisi='" + tbKardesSay.Text + "', AileDurumu='" + cbAileDurumu.Text + "', Okul='" + tbOkul.Text + "', Bolum='" + tbBolum.Text + "', Sinif='" + tbSinif.Text + "', OgrenimTuru='" + cbOgrenimTuru.Text + "', OgrenciNo='" + tbOgrenciNo.Text + "', BlokNo='" + cbBlokNo.Text + "', OdaNo='" + cbOdaNo.Text + "', KatNo='" + lbKatNo.Text + "', YatakNo='" + cbYatakNo.Text + "', KayitTarih='" +
                        dtpKayitTarihi.Text + "', TC='" + tbTCNo.Text + "', AnneAdi='" + tbAnneAdi.Text + "', BabaAdi='" + tbBabaAdi.Text + "', DogumYeri='" + tbDogumYeri.Text + "', DogumTarihi='" + dtpDogumTarihi.Text + "', Dini='" + tbDini.Text + "', Il='" + tbIl.Text + "', Ilce='" + tbIlce.Text + "', MahalleKoy='" + tbMahalleKoy.Text + "', KimliginVerildigiYer='" + tbVerildigiYer.Text + "', MedeniDurum='" + cbMedeniDurumu.Text + "', KanGrubu='" +
                        cbKanGrubu.Text + "', VeliAd='" + tbVeliAd.Text + "', VeliSoyad='" + tbVeliSoyad.Text + "', VeliYakinlikDerecesi='" + tbYakinlikDerecesi.Text + "', VeliTelefon='" + tbVeliEvTel.Text + "', VeliCepTelefonu='" + tbVeliCepTel.Text + "', VeliAdres='" + tbAdres.Text + "',Ozur='" + tbOzurDurumu.Text + "', Hastalik='" + tbHastalikDurumu.Text + "', SaglikRaporuDurumu='" + cbSaglikRaporu.Text + "'", baglan);
                    yenile.ExecuteNonQuery();
                    baglan.Close();
                    groupBox1.Enabled = false;
                    groupBox2.Enabled = false;
                    button1.Enabled = false;
                    groupBox3.Enabled = false;
                    groupBox4.Enabled = false;
                    groupBox5.Enabled = false;
                    button3.Enabled = true;
                    button2.Text = "Güncelle";
                }
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

                        OleDbCommand silYataktan = new OleDbCommand("UPDATE oda_yatak_" + labelBilgMilg3.Text + " SET " + labelBilgMilg.Text + "='boş' WHERE Oda_No='" + labelBilgMilg2.Text + "'", baglan2);
                        silYataktan.ExecuteNonQuery();

                        if (oku2["1"].ToString() != "boş" && oku2["2"].ToString() != "boş" && oku2["3"].ToString() != "boş" && oku2["4"].ToString() != "boş")
                        {
                            OleDbCommand odaUygunluk = new OleDbCommand("UPDATE oda_yatak_" + cbBlokNo.Text + " SET Oda_Uygunluk='uygun değil'  WHERE Oda_No='" + cbOdaNo.Text + "'", baglan2);
                            OleDbCommand odaUygunluk2 = new OleDbCommand("UPDATE blok_oda SET " + cbOdaNo.Text + "='uygun değil' WHERE Blok_No='" + cbBlokNo.Text + "'", baglan2);
                            odaUygunluk.ExecuteNonQuery();
                            odaUygunluk2.ExecuteNonQuery();
                        }
                        else
                        {
                            OleDbCommand odaUygunluk = new OleDbCommand("UPDATE oda_yatak_" + cbBlokNo.Text + " SET Oda_Uygunluk='uygun'  WHERE Oda_No='" + cbOdaNo.Text + "'", baglan2);
                            OleDbCommand odaUygunluk2 = new OleDbCommand("UPDATE blok_oda SET " + cbOdaNo.Text + "='uygun' WHERE Blok_No='" + cbBlokNo.Text + "'", baglan2);

                            OleDbCommand ekleYatax = new OleDbCommand("UPDATE oda_yatak_" + cbBlokNo.Text + " SET " + cbYatakNo.Text + "='"+tbTCNo.Text+"' WHERE Oda_No='" + cbOdaNo.Text + "'", baglan2);
                            ekleYatax.ExecuteNonQuery();

                            odaUygunluk.ExecuteNonQuery();
                            odaUygunluk2.ExecuteNonQuery();
                        }
                        this.Close();
                        MessageBox.Show("Bilgiler başarıyla güncellendi");
                    }
                    else
                        MessageBox.Show("Fazla zorlama!", "Oda dolu!");
                }
                baglan2.Close();
            }
        }

        private void ArayuzuDuzenle()
        {
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            button1.Enabled = true;
            groupBox3.Enabled = true;
            tbTCNo.Enabled = false;
            groupBox4.Enabled = true;
            groupBox5.Enabled = true;
            button3.Enabled = false;
            labelBilgMilg.Text = cbYatakNo.Text;
            labelBilgMilg2.Text = cbOdaNo.Text;
            labelBilgMilg3.Text = cbBlokNo.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult msgbx;
            msgbx=MessageBox.Show("Öğrenciyi kayıttan silmek istediğinize emin misiniz?","Silinsin mi?",MessageBoxButtons.YesNo);
            if (msgbx==DialogResult.Yes)
            {

                OleDbConnection baglam = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=YurtVeriTabani.mdb;");
                baglam.Open();
                OleDbCommand yatakFilan = new OleDbCommand("UPDATE oda_yatak_" + cbBlokNo.Text + " SET Oda_Uygunluk='uygun',"+cbOdaNo.Text+"='boş' WHERE Oda_No='" + cbOdaNo.Text + "'", baglam);
                OleDbCommand odaUygunluk2 = new OleDbCommand("UPDATE blok_oda SET " + cbOdaNo.Text + "='uygun' WHERE Blok_No='" + cbBlokNo.Text + "'", baglam);
                OleDbCommand sil = new OleDbCommand("DELETE FROM ogrenciler where TC='" + tbTCNo.Text + "'", baglam);
                sil.ExecuteNonQuery();
                yatakFilan.ExecuteNonQuery();
                odaUygunluk2.ExecuteNonQuery();

                OleDbCommand silYataktan = new OleDbCommand("UPDATE oda_yatak_" + cbBlokNo.Text + " SET " + cbYatakNo.Text + "='boş' WHERE Oda_No='" + cbOdaNo.Text + "'", baglam);
                silYataktan.ExecuteNonQuery();
                MessageBox.Show("Öğrenci kaydı silinmiştir.");
                Close();
            }
        }

        public bool bl = false;
        private void FormOgrBilgileri_Load(object sender, EventArgs e)
        {
            if(!bl)
            FormOgrenciAra.ActiveForm.Hide();
        }
        internal void OgrenciBagla(Ogrenci bulunan)
        {
            tbAd.Text = bulunan.kisiselBilgiler.Ad;
            tbSoyad.Text = bulunan.kisiselBilgiler.Soyad;
            tbKardesSay.Text = bulunan.kisiselBilgilerEk.KardesSayisi;
            cbAileDurumu.Text = bulunan.kisiselBilgilerEk.AileDurumu;
            tbCepNo.Text = bulunan.kisiselBilgiler.CepNumarasi;
            tbEmail.Text = bulunan.kisiselBilgiler.Email;
            tbKendiHakkinda.Text = bulunan.kisiselBilgiler.HakkindaBilgi;
            tbOkul.Text = bulunan.okulYurtBilgileri.Okul;
            tbBolum.Text = bulunan.okulYurtBilgileri.Bolum;
            tbSinif.Text = bulunan.okulYurtBilgileri.Sinif;
            cbOgrenimTuru.Text = bulunan.okulYurtBilgileri.OgrenimTuru;
            tbOgrenciNo.Text = bulunan.okulYurtBilgileri.OgrenciNo;
            cbBlokNo.Text = bulunan.okulYurtBilgileri.BlokNo;
            cbOdaNo.Text = bulunan.okulYurtBilgileri.OdaNo;
            lbKatNo.Text = ((((Convert.ToInt32(bulunan.okulYurtBilgileri.OdaNo)) - 1) / 10) + 1).ToString();
            cbYatakNo.Text = bulunan.okulYurtBilgileri.YatakNo;
            dtpKayitTarihi.Text = bulunan.okulYurtBilgileri.KayitTarih;
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
            tbVeliAd.Text = bulunan.veliBilgileri.Ad;
            tbVeliSoyad.Text = bulunan.veliBilgileri.Soyad;
            tbYakinlikDerecesi.Text = bulunan.veliBilgileri.YakinlikDerecesi;
            tbVeliEvTel.Text = bulunan.veliBilgileri.Telefon;
            tbVeliCepTel.Text = bulunan.veliBilgileri.CepTelefonu;
            tbAdres.Text = bulunan.veliBilgileri.Adres;
            tbOzurDurumu.Text = bulunan.saglikBilgileri.Ozur;
            tbHastalikDurumu.Text = bulunan.saglikBilgileri.Hastalik;
            cbSaglikRaporu.Text = bulunan.saglikBilgileri.SaglikRaporuDurumu;
            string fl =FormOgrenciKayit.path + @"\ogrenci\" + bulunan.kimlikBilgileri.TC.ToString() + ".jpg";
            if (File.Exists(fl))
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Load(fl);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("provider=Microsoft.jet.oledb.4.0; Data Source=YurtVeriTabani.mdb;");
            baglanti.Open();
            OleDbCommand veri = new OleDbCommand();
            veri.Connection = baglanti;
            veri.CommandText = "select * from ogrenciler";
            OleDbDataReader oku = veri.ExecuteReader();
            Ogrenci bulunanOgrenci = null;
            if (oku.Read())
            {
                bulunanOgrenci = new Ogrenci(oku);

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