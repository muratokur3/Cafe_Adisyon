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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
         // SqlConnection baglanti = new SqlConnection(@"Data Source = (LocalDB)\V12.0;Integrated Security = True;AttachDbFileName='|DataDirectory|\adisyon90lar.mdf'");
       SqlConnection baglanti = new SqlConnection("Data Source = NEWBILGISAYAR\\SQLEXPRESS;Initial Catalog = adisyon90lar; Integrated Security = True;");



        int kontrol;
      
        
        private void masakontrol()
        {
            this.Location = Screen.PrimaryScreen.Bounds.Location;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT  *FROM masalar where masaadi='" + kontrol + "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                switch (kontrol)
                {
                    case 1:button1.BackColor = Color.Magenta; button1.ForeColor = Color.White;break;
                    case 2:button2.BackColor = Color.Magenta; button2.ForeColor = Color.White; break;
                    case 3: button3.BackColor = Color.Magenta; button3.ForeColor = Color.White; break;
                    case 4: button4.BackColor = Color.Magenta; button4.ForeColor = Color.White; break;
                    case 5: button5.BackColor = Color.Magenta; button5.ForeColor = Color.White; break;
                    case 6: button6.BackColor = Color.Magenta; button6.ForeColor = Color.White; break;
                    case 7: button7.BackColor = Color.Magenta; button7.ForeColor = Color.White; break;
                    case 8: button8.BackColor = Color.Magenta; button8.ForeColor = Color.White; break;
                    case 9: button9.BackColor = Color.Magenta; button9.ForeColor = Color.White; break;
                    case 10: button10.BackColor = Color.Magenta; button10.ForeColor = Color.White; break;
                    case 11: button11.BackColor = Color.Magenta; button11.ForeColor = Color.White; break;
                    case 12: button12.BackColor = Color.Magenta; button12.ForeColor = Color.White; break;
                    case 13: button13.BackColor = Color.Magenta; button13.ForeColor = Color.White; break;
                    case 14: button14.BackColor = Color.Magenta; button14.ForeColor = Color.White; break;
                    case 15: button15.BackColor = Color.Magenta; button15.ForeColor = Color.White; break;
                    case 16: button16.BackColor = Color.Magenta; button16.ForeColor = Color.White; break;
                    case 17: button17.BackColor = Color.Magenta; button17.ForeColor = Color.White; break;
                    case 18: button18.BackColor = Color.Magenta; button18.ForeColor = Color.White; break;
                    case 19: button19.BackColor = Color.Magenta; button19.ForeColor = Color.White; break;
                    case 20: button20.BackColor = Color.Magenta; button20.ForeColor = Color.White; break;
                    case 21: button21.BackColor = Color.Magenta; button21.ForeColor = Color.White; break;
                    case 22: button22.BackColor = Color.Magenta; button22.ForeColor = Color.White; break;
                    case 23: button23.BackColor = Color.Magenta; button23.ForeColor = Color.White; break;
                    case 24: button24.BackColor = Color.Magenta; button24.ForeColor = Color.White; break;
                    case 25: button25.BackColor = Color.Magenta; button25.ForeColor = Color.White; break;
                    case 26: button26.BackColor = Color.Magenta; button26.ForeColor = Color.White; break;
                    case 27: button27.BackColor = Color.Magenta; button27.ForeColor = Color.White; break;
                    case 28: button28.BackColor = Color.Magenta; button28.ForeColor = Color.White; break;
                    case 29: button29.BackColor = Color.Magenta; button29.ForeColor = Color.White; break;
                    case 30: button30.BackColor = Color.Magenta; button30.ForeColor = Color.White; break;
                    



                    default:
                        break;
                }
                
                
            }
            baglanti.Close();
        }

        private void btnsatis_Click(object sender, EventArgs e)
        {
            Form4 fom4 = new Form4();
            fom4.Show();
            this.Hide();
        }



        private void btnanasayfa_Click(object sender, EventArgs e)
        {
            Form2 fom2 = new Form2();
            fom2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            Form4 fom4 = new Form4();
            fom4.masaa = 1.ToString();
            fom4.Show();
            this.Hide();


        }

        private void button2_Click(object sender, EventArgs e)
        {


            Form4 fom4 = new Form4();
            fom4.masaa = 2.ToString();
            fom4.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            Form4 fom4 = new Form4();
            fom4.masaa = 3.ToString();
            fom4.Show();
            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {

            Form4 fom4 = new Form4();
            fom4.masaa = 4.ToString();
            fom4.Show();
            this.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {

            Form4 fom4 = new Form4();
            fom4.masaa = 5.ToString();
            fom4.Show();
            this.Hide();

        }

        private void button6_Click(object sender, EventArgs e)
        {

            Form4 fom4 = new Form4();
            fom4.masaa = 6.ToString();
            fom4.Show();
            this.Hide();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form4 fom4 = new Form4();
            fom4.masaa = 7.ToString();
            fom4.Show();
            this.Hide();

        }

        private void button8_Click(object sender, EventArgs e)
        {

            Form4 fom4 = new Form4();
            fom4.masaa = 8.ToString();
            fom4.Show();
            this.Hide();

        }

        private void button9_Click(object sender, EventArgs e)
        {

            Form4 fom4 = new Form4();
            fom4.masaa = 9.ToString();
            fom4.Show();
            this.Hide();

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            kontrol = 1;
            masakontrol();
            kontrol = 2;
            masakontrol();
            kontrol = 3;
            masakontrol();
            kontrol = 4;
            masakontrol();
            kontrol = 5;
            masakontrol();
            kontrol = 6;
            masakontrol();
            kontrol = 7;
            masakontrol();
            kontrol = 8;
            masakontrol();
            kontrol = 9;
            masakontrol();
            kontrol = 10;
            masakontrol();
            kontrol = 11;
            masakontrol();
            kontrol = 12;
            masakontrol();
            kontrol = 13;
            masakontrol();
            kontrol = 14;
            masakontrol();
            kontrol = 15;
            masakontrol();
            kontrol = 16;
            masakontrol();
            kontrol = 17;
            masakontrol();
            kontrol = 18;
            masakontrol();
            kontrol = 19;
            masakontrol();
            kontrol = 20;
            masakontrol();
            kontrol = 21;
            masakontrol();
            kontrol = 22;
            masakontrol();
            kontrol = 23;
            masakontrol();
            kontrol = 24;
            masakontrol();
            kontrol = 25;
            masakontrol();
            kontrol = 26;
            masakontrol();
            kontrol = 27;
            masakontrol();
            kontrol = 28;
            masakontrol();
            kontrol = 29;
            masakontrol();
            kontrol = 30;
            masakontrol();

        }

        private void btnanasayfa_Click_1(object sender, EventArgs e)
        {
            Form2 fom2 = new Form2();
            fom2.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form4 fom4 = new Form4();
            fom4.masaa = 10.ToString();
            fom4.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form4 fom4 = new Form4();
            fom4.masaa = 11.ToString();
            fom4.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form4 fom4 = new Form4();
            fom4.masaa = 12.ToString();
            fom4.Show();
            this.Hide();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form4 fom4 = new Form4();
            fom4.masaa = 13.ToString();
            fom4.Show();
            this.Hide();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Form4 fom4 = new Form4();
            fom4.masaa = 14.ToString();
            fom4.Show();
            this.Hide();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Form4 fom4 = new Form4();
            fom4.masaa = 15.ToString();
            fom4.Show();
            this.Hide();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Form4 fom4 = new Form4();
            fom4.masaa = 16.ToString();
            fom4.Show();
            this.Hide();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Form4 fom4 = new Form4();
            fom4.masaa = 17.ToString();
            fom4.Show();
            this.Hide();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Form4 fom4 = new Form4();
            fom4.masaa = 18.ToString();
            fom4.Show();
            this.Hide();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Form4 fom4 = new Form4();
            fom4.masaa = 19.ToString();
            fom4.Show();
            this.Hide();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Form4 fom4 = new Form4();
            fom4.masaa = 20.ToString();
            fom4.Show();
            this.Hide();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Form4 fom4 = new Form4();
            fom4.masaa = 21.ToString();
            fom4.Show();
            this.Hide();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Form4 fom4 = new Form4();
            fom4.masaa = 22.ToString();
            fom4.Show();
            this.Hide();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Form4 fom4 = new Form4();
            fom4.masaa = 23.ToString();
            fom4.Show();
            this.Hide();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Form4 fom4 = new Form4();
            fom4.masaa = 24.ToString();
            fom4.Show();
            this.Hide();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Form4 fom4 = new Form4();
            fom4.masaa = 25.ToString();
            fom4.Show();
            this.Hide();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Form4 fom4 = new Form4();
            fom4.masaa = 26.ToString();
            fom4.Show();
            this.Hide();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            Form4 fom4 = new Form4();
            fom4.masaa = 27.ToString();
            fom4.Show();
            this.Hide();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            Form4 fom4 = new Form4();
            fom4.masaa = 28.ToString();
            fom4.Show();
            this.Hide();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            Form4 fom4 = new Form4();
            fom4.masaa = 29.ToString();
            fom4.Show();
            this.Hide();
        }

        
        private void button30_Click_1(object sender, EventArgs e)
        {
            Form4 fom4 = new Form4();
            fom4.masaa = 30.ToString();
            fom4.Show();
            this.Hide();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            Form2 fom2 = new Form2();
            fom2.Show();
            this.Hide();
        }
    }
}
