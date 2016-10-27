using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace projedeneme1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.ActiveForm.Hide();
            Form2 frm2 = new Form2();
            frm2.ShowDialog();
        }
        string[] str = { "Ş", "  e", "    n", "        Y", "          u", "            r", "             t", "Şen Yurt", " ", "Şen Yurt", " ", "Şen Yurt", " " };
        int i = 0;
        string lbl = "H\no\nş\ng\ne\nl\nd\ni\nn\ni\nz\n \n \n \n \n \n";
        private void timer1_Tick(object sender, EventArgs e)
        {
            i %= 13;
            label1.Text = Convert.ToString(str[i]);
            if (label1.Text == "\0")
                label1.Text = "";
            i++;

            lbl = lbl.Substring(2) + lbl.Substring(0, 2);
            label4.Text = lbl;
            label5.Text = lbl;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SoundPlayer sesAcilis = new SoundPlayer();
            string konumAcilis = "(Ireland)-Instrumental Ballad Lands.wav";
            sesAcilis.SoundLocation = konumAcilis;
            sesAcilis.PlayLooping();
            timer1.Enabled = true;
            timer1.Interval = 200;
            notifyIcon1.ShowBalloonTip(3000, "Hoşgeldiniz", "Şen Yurt'un şen personeli, saygılar...", ToolTipIcon.Info);
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            SoundPlayer sesAcilis = new SoundPlayer();
            if (radioButton2.Checked)
            {
                string konumAcilis = "(Ireland)-Instrumental Ballad Lands.wav";
                sesAcilis.SoundLocation = konumAcilis;
            sesAcilis.PlayLooping();
            }
            else if (radioButton1.Checked)
            {
                string konumAcilis = "Kiroro - Mirai.wav";
                sesAcilis.SoundLocation = konumAcilis;
                sesAcilis.PlayLooping();
            }
            else if (radioButton3.Checked)
            {
                string konumAcilis = "alexander rybak - fairytale - melodi grand prix 2009(2).wav";
                sesAcilis.SoundLocation = konumAcilis;
                sesAcilis.PlayLooping();
            }
            else if (radioButton4.Checked)
            {
                sesAcilis.Stop();
            }
        }
    }
}