using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace z07.forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string str;
            string result;

            str = richTextBox1.Text;
            if (str.Length % 2 != 0) // определяем четное число символов в строке или нет
                result = str.Remove((str.Length / 2), 1); // метод Remove удаляет один символ с индексом
                                                          // (длина строки разделить попалам) 
            else
                result = str.Remove((str.Length / 2) - 1, 2);
            richTextBox2.Text=result;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string inStr = richTextBox3.Text;
            var result = inStr.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(s => s.Length != 1);
            string outStr = string.Join(" ", result.ToArray());
            richTextBox4.Text = outStr;
        }
    }
}
