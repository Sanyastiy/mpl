using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace z11.forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label3.Text = "";
            label4.Text = "";
        }
        
        class ArrayDouble
        {
            // Поля: •	    int [,] IntArray; •	    int n.
            int[,] IntArray;
            int n;

            // Конструктор, позволяющий создать массив размерности n×n.
            public ArrayDouble(int n)
            {
                this.n = n;
                IntArray = new int[n, n];
            }

            //ввести элементы массива с клавиатуры;
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
                            IntArray[i, j] = Convert.ToInt32(dataGridView.Rows[i].Cells[j].Value);
                            }
                        }
                    }
                    catch (System.Exception e)//обработка пойманного исключения
                    {
                       // MessageBox.Show(e.Message + "\n(Использование букв и символов недопустимо!)", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                
            }

            //вывести элементы массива на экран;
            public void Show(DataGridView dataGridView)
            {
                             
                    //указываем контроллу в который пишем количество строк и столбцов
                    dataGridView.RowCount = IntArray.GetLength(0);
                    dataGridView.ColumnCount = IntArray.GetLength(1);
                    for (int i = 0; i < IntArray.GetLength(0); i++)
                    {
                        for (int j = 0; j < IntArray.GetLength(1); j++)
                        {
                            //пишем значения из массива в ячейки контролла
                            dataGridView.Rows[i].Cells[j].Value = IntArray[i, j];
                        }
                    }

                }
            

            //вычислить сумму элеметов i-того столбца.
            public int Calculate_Col(int k)
            {
                int sum = 0;
                for (int i = 0; i < n; i++)
                    sum += IntArray[i, k];
                return sum;
            }

            //позволяющее вычислить количество нулевых элементов в массиве (доступное только для чтения);
            public int Zero_Element
            {
                get
                {
                    int count = 0;
                    for (int i = 0; i < n; i++)
                        for (int j = 0; j < n; j++)
                        {
                            if (IntArray[i, j] == 0)
                                count++;
                        }
                    return count;
                }
            }

            // позволяющее установить значение всех элементы главной диагонали массива равное скаляру (доступное только для записи).
            public int Scal
            {
                set
                {
                    for (int i = 0; i < n; i++)
                        IntArray[i, i] = value;
                }
            }

            //Двумерный индексатор, позволяющий обращаться к соответствующему элементу массива.
            public int this[int index1, int index2]
            {
                get { return IntArray[index1, index2]; }
            }

 
            // Преобразования класса массив в двумерный массив (и наоборот).
            public static explicit operator int[,] (ArrayDouble obj)
            {
                return obj.IntArray;
            }

            public static explicit operator ArrayDouble(int[,] array)
            {
                ArrayDouble obj = new ArrayDouble(array.Length);
                array.CopyTo(obj.IntArray, 0);
                return obj;
            }


        }

        ArrayDouble array;
        private void Button1_Click(object sender, EventArgs e)
        {
            int n = int.Parse(textBox1.Text);
            array = new ArrayDouble(n);
            tabControl1.SelectedIndex = 1;
            dataGridView1.RowCount = n;
            dataGridView1.ColumnCount = n;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            array.ReadArray(dataGridView1);
            label4.Text = "Количество нулевых элементов " +Environment.NewLine+ array.Zero_Element;
            tabControl1.SelectedIndex = 2;
            button3.Visible = true;
            button5.Visible = true;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            int col = int.Parse(textBox2.Text);
            label3.Text = "Сумма колонки " + col.ToString() + " равна "+ array.Calculate_Col(col-1);
        }


        private void Button5_Click(object sender, EventArgs e)
        {
            array.Scal = 5;
            array.Show(dataGridView1);
        }
    }
}
