using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace z06.forms
{
    public partial class Form1 : Form
    {
        static int[] Input(int n)
        {
            int[] a = new int[n];
            Random rand = new Random();
            for (int i = 0; i < n; ++i)
            {
                a[i] = rand.Next(-20, 20);
            }
            return a;
        }


        static double Change(int[] a)
        {
            int count = 0;
            double avg = 0;
            for (int i = 0; i < a.Length; ++i)
                if (a[i] < 0) { avg += a[i]; count++; }
            avg /= count;
            return avg;
        }


        static int[,] Input2(int n, int m)
        {
            int[,] a = new int[n, m];
            Random rand = new Random();
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < m; ++j)
                {
                    a[i, j] = rand.Next(-20, 20);
                }
            return a;
        }


        static double Change2(int[,] a)
        {
            int count = 0;
            double avg = 0;
            for (int i = 0; i < a.GetLength(0); ++i)
                for (int j = 0; j < a.GetLength(1); ++j)
                    if (a[i, j] < 0) { avg += a[i, j]; count++; }
            avg /= count;
            return avg;
        }


        static int Min(int[] a)
        {
            int min = a[0];
            for (int i = 1; i < a.Length; ++i)
                if (a[i] < min) min = a[i];
            return min;
        }

        static void Rezalt(int[,] a)
        {
            int row1;
            int row2;
            if (a.GetLength(0) % 2 == 0)
            {
                row1 = a.GetLength(0) / 2;
                row2 = row1 - 1;
            }
            else
            {
                row1 = a.GetLength(0) / 2;
                row2 = 0;
            }
            for (int i = 0; i < a.GetLength(1); i++)
            {
                int tmp = a[row1, i];
                a[row1, i] = a[row2, i];
                a[row2, i] = tmp;
            }
        }


        static int[] Pol4(int[,] a)
        {
            int[] sum = new int[a.GetLength(1)];
            for (int i = 0; i < a.GetLength(1); ++i)
            {
                for (int j = 0; j < a.GetLength(0); ++j)
                {
                    if (a[j, i] < 0)
                        sum[i] += a[j, i];
                }
            }
            return sum;
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            int[] myArray = Input(int.Parse(textBox2.Text));
            richTextBox1.Text += "Исходный массив:";
            richTextBox1.Text += Environment.NewLine;
            for (int i = 0; i < myArray.Length; ++i)
                richTextBox1.Text += myArray[i].ToString() + " ";
            richTextBox1.Text += Environment.NewLine;
            richTextBox1.Text += "average" + Environment.NewLine + Change(myArray) + Environment.NewLine;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            int[,] myArray = Input2(int.Parse(textBox6.Text), int.Parse(textBox7.Text));
            for (int i = 0; i < myArray.GetLength(0); ++i) {
                for (int j = 0; j < myArray.GetLength(1); ++j)
                    richTextBox2.Text += myArray[i,j].ToString() + " ";
                richTextBox2.Text += Environment.NewLine;
            }
            richTextBox2.Text += Environment.NewLine;
            richTextBox2.Text += "average" + Environment.NewLine + Change2(myArray) + Environment.NewLine;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int[] myArray = Input(int.Parse(textBox1.Text));
            int min = Min(myArray);
            int kol = 0;
            for (int i = 0; i < myArray.Length; ++i)
            {
                richTextBox3.Text += myArray[i].ToString() +" ";
            }
            richTextBox3.Text += Environment.NewLine;
            for (int i = 0; i < myArray.Length; ++i)
            {
                if (myArray[i] == min) { kol = i; break; }
            }
            richTextBox3.Text += Environment.NewLine;
            richTextBox3.Text += "номер первого минимального элемента = " + Environment.NewLine + kol + Environment.NewLine;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            int[,] myArray = Input2(int.Parse(textBox3.Text), int.Parse(textBox4.Text));
            for (int i = 0; i < myArray.GetLength(0); ++i)
            {
                for (int j = 0; j < myArray.GetLength(1); ++j)
                    richTextBox4.Text += myArray[i, j].ToString() + " ";
                richTextBox4.Text += Environment.NewLine;
            }
            Rezalt(myArray);
            richTextBox4.Text +="измененный массив"+ Environment.NewLine;
            for (int i = 0; i < myArray.GetLength(0); ++i)
            {
                for (int j = 0; j < myArray.GetLength(1); ++j)
                    richTextBox4.Text += myArray[i, j].ToString() + " ";
                richTextBox4.Text += Environment.NewLine;
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            
            int[,] myArray = Input2(int.Parse(textBox5.Text), int.Parse(textBox8.Text));
            richTextBox5.Text += "исходный массив"+ Environment.NewLine;
            for (int i = 0; i < myArray.GetLength(0); ++i)
            {
                for (int j = 0; j < myArray.GetLength(1); ++j)
                    richTextBox5.Text += myArray[i, j].ToString() + " ";
                richTextBox5.Text += Environment.NewLine;
            }
            richTextBox5.Text += Environment.NewLine + " cумма отрицательных элементов по колонкам"+ Environment.NewLine;
            int[] sum = Pol4(myArray);
            for (int i = 0; i < sum.Length; ++i)
                richTextBox5.Text += sum[i].ToString() + " ";
            richTextBox5.Text += Environment.NewLine;
        }
    }
}
