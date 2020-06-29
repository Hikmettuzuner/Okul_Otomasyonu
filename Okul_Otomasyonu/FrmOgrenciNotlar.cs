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
    public partial class FrmOgrenciNotlar : Form
    {
        public FrmOgrenciNotlar()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-U1MNBOC;Initial Catalog=OkulDB;Integrated Security=True");
        public string numara;

        private void FrmOgrenciNotlar_Load(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("SELECT DERSAD,SINAV1,SINAV2,SINAV3,PROJE,ORTALAMA,DURUM FROM TBL_NOTLAR INNER JOIN TBL_DERSLER ON TBL_NOTLAR.DERSID =TBL_DERSLER.DERSID WHERE OGRID=@P1", connection);
            komut.Parameters.AddWithValue("@p1", numara);
            //this.Text = numara.ToString();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
                
                
        }
    }
}
