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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("provider=Microsoft.jet.oledb.4.0; Data Source=YurtVeriTabani.mdb;");
            baglanti.Open();
            OleDbCommand veri1 = new OleDbCommand();
            OleDbCommand veri2 = new OleDbCommand();
            veri1.Connection = baglanti;
            veri2.Connection = baglanti;
            veri1.CommandText = "select * from yonetici_girisi";
            veri2.CommandText = "select * from personel_girisi";
            OleDbDataReader oku1 = veri1.ExecuteReader();
            OleDbDataReader oku2 = veri2.ExecuteReader();
            if (comboBox1.Text == "Yönetici Girişi")
            {
                if (oku1.Read())
                {
                    if (textBox1.Text == oku1["kullanici_ad"].ToString() && textBox2.Text == oku1["kullanici_sifre"].ToString())
                    {
                        Form2.ActiveForm.Hide();
                        Form3 frm3 = new Form3();
                        frm3.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Hatalı giriş");
                        textBox1.Text = "";
                        textBox2.Text = "";
                    }
                }
            }
            else if (comboBox1.Text == "Personel Girişi")
            {
                bool bl = false;
                while (oku2.Read())
                {
                    if (textBox1.Text == oku2["kullanici_ad"].ToString() && textBox2.Text == oku2["kullanici_sifre"].ToString())
                    {
                        Form2.ActiveForm.Hide();
                        Form4 frm4 = new Form4();
                        frm4.label1.Text = oku2["kullanici_ad"].ToString();
                        frm4.label2.Text = oku2["kullanici_sifre"].ToString();
                        label1.Visible = true;
                        label2.Visible = true;
                        frm4.ShowDialog();
                        bl = true;
                    }

                }
                if (!bl)
                {
                    MessageBox.Show("Hatalı giriş");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
            }
            baglanti.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
