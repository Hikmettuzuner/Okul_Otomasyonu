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
    public partial class FrmDersIslemleri : Form
    {
        public FrmDersIslemleri()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.TBL_DERSLERTableAdapter ds = new DataSet1TableAdapters.TBL_DERSLERTableAdapter();

        private void FrmDersIslemleri_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ds.DersEkle(textBox2.Text);
            MessageBox.Show("Ekleme Başarılı");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ds.DersSil(byte.Parse(textBox1.Text));
            MessageBox.Show("Silme BAŞARILI");
            ds.DersListesi();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ds.DersGuncelle(textBox1.Text, byte.Parse(textBox2.Text));
            MessageBox.Show("Güncelleme BAŞARILI");
            ds.DersListesi();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersListesi();
        }
    }
}
