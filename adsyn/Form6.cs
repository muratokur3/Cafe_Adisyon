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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = NEWBILGISAYAR\\SQLEXPRESS;Initial Catalog = adisyon90lar; Integrated Security = True;");
        public void gosterr()
        {
           listView1.Items.Clear();
            DateTime zaman = DateTime.Today;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM satilanurunler where satilanuruntarihi='" + zaman.ToShortDateString()+"'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["satisno"].ToString();
                ekle.SubItems.Add(oku["satilanurunadi"].ToString());
                ekle.SubItems.Add(oku["satilanurunfiyati"].ToString());
                ekle.SubItems.Add(oku["satilanurunadeti"].ToString());
                ekle.SubItems.Add(oku["satilanurunkategorisi"].ToString());
                ekle.SubItems.Add(oku["satilanuruntarihi"].ToString());
                ekle.SubItems.Add(oku["satilanurunsaati"].ToString());
                ekle.SubItems.Add(oku["satilanuruntahsilatb"].ToString());
                ekle.SubItems.Add(oku["satilanurunttutari"].ToString());
                ekle.SubItems.Add(oku["satilanurunmasasi"].ToString());
                ekle.SubItems.Add(oku["satilanurunaciklamasi"].ToString());

                listView1.Items.Add(ekle);

            }
            baglanti.Close();

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            this.Location = Screen.PrimaryScreen.Bounds.Location;

            gosterr();
        }

        private void button7_Click(object sender, EventArgs e)
        {
          string t1=  dateTimePicker1.Value.ToShortDateString();
          string t2=  dateTimePicker2.Value.ToShortDateString();

            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM satilanurunler WHERE satilanuruntarihi between '" + t1 + "' and '" + t2 + "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["satisno"].ToString();
                ekle.SubItems.Add(oku["satilanurunadi"].ToString());
                ekle.SubItems.Add(oku["satilanurunfiyati"].ToString());
                ekle.SubItems.Add(oku["satilanurunadeti"].ToString());
                ekle.SubItems.Add(oku["satilanurunkategorisi"].ToString());
                ekle.SubItems.Add(oku["satilanuruntarihi"].ToString());
                ekle.SubItems.Add(oku["satilanurunsaati"].ToString());
                ekle.SubItems.Add(oku["satilanuruntahsilatb"].ToString());
                ekle.SubItems.Add(oku["satilanurunttutari"].ToString());
                ekle.SubItems.Add(oku["satilanurunmasasi"].ToString());
                ekle.SubItems.Add(oku["satilanurunaciklamasi"].ToString());

                listView1.Items.Add(ekle);

            }
            baglanti.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string t1 = dateTimePicker3.Value.ToShortDateString();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM satilanurunler WHERE satilanuruntarihi='" + t1+"'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["satisno"].ToString();
                ekle.SubItems.Add(oku["satilanurunadi"].ToString());
                ekle.SubItems.Add(oku["satilanurunfiyati"].ToString());
                ekle.SubItems.Add(oku["satilanurunadeti"].ToString());
                ekle.SubItems.Add(oku["satilanurunkategorisi"].ToString());
                ekle.SubItems.Add(oku["satilanuruntarihi"].ToString());
                ekle.SubItems.Add(oku["satilanurunsaati"].ToString());
                ekle.SubItems.Add(oku["satilanuruntahsilatb"].ToString());
                ekle.SubItems.Add(oku["satilanurunttutari"].ToString());
                ekle.SubItems.Add(oku["satilanurunmasasi"].ToString());
                ekle.SubItems.Add(oku["satilanurunaciklamasi"].ToString());

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

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = false;
             listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM satilanurunler", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["satisno"].ToString();
                ekle.SubItems.Add(oku["satilanurunadi"].ToString());
                ekle.SubItems.Add(oku["satilanurunfiyati"].ToString());
                ekle.SubItems.Add(oku["satilanurunadeti"].ToString());
                ekle.SubItems.Add(oku["satilanurunkategorisi"].ToString());
                ekle.SubItems.Add(oku["satilanuruntarihi"].ToString());
                ekle.SubItems.Add(oku["satilanurunsaati"].ToString());
                ekle.SubItems.Add(oku["satilanuruntahsilatb"].ToString());
                ekle.SubItems.Add(oku["satilanurunttutari"].ToString());
                ekle.SubItems.Add(oku["satilanurunmasasi"].ToString());
                ekle.SubItems.Add(oku["satilanurunaciklamasi"].ToString());

                listView1.Items.Add(ekle);

            }
            baglanti.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 fom2 = new Form2();
            fom2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gosterr();
            panel2.Visible = false;
            panel1.Visible = false;
        }
    }
}
