using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace projedeneme1
{
    class Personel : Kisi
    {
        public SaglikBilgileri saglikBilgileri;
        public SiraKimlik siraKimlik;

        public Personel()
        {
            kisiselBilgiler = new KisiselBilgiler();
            kimlikBilgileri = new KimlikBilgileri();
            saglikBilgileri = new SaglikBilgileri();
            siraKimlik = new SiraKimlik();
        }

        public static Personel TCyeGoreOgrenciGetir(string TC)
        {
            OleDbConnection baglanti = new OleDbConnection("provider=Microsoft.jet.oledb.4.0; Data Source=YurtVeriTabani.mdb;");
            baglanti.Open();
            OleDbCommand veri = new OleDbCommand();
            veri.Connection = baglanti;
            veri.CommandText = "select * from personel where TC='" + TC + "'";
            OleDbDataReader oku = veri.ExecuteReader();
            Personel bulunanPersonel = null;
            if (oku.Read())
            {
                bulunanPersonel = new Personel(oku);

            }
            baglanti.Close();
            return bulunanPersonel;
        }
        public Personel(OleDbDataReader oku)
        {
            kisiselBilgiler = new KisiselBilgiler();
            kimlikBilgileri = new KimlikBilgileri();
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
    }
}
