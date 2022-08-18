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
    public partial class anaform : Form
    {
        public anaform()
        {
            InitializeComponent();
        }
        SqlConnection baglanti=new SqlConnection("Data Source=DESKTOP-QBFPK40\\SQLEXPRESS;Initial Catalog=PersonelDB;Integrated Security=True");
        //Data Source=DESKTOP-QBFPK40\SQLEXPRESS;Initial Catalog=PersonelDB;Integrated Security=True

        void temizle()
        {
            txtid.Text = "";
            txtad.Text = "";
            txtsoyad.Text = "";
            txtmeslek.Text = "";
            mtxtmaas.Text = "";
            cmbsehir.Text = "";
            rdbbekar.Checked = false;
            rdbevli.Checked = false;
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            this.personel_tblTableAdapter.Fill(this.personelDBDataSet.personel_tbl);
        }

      

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("insert into personel_tbl (Perad,Persoyad,Persehir,Permaas,Permeslek,Perdurum) values (@p1,@p2,@p3,@p4,@p5,@p6)",baglanti);
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbsehir.Text);
            komut.Parameters.AddWithValue("@p4", mtxtmaas.Text);
            komut.Parameters.AddWithValue("@p5", txtmeslek.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);

            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Personel eklendi.");
        }

        private void rdbevli_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbevli.Checked == true)
            {
                label8.Text = "True";
            }
        }

        private void rdbbekar_CheckedChanged(object sender, EventArgs e)
        {
            if(rdbbekar.Checked == true)
            { 
                label8.Text = "False"; 
            }
            
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtsoyad.Text= dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbsehir.Text= dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mtxtmaas.Text= dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtmeslek.Text= dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if(label8.Text == "True")
            {
                rdbevli.Checked = true;
                
            }
            else
            {
                rdbbekar.Checked = true;
               
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kayitsil = new SqlCommand("Delete from personel_tbl where perid=@k1",baglanti);
            kayitsil.Parameters.AddWithValue("@k1",txtid.Text);
            kayitsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Silindi.");
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand guncelle = new SqlCommand("update personel_tbl set perad=@a1,persoyad=@a2,persehir=@a3,permaas=@a4,permeslek=@a5,perdurum=@a6 where perid=@a7",baglanti);
            guncelle.Parameters.AddWithValue("@a1",txtad.Text);
            guncelle.Parameters.AddWithValue("@a2", txtsoyad.Text);
            guncelle.Parameters.AddWithValue("@a3", cmbsehir.Text);
            guncelle.Parameters.AddWithValue("@a4", mtxtmaas.Text);
            guncelle.Parameters.AddWithValue("@a5", txtmeslek.Text);
            guncelle.Parameters.AddWithValue("@a6", label8.Text);
            guncelle.Parameters.AddWithValue("@a7", txtid.Text);
            guncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Güncellendi.");

        }

        private void btnistatistik_Click(object sender, EventArgs e)
        {
            frmistatistik fr=new frmistatistik();
            fr.Show();
        }

        private void btngrafikler_Click(object sender, EventArgs e)
        {
            frmgrafikler gr = new frmgrafikler();
            gr.Show();

        }
    }
}
