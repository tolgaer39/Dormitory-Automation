using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace projedeneme1
{
    class BlokMlok
    {
        public Blok_Oda blok_Oda;

        public BlokMlok()
        {
            blok_Oda = new Blok_Oda();
        }

        public static BlokMlok bloguGetir(string blk)
        {
            OleDbConnection baglantix = new OleDbConnection("provider=Microsoft.jet.oledb.4.0; Data Source=YurtVeriTabani.mdb;");
            baglantix.Open();
            OleDbCommand verix = new OleDbCommand();
            verix.Connection = baglantix;
            verix.CommandText = "select * from blok_oda where Blok_No='" + blk + "'";
            OleDbDataReader okux = verix.ExecuteReader();
            BlokMlok bulunanBlok = null;
            if (okux.Read())
            {
                bulunanBlok = new BlokMlok(okux);
            }
            baglantix.Close();
            return bulunanBlok;
        }

        public BlokMlok(OleDbDataReader okux)
        {
            blok_Oda = new Blok_Oda();

            blok_Oda.blokNo = okux["Blok_No"].ToString();
            blok_Oda.oda1 = okux["1"].ToString();
            blok_Oda.oda2 = okux["2"].ToString();
            blok_Oda.oda3 = okux["3"].ToString();
            blok_Oda.oda4 = okux["4"].ToString();
            blok_Oda.oda5 = okux["5"].ToString();
            blok_Oda.oda6 = okux["6"].ToString();
            blok_Oda.oda7 = okux["7"].ToString();
            blok_Oda.oda8 = okux["8"].ToString();
            blok_Oda.oda9 = okux["9"].ToString();
            blok_Oda.oda10 = okux["10"].ToString();
            blok_Oda.oda11 = okux["11"].ToString();
            blok_Oda.oda12 = okux["12"].ToString();
            blok_Oda.oda13 = okux["13"].ToString();
            blok_Oda.oda14 = okux["14"].ToString();
            blok_Oda.oda15 = okux["15"].ToString();
            blok_Oda.oda16 = okux["16"].ToString();
            blok_Oda.oda17 = okux["17"].ToString();
            blok_Oda.oda18 = okux["18"].ToString();
            blok_Oda.oda19 = okux["19"].ToString();
            blok_Oda.oda20 = okux["20"].ToString();
            blok_Oda.oda21 = okux["21"].ToString();
            blok_Oda.oda22 = okux["22"].ToString();
            blok_Oda.oda23 = okux["23"].ToString();
            blok_Oda.oda24 = okux["24"].ToString();
            blok_Oda.oda25 = okux["25"].ToString();
            blok_Oda.oda26 = okux["26"].ToString();
            blok_Oda.oda27 = okux["27"].ToString();
            blok_Oda.oda28 = okux["28"].ToString();
            blok_Oda.oda29 = okux["29"].ToString();
            blok_Oda.oda30 = okux["30"].ToString();
        }
    }
}