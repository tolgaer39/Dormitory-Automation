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
    public partial class FormPersonelSifreDegisim : Form
    {
        public FormPersonelSifreDegisim()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Kullanıcı adları bölümünden en az biri boş bırakıldı!");
            }
            else if (textBox3.Text != textBox4.Text)
            {
                MessageBox.Show("Şifreler uyuşmuyor lütfen tekrar girin");
            }
            else if (textBox1.Text != "" && textBox3.Text == textBox4.Text && textBox2.Text != "" && textBox3.Text != "")
            {
                OleDbConnection bagla = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=YurtVeriTabani.mdb");
                OleDbCommand veri = new OleDbCommand("SELECT kullanici_ad FROM personel_girisi where (kullanici_ad='" + textBox1.Text + "' ) ", bagla);
                OleDbDataReader oku;
                bagla.Open();
                string srg1;
                oku = veri.ExecuteReader();
                if (oku.Read())
                {

                    srg1 = oku["kullanici_ad"].ToString();

                    if (textBox1.Text == srg1.ToString())
                    {

                        OleDbCommand yenile = new OleDbCommand("UPDATE personel_girisi SET kullanici_ad='" + textBox2.Text + "',kullanici_sifre='" + textBox3.Text + "' where kullanici_ad='" + textBox1.Text + "'", bagla);
                        yenile.ExecuteNonQuery();
                        bagla.Close();
                        MessageBox.Show("Hesap Yenilendi");
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show(textBox1.Text + " kullanıcısı sistemde kayıtlı değildir");

                }
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
