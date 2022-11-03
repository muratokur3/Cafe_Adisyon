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

namespace adsyn
{
    public partial class FaturaTakipIslemleri : Form
    {
        public FaturaTakipIslemleri()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = NEWBILGISAYAR\\SQLEXPRESS;Initial Catalog = adisyon90lar; Integrated Security = True;");

        public void gosterr()
        {
            listView1.Items.Clear();
            DateTime zaman = DateTime.Today;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM faturagirisi where islem_tarihi='"+zaman.ToShortDateString()+"'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["urun_no"].ToString();
                ekle.SubItems.Add(oku["adi"].ToString());
                ekle.SubItems.Add(oku["miktari"].ToString());
                ekle.SubItems.Add(oku["alis_fiyati"].ToString());
                ekle.SubItems.Add(oku["firma_adi"].ToString());
                ekle.SubItems.Add(oku["toplam_tutar"].ToString());
                ekle.SubItems.Add(oku["islem_tahsilat_b"].ToString());
                ekle.SubItems.Add(oku["islem_tarihi"].ToString());

                listView1.Items.Add(ekle);
            }
            baglanti.Close();

        }
        private void FaturaTakipIslemleri_Load(object sender, EventArgs e)
        {
            gosterr();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 fom2 = new Form2();
            fom2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {

            panel2.Visible = true;
            panel1.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            panel2.Visible = false;
            panel1.Visible = false;
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM faturagirisi ", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["urun_no"].ToString();
                ekle.SubItems.Add(oku["adi"].ToString());
                ekle.SubItems.Add(oku["miktari"].ToString());
                ekle.SubItems.Add(oku["alis_fiyati"].ToString());
                ekle.SubItems.Add(oku["firma_adi"].ToString());
                ekle.SubItems.Add(oku["toplam_tutar"].ToString());
                ekle.SubItems.Add(oku["islem_tahsilat_b"].ToString());
                ekle.SubItems.Add(oku["islem_tarihi"].ToString());

                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            listView1.Items.Clear();
            string t1 = dateTimePicker3.Value.ToShortDateString();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM faturagirisi WHERE islem_tarihi='" + t1+ "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["urun_no"].ToString();
                ekle.SubItems.Add(oku["adi"].ToString());
                ekle.SubItems.Add(oku["miktari"].ToString());
                ekle.SubItems.Add(oku["alis_fiyati"].ToString());
                ekle.SubItems.Add(oku["firma_adi"].ToString());
                ekle.SubItems.Add(oku["toplam_tutar"].ToString());
                ekle.SubItems.Add(oku["islem_tahsilat_b"].ToString());
                ekle.SubItems.Add(oku["islem_tarihi"].ToString());

                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            string t1 = dateTimePicker1.Value.ToShortDateString();
            string t2 = dateTimePicker2.Value.ToShortDateString();

            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM faturagirisi WHERE islem_tarihi between '" + t1 + "' and '" + t2 + "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["urun_no"].ToString();
                ekle.SubItems.Add(oku["adi"].ToString());
                ekle.SubItems.Add(oku["miktari"].ToString());
                ekle.SubItems.Add(oku["alis_fiyati"].ToString());
                ekle.SubItems.Add(oku["firma_adi"].ToString());
                ekle.SubItems.Add(oku["toplam_tutar"].ToString());
                ekle.SubItems.Add(oku["islem_tahsilat_b"].ToString());
                ekle.SubItems.Add(oku["islem_tarihi"].ToString());

                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            gosterr();
            panel2.Visible = false;
            panel1.Visible = false;
        }
    }
}
