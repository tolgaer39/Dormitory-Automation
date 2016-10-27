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
    public partial class FormOgrenciAra : Form
    {
        public FormOgrenciAra()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ogrenci bulunan = Ogrenci.TCyeGoreOgrenciGetir(textBox1.Text);
            if (bulunan != null)
            {
                FormOgrBilgileri Bilgi = new FormOgrBilgileri();
                Bilgi.OgrenciBagla(bulunan);
                Bilgi.blokxxx();
                Bilgi.ShowDialog();
            }
            else
            {
                MessageBox.Show("Numarayı doğru girdiğinizden emin olun!\nUygun kayıt bulunamadı...");
                textBox1.Text = "";
            }
        }
    }
}
