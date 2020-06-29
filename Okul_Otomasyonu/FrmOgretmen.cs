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
    public partial class FrmOgretmen : Form
    {
        public FrmOgretmen()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmKlüpIslemleri frmKlüpIslemleri = new FrmKlüpIslemleri();
            frmKlüpIslemleri.Show();
        }

        private void FrmOgretmen_Load(object sender, EventArgs e)
        {




        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmDersIslemleri frmDersIslemleri = new FrmDersIslemleri();
            frmDersIslemleri.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            FrmOgrenciIslemleri frmOgrenciIslemleri = new FrmOgrenciIslemleri();
            frmOgrenciIslemleri.Show();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            FrmSinavNotlari SinavNotlari = new FrmSinavNotlari();
            SinavNotlari.Show();
        }
    }
}
