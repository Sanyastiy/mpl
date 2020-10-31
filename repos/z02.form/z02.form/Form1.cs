using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace z02.form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label3.Text = "";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
               
                float x = float.Parse(textBox1.Text);
                float y = float.Parse(textBox2.Text);
                if ((y>(float)Math.Abs(x)&&(x*x+y*y<15*15)))
                    label3.Text = "внутри";
                else if ((y > (float)Math.Abs(x) && (x * x + y * y <= 15*15)))
                    label3.Text = "на границе";
                else label3.Text = "вне";
            }
            catch (Exception) { label3.Text = "неверные данные"; }
        }
    }
}
