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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        
        string satisno;
            int id = 0,a;

        SqlConnection baglanti = new SqlConnection("Data Source = NEWBILGISAYAR\\SQLEXPRESS;Initial Catalog = adisyon90lar; Integrated Security = True;");

        private void yuksekdegerial()
        {


            baglanti.Open();
            SqlCommand cmdeydgr = new SqlCommand("SELECT Max(UrunId) FROM urunler", baglanti);
            SqlDataReader dr = cmdeydgr.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                satisno = dr[0].ToString();
            }
            baglanti.Close();
            a = Convert.ToInt32(satisno);
            a += 1;
        }


        public void gosterr()
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM urunler", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["UrunId"].ToString();
                ekle.SubItems.Add(oku["UrunAd"].ToString());
                ekle.SubItems.Add(oku["UrunFiyat"].ToString());
                ekle.SubItems.Add(oku["UrunKategori"].ToString());
                listView1.Items.Add(ekle);
            }
            baglanti.Close();
            
        }



        private void Form5_Load(object sender, EventArgs e)
        {

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

           
                panel3.Visible = true;
           
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel3.Visible = false;
          
                panel2.Visible = true;
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = false;
           
                panel1.Visible = true;
        


        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            yuksekdegerial();
            baglanti.Open();
            SqlCommand komuti = new SqlCommand("INSERT INTO urunler (UrunId,UrunAd,UrunFiyat,UrunAdet,UrunKategori) VALUES('"+a+"','" + textBox2.Text + "','" + textBox3.Text + "','" + 1 + "','" + textBox5.Text + "')", baglanti);
            komuti.ExecuteNonQuery();
            baglanti.Close();
            gosterr();
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";

            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand silkomutu = new SqlCommand("DELETE FROM urunler where UrunId='" + textBox6.Text + "'", baglanti);
            silkomutu.ExecuteNonQuery();
            baglanti.Close();
            gosterr();
            textBox6.Text = "";

        }

        private void button7_Click(object sender, EventArgs e)
        {
            

            baglanti.Open();
            SqlCommand komuti = new SqlCommand("UPDATE urunler SET UrunId='"+id+ "', UrunAd='" + textBox8.Text + "', UrunFiyat= '" + Convert.ToDouble(textBox10.Text) + "', UrunAdet='" + 1 + "',UrunKategori='" + textBox11.Text + "' WHERE UrunId='"+id+"'", baglanti);
            komuti.ExecuteNonQuery();
            baglanti.Close();
            gosterr();
            textBox8.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";


        }

        private void button8_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM urunler where UrunId='"+id+"'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textBox8.Text = oku["UrunAd"].ToString();
                textBox10.Text = oku["UrunFiyat"].ToString();
                textBox11.Text = oku["UrunKategori"].ToString();

            }
            baglanti.Close();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {


            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM urunler where UrunId='" + id + "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textBox8.Text = oku["UrunAd"].ToString();
                textBox10.Text = oku["UrunFiyat"].ToString();
                textBox11.Text = oku["UrunKategori"].ToString();

            }
            baglanti.Close();
        }
    }
}
