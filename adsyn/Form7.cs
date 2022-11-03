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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = NEWBILGISAYAR\\SQLEXPRESS;Initial Catalog = adisyon90lar; Integrated Security = True;");
        private void goster()
        {
            listView1.Items.Clear();
            DateTime zaman = DateTime.Today;
            baglanti.Open();
            SqlCommand cmdg = new SqlCommand("select *from masraflar where masraftarihi='"+zaman.ToShortDateString()+"' ", baglanti);
            SqlDataReader oku = cmdg.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["masrafdegeri"].ToString();
                ekle.SubItems.Add(oku["masrafaciklamasi"].ToString());
                ekle.SubItems.Add(oku["masraftarihi"].ToString());
                ekle.SubItems.Add(oku["masrafsaati"].ToString());
                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == false)
            {
                panel1.Visible = true;
                panel2.Visible = false;
            }
            else
                panel1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            if (panel2.Visible == false)
            {
                panel2.Visible = true;
                panel1.Visible = false;
            }
            else
            {
                panel2.Visible = false;
            }
            goster();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime zsaat = DateTime.Now;
            string saat = zsaat.ToLongTimeString();
            DateTime zaman = DateTime.Today;
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("insert into masraflar (masrafdegeri,masrafaciklamasİ,masraftarihi,masrafsaati) values('"+textBox2.Text+"','"+textBox1.Text+"','"+zaman.ToShortDateString()+"','"+saat+"')",baglanti);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Başarıyla Eklendi");
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel3.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel4.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel4.Visible = false;
            
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM masraflar", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["masrafdegeri"].ToString();
                ekle.SubItems.Add(oku["masrafaciklamasi"].ToString());
                ekle.SubItems.Add(oku["masraftarihi"].ToString());
                ekle.SubItems.Add(oku["masrafsaati"].ToString());
                listView1.Items.Add(ekle);
            }
            baglanti.Close();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form2 fom2 = new Form2();
            fom2.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
           listView1.Items.Clear();
            string t1 = dateTimePicker3.Value.ToShortDateString();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM masraflar WHERE masraftarihi='" +t1 + "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["masrafdegeri"].ToString();
                ekle.SubItems.Add(oku["masrafaciklamasi"].ToString());
                ekle.SubItems.Add(oku["masraftarihi"].ToString());
                ekle.SubItems.Add(oku["masrafsaati"].ToString());
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
            SqlCommand komut = new SqlCommand("SELECT *FROM masraflar WHERE masraftarihi between '" + t1 + "' and '" + t2 + "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["masrafdegeri"].ToString();
                ekle.SubItems.Add(oku["masrafaciklamasi"].ToString());
                ekle.SubItems.Add(oku["masraftarihi"].ToString());
                ekle.SubItems.Add(oku["masrafsaati"].ToString());
                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            goster();
            panel3.Visible = false;
            panel4.Visible = false;

        }
    }
}
