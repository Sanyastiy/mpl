using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace z02.console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("x=");
                float x = float.Parse(Console.ReadLine());
                Console.Write("y=");
                float y = float.Parse(Console.ReadLine());
                if ((y > (float)Math.Abs(x) && (x * x + y * y < 15 * 15)))
                Console.WriteLine("внутри");
                else if ((y > (float)Math.Abs(x) && (x * x + y * y <= 15 * 15)))
                    Console.WriteLine("на границе");
                else Console.WriteLine("вне");
                Console.ReadKey();
            }
            catch (Exception) { Console.WriteLine("неверные данные"); Console.ReadKey(); }
        }

    }
}

