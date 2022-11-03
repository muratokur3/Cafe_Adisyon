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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = NEWBILGISAYAR\\SQLEXPRESS;Initial Catalog = adisyon90lar; Integrated Security = True;");
        public void gosterr()
        {
            listView1.Items.Clear();
            DateTime zaman1 = DateTime.Today;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM z_raporu  where z_tarihi='" + zaman1.ToShortDateString() + "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["z_tarihi"].ToString();
                ekle.SubItems.Add(oku["z_devir"].ToString());
                ekle.SubItems.Add(oku["z_masraf"].ToString());
                ekle.SubItems.Add(oku["z_satis"].ToString());
                ekle.SubItems.Add(oku["z_kasa"].ToString());
                ekle.SubItems.Add(oku["z_curo"].ToString());
                ekle.SubItems.Add(oku["z_aciklama"].ToString());

                listView1.Items.Add(ekle);

            }
            baglanti.Close();

        }
        private void Form8_Load(object sender, EventArgs e)
        {
            baglanti.Close();
            this.Location = Screen.PrimaryScreen.Bounds.Location;
            gosterr();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form2 fom2 = new Form2();
            fom2.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            panel2.Visible = false;
            panel1.Visible = false;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM z_raporu", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["z_tarihi"].ToString();
                ekle.SubItems.Add(oku["z_devir"].ToString());
                ekle.SubItems.Add(oku["z_masraf"].ToString());
                ekle.SubItems.Add(oku["z_satis"].ToString());
                ekle.SubItems.Add(oku["z_kasa"].ToString());
                ekle.SubItems.Add(oku["z_curo"].ToString());
                ekle.SubItems.Add(oku["z_aciklama"].ToString());

                listView1.Items.Add(ekle);

            }
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            panel1.Visible = true;
            panel2.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string t1 = dateTimePicker3.Value.ToShortDateString();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM z_raporu WHERE z_tarihi='" + t1 + "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {

                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["z_tarihi"].ToString();
                ekle.SubItems.Add(oku["z_devir"].ToString());
                ekle.SubItems.Add(oku["z_masraf"].ToString());
                ekle.SubItems.Add(oku["z_satis"].ToString());
                ekle.SubItems.Add(oku["z_kasa"].ToString());
                ekle.SubItems.Add(oku["z_curo"].ToString());
                ekle.SubItems.Add(oku["z_aciklama"].ToString());

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
            SqlCommand komut = new SqlCommand("SELECT *FROM z_raporu WHERE z_tarihi between '" + t1 + "' and '" + t2 + "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {

                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["z_tarihi"].ToString();
                ekle.SubItems.Add(oku["z_devir"].ToString());
                ekle.SubItems.Add(oku["z_masraf"].ToString());
                ekle.SubItems.Add(oku["z_satis"].ToString());
                ekle.SubItems.Add(oku["z_kasa"].ToString());
                ekle.SubItems.Add(oku["z_curo"].ToString());
                ekle.SubItems.Add(oku["z_aciklama"].ToString());

                listView1.Items.Add(ekle);


            }
            baglanti.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            gosterr();
            panel2.Visible = false;
            panel1.Visible = false;
        }
    }
}
