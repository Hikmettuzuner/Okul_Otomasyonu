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
    public partial class FrmKlüpIslemleri : Form
    {
        public FrmKlüpIslemleri()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-U1MNBOC;Initial Catalog=OkulDB;Integrated Security=True");

        public void listele()
        {

            SqlCommand cmd = new SqlCommand("SELECT * FROM TBL_KULUPLER", connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void FrmKlüpIslemleri_Load(object sender, EventArgs e)
        {
            listele();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            listele();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand komutGuncelle = new SqlCommand("UPDATE TBL_KULUPLER SET KULUPAD=@P2 WHERE KULUPID=@P1 ", connection);
            komutGuncelle.Parameters.AddWithValue("@P1", textBox1.Text);
            komutGuncelle.Parameters.AddWithValue("@P2", textBox2.Text);
            komutGuncelle.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("SİLME BAŞARILI");

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand komutSil = new SqlCommand("DELETE FROM TBL_KULUPLER WHERE KULUPID=@P1", connection);
            komutSil.Parameters.AddWithValue("@p1", textBox1.Text);
            komutSil.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("SİLME BAŞARILI");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand komutekle = new SqlCommand("INSERT INTO TBL_KULUPLER(KULUPAD) VALUES (@p1)", connection);
            komutekle.Parameters.AddWithValue("@p1", textBox2.Text);
            komutekle.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("EKLEME BAŞARILI");
            listele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.LightBlue;

        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.White;

        }
    }
}