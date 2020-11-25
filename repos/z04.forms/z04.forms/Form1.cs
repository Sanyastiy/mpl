using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace z04.forms
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try { 
            static float a(float n)
            {
                float x, y;
                x = float.Parse(Math.Pow(2, (n - 1)).ToString());
                y = float.Parse(Math.Pow(2, n).ToString());
                if ((x <= n) && (n <= y))
                {
                    return n;
                }
                else if (n == 1) { return 1; }
                else return a((n / 2) + 1);
            }

            {
                float n;
                n = float.Parse(textBox1.Text);
                label2.Text = (a(n)).ToString();
            }
        }
            catch (Exception) { }
}

        private void Button2_Click(object sender, EventArgs e)
        {
            try { 
            void ttt(int nmax, int n)
            {

                int je;
                if (n <= nmax)
                {
                    for (je = 1; je <= n; je++)
                        richTextBox1.Text+=(n);
                    richTextBox1.Text += Environment.NewLine;
                    ttt(nmax, n + 1);
                }
            }
            
            ttt(int.Parse(textBox3.Text), 1);
            Console.WriteLine();
            }
            catch (Exception) { }
        }
    }
}
