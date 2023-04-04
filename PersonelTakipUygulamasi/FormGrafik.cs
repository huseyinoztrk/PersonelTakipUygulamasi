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
    public partial class FormGrafik : Form
    {
        public FormGrafik()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=MAT225;Initial Catalog=Personel;Integrated Security=True");

        private void FormGrafik_Load(object sender, EventArgs e)
        {
            //grafik şehir
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select PersonelSehir,count(*) from personel group by PersonelSehir", baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(dr1[0], dr1[1]);
            }
            baglanti.Close();

            //grafik meslek-maaş
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select personelmeslek,avg(personelmaas) from personel group by personelmeslek", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(dr2[0], dr2[1]);
            }
            baglanti.Close();
        }
    }
}
