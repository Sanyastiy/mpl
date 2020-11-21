using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace z03.form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int x = int.Parse(textBox1.Text);
                x = Math.Abs(x);
                if (x < 10)
                    label2.Text = "Число однозначное";
                else
                    label2.Text = "f(" + x + ")= " + (x / 10 % 10);
            }
            catch (Exception) { }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            try
            {
                static double f(double x)
            {
                double y;
                if ((x * x + 2 * x + 1) < 2) y = Math.Pow(x, 2);
                else if (2 <= (x * x + 2 * x + 1) && 3 > (x * x + 2 * x + 1)) y = 1 / (Math.Pow(x, 2) - 1);
                else y = 0;
                return y;
            }
            double a = double.Parse(textBox2.Text);
            double b = double.Parse(textBox3.Text);
            double h = double.Parse(textBox4.Text);
            for (double i = a; i <= b; i += h) {
                    richTextBox1.Text += ("f(" + i + ")=" +f(i)+ Environment.NewLine);
                }

            }
            catch (Exception) { }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            try
            {
                static double f(double x, out double y)
            {
                double yy;
                if ((x * x + 2 * x + 1) < 2)
                {
                    yy = Math.Pow(x, 2);
                }
                else if (2 <= (x * x + 2 * x + 1) && 3 > (x * x + 2 * x + 1))
                {
                    yy = 1 / (Math.Pow(x, 2) - 1);
                }
                else yy = 0;
                y = yy;
                return yy;
            }
            double a = double.Parse(textBox7.Text);
            double b = double.Parse(textBox6.Text);
            double h = double.Parse(textBox5.Text);
            double yy, ii;
            for (double i = a; i <= b; i += h)
            {
                ii = f(i, out yy);
                richTextBox2.Text += ("f(" + i + ")=" + ii +" "+ yy + Environment.NewLine);
            }
        }
            catch (Exception exp) { MessageBox.Show(exp.ToString()); }
}
    }
    
    }

