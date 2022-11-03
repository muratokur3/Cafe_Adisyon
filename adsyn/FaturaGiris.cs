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
    public partial class FaturaGiris : Form
    {
        public FaturaGiris()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source = NEWBILGISAYAR\\SQLEXPRESS;Initial Catalog = adisyon90lar; Integrated Security = True;");
        Int32 a=0;
        string tahsilatb;
        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.Visible == false)
            {
                listView1.Visible = true;
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
            else
                listView1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {

                DateTime zsaat = DateTime.Now;
                string saat = zsaat.ToLongTimeString();
                DateTime zaman = DateTime.Today;
                baglanti.Open();
                SqlCommand cmd = new SqlCommand("insert into masraflar (masrafdegeri,masrafaciklamasİ,masraftarihi,masrafsaati) values('" + textBox6.Text + "','" + textBox5.Text + " - firmasına faturadır" + "','" + zaman.ToShortDateString() + "','" + saat + "')", baglanti);
                cmd.ExecuteNonQuery();
                baglanti.Close();

            }
            DateTime zamaan = DateTime.Today;
            a++;
            baglanti.Open();
            SqlCommand komuti = new SqlCommand("INSERT INTO faturagirisi (islem_no,urun_no,adi,miktari,alis_fiyati,firma_adi,toplam_tutar,islem_tahsilat_b,islem_tarihi) VALUES('" + a + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + tahsilatb + "','" + zamaan.ToShortDateString() + "')", baglanti);
            komuti.ExecuteNonQuery();
            baglanti.Close();



            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            checkBox1.Checked = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                tahsilatb = "NAKİT";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                tahsilatb = "KART";
            }
        }

        private void FaturaGiris_Load(object sender, EventArgs e)
        {
         
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 fom2 = new Form2();
            fom2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            int id = 0;
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM urunler where UrunId='"+id+"'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
               textBox1.Text = oku["UrunId"].ToString();
                textBox2.Text = oku["UrunAd"].ToString();
            }
            baglanti.Close();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int id = 0;
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM urunler where UrunId='" + id + "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textBox1.Text = oku["UrunId"].ToString();
                textBox2.Text = oku["UrunAd"].ToString();
            }
            baglanti.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked==true)
            {
                radioButton1.Visible = true;
                radioButton2.Visible = true;

            }
            else
            {
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                tahsilatb = "ödenmedi";
            }
        }
    }
}
