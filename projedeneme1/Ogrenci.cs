using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace projedeneme1
{
    class Ogrenci : Kisi
    {
        public KisiselBilgilerEk kisiselBilgilerEk;
        public OkulYurtBilgileri okulYurtBilgileri;
        public VeliBilgileri veliBilgileri;
        public SaglikBilgileri saglikBilgileri;
        public SiraKimlik siraKimlik;

        public Ogrenci()
        {
            kisiselBilgiler = new KisiselBilgiler();
            kisiselBilgilerEk = new KisiselBilgilerEk();
            okulYurtBilgileri = new OkulYurtBilgileri();
            kimlikBilgileri = new KimlikBilgileri();
            veliBilgileri = new VeliBilgileri();
            saglikBilgileri = new SaglikBilgileri();
            siraKimlik = new SiraKimlik();
        }

        public static Ogrenci TCyeGoreOgrenciGetir(string TC)
        {
            OleDbConnection baglanti = new OleDbConnection("provider=Microsoft.jet.oledb.4.0; Data Source=YurtVeriTabani.mdb;");
            baglanti.Open();
            OleDbCommand veri = new OleDbCommand();
            veri.Connection = baglanti;
            veri.CommandText = "select * from ogrenciler where TC='" + TC + "'";
            OleDbDataReader oku = veri.ExecuteReader();
            Ogrenci bulunanOgrenci = null;
            if (oku.Read())
            {
                bulunanOgrenci = new Ogrenci(oku);
            }
            baglanti.Close();
            return bulunanOgrenci;
        }

        /*public static Ogrenci yatakTC(string yTC)
        {
            Form3 frm3 = new Form3();
            OleDbConnection baglanti = new OleDbConnection("provider=Microsoft.jet.oledb.4.0; Data Source=YurtVeriTabani.mdb;");
            baglanti.Open();
            OleDbCommand veri = new OleDbCommand();
            veri.Connection = baglanti;
            veri.CommandText = "select * from oda_yatak_" + frm3.xblok.ToString() + " where Oda_No='" + yTC + "'";
            OleDbDataReader oku = veri.ExecuteReader();
            Ogrenci bulYatTC = null;
            if (oku.Read())
            {
                bulYatTC = new Ogrenci(oku);
            }
            baglanti.Close();
            return bulYatTC;
        }*/

        public Ogrenci(OleDbDataReader oku)
        {
            kisiselBilgiler = new KisiselBilgiler();
            kisiselBilgilerEk = new KisiselBilgilerEk();
            okulYurtBilgileri = new OkulYurtBilgileri();
            kimlikBilgileri = new KimlikBilgileri();
            veliBilgileri = new VeliBilgileri();
            saglikBilgileri = new SaglikBilgileri();
            siraKimlik = new SiraKimlik();

            siraKimlik.sirasi = oku["Kimlik"].ToString();
            kisiselBilgiler.Ad = oku["Ad"].ToString();
            kisiselBilgiler.Soyad = oku["Soyad"].ToString();
            kisiselBilgiler.CepNumarasi = oku["CepNumarasi"].ToString();
            kisiselBilgiler.Email = oku["Email"].ToString();
            kisiselBilgiler.HakkindaBilgi = oku["HakkindaBilgi"].ToString();
            kimlikBilgileri.TC = oku["TC"].ToString();
            kimlikBilgileri.AnneAdi = oku["AnneAdi"].ToString();
            kimlikBilgileri.BabaAdi = oku["BabaAdi"].ToString();
            kimlikBilgileri.DogumYeri = oku["DogumYeri"].ToString();
            kimlikBilgileri.DogumTarihi = oku["DogumTarihi"].ToString();
            kimlikBilgileri.Dini = oku["Dini"].ToString();
            kimlikBilgileri.Il = oku["Il"].ToString();
            kimlikBilgileri.Ilce = oku["Ilce"].ToString();
            kimlikBilgileri.MahalleKoy = oku["MahalleKoy"].ToString();
            kimlikBilgileri.KimliginVerildigiYer = oku["KimliginVerildigiYer"].ToString();
            kimlikBilgileri.MedeniDurum = oku["MedeniDurum"].ToString();
            kimlikBilgileri.KanGrubu = oku["KanGrubu"].ToString();
            kisiselBilgilerEk.KardesSayisi = oku["KardesSayisi"].ToString();
            kisiselBilgilerEk.AileDurumu = oku["AileDurumu"].ToString();
            okulYurtBilgileri.Okul = oku["Okul"].ToString();
            okulYurtBilgileri.Bolum = oku["Bolum"].ToString();
            okulYurtBilgileri.Sinif = oku["Sinif"].ToString();
            okulYurtBilgileri.OgrenimTuru = oku["OgrenimTuru"].ToString();
            okulYurtBilgileri.OgrenciNo = oku["OgrenciNo"].ToString();
            okulYurtBilgileri.BlokNo = oku["BlokNo"].ToString();
            okulYurtBilgileri.OdaNo = oku["OdaNo"].ToString();
            okulYurtBilgileri.KatNo = oku["KatNo"].ToString();
            okulYurtBilgileri.YatakNo = oku["YatakNo"].ToString();
            okulYurtBilgileri.KayitTarih = oku["KayitTarih"].ToString();
            veliBilgileri.Ad = oku["VeliAd"].ToString();
            veliBilgileri.Soyad = oku["VeliSoyad"].ToString();
            veliBilgileri.YakinlikDerecesi = oku["VeliYakinlikDerecesi"].ToString();
            veliBilgileri.CepTelefonu = oku["VeliCepTelefonu"].ToString();
            veliBilgileri.Telefon = oku["VeliTelefon"].ToString();
            veliBilgileri.Adres = oku["VeliAdres"].ToString();
            saglikBilgileri.Ozur = oku["Ozur"].ToString();
            saglikBilgileri.Hastalik = oku["Hastalik"].ToString();
            saglikBilgileri.SaglikRaporuDurumu = oku["SaglikRaporuDurumu"].ToString();
        }

        internal KimlikBilgileri KimlikBilgileri
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        internal OkulYurtBilgileri OkulYurtBilgileri
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public KisiselBilgiler KisiselBilgiler
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        internal KisiselBilgilerEk KisiselBilgilerEk
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        internal SiraKimlik SiraKimlik
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        internal SaglikBilgileri SaglikBilgileri
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        internal VeliBilgileri VeliBilgileri
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

    }
}
