using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace projedeneme1
{
    class OdaModa
    {
        public Oda_Yatak oda_Yatak;

        public OdaModa()
        {
            oda_Yatak = new Oda_Yatak();
        }

        public static OdaModa odayiGetir(string od, string bk)
        {
            OleDbConnection baglantiy = new OleDbConnection("provider=Microsoft.jet.oledb.4.0; Data Source=YurtVeriTabani.mdb;");
            baglantiy.Open();
            OleDbCommand veriy = new OleDbCommand();
            veriy.Connection = baglantiy;
                veriy.CommandText = "select * from oda_yatak_"+bk+" where Oda_No='" + od + "'";
            OleDbDataReader okuy = veriy.ExecuteReader();
            OdaModa bulunanOda = null;
            if (okuy.Read())
            {
                bulunanOda = new OdaModa(okuy);
            }
            baglantiy.Close();
            return bulunanOda;
        }

        public OdaModa(OleDbDataReader okuy)
        {
            oda_Yatak = new Oda_Yatak();

            oda_Yatak.odaNo = okuy["Oda_No"].ToString();
            oda_Yatak.odaUygunluk = okuy["Oda_Uygunluk"].ToString();
            oda_Yatak.yatak1 = okuy["1"].ToString();
            oda_Yatak.yatak2 = okuy["2"].ToString();
            oda_Yatak.yatak3 = okuy["3"].ToString();
            oda_Yatak.yatak4 = okuy["4"].ToString();
        }
    }
}