using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 计算经纬度
{
    public partial class 经纬度计算器 : Form
    {

        double 经度1=0;
        double 经度2=0;
        double 纬度1=0;
        double 纬度2=0;
        private const double EARTH_RADIUS1 = 6371004;
        private const double EARTH_RADIUS2 = 6378137;

        double EARTH_RADIUS = 6371004;


        public 经纬度计算器()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;

            double.TryParse(tb.Text.ToString(), out this.经度1);

            textBox5.Text = System.Math.Abs(经度1 - 经度2).ToString();
            juli();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            double.TryParse(tb.Text.ToString(), out this.经度2);

            textBox5.Text = System.Math.Abs(经度1 - 经度2).ToString();
            juli();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            double.TryParse(tb.Text.ToString(), out this.纬度1);
            textBox6.Text = System.Math.Abs(纬度1 - 纬度2).ToString();
            juli();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            double.TryParse(tb.Text.ToString(), out this.纬度2);
            textBox6.Text = System.Math.Abs(纬度1 - 纬度2).ToString();
            juli();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
        }

        private static double Rad(double d)
        {
            return (double)d * Math.PI / 180d;
        }

        private void  juli()
        {
            double radLat1 = Rad(纬度1);
            double radLng1 = Rad(经度1);
            double radLat2 = Rad(纬度2);
            double radLng2 = Rad(经度2);
            double a = radLat1 - radLat2;
            double b = radLng1 - radLng2;
            double result = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) + Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2))) * EARTH_RADIUS;
            textBox7.Text = result.ToString();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true) {
                EARTH_RADIUS = EARTH_RADIUS1;
            }
            else
            {
                EARTH_RADIUS = EARTH_RADIUS2;
            }
            juli();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                EARTH_RADIUS = EARTH_RADIUS1;
            }
            else
            {
                EARTH_RADIUS = EARTH_RADIUS2;
            }
            juli();

        }
    }
}
