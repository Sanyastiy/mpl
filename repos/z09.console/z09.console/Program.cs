using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace z09.console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Создать файл и записать в него числа последовательности, попадающие в заданный интервал press 1");
            Console.WriteLine("Дан текстовый файл. Выяснить, имеется ли в нем строка, которая начинается с данной буквы. Если да, то напечатать ее press 2");
            Console.WriteLine("Выход press 0");

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
                        var start = 6;
                        var end = 11;
                        var input = new[] { 5, 6, 7, 9, 10, 11, 20, 25, 30 };

                        using (var sw = new StreamWriter("out1.txt"))
                        {
                            Console.WriteLine("Исходная последовательность");
                            foreach (var x in input)
                                Console.Write(x + " ");
                            
                            Console.WriteLine("");
                            Console.WriteLine("Последовательность входящая в интервал");
                            foreach (var x in input)
                                if (x >= start && x <= end)
                                {
                                    sw.WriteLine(x);
                                    Console.Write(x+" ");
                                }
                            Console.WriteLine("");
                        }
                    }
                    else if (answer == 2)
                    {
                        Console.Write("Введите заданную букву: ");
                        string a = char.Parse(Console.ReadLine()).ToString();
                        using (StreamReader reader = new StreamReader("out2.txt"))
                        {
                            while (!reader.EndOfStream)
                            {
                                string s = reader.ReadLine();
                                if (s.StartsWith(a))
                                {
                                    Console.WriteLine(s);
                                }
                            }
                        }

                    }
                    else if (answer == 0)
                    {
                        break;
                    }
                    else Console.WriteLine("неверный вариант");
                    Console.ReadKey();
                }
                catch (Exception) { Console.WriteLine("Неверные данные"); }
            }
        }
    }
}
