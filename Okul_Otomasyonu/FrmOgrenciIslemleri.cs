using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Okul_Otomasyonu
{
    public partial class FrmOgrenciIslemleri : Form
    {
        public FrmOgrenciIslemleri()
        {
            InitializeComponent();
        }
        public string c = "";

        DataSet1TableAdapters.TBL_OGRENCILERTableAdapter ogrTbl = new DataSet1TableAdapters.TBL_OGRENCILERTableAdapter();
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-U1MNBOC;Initial Catalog=OkulDB;Integrated Security=True");


        private void FrmOgrenciIslemleri_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ogrTbl.OgrenciListesi();


            baglanti.Open();
            SqlCommand combaKulup = new SqlCommand("SELECT * FROM TBL_KULUPLER", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(combaKulup);
            DataTable dt = new DataTable();
            da.Fill(dt);

            comboBox1.DisplayMember = "KULUPAD";
            comboBox1.ValueMember = "KULUPID";
            comboBox1.DataSource = dt;

            baglanti.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ogrTbl.OgrenciEkle(textBox2.Text, textBox4.Text, byte.Parse(comboBox1.SelectedValue.ToString()), c);
            MessageBox.Show("Ekleme Başarılı");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ogrTbl.OgrenciListesi();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ogrTbl.OgrenciSil(int.Parse(textBox1.Text));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ogrTbl.OgrenciGuncelle(textBox2.Text, textBox4.Text, byte.Parse(comboBox1.SelectedValue.ToString()), c, int.Parse(textBox1.Text));
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                c = "kız";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                c = "erkek";
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ogrTbl.OgrenciGetir(textBox3.Text);
        }
    }
}
