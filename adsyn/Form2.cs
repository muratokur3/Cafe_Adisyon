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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

       //  SqlConnection baglanti = new SqlConnection(@"Data Source = (LocalDB)\V12.0;Integrated Security = True;AttachDbFileName='|DataDirectory|\adisyon90lar.mdf'");

        SqlConnection baglanti = new SqlConnection("Data Source = NEWBILGISAYAR\\SQLEXPRESS;Initial Catalog = adisyon90lar; Integrated Security = True;");

        DateTime zaman = DateTime.Today;

        string satis_tutar, masraf_tutar, devir_tutar, aciklama, varmi;
        double satist, masraft, devirt, kasat, curot;

        private void varmii ()
            {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM masraflar WHERE masraftarihi='"+zaman.ToShortDateString()+"'", baglanti);
            SqlDataReader oku = cmd.ExecuteReader();
            if (oku.Read())
            {
                varmi = oku["masraftarihi"].ToString();
            }
            baglanti.Close();
        }


        private void btnmasa_Click(object sender, EventArgs e)
        {
            Form3 fom3 = new Form3();
            fom3.Show();
            this.Hide();
        }
       
        private void z_masraf()
        {
            baglanti.Open();
            SqlCommand cmdtplm = new SqlCommand("SELECT Sum(masrafdegeri) FROM masraflar WHERE masraftarihi='" + zaman.ToShortDateString() + "'", baglanti);
            SqlDataReader dr = cmdtplm.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                masraf_tutar = dr[0].ToString();
                label3.Text = masraf_tutar;
            }
            baglanti.Close();            
        }
        private void z_satis()
        {
            baglanti.Open();
            SqlCommand cmdtplm = new SqlCommand("SELECT Sum(satisttr) FROM satistutari WHERE trh='" + zaman.ToShortDateString() + "'", baglanti);
            SqlDataReader dr = cmdtplm.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                satis_tutar = dr[0].ToString();
                label4.Text = satis_tutar;
            }
            baglanti.Close();
        }
        private void z_kasadevir()
        {
            baglanti.Close();
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM z_raporu WHERE z_tarihi='" + zaman.ToShortDateString() + "'", baglanti);
            SqlDataReader oku = cmd.ExecuteReader();
            while (oku.Read())
            {
                devir_tutar = oku["z_devir"].ToString();
                label10.Text = devir_tutar;
            }

            baglanti.Close();

        }
        private void z_raaporu()
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM masraflar WHERE masraftarihi='" + zaman.ToShortDateString() + "'", baglanti);
            SqlDataReader oku = cmd.ExecuteReader();
            if (oku.Read())
            {
            z_kasadevir();
            z_masraf();
            z_satis(); 

            }
            else
	{
                MessageBox.Show("bu tarihte veri bulunmadı!!");
            }
           baglanti.Close();
                       
        }
       
        private void btnhesap_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 fom3 = new Form3();
            fom3.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Location = Screen.PrimaryScreen.Bounds.Location;
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime zaman = DateTime.Now;
            label1.Text = zaman.ToLongTimeString();

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label2.Text =DateTime.Now.Day.ToString()+" "+DateTime.Now.DayOfWeek.ToString()+" "+DateTime.Now.Year.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 fom5 = new Form5();
            fom5.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "Kadiser9003")
            {
            panel3.Visible = true;
            panel5.Visible = false;
            panel4.Visible = false;
            z_raaporu();

            }
            else
            {
                MessageBox.Show("Şifre Hatalı!! ");
            }
            textBox1.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            button6.Visible = true;

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form7 fom7 = new Form7();
            fom7.Show();
            this.Hide();

           
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            panel5.Visible = false;
            panel4.Visible = true;
            panel3.Visible = false;
            label9.Text = "ANASAYFA";
            
          
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked==true)
            {
                textBox2.Visible = true;
            }
            else
            {
                textBox2.Visible = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox2.Checked == true)
            {
                dateTimePicker1.Visible = true;
                button15.Visible = true;
            }
            else
            {
                dateTimePicker1.Visible = false;
                button15.Visible = false;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            zaman = dateTimePicker1.Value;
            z_raaporu();
            
        }

        private void button16_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel3.Visible = false;
            panel5.Visible = false;
            checkBox2.Checked = false;
            label13.Text = "000,0000";
            DateTime z = DateTime.Today;
            dateTimePicker1.Value = Convert.ToDateTime(z.ToShortDateString());
            zaman = dateTimePicker1.Value;
            label9.Text = "ANASAYFA";

        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form5 fom5 = new Form5();
            fom5.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 fom6 = new Form6();
            fom6.Show();
            this.Hide();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            FaturaGiris faturagiris = new FaturaGiris();
            faturagiris.Show();
            this.Hide();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            FaturaTakipIslemleri faturatakip = new FaturaTakipIslemleri();
            faturatakip.Show();
            this.Hide();
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            Form8 fom8 = new Form8();
            fom8.Show();
            this.Hide();
            timer1.Stop();
            timer2.Stop();
        }

       

      

        private void button14_Click(object sender, EventArgs e)
        {
            devirt = Convert.ToDouble(label10.Text);
            masraft = Convert.ToDouble(label3.Text);
            satist = Convert.ToDouble(label4.Text);
            kasat = (satist + devirt) - masraft;
            label13.Text = kasat.ToString();
           
        }

        private void button8_Click_1(object sender, EventArgs e)
        {

            if (label13.Text=="000,0000")
            {
                MessageBox.Show("lütfen önce hesaplayınız! boş deger içeriyor!!");
            }
            else
            {
                if (textBox2.Text=="")
                {
                    aciklama = "yok";
                }
                else
                {
                    aciklama = textBox2.Text;
                }          
              baglanti.Open();
            SqlCommand komuti = new SqlCommand("UPDATE z_raporu SET z_masraf='" + masraft + "', z_satis='" + satist + "', z_curo= '" + curot + "',z_kasa='"+kasat+"', z_aciklama='" + aciklama + "' WHERE z_tarihi='" + zaman.ToShortDateString() + "'", baglanti);
            komuti.ExecuteNonQuery();
            baglanti.Close();
                MessageBox.Show("başarıyla gerçekleşti");
                panel4.Visible = true;
                panel3.Visible = false;
                panel5.Visible = false;             
                checkBox2.Checked = false;
                label13.Text = "000,0000";
                DateTime z = DateTime.Today;
                dateTimePicker1.Value = Convert.ToDateTime(z.ToShortDateString());
                zaman = dateTimePicker1.Value;
                label9.Text = "ANASAYFA";

            }


        }

        private void button7_Click(object sender, EventArgs e)
        {
        
           panel5.Visible = true;
            panel4.Visible = false;
            panel3.Visible = false;           
            label9.Text = "Z-RAPORU";

        }
    }
}
