using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace z12.forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label2.Text = "";
        }
        class ArrayDouble
        {
            // Поля: •	double [][] DoubleArray; •	int n, m.
            int n, m;
            double[,] DoubleArray;

            // Конструктор, позволяющий создать массив размерности n×m.
            public ArrayDouble(int n, int m)
            {
                this.n = n;
                this.m = m;

                DoubleArray = new double[n, m];
            }

            public ArrayDouble() { }

            // Ввести элементы массива с клавиатуры;
            public void Enter_Array()
            {
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < m; j++)
                    {
                        Console.Write("Введите элемент DoubleArray[{0},{1}] = ", i, j);
                        DoubleArray[i, j] = double.Parse(Console.ReadLine());
                    }
            }
            public void ReadArray(DataGridView dataGridView)
            {
                double[,] matrs;
                //создаём новый массив размера dataGridView.RowCount на dataGridView.ColumnCount
                //где RowCount количество строк у элемента, а ColumnCount количество столбцов
                matrs = new double[dataGridView.RowCount, dataGridView.ColumnCount];
                try//отлов исключений
                {
                    for (int i = 0; i < dataGridView.RowCount; i++)
                    {
                        for (int j = 0; j < dataGridView.ColumnCount; j++)
                        {
                            //Преобразуем значения из ячеек в числа, и пишем в массив
                            //Если не число то происходит вызов исключения и его обработка
                            DoubleArray[i, j] = Convert.ToInt32(dataGridView.Rows[i].Cells[j].Value);
                        }
                    }
                }
                catch (System.Exception e)//обработка пойманного исключения
                {
                    // MessageBox.Show(e.Message + "\n(Использование букв и символов недопустимо!)", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Вывести элементы массива на экран
            public void Show(DataGridView dataGridView)
            {

                //указываем контроллу в который пишем количество строк и столбцов
                dataGridView.RowCount = DoubleArray.GetLength(0);
                dataGridView.ColumnCount = DoubleArray.GetLength(1);
                for (int i = 0; i < DoubleArray.GetLength(0); i++)
                {
                    for (int j = 0; j < DoubleArray.GetLength(1); j++)
                    {
                        //пишем значения из массива в ячейки контролла
                        dataGridView.Rows[i].Cells[j].Value = DoubleArray[i, j];
                    }
                }

            }

            // Отсортировать элементы каждой строки массива в порядке убывания.
            public void Sort()
            {
                bool a;
                double temp;
                for (int i = 0; i < n; i++)
                {
                    a = true;
                    while (a)
                    {
                        a = false;
                        for (int j = 0; j < m - 1; j++)
                        {
                            if (DoubleArray[i, j] < DoubleArray[i, j + 1])
                            {
                                temp = DoubleArray[i, j];
                                DoubleArray[i, j] = DoubleArray[i, j + 1];
                                DoubleArray[i, j + 1] = temp;
                                a = true;
                            }
                        }
                    }
                }
            }

            // Возвращающее общее количество элементов в массиве (доступное только для чтения);
            public int Total_Elements
            {
                get
                {
                    return n * m;
                }
            }


            //Двумерный индексатор, позволяющий обращаться к соответствующему элементу массива.
            public double this[int i, int j]
            {
                get { return DoubleArray[i, j]; }
            }

            // Операция ++: одновременно увеличивает значение всех элементов массива на 1;
            public static ArrayDouble operator ++(ArrayDouble obj)
            {
                for (int i = 0; i < obj.n; i++)
                    for (int j = 0; j < obj.m; j++)
                        obj.DoubleArray[i, j] = obj.DoubleArray[i, j] + 1;
                return obj;
            }

            // Операция --: одновременно уменьшает значение всех элементов массива на 1;
            public static ArrayDouble operator --(ArrayDouble obj)
            {
                for (int i = 0; i < obj.n; i++)
                    for (int j = 0; j < obj.m; j++)
                        obj.DoubleArray[i, j] = obj.DoubleArray[i, j] - 1;
                return obj;
            }

            // константа true: обращение к экземпляру класса дает значение true, если каждая строка массива упорядоченна по возрастанию, иначе false.
            public static bool operator true(ArrayDouble obj)
            {
                int count = 0;
                for (int i = 0; i < obj.n; i++)
                    for (int j = 0; j < obj.m - 1; j++)
                        if (obj.DoubleArray[i, j] > obj.DoubleArray[i, j + 1])
                            count++;
                if (count == 0)
                    return true;
                return false;
            }

            // Константа false: обращение к экземпляру класса дает значение true, если каждая строка массива упорядоченна по возрастанию, иначе false.
            public static bool operator false(ArrayDouble obj)
            {
                int count = 0;
                for (int i = 0; i < obj.n; i++)
                    for (int j = 0; j < obj.m - 1; j++)
                        if (obj.DoubleArray[i, j] > obj.DoubleArray[i, j + 1])
                            count++;
                if (count != 0)
                    return false;
                return true;
            }

            // Преобразования класса массив в ступенчатый массив (и наоборот)
            public static explicit operator double[][](ArrayDouble obj)
            {
                double[][] array = new double[obj.n][];
                for (int i = 0; i < obj.n; i++)
                {
                    array[i] = new double[obj.m];
                    for (int j = 0; j < obj.m; j++)
                        array[i][j] = obj.DoubleArray[i, j];
                }
                return array;
            }

            public static explicit operator ArrayDouble(double[][] array)
            {
                int n, m;
                n = array.Length;
                m = array[0].Length;
                ArrayDouble obj = new ArrayDouble(n, m);
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                        obj.DoubleArray[i, j] = array[i][j];
                }
                return obj;
            }

        }
        ArrayDouble array;
        private void button1_Click(object sender, EventArgs e)
        {
            int n = int.Parse(textBox1.Text);
            int m = int.Parse(textBox3.Text);
            array = new ArrayDouble(n,m);
            tabControl1.SelectedIndex = 1;
            dataGridView1.RowCount = n;
            dataGridView1.ColumnCount = m;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            array.ReadArray(dataGridView1);
            label2.Text = "Строки массива "+ ((array)?"":"не ") +"упорядочены по возростаню" + Environment.NewLine;
            tabControl1.SelectedIndex = 2;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            array++;
            array.Show(dataGridView1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            array--;
            array.Show(dataGridView1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            array.Sort();
            array.Show(dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ++array;
            array.Show(dataGridView1);
        }
    }
}
