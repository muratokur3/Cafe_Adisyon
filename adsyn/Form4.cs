using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace adsyn
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source = NEWBILGISAYAR\\SQLEXPRESS;Initial Catalog = adisyon90lar; Integrated Security = True;");


        public string masaa;
        int adett = 1, masaurundi, a, no_urun = 0, urun_no = 0;
        string kat, satisno, tahsilatb, masatutar;
        string aciklama = "yok";
        double fiyati, tutari, tutar;

        private void yuksekdegerial()
        {


            baglanti.Open();
            SqlCommand cmdeydgr = new SqlCommand("SELECT Max(satisno) FROM satilanurunler", baglanti);
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


        private void satistamamlama()
        {


            DateTime zsaat = DateTime.Now;
            string saat = zsaat.ToLongTimeString();
            DateTime zaman = DateTime.Today;
            baglanti.Open();
            SqlCommand komuti = new SqlCommand("INSERT INTO satilanurunler (satisno,satilanurunadi,satilanurunfiyati,satilanurunadeti,satilanurunkategorisi,satilanuruntarihi,satilanurunsaati,satilanuruntahsilatb,satilanurunttutari,satilanurunmasasi,satilanurunaciklamasi) SELECT '" + a + "',masaurunadi,masaurunfiyati,masaurunadeti,masaurunkategori,'" + zaman.ToShortDateString() + "','" + saat + "','" + tahsilatb + "','" + Convert.ToDouble(textBox1.Text) + "','" + masaa + "','" + aciklama + "' FROM masalar WHERE masaadi='" + masaa + "'", baglanti);
            komuti.ExecuteNonQuery();
            baglanti.Close();
           
            baglanti.Open();
            SqlCommand komut= new SqlCommand("INSERT INTO satistutari (trh,satisttr) SELECT  '"+ zaman.ToShortDateString() + "',"+ Convert.ToDouble(textBox1.Text) + "", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        private void goster()
        {
            listView1.Items.Clear();

            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM urunler WHERE UrunKategori='" + kat + "'", baglanti);
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

        public void sgoster()
        {
            listView2.Items.Clear();

            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM masalar where masaadi='" + masaa + "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {

                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["masaurunid"].ToString();
                ekle.SubItems.Add(oku["masaurunadi"].ToString());
                ekle.SubItems.Add(oku["masaurunfiyati"].ToString());
                ekle.SubItems.Add(oku["masaurunadeti"].ToString());
                ekle.SubItems.Add(oku["masauruntutar"].ToString());
                ekle.SubItems.Add(oku["masaurunkategori"].ToString());

                listView2.Items.Add(ekle);

            }
            baglanti.Close();
            toplam();

        }


        public void toplam()
        {
            baglanti.Open();
            SqlCommand cmdtplm = new SqlCommand("SELECT Sum(masauruntutar) FROM masalar WHERE masaadi='" + masaa + "'", baglanti);
            SqlDataReader dr = cmdtplm.ExecuteReader();
            if (dr.HasRows)
            {

                dr.Read();
                textBox1.Text = dr[0].ToString();
                masatutar = dr[0].ToString();


            }

            baglanti.Close();
        }

        private void eklemekler()
        {




            if (no_urun == 0)
            {
                MessageBox.Show("secim yap");
            }
            else
            {

                //*************************************************************************

                baglanti.Open();
                SqlCommand komuto = new SqlCommand("SELECT  *from masalar WHERE masaadi='" + masaa + "' AND masaurunid='" + no_urun + "'", baglanti);
                SqlDataReader okuo = komuto.ExecuteReader();
                while (okuo.Read())
                {
                    masaurundi = Convert.ToInt32(okuo["masaurunid"]);
                    adett = Convert.ToInt32(okuo["masaurunadeti"]);
                    fiyati = Convert.ToDouble(okuo["masaurunfiyati"]);
                    tutari = Convert.ToDouble(okuo["masauruntutar"]);


                }
                baglanti.Close();
                //*************************************************************************
                
                if (masaurundi == no_urun)
                {
                    adett++;

                    baglanti.Open();
                    SqlCommand cmdadetart = new SqlCommand("UPDATE masalar SET masaurunadeti=" + adett + " WHERE masaadi='" + masaa + "' AND masaurunid=" + no_urun + "", baglanti);
                    cmdadetart.ExecuteNonQuery();
                    baglanti.Close();

                    tutari += fiyati;

                    baglanti.Open();
                    SqlCommand cmdtutar = new SqlCommand($"UPDATE masalar SET masauruntutar={ tutari.ToString().Replace(",",".") } WHERE masaadi='{masaa}' AND masaurunid={no_urun}", baglanti);
                    //SqlCommand cmdtutar = new SqlCommand(String.Format("UPDATE masalar SET masauruntutar={0} WHERE masaadi='{1}' AND masaurunid={2}", tutari, masaa, no_urun), baglanti);
                    cmdtutar.ExecuteNonQuery();
                    baglanti.Close();


                }
                else
                {

                    baglanti.Open();
                    SqlCommand cmdadetekl = new SqlCommand("INSERT INTO masalar (masaadi,masaurunadi,masaurunfiyati,masaurunadeti,masatutar,masaurunid,masauruntutar,masaurunkategori) SELECT '" + masaa + "',UrunAd,UrunFiyat,UrunAdet,'" + tutar + "',UrunId,UrunFiyat,UrunKategori FROM urunler WHERE UrunId='" + no_urun + "'", baglanti);
                    cmdadetekl.ExecuteNonQuery();
                    baglanti.Close();

                }

            }

        }

        private void cikar()
        {

            if (urun_no == 0)
            {
                MessageBox.Show("secim yap");
            }
            else
            {

                //*************************************************************************

                baglanti.Open();
                SqlCommand komuto = new SqlCommand("SELECT  *from masalar WHERE masaadi='" + masaa + "' AND masaurunid='" + urun_no + "'", baglanti);
                SqlDataReader okuo = komuto.ExecuteReader();
                while (okuo.Read())
                {
                    masaurundi = Convert.ToInt32(okuo["masaurunid"]);
                    adett = Convert.ToInt32(okuo["masaurunadeti"]);
                    fiyati = Convert.ToInt32(okuo["masaurunfiyati"]);
                    tutari = Convert.ToInt32(okuo["masauruntutar"]);


                }
                baglanti.Close();
                //*************************************************************************



                if (adett > 1)
                {
                    adett--;
                    tutari -= fiyati;
                    baglanti.Open();
                    SqlCommand cmdadetart = new SqlCommand("UPDATE masalar SET masaurunadeti='" + adett + "' WHERE masaadi='" + masaa + "' AND masaurunid='" + urun_no + "'", baglanti);
                    cmdadetart.ExecuteNonQuery();
                    baglanti.Close();

                    baglanti.Open();
                    SqlCommand cmdtutar = new SqlCommand("UPDATE masalar SET masauruntutar='" + tutari + "' WHERE masaadi='" + masaa + "' AND masaurunid='" + urun_no + "'", baglanti);
                    cmdtutar.ExecuteNonQuery();
                    baglanti.Close();


                }
                else
                {

                    baglanti.Open();
                    SqlCommand silkomutu = new SqlCommand("DELETE FROM masalar WHERE masaadi='" + masaa + "' AND masaurunid='" + urun_no + "'", baglanti);
                    silkomutu.ExecuteNonQuery();
                    baglanti.Close();


                }

            }



        }

        private void btnanasayfa_Click(object sender, EventArgs e)
        {
            Form2 fom2 = new Form2();
            fom2.Show();
            this.Hide();
        }

        private void btnmasa_Click(object sender, EventArgs e)
        {
            Form3 fom3 = new Form3();
            fom3.Show();
            this.Hide();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            urun_no = 0;
            this.Location = Screen.PrimaryScreen.Bounds.Location;
            label6.Text = "MASA-" + masaa;
            sgoster();
            gosterr();
        }

        private void button21_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            cikar();
            sgoster();


        }

        private void button21_Click_1(object sender, EventArgs e)
        {
            Form3 fom3 = new Form3();
            fom3.Show();
            this.Hide();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                tahsilatb = "KART";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                label2.Visible = true;
                textBox2.Visible = true;
            }
            else
            {
                label2.Visible = false;
                textBox2.Visible = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            kat = button7.Text;
            goster();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            kat = button8.Text;
            goster();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            kat = button4.Text;
            goster();
        }



        private void button17_Click(object sender, EventArgs e)
        {
            kat = button17.Text;
            goster();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            kat = button19.Text;
            goster();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            kat = button11.Text;
            goster();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            kat = button10.Text;
            goster();
        }



        private void button14_Click_1(object sender, EventArgs e)
        {
            kat = ms1.Text;
            goster();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            kat = button13.Text;
            goster();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            kat = button12.Text;
            goster();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            kat = button16.Text;
            goster();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            kat = button15.Text;
            goster();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            kat = button20.Text;
            goster();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gosterr();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            if (radioButton1.Checked == false)
            {
                radioButton1.Checked = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked == false)
            {
                radioButton2.Checked = true;

            }
        }

        private void listView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            urun_no = int.Parse(listView2.SelectedItems[0].SubItems[0].Text);
            cikar();
            sgoster();
        }
        ///********************************************************************************************EKLEMEK***********************************************************************************************************************
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            no_urun = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            eklemekler();
            sgoster();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                tahsilatb = "NAKİT";
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            eklemekler();
            sgoster();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            kat = button3.Text;
            goster();

        }

        private void button22_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="")
            {
                MessageBox.Show("MASA ŞUAN BOŞ. İŞLEM TAMAMLANMADI");

            }
            else
            {
               
           
             double text = Convert.ToDouble(textBox1.Text);

            if (radioButton1.Checked == true || radioButton2.Checked == true)
            {
                if (Convert.ToDouble(masatutar) > text)
                {
                   
                    if (textBox2.Text == "")
                    {

                        aciklama = "+++++++++++fiyat değişikliği var fakat açıklama yok!!";
                    }
                    else
                    aciklama = "+++++" + textBox2.Text;
                }
                else
                {
                    if (textBox2.Text == "")
                    {
                        aciklama = "yok";
                    }
                    else
                    {
                        aciklama = "///////" + textBox2.Text + "///////";
                    }
                }

                yuksekdegerial();
                satistamamlama();
                listView2.Items.Clear();
                label1.Text = "0";
                baglanti.Open();
                SqlCommand silkomutu = new SqlCommand("DELETE FROM masalar where masaadi='" + masaa + "'", baglanti);
                silkomutu.ExecuteNonQuery();
                baglanti.Close();
                Form3 fom3 = new Form3();
                fom3.Show();
                this.Hide();
            }
                else { 
                MessageBox.Show("Lütfen tahsilat biçimini seçiniz!!!");
                }


            }
        }

        private void ms1_Click(object sender, EventArgs e)
        {
            kat = ms1.Text;
            goster();

        }

        private void sil_Click(object sender, EventArgs e)
        {
            tutar = 0;
            textBox1.Text = "";
            baglanti.Open();
            SqlCommand silkomutu = new SqlCommand("DELETE FROM masalar where masaadi='" + masaa + "'", baglanti);
            silkomutu.ExecuteNonQuery();
            baglanti.Close();
            listView2.Items.Clear();
            sgoster();
        }
    }
}
