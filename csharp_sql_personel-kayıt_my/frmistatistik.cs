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
    public partial class frmistatistik : Form
    {
        public frmistatistik()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-QBFPK40\\SQLEXPRESS;Initial Catalog=PersonelDB;Integrated Security=True");

        private void frmistatistik_Load(object sender, EventArgs e)
        {
            //TOPLAM PERSONEL SAYISI

            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select count(*) from personel_tbl",baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lbltopper.Text = dr1[0].ToString();
            }
            baglanti.Close();

            //EVLİ PERSONEL SAYISI

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select count(*) from personel_tbl where perdurum=1", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblevliper.Text = dr2[0].ToString();
            }
            baglanti.Close();

            //BEKAR PERSONEL SAYISI

            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select count(*) from personel_tbl where perdurum=0", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
               lblbekarper.Text = dr3[0].ToString();
            }
            baglanti.Close();

            //ŞEHİR SAYISI

            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("select count(distinct(persehir)) from personel_tbl", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lblsehir.Text = dr4[0].ToString();
            }
            baglanti.Close();

            //TOPLAM MAAŞ

            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("select sum(permaas) from personel_tbl", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lbltopmaas.Text = dr5[0].ToString();
            }
            baglanti.Close();

            //ORTALAMA MAAŞ

            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("select avg(permaas) from personel_tbl", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                lblortmaas.Text = dr6[0].ToString();
            }
            baglanti.Close();
        }
    }
}
