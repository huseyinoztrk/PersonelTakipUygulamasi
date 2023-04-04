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
    public partial class FormGiris : Form
    {
        public FormGiris()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=MAT225;Initial Catalog=Personel;Integrated Security=True");

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from AdminPanel where KullaniciAdi=@p1 and Sifre=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtKullaniciAdi.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Form1 fr = new Form1();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Girmiş olduğunuz Kullanıcı Adı veya Şifre hatalıdır!", "Uyarı");
            }
            baglanti.Close();
        }
    }
}
