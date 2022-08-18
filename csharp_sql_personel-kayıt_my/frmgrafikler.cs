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

namespace csharp_sql_personel_kayıt_my
{
    public partial class frmgrafikler : Form
    {
        public frmgrafikler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-QBFPK40\\SQLEXPRESS;Initial Catalog=PersonelDB;Integrated Security=True");

        private void grafikler_Load(object sender, EventArgs e)
        {
            //GRAFİK 1
            baglanti.Open();
            SqlCommand komutg1=new SqlCommand("select persehir,count(*) from personel_tbl group by persehir",baglanti);
            SqlDataReader dr1=komutg1.ExecuteReader();
            while(dr1.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(dr1[0], dr1[1]);
            }
            baglanti.Close();

            //GRAFİK2
            baglanti.Open();
            SqlCommand komutg2 = new SqlCommand("select permeslek,avg(permaas) from personel_tbl group by permeslek", baglanti);
            SqlDataReader dr2 = komutg2.ExecuteReader();
            while (dr2.Read())
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(dr2[0], dr2[1]);
            }
            baglanti.Close();
        }
    }
}
