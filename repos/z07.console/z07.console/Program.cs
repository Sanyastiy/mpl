using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace z07.console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Удалить среднюю букву, если длина строки нечетная, и две средних, если длина строки четная press 1");
            Console.WriteLine("Удалить из сообщения все однобуквенные слова press 2");

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
                        string str;
                        string result;
                        Console.WriteLine(" Напишите строку ");
                        str = Console.ReadLine();
                        if (str.Length % 2 != 0) // определяем четное число символов в строке или нет
                            result = str.Remove((str.Length / 2), 1); // метод Remove удаляет один символ с индексом
                                                                      // (длина строки разделить попалам) 
                        else
                            result = str.Remove((str.Length / 2) - 1, 2);
                        Console.WriteLine(result);

                    }
                    else if (answer == 2)
                    {
                        Console.WriteLine("Введите строку состоящую из слов разделённых пробелом");
                        string inStr = Console.ReadLine();
                        var result = inStr.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Where(s => s.Length != 1);
                        string outStr = string.Join(" ", result.ToArray());
                        Console.WriteLine(outStr);
                        Console.ReadKey();
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
