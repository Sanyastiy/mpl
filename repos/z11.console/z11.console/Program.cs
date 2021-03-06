﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArrayDouble
{
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
        public void ReadArray()
        {
            Console.WriteLine("Введите элементы массива:");
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    Console.Write("IntArray[{0},{1}] = ", i, j);
                    IntArray[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            Console.WriteLine("Длина массива: " + IntArray.Length);
        }

        //вывести элементы массива на экран;
        public void Show()
        {
            Console.WriteLine("Массив:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(" [{0},{1}] = {2}", i, j, IntArray[i, j]);
                Console.WriteLine();
            }
        }

        //вычислить сумму элеметов i-того столбца.
        public int Calculate_Row(int k)
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

        public int DefaultSize
        {
            get
            {                
                return n;
            }
            set
            {
                n = value;
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
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива: ");
            int n = int.Parse(Console.ReadLine());
            ArrayDouble array = new ArrayDouble(n);

            Console.WriteLine("\nВведите массив: ");
            array.ReadArray();

            Console.WriteLine("\nВывести элементы массива на экран:");
            array.Show();

            Console.WriteLine(array.DefaultSize);
            array.DefaultSize = 3;
            Console.WriteLine(array.DefaultSize);
            array.ReadArray();
            array.Show();

            Console.WriteLine("\nВведите номер столбца, сумму которого необходимо вычислить:");
            int row = int.Parse(Console.ReadLine());
            Console.WriteLine("Summ = {0}", array.Calculate_Row(row));

            Console.WriteLine("\nКоличество нулевых элементов: {0}", array.Zero_Element);

            Console.WriteLine("\nУстановить значение всех элементы главной диагонали массива равное скаляру (5): ");
            array.Scal = 5;
            array.Show();

            Console.ReadLine();

        }
    }
}