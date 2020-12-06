using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace z08.console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Удалите из сообщения все русские слова press 1");
            
                try
                {
                    
                        string str;
                        string result;
                        Console.WriteLine(" Напишите строку ");
                        str = Console.ReadLine();

                        result = Regex.Replace(str, @"\b[а-я]+", "");
                        Console.WriteLine(result);     
                    Console.ReadKey();
                }

                catch (Exception) { Console.WriteLine("Неверные данные"); }
            }
        }
    }

