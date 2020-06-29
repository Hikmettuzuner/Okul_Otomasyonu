using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Okul_Otomasyonu
{
    public partial class FrmSinavNotlari : Form
    {
        public FrmSinavNotlari()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-U1MNBOC;Initial Catalog=OkulDB;Integrated Security=True");

        DataSet1TableAdapters.TBL_NOTLARTableAdapter daNotlar = new DataSet1TableAdapters.TBL_NOTLARTableAdapter();

        public int sinav1, sinav2, sinav3, proje;
        public double ortalama;
        public string durum;
        public int notid;
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = daNotlar.NotGetir(int.Parse(p1.Text));
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            daNotlar.NotGuncelle(byte.Parse(comboBox1.SelectedValue.ToString()),int.Parse(p1.Text), byte.Parse(textBox2.Text), byte.Parse(textBox3.Text), byte.Parse(textBox4.Text), byte.Parse(textBox5.Text), decimal.Parse(textBox6.Text),bool.Parse(textBox7.Text),notid);

        }

        private void FrmSinavNotlari_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand combaKulup = new SqlCommand("SELECT * FROM TBL_DERSLER", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(combaKulup);
            DataTable dt = new DataTable();
            da.Fill(dt);

            comboBox1.DisplayMember = "DERSAD";
            comboBox1.ValueMember = "DERSID";
            comboBox1.DataSource = dt;

            baglanti.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            notid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            //textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            sinav1 = Convert.ToInt32(textBox2.Text);
            sinav2 = Convert.ToInt32(textBox3.Text);
            sinav3 = Convert.ToInt32(textBox4.Text);
            proje = Convert.ToInt32(textBox5.Text);
            ortalama = (sinav1 + sinav2 + sinav3 + proje) / 4;
            textBox6.Text = ortalama.ToString();
            if (ortalama >= 50)
            {
                textBox7.Text = "True";
            }
            else
            {
                textBox7.Text = "False";

            }


        }
    }
}
