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

namespace PersonelTakipUygulamasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=MAT225;Initial Catalog=Personel;Integrated Security=True");

        void temizle()
        {
            TxtPersonelID.Text = "";
            TxtAd.Text = "";
            TxtSoyad.Text = "";
            TxtMeslek.Text = "";
            MskMaas.Text = "";
            CmbSehir.Text = "";
            RdbBekar.Checked = false;
            RdbEvli.Checked = false;
            TxtAd.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.personelTableAdapter.Fill(this.personelDataSet1.Personel);
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            this.personelTableAdapter.Fill(this.personelDataSet1.Personel);
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutekle = new SqlCommand("Insert into Personel (PersonelAd,PersonelSoyad,PersonelSehir,PersonelMaas,PersonelMeslek,PersonelDurum) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komutekle.Parameters.AddWithValue("@p1", TxtAd.Text);
            komutekle.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komutekle.Parameters.AddWithValue("@p3", CmbSehir.Text);
            komutekle.Parameters.AddWithValue("@p4", MskMaas.Text);
            komutekle.Parameters.AddWithValue("@p5", TxtMeslek.Text);
            komutekle.Parameters.AddWithValue("@p6", label8.Text);
            komutekle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel listeye eklenmiştir.");
        }

        private void RdbEvli_CheckedChanged(object sender, EventArgs e)
        {
            if (RdbEvli.Checked == true)
            {
                label8.Text = "True";
            }
        }

        private void RdbBekar_CheckedChanged(object sender, EventArgs e)
        {
            if(RdbBekar.Checked == true)
            {
                label8.Text = "False";
            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }


        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text == "True")
            {
                RdbEvli.Checked = true;
            }
            if (label8.Text == "False")
            {
                RdbBekar.Checked= true;
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete from Personel where Personelid=@p1", baglanti);
            komutsil.Parameters.AddWithValue("@p1", TxtPersonelID.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personelin kaydı silinmiştir.");
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            TxtPersonelID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            CmbSehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            MskMaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            TxtMeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("Update personel set personelad=@p1,personelsoyad=@p2,personelsehir=@p3,personelmaas=@p4,PersonelDurum=@p5,personelmeslek=@p6 where Personelid=@p7", baglanti);
            komutguncelle.Parameters.AddWithValue("@p1", TxtAd.Text);
            komutguncelle.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komutguncelle.Parameters.AddWithValue("@p3", CmbSehir.Text);
            komutguncelle.Parameters.AddWithValue("@p4", MskMaas.Text);
            komutguncelle.Parameters.AddWithValue("@p5", label8.Text);
            komutguncelle.Parameters.AddWithValue("@p6", TxtMeslek.Text);
            komutguncelle.Parameters.AddWithValue("@p7", TxtPersonelID.Text);
            komutguncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel başarıyla güncellenmiştir.");
        }

        private void BtnIstatistik_Click(object sender, EventArgs e)
        {
            FormIstatistik fr = new FormIstatistik();
            fr.Show();
        }

        private void BtnGrafikler_Click(object sender, EventArgs e)
        {
            FormGrafik fr = new FormGrafik();
            fr.Show();
        }
    }
}
