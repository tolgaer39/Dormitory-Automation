using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace projedeneme1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void tsmiBilgilerimiGoruntule_Click(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("provider=Microsoft.jet.oledb.4.0; Data Source=YurtVeriTabani.mdb;");
            baglanti.Open();
            OleDbCommand komut2 = new OleDbCommand();
            komut2.Connection = baglanti;
            komut2.CommandText = "select * from personel_girisi where kullanici_ad='"+label1.Text+"'";
            OleDbDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                if (label1.Text == oku2["kullanici_ad"].ToString() && label2.Text == oku2["kullanici_sifre"].ToString())
                {
                    Personel bulunan = Personel.TCyeGoreOgrenciGetir(oku2["pTC"].ToString());
                    if (bulunan != null)
                    {
                        FormPersBilgileri frmPersBilgileri = new FormPersBilgileri();
                        frmPersBilgileri.PersonelBagla(bulunan);
                        frmPersBilgileri.button1.Visible = false;
                        frmPersBilgileri.button2.Visible = false;
                        frmPersBilgileri.button3.Visible = false;
                        frmPersBilgileri.bl = true;
                        frmPersBilgileri.ShowDialog();
                        break;
                    }
                }
            }
            baglanti.Close();
        }

        private void tsmiPersonelSifremiDegistir_Click(object sender, EventArgs e)
        {
            FormPersonelSifreDegisim frmPersonelSifreDegisim = new FormPersonelSifreDegisim();
            frmPersonelSifreDegisim.ShowDialog();
        }
        private void tsmiTcOgrAra_Click(object sender, EventArgs e)
        {
            FormOgrenciAra frmOgrAra = new FormOgrenciAra();
            frmOgrAra.ShowDialog();
        }

        private void blok1kat1odalar_Click(object sender, EventArgs e)
        {
            FormYataklar frmYataklar = new FormYataklar();
            OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=YurtVeriTabani.mdb;");
            baglan.Open();
            OleDbCommand bulalim = new OleDbCommand("select * from oda_yatak_1 where Oda_No='" + sender.ToString().Split('.').First() + "'", baglan);
            OleDbDataReader oku;
            oku = bulalim.ExecuteReader();
            if (oku.Read())
            {
                frmYataklar.labelBlok.Text = "1"; frmYataklar.labelOda.Text = sender.ToString().Split('.').First();
                if (oku["1"].ToString() == "boş")
                {
                    frmYataklar.label1.Text = "1. Yatak: Boş";
                    frmYataklar.labelYatak1.Text = oku["1"].ToString();
                }
                else
                {
                    frmYataklar.label1.Text = "1. Yatak: Dolu";
                    frmYataklar.labelYatak1.Text = oku["1"].ToString();
                }
                if (oku["2"].ToString() == "boş")
                {
                    frmYataklar.label2.Text = "2. Yatak: Boş";
                    frmYataklar.labelYatak2.Text = oku["2"].ToString();
                }
                else
                {
                    frmYataklar.label2.Text = "2. Yatak: Dolu";
                    frmYataklar.labelYatak2.Text = oku["2"].ToString();
                }
                if (oku["3"].ToString() == "boş")
                {
                    frmYataklar.label3.Text = "3. Yatak: Boş";
                    frmYataklar.labelYatak3.Text = oku["3"].ToString();
                }
                else
                {
                    frmYataklar.label3.Text = "3. Yatak: Dolu";
                    frmYataklar.labelYatak3.Text = oku["3"].ToString();
                }
                if (oku["4"].ToString() == "boş")
                {
                    frmYataklar.label4.Text = "4. Yatak: Boş";
                    frmYataklar.labelYatak4.Text = oku["4"].ToString();
                }
                else
                {
                    frmYataklar.label4.Text = "4. Yatak: Dolu";
                    frmYataklar.labelYatak4.Text = oku["4"].ToString();
                }
            }
            frmYataklar.label5.Text = "1. Blok, 1. Kat, " + sender.ToString();
            frmYataklar.ShowDialog();
        }

        private void blok1kat2odalar_Click(object sender, EventArgs e)
        {
            FormYataklar frmYataklar = new FormYataklar();
            OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=YurtVeriTabani.mdb;");
            baglan.Open();
            OleDbCommand bulalim = new OleDbCommand("select * from oda_yatak_1 where Oda_No='" + sender.ToString().Split('.').First() + "'", baglan);
            OleDbDataReader oku;
            oku = bulalim.ExecuteReader();
            if (oku.Read())
            {
                frmYataklar.labelBlok.Text = "1"; frmYataklar.labelOda.Text = sender.ToString().Split('.').First();
                if (oku["1"].ToString() == "boş")
                {
                    frmYataklar.label1.Text = "1. Yatak: Boş";
                    frmYataklar.labelYatak1.Text = oku["1"].ToString();
                }
                else
                {
                    frmYataklar.label1.Text = "1. Yatak: Dolu";
                    frmYataklar.labelYatak1.Text = oku["1"].ToString();
                }
                if (oku["2"].ToString() == "boş")
                {
                    frmYataklar.label2.Text = "2. Yatak: Boş";
                    frmYataklar.labelYatak2.Text = oku["2"].ToString();
                }
                else
                {
                    frmYataklar.label2.Text = "2. Yatak: Dolu";
                    frmYataklar.labelYatak2.Text = oku["2"].ToString();
                }
                if (oku["3"].ToString() == "boş")
                {
                    frmYataklar.label3.Text = "3. Yatak: Boş";
                    frmYataklar.labelYatak3.Text = oku["3"].ToString();
                }
                else
                {
                    frmYataklar.label3.Text = "3. Yatak: Dolu";
                    frmYataklar.labelYatak3.Text = oku["3"].ToString();
                }
                if (oku["4"].ToString() == "boş")
                {
                    frmYataklar.label4.Text = "4. Yatak: Boş";
                    frmYataklar.labelYatak4.Text = oku["4"].ToString();
                }
                else
                {
                    frmYataklar.label4.Text = "4. Yatak: Dolu";
                    frmYataklar.labelYatak4.Text = oku["4"].ToString();
                }
            }
            frmYataklar.label5.Text = "1. Blok, 2. Kat, " + sender.ToString();
            frmYataklar.ShowDialog();
        }

        private void blok1kat3odalar_Click(object sender, EventArgs e)
        {
            FormYataklar frmYataklar = new FormYataklar();
            OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=YurtVeriTabani.mdb;");
            baglan.Open();
            OleDbCommand bulalim = new OleDbCommand("select * from oda_yatak_1 where Oda_No='" + sender.ToString().Split('.').First() + "'", baglan);
            OleDbDataReader oku;
            oku = bulalim.ExecuteReader();
            if (oku.Read())
            {
                frmYataklar.labelBlok.Text = "1"; frmYataklar.labelOda.Text = sender.ToString().Split('.').First();
                if (oku["1"].ToString() == "boş")
                {
                    frmYataklar.label1.Text = "1. Yatak: Boş";
                    frmYataklar.labelYatak1.Text = oku["1"].ToString();
                }
                else
                {
                    frmYataklar.label1.Text = "1. Yatak: Dolu";
                    frmYataklar.labelYatak1.Text = oku["1"].ToString();
                }
                if (oku["2"].ToString() == "boş")
                {
                    frmYataklar.label2.Text = "2. Yatak: Boş";
                    frmYataklar.labelYatak2.Text = oku["2"].ToString();
                }
                else
                {
                    frmYataklar.label2.Text = "2. Yatak: Dolu";
                    frmYataklar.labelYatak2.Text = oku["2"].ToString();
                }
                if (oku["3"].ToString() == "boş")
                {
                    frmYataklar.label3.Text = "3. Yatak: Boş";
                    frmYataklar.labelYatak3.Text = oku["3"].ToString();
                }
                else
                {
                    frmYataklar.label3.Text = "3. Yatak: Dolu";
                    frmYataklar.labelYatak3.Text = oku["3"].ToString();
                }
                if (oku["4"].ToString() == "boş")
                {
                    frmYataklar.label4.Text = "4. Yatak: Boş";
                    frmYataklar.labelYatak4.Text = oku["4"].ToString();
                }
                else
                {
                    frmYataklar.label4.Text = "4. Yatak: Dolu";
                    frmYataklar.labelYatak4.Text = oku["4"].ToString();
                }
            }
            frmYataklar.label5.Text = "1. Blok, 3. Kat, " + sender.ToString();
            frmYataklar.ShowDialog();
        }

        private void blok2kat1odalar_Click(object sender, EventArgs e)
        {
            FormYataklar frmYataklar = new FormYataklar();
            OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=YurtVeriTabani.mdb;");
            baglan.Open();
            OleDbCommand bulalim = new OleDbCommand("select * from oda_yatak_2 where Oda_No='" + sender.ToString().Split('.').First() + "'", baglan);
            OleDbDataReader oku;
            oku = bulalim.ExecuteReader();
            if (oku.Read())
            {
                frmYataklar.labelBlok.Text = "2"; frmYataklar.labelOda.Text = sender.ToString().Split('.').First();
                if (oku["1"].ToString() == "boş")
                {
                    frmYataklar.label1.Text = "1. Yatak: Boş";
                    frmYataklar.labelYatak1.Text = oku["1"].ToString();
                }
                else
                {
                    frmYataklar.label1.Text = "1. Yatak: Dolu";
                    frmYataklar.labelYatak1.Text = oku["1"].ToString();
                }
                if (oku["2"].ToString() == "boş")
                {
                    frmYataklar.label2.Text = "2. Yatak: Boş";
                    frmYataklar.labelYatak2.Text = oku["2"].ToString();
                }
                else
                {
                    frmYataklar.label2.Text = "2. Yatak: Dolu";
                    frmYataklar.labelYatak2.Text = oku["2"].ToString();
                }
                if (oku["3"].ToString() == "boş")
                {
                    frmYataklar.label3.Text = "3. Yatak: Boş";
                    frmYataklar.labelYatak3.Text = oku["3"].ToString();
                }
                else
                {
                    frmYataklar.label3.Text = "3. Yatak: Dolu";
                    frmYataklar.labelYatak3.Text = oku["3"].ToString();
                }
                if (oku["4"].ToString() == "boş")
                {
                    frmYataklar.label4.Text = "4. Yatak: Boş";
                    frmYataklar.labelYatak4.Text = oku["4"].ToString();
                }
                else
                {
                    frmYataklar.label4.Text = "4. Yatak: Dolu";
                    frmYataklar.labelYatak4.Text = oku["4"].ToString();
                }
            }
            frmYataklar.label5.Text = "2. Blok, 1. Kat, " + sender.ToString();
            frmYataklar.ShowDialog();
        }

        private void blok2kat2odalar_Click(object sender, EventArgs e)
        {
            FormYataklar frmYataklar = new FormYataklar();
            OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=YurtVeriTabani.mdb;");
            baglan.Open();
            OleDbCommand bulalim = new OleDbCommand("select * from oda_yatak_2 where Oda_No='" + sender.ToString().Split('.').First() + "'", baglan);
            OleDbDataReader oku;
            oku = bulalim.ExecuteReader();
            if (oku.Read())
            {
                frmYataklar.labelBlok.Text = "2"; frmYataklar.labelOda.Text = sender.ToString().Split('.').First();
                if (oku["1"].ToString() == "boş")
                {
                    frmYataklar.label1.Text = "1. Yatak: Boş";
                    frmYataklar.labelYatak1.Text = oku["1"].ToString();
                }
                else
                {
                    frmYataklar.label1.Text = "1. Yatak: Dolu";
                    frmYataklar.labelYatak1.Text = oku["1"].ToString();
                }
                if (oku["2"].ToString() == "boş")
                {
                    frmYataklar.label2.Text = "2. Yatak: Boş";
                    frmYataklar.labelYatak2.Text = oku["2"].ToString();
                }
                else
                {
                    frmYataklar.label2.Text = "2. Yatak: Dolu";
                    frmYataklar.labelYatak2.Text = oku["2"].ToString();
                }
                if (oku["3"].ToString() == "boş")
                {
                    frmYataklar.label3.Text = "3. Yatak: Boş";
                    frmYataklar.labelYatak3.Text = oku["3"].ToString();
                }
                else
                {
                    frmYataklar.label3.Text = "3. Yatak: Dolu";
                    frmYataklar.labelYatak3.Text = oku["3"].ToString();
                }
                if (oku["4"].ToString() == "boş")
                {
                    frmYataklar.label4.Text = "4. Yatak: Boş";
                    frmYataklar.labelYatak4.Text = oku["4"].ToString();
                }
                else
                {
                    frmYataklar.label4.Text = "4. Yatak: Dolu";
                    frmYataklar.labelYatak4.Text = oku["4"].ToString();
                }
            }
            frmYataklar.label5.Text = "2. Blok, 2. Kat, " + sender.ToString();
            frmYataklar.ShowDialog();
        }

        private void blok2kat3odalar_Click(object sender, EventArgs e)
        {
            FormYataklar frmYataklar = new FormYataklar();
            OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=YurtVeriTabani.mdb;");
            baglan.Open();
            OleDbCommand bulalim = new OleDbCommand("select * from oda_yatak_2 where Oda_No='" + sender.ToString().Split('.').First() + "'", baglan);
            OleDbDataReader oku;
            oku = bulalim.ExecuteReader();
            if (oku.Read())
            {
                frmYataklar.labelBlok.Text = "2"; frmYataklar.labelOda.Text = sender.ToString().Split('.').First();
                if (oku["1"].ToString() == "boş")
                {
                    frmYataklar.label1.Text = "1. Yatak: Boş";
                    frmYataklar.labelYatak1.Text = oku["1"].ToString();
                }
                else
                {
                    frmYataklar.label1.Text = "1. Yatak: Dolu";
                    frmYataklar.labelYatak1.Text = oku["1"].ToString();
                }
                if (oku["2"].ToString() == "boş")
                {
                    frmYataklar.label2.Text = "2. Yatak: Boş";
                    frmYataklar.labelYatak2.Text = oku["2"].ToString();
                }
                else
                {
                    frmYataklar.label2.Text = "2. Yatak: Dolu";
                    frmYataklar.labelYatak2.Text = oku["2"].ToString();
                }
                if (oku["3"].ToString() == "boş")
                {
                    frmYataklar.label3.Text = "3. Yatak: Boş";
                    frmYataklar.labelYatak3.Text = oku["3"].ToString();
                }
                else
                {
                    frmYataklar.label3.Text = "3. Yatak: Dolu";
                    frmYataklar.labelYatak3.Text = oku["3"].ToString();
                }
                if (oku["4"].ToString() == "boş")
                {
                    frmYataklar.label4.Text = "4. Yatak: Boş";
                    frmYataklar.labelYatak4.Text = oku["4"].ToString();
                }
                else
                {
                    frmYataklar.label4.Text = "4. Yatak: Dolu";
                    frmYataklar.labelYatak4.Text = oku["4"].ToString();
                }
            }
            frmYataklar.label5.Text = "2. Blok, 3. Kat, " + sender.ToString();
            frmYataklar.ShowDialog();
        }

        private void blok3kat1odalar_Click(object sender, EventArgs e)
        {
            FormYataklar frmYataklar = new FormYataklar();
            OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=YurtVeriTabani.mdb;");
            baglan.Open();
            OleDbCommand bulalim = new OleDbCommand("select * from oda_yatak_3 where Oda_No='" + sender.ToString().Split('.').First() + "'", baglan);
            OleDbDataReader oku;
            oku = bulalim.ExecuteReader();
            if (oku.Read())
            {
                frmYataklar.labelBlok.Text = "3"; frmYataklar.labelOda.Text = sender.ToString().Split('.').First();
                if (oku["1"].ToString() == "boş")
                {
                    frmYataklar.label1.Text = "1. Yatak: Boş";
                    frmYataklar.labelYatak1.Text = oku["1"].ToString();
                }
                else
                {
                    frmYataklar.label1.Text = "1. Yatak: Dolu";
                    frmYataklar.labelYatak1.Text = oku["1"].ToString();
                }
                if (oku["2"].ToString() == "boş")
                {
                    frmYataklar.label2.Text = "2. Yatak: Boş";
                    frmYataklar.labelYatak2.Text = oku["2"].ToString();
                }
                else
                {
                    frmYataklar.label2.Text = "2. Yatak: Dolu";
                    frmYataklar.labelYatak2.Text = oku["2"].ToString();
                }
                if (oku["3"].ToString() == "boş")
                {
                    frmYataklar.label3.Text = "3. Yatak: Boş";
                    frmYataklar.labelYatak3.Text = oku["3"].ToString();
                }
                else
                {
                    frmYataklar.label3.Text = "3. Yatak: Dolu";
                    frmYataklar.labelYatak3.Text = oku["3"].ToString();
                }
                if (oku["4"].ToString() == "boş")
                {
                    frmYataklar.label4.Text = "4. Yatak: Boş";
                    frmYataklar.labelYatak4.Text = oku["4"].ToString();
                }
                else
                {
                    frmYataklar.label4.Text = "4. Yatak: Dolu";
                    frmYataklar.labelYatak4.Text = oku["4"].ToString();
                }
            }
            frmYataklar.label5.Text = "3. Blok, 1. Kat, " + sender.ToString();
            frmYataklar.ShowDialog();
        }

        private void blok3kat2odalar_Click(object sender, EventArgs e)
        {
            FormYataklar frmYataklar = new FormYataklar();
            OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=YurtVeriTabani.mdb;");
            baglan.Open();
            OleDbCommand bulalim = new OleDbCommand("select * from oda_yatak_3 where Oda_No='" + sender.ToString().Split('.').First() + "'", baglan);
            OleDbDataReader oku;
            oku = bulalim.ExecuteReader();
            if (oku.Read())
            {
                frmYataklar.labelBlok.Text = "3"; frmYataklar.labelOda.Text = sender.ToString().Split('.').First();
                if (oku["1"].ToString() == "boş")
                {
                    frmYataklar.label1.Text = "1. Yatak: Boş";
                    frmYataklar.labelYatak1.Text = oku["1"].ToString();
                }
                else
                {
                    frmYataklar.label1.Text = "1. Yatak: Dolu";
                    frmYataklar.labelYatak1.Text = oku["1"].ToString();
                }
                if (oku["2"].ToString() == "boş")
                {
                    frmYataklar.label2.Text = "2. Yatak: Boş";
                    frmYataklar.labelYatak2.Text = oku["2"].ToString();
                }
                else
                {
                    frmYataklar.label2.Text = "2. Yatak: Dolu";
                    frmYataklar.labelYatak2.Text = oku["2"].ToString();
                }
                if (oku["3"].ToString() == "boş")
                {
                    frmYataklar.label3.Text = "3. Yatak: Boş";
                    frmYataklar.labelYatak3.Text = oku["3"].ToString();
                }
                else
                {
                    frmYataklar.label3.Text = "3. Yatak: Dolu";
                    frmYataklar.labelYatak3.Text = oku["3"].ToString();
                }
                if (oku["4"].ToString() == "boş")
                {
                    frmYataklar.label4.Text = "4. Yatak: Boş";
                    frmYataklar.labelYatak4.Text = oku["4"].ToString();
                }
                else
                {
                    frmYataklar.label4.Text = "4. Yatak: Dolu";
                    frmYataklar.labelYatak4.Text = oku["4"].ToString();
                }
            }
            frmYataklar.label5.Text = "3. Blok, 2. Kat, " + sender.ToString();
            frmYataklar.ShowDialog();
        }

        private void blok3kat3odalar_Click(object sender, EventArgs e)
        {
            FormYataklar frmYataklar = new FormYataklar();
            OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=YurtVeriTabani.mdb;");
            baglan.Open();
            OleDbCommand bulalim = new OleDbCommand("select * from oda_yatak_3 where Oda_No='" + sender.ToString().Split('.').First() + "'", baglan);
            OleDbDataReader oku;
            oku = bulalim.ExecuteReader();
            if (oku.Read())
            {
                frmYataklar.labelBlok.Text = "3"; frmYataklar.labelOda.Text = sender.ToString().Split('.').First();
                if (oku["1"].ToString() == "boş")
                {
                    frmYataklar.label1.Text = "1. Yatak: Boş";
                    frmYataklar.labelYatak1.Text = oku["1"].ToString();
                }
                else
                {
                    frmYataklar.label1.Text = "1. Yatak: Dolu";
                    frmYataklar.labelYatak1.Text = oku["1"].ToString();
                }
                if (oku["2"].ToString() == "boş")
                {
                    frmYataklar.label2.Text = "2. Yatak: Boş";
                    frmYataklar.labelYatak2.Text = oku["2"].ToString();
                }
                else
                {
                    frmYataklar.label2.Text = "2. Yatak: Dolu";
                    frmYataklar.labelYatak2.Text = oku["2"].ToString();
                }
                if (oku["3"].ToString() == "boş")
                {
                    frmYataklar.label3.Text = "3. Yatak: Boş";
                    frmYataklar.labelYatak3.Text = oku["3"].ToString();
                }
                else
                {
                    frmYataklar.label3.Text = "3. Yatak: Dolu";
                    frmYataklar.labelYatak3.Text = oku["3"].ToString();
                }
                if (oku["4"].ToString() == "boş")
                {
                    frmYataklar.label4.Text = "4. Yatak: Boş";
                    frmYataklar.labelYatak4.Text = oku["4"].ToString();
                }
                else
                {
                    frmYataklar.label4.Text = "4. Yatak: Dolu";
                    frmYataklar.labelYatak4.Text = oku["4"].ToString();
                }
            }
            frmYataklar.label5.Text = "3. Blok, 3. Kat, " + sender.ToString();
            frmYataklar.ShowDialog();
        }

        private void blok4kat1odalar_Click(object sender, EventArgs e)
        {
            FormYataklar frmYataklar = new FormYataklar();
            OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=YurtVeriTabani.mdb;");
            baglan.Open();
            OleDbCommand bulalim = new OleDbCommand("select * from oda_yatak_4 where Oda_No='" + sender.ToString().Split('.').First() + "'", baglan);
            OleDbDataReader oku;
            oku = bulalim.ExecuteReader();
            if (oku.Read())
            {
                frmYataklar.labelBlok.Text = "4"; frmYataklar.labelOda.Text = sender.ToString().Split('.').First();
                if (oku["1"].ToString() == "boş")
                {
                    frmYataklar.label1.Text = "1. Yatak: Boş";
                    frmYataklar.labelYatak1.Text = oku["1"].ToString();
                }
                else
                {
                    frmYataklar.label1.Text = "1. Yatak: Dolu";
                    frmYataklar.labelYatak1.Text = oku["1"].ToString();
                }
                if (oku["2"].ToString() == "boş")
                {
                    frmYataklar.label2.Text = "2. Yatak: Boş";
                    frmYataklar.labelYatak2.Text = oku["2"].ToString();
                }
                else
                {
                    frmYataklar.label2.Text = "2. Yatak: Dolu";
                    frmYataklar.labelYatak2.Text = oku["2"].ToString();
                }
                if (oku["3"].ToString() == "boş")
                {
                    frmYataklar.label3.Text = "3. Yatak: Boş";
                    frmYataklar.labelYatak3.Text = oku["3"].ToString();
                }
                else
                {
                    frmYataklar.label3.Text = "3. Yatak: Dolu";
                    frmYataklar.labelYatak3.Text = oku["3"].ToString();
                }
                if (oku["4"].ToString() == "boş")
                {
                    frmYataklar.label4.Text = "4. Yatak: Boş";
                    frmYataklar.labelYatak4.Text = oku["4"].ToString();
                }
                else
                {
                    frmYataklar.label4.Text = "4. Yatak: Dolu";
                    frmYataklar.labelYatak4.Text = oku["4"].ToString();
                }
            }
            frmYataklar.label5.Text = "4. Blok, 1. Kat, " + sender.ToString();
            frmYataklar.ShowDialog();
        }

        private void blok4kat2odalar_Click(object sender, EventArgs e)
        {
            FormYataklar frmYataklar = new FormYataklar();
            OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=YurtVeriTabani.mdb;");
            baglan.Open();
            OleDbCommand bulalim = new OleDbCommand("select * from oda_yatak_4 where Oda_No='" + sender.ToString().Split('.').First() + "'", baglan);
            OleDbDataReader oku;
            oku = bulalim.ExecuteReader();
            if (oku.Read())
            {
                frmYataklar.labelBlok.Text = "4"; frmYataklar.labelOda.Text = sender.ToString().Split('.').First();
                if (oku["1"].ToString() == "boş")
                {
                    frmYataklar.label1.Text = "1. Yatak: Boş";
                    frmYataklar.labelYatak1.Text = oku["1"].ToString();
                }
                else
                {
                    frmYataklar.label1.Text = "1. Yatak: Dolu";
                    frmYataklar.labelYatak1.Text = oku["1"].ToString();
                }
                if (oku["2"].ToString() == "boş")
                {
                    frmYataklar.label2.Text = "2. Yatak: Boş";
                    frmYataklar.labelYatak2.Text = oku["2"].ToString();
                }
                else
                {
                    frmYataklar.label2.Text = "2. Yatak: Dolu";
                    frmYataklar.labelYatak2.Text = oku["2"].ToString();
                }
                if (oku["3"].ToString() == "boş")
                {
                    frmYataklar.label3.Text = "3. Yatak: Boş";
                    frmYataklar.labelYatak3.Text = oku["3"].ToString();
                }
                else
                {
                    frmYataklar.label3.Text = "3. Yatak: Dolu";
                    frmYataklar.labelYatak3.Text = oku["3"].ToString();
                }
                if (oku["4"].ToString() == "boş")
                {
                    frmYataklar.label4.Text = "4. Yatak: Boş";
                    frmYataklar.labelYatak4.Text = oku["4"].ToString();
                }
                else
                {
                    frmYataklar.label4.Text = "4. Yatak: Dolu";
                    frmYataklar.labelYatak4.Text = oku["4"].ToString();
                }
            }
            frmYataklar.label5.Text = "4. Blok, 2. Kat, " + sender.ToString();
            frmYataklar.ShowDialog();
        }

        private void blok4kat3odalar_Click(object sender, EventArgs e)
        {
            FormYataklar frmYataklar = new FormYataklar();
            OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=YurtVeriTabani.mdb;");
            baglan.Open();
            OleDbCommand bulalim = new OleDbCommand("select * from oda_yatak_4 where Oda_No='" + sender.ToString().Split('.').First() + "'", baglan);
            OleDbDataReader oku;
            oku = bulalim.ExecuteReader();
            if (oku.Read())
            {
                frmYataklar.labelBlok.Text = "4"; frmYataklar.labelOda.Text = sender.ToString().Split('.').First();
                if (oku["1"].ToString() == "boş")
                {
                    frmYataklar.label1.Text = "1. Yatak: Boş";
                    frmYataklar.labelYatak1.Text = oku["1"].ToString();
                }
                else
                {
                    frmYataklar.label1.Text = "1. Yatak: Dolu";
                    frmYataklar.labelYatak1.Text = oku["1"].ToString();
                }
                if (oku["2"].ToString() == "boş")
                {
                    frmYataklar.label2.Text = "2. Yatak: Boş";
                    frmYataklar.labelYatak2.Text = oku["2"].ToString();
                }
                else
                {
                    frmYataklar.label2.Text = "2. Yatak: Dolu";
                    frmYataklar.labelYatak2.Text = oku["2"].ToString();
                }
                if (oku["3"].ToString() == "boş")
                {
                    frmYataklar.label3.Text = "3. Yatak: Boş";
                    frmYataklar.labelYatak3.Text = oku["3"].ToString();
                }
                else
                {
                    frmYataklar.label3.Text = "3. Yatak: Dolu";
                    frmYataklar.labelYatak3.Text = oku["3"].ToString();
                }
                if (oku["4"].ToString() == "boş")
                {
                    frmYataklar.label4.Text = "4. Yatak: Boş";
                    frmYataklar.labelYatak4.Text = oku["4"].ToString();
                }
                else
                {
                    frmYataklar.label4.Text = "4. Yatak: Dolu";
                    frmYataklar.labelYatak4.Text = oku["4"].ToString();
                }
            }
            frmYataklar.label5.Text = "4. Blok, 3. Kat, " + sender.ToString();
            frmYataklar.ShowDialog();
        }

        private void blok5kat1odalar_Click(object sender, EventArgs e)
        {
            FormYataklar frmYataklar = new FormYataklar();
            OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=YurtVeriTabani.mdb;");
            baglan.Open();
            OleDbCommand bulalim = new OleDbCommand("select * from oda_yatak_5 where Oda_No='" + sender.ToString().Split('.').First() + "'", baglan);
            OleDbDataReader oku;
            oku = bulalim.ExecuteReader();
            if (oku.Read())
            {
                frmYataklar.labelBlok.Text = "5"; frmYataklar.labelOda.Text = sender.ToString().Split('.').First();
                if (oku["1"].ToString() == "boş")
                {
                    frmYataklar.label1.Text = "1. Yatak: Boş";
                    frmYataklar.labelYatak1.Text = oku["1"].ToString();
                }
                else
                {
                    frmYataklar.label1.Text = "1. Yatak: Dolu";
                    frmYataklar.labelYatak1.Text = oku["1"].ToString();
                }
                if (oku["2"].ToString() == "boş")
                {
                    frmYataklar.label2.Text = "2. Yatak: Boş";
                    frmYataklar.labelYatak2.Text = oku["2"].ToString();
                }
                else
                {
                    frmYataklar.label2.Text = "2. Yatak: Dolu";
                    frmYataklar.labelYatak2.Text = oku["2"].ToString();
                }
                if (oku["3"].ToString() == "boş")
                {
                    frmYataklar.label3.Text = "3. Yatak: Boş";
                    frmYataklar.labelYatak3.Text = oku["3"].ToString();
                }
                else
                {
                    frmYataklar.label3.Text = "3. Yatak: Dolu";
                    frmYataklar.labelYatak3.Text = oku["3"].ToString();
                }
                if (oku["4"].ToString() == "boş")
                {
                    frmYataklar.label4.Text = "4. Yatak: Boş";
                    frmYataklar.labelYatak4.Text = oku["4"].ToString();
                }
                else
                {
                    frmYataklar.label4.Text = "4. Yatak: Dolu";
                    frmYataklar.labelYatak4.Text = oku["4"].ToString();
                }
            }
            frmYataklar.label5.Text = "5. Blok, 1. Kat, " + sender.ToString();
            frmYataklar.ShowDialog();
        }

        private void blok5kat2odalar_Click(object sender, EventArgs e)
        {
            FormYataklar frmYataklar = new FormYataklar();
            OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=YurtVeriTabani.mdb;");
            baglan.Open();
            OleDbCommand bulalim = new OleDbCommand("select * from oda_yatak_5 where Oda_No='" + sender.ToString().Split('.').First() + "'", baglan);
            OleDbDataReader oku;
            oku = bulalim.ExecuteReader();
            if (oku.Read())
            {
                frmYataklar.labelBlok.Text = "5"; frmYataklar.labelOda.Text = sender.ToString().Split('.').First();
                if (oku["1"].ToString() == "boş")
                {
                    frmYataklar.label1.Text = "1. Yatak: Boş";
                    frmYataklar.labelYatak1.Text = oku["1"].ToString();
                }
                else
                {
                    frmYataklar.label1.Text = "1. Yatak: Dolu";
                    frmYataklar.labelYatak1.Text = oku["1"].ToString();
                }
                if (oku["2"].ToString() == "boş")
                {
                    frmYataklar.label2.Text = "2. Yatak: Boş";
                    frmYataklar.labelYatak2.Text = oku["2"].ToString();
                }
                else
                {
                    frmYataklar.label2.Text = "2. Yatak: Dolu";
                    frmYataklar.labelYatak2.Text = oku["2"].ToString();
                }
                if (oku["3"].ToString() == "boş")
                {
                    frmYataklar.label3.Text = "3. Yatak: Boş";
                    frmYataklar.labelYatak3.Text = oku["3"].ToString();
                }
                else
                {
                    frmYataklar.label3.Text = "3. Yatak: Dolu";
                    frmYataklar.labelYatak3.Text = oku["3"].ToString();
                }
                if (oku["4"].ToString() == "boş")
                {
                    frmYataklar.label4.Text = "4. Yatak: Boş";
                    frmYataklar.labelYatak4.Text = oku["4"].ToString();
                }
                else
                {
                    frmYataklar.label4.Text = "4. Yatak: Dolu";
                    frmYataklar.labelYatak4.Text = oku["4"].ToString();
                }
            }
            frmYataklar.label5.Text = "5. Blok, 2. Kat, " + sender.ToString();
            frmYataklar.ShowDialog();
        }

        private void blok5kat3odalar_Click(object sender, EventArgs e)
        {
            FormYataklar frmYataklar = new FormYataklar();
            OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=YurtVeriTabani.mdb;");
            baglan.Open();
            OleDbCommand bulalim = new OleDbCommand("select * from oda_yatak_5 where Oda_No='" + sender.ToString().Split('.').First() + "'", baglan);
            OleDbDataReader oku;
            oku = bulalim.ExecuteReader();
            if (oku.Read())
            {
                frmYataklar.labelBlok.Text = "5"; frmYataklar.labelOda.Text = sender.ToString().Split('.').First();
                if (oku["1"].ToString() == "boş")
                {
                    frmYataklar.label1.Text = "1. Yatak: Boş";
                    frmYataklar.labelYatak1.Text = oku["1"].ToString();
                }
                else
                {
                    frmYataklar.label1.Text = "1. Yatak: Dolu";
                    frmYataklar.labelYatak1.Text = oku["1"].ToString();
                }
                if (oku["2"].ToString() == "boş")
                {
                    frmYataklar.label2.Text = "2. Yatak: Boş";
                    frmYataklar.labelYatak2.Text = oku["2"].ToString();
                }
                else
                {
                    frmYataklar.label2.Text = "2. Yatak: Dolu";
                    frmYataklar.labelYatak2.Text = oku["2"].ToString();
                }
                if (oku["3"].ToString() == "boş")
                {
                    frmYataklar.label3.Text = "3. Yatak: Boş";
                    frmYataklar.labelYatak3.Text = oku["3"].ToString();
                }
                else
                {
                    frmYataklar.label3.Text = "3. Yatak: Dolu";
                    frmYataklar.labelYatak3.Text = oku["3"].ToString();
                }
                if (oku["4"].ToString() == "boş")
                {
                    frmYataklar.label4.Text = "4. Yatak: Boş";
                    frmYataklar.labelYatak4.Text = oku["4"].ToString();
                }
                else
                {
                    frmYataklar.label4.Text = "4. Yatak: Dolu";
                    frmYataklar.labelYatak4.Text = oku["4"].ToString();
                }
            }
            frmYataklar.label5.Text = "5. Blok, 3. Kat, " + sender.ToString();
            frmYataklar.ShowDialog();
        }
    }
}