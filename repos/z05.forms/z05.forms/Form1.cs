using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace z05.forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            double f(double x)
            {
                try
                {
                    //если х не попадает в область определения, то генерируется исключение 
                    if (Math.Abs(x) == 2) throw new Exception();
                    else return Math.Log(4 - Math.Pow(x, 2));
                }
                catch
                {
                    throw;
                }
            }
            try
            {
                double a = double.Parse(textBox2.Text);
                double b = double.Parse(textBox3.Text);
                double h = double.Parse(textBox4.Text);
                for (double i = a; i <= b; i += h)
                    try
                    {
                        if (Double.IsNaN(f(i)))
                            richTextBox1.Text += ("y(" + i + ")= за пределами значения функции "+ Environment.NewLine); 
                            else richTextBox1.Text+=("y(" +i+")= "+f(i) + Environment.NewLine);
                    }
                    catch
                    {
                        richTextBox1.Text += ("y(" + i + ")= функция не определена (0)" + Environment.NewLine);
                    }
            }
            catch (FormatException)
            {
                richTextBox1.Text += ("Неверный формат ввода данных");
            }
            catch
            {
                richTextBox1.Text += ("Неизвестная ошибка");
            }
           
        }

    }
}
