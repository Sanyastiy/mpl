using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace z06.console
{
    class Class
    {
        static int[] Input()
        {
            Console.WriteLine("введите размерность массива");
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n];
            Random rand = new Random();
            for (int i = 0; i < n; ++i)
            {
                a[i] = rand.Next(-20,20); 
            }
            return a;
        }

        static void Print(int[] a)
        {
            for (int i = 0; i < a.Length; ++i) Console.Write("{0} ", a[i]);
            Console.WriteLine();
        }

        static void Change(int[] a)
        {
            int count = 0;
            double avg = 0;
            for (int i = 0; i < a.Length; ++i)
                if (a[i] < 0) { avg += a[i]; count++; }
            avg /= count;
            Console.WriteLine(avg);
        }


        static int[,] Input2(out int n, out int m)
        {
            Console.WriteLine("введите размерность массива");
            Console.Write("n = ");
            n = int.Parse(Console.ReadLine());
            Console.Write("m = ");
            m = int.Parse(Console.ReadLine());
            int[,] a = new int[n, m];
            Random rand = new Random();
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < m; ++j)
                {
                    a[i, j] = rand.Next(-20, 20);
                }
            return a;
        }

        static void Print2(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); ++i, Console.WriteLine())
                for (int j = 0; j < a.GetLength(1); ++j)
                    Console.Write("{0,5} ", a[i, j]);
        }

        static void Change2(int[,] a)
        {
            int count = 0;
            double avg = 0;
            for (int i = 0; i < a.GetLength(0); ++i)
                for (int j = 0; j < a.GetLength(1); ++j)
                    if (a[i, j] < 0) { avg += a[i, j]; count++; }
            avg /= count;
            Console.WriteLine(avg);
        }


        static int Min(int[] a)
        {
            int min = a[0];
            for (int i = 1; i < a.Length; ++i)
                if (a[i] > min) min = a[i];
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

        static int[,] Input3(out int n)
        {
            Console.WriteLine("введите размерность массива");
            Console.Write("n = ");
            n = int.Parse(Console.ReadLine());
            int[,] a = new int[n, n];
            Random rand = new Random();
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < n; ++j)
                {
                    a[i, j] = rand.Next(-20, 20);
                }
            return a;
        }
        static void Print3(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); ++i, Console.WriteLine())
                for (int j = 0; j < a.GetLength(1); ++j)
                    Console.Write("{0,5} ", a[i, j]);
        }


        static int Pol4(int[,] a)
        {
            Console.WriteLine();
            int[] sum = new int[a.GetLength(1)];
            for (int i = 0; i < a.GetLength(1); ++i)
            {
                for (int j = 0; j < a.GetLength(0); ++j)
                {
                    if (a[j, i] < 0)
                        sum[i] += a[j, i];
                }
            }
            Print(sum);
            return 0;
        }

        static void Main(string[] args)
                {
                    Console.WriteLine("To calculate avarage of negative numbers of [] press 1");
                    Console.WriteLine("To calculate avarage of negative numbers of [,] press 2");
                    Console.WriteLine("To calculate first minimal number press 3");
                    Console.WriteLine("Поменять местами две средних строки, если количество строк четное, и первую со средней строкой, если количество строк нечетное. 4");
                    Console.WriteLine("Для каждого столбца подсчитать сумму отрицательных элементов и записать данные в новый массив.  press 5");
                    Console.WriteLine("To exit press 0");
                    int answer = -1;
                    while (answer != 0)
                    {
                        try
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Your choise");
                            answer = int.Parse(Console.ReadLine());
                    if (answer == 1)
                    {
                        int[] myArray = Input();
                        Console.WriteLine("Исходный массив:");
                        Print(myArray);
                        Change(myArray);
                        Console.ReadKey();
                    }
                    else if (answer == 2)
                    {
                        int n, m;
                        int[,] myArray = Input2(out n, out m);
                        Console.WriteLine("Исходный массив:");
                        Print2(myArray);
                        Change2(myArray);
                    }
                    else if (answer == 3)
                    {
                        int[] myArray = Input();
                        int min = Min(myArray);
                        int kol = 0;
                        for (int i = 0; i < myArray.Length; ++i)
                            if (myArray[i] == min) { kol = i; break; }
                        Console.WriteLine("номер первого минимального элемента = " + kol);
                    }
                    else if (answer == 4)
                    {
                        int n;
                        int[,] myArray = Input3(out n);
                        Console.WriteLine("Исходный массив:");
                        Print3(myArray);
                        Console.WriteLine("Полученный массив:");
                        Rezalt(myArray);
                        Print3(myArray);
                    }
                    else if (answer == 5)
                    {
                        int n, m;
                        int[,] myArray = Input2(out n, out m);
                        Console.WriteLine("Исходный массив:");
                        Print2(myArray);
                        Pol4(myArray);
                    }
                    else if (answer == 0)
                    {
                        break;
                    }
                    else Console.WriteLine("неверный вариант");

                        }
                        catch (Exception) { Console.WriteLine("Неверные данные"); }
                        Console.ReadKey();
                    }
                }
            }
        }
    