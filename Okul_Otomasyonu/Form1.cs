using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Okul_Otomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "")
            {
                MessageBox.Show("lütfen Değer Giriniz..");
            }
            else
            {
                FrmOgrenciNotlar fr = new FrmOgrenciNotlar();
                fr.numara = textBox1.Text;
                fr.Show();
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmOgretmen frr = new FrmOgretmen();
            frr.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
