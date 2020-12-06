using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace z09.forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var start = 6;
            var end = 11;
            var input = new[] { 5, 6, 7, 9, 10, 11, 20, 25, 30 };

            using (var sw = new StreamWriter("out1.txt"))
            {
               richTextBox2.Text+=("Исходная последовательность");
                foreach (var x in input)
                    richTextBox2.Text += (x + " ");

                richTextBox2.Text += Environment.NewLine;
                richTextBox2.Text += ("Последовательность входящая в интервал");
                foreach (var x in input)
                    if (x >= start && x <= end)
                    {
                        sw.WriteLine(x);
                        richTextBox2.Text += (x + " ");
                    }
                richTextBox2.Text += Environment.NewLine;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string a = char.Parse(richTextBox3.Text).ToString();
            using (StreamReader reader = new StreamReader("out2.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string s = reader.ReadLine();
                    if (s.StartsWith(a))
                    {
                        richTextBox4.Text+=s+Environment.NewLine;
                    }
                }
            }
        }
    }
}
