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
    public partial class FormIstatistik : Form
    {

        SqlConnection baglanti = new SqlConnection("Data Source=MAT225;Initial Catalog=Personel;Integrated Security=True");

        public FormIstatistik()
        {
            InitializeComponent();
        }

        private void FormIstatistik_Load(object sender, EventArgs e)
        {
            //Toplam personel sayısı
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select Count(*) from personel", baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                LblToplamPersonel.Text = dr1[0].ToString();
            }
            baglanti.Close();

            //Evli personel sayısı
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select Count(*) from personel where personeldurum=1",baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                LblEvli.Text = dr2[0].ToString();
            }
            baglanti.Close();

            //Bekar Personel sayisi
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select count(*) from personel where personeldurum=0", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                LblBekar.Text = dr3[0].ToString();
            }
            baglanti.Close();

            //şehir sayısı
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("select count(distinct(personelsehir)) from personel", baglanti);
            SqlDataReader dr4=komut4.ExecuteReader();
            while (dr4.Read())
            {
                LblSehir.Text = dr4[0].ToString();
            }
            baglanti.Close();

            //toplam maaş
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("select sum(personelmaas) from personel", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                LblToplamMaas.Text=dr5[0].ToString();
            }
            baglanti.Close();

            //ortalama maaş
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("select avg(personelmaas) from personel",baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                LblOrtalamaMaas.Text = dr6[0].ToString();
            }
            baglanti.Close();
        }
    }
}
