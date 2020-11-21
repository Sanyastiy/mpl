using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace z03.console
{
    class Program
    {
        static void Main(string[] args)
        {       
                Console.WriteLine("To calculate f(x) press 1");
                Console.WriteLine("To calculate y press 2");
                Console.WriteLine("To calculate overload x and y function press 3");
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
                        Console.Write("x=");
                        int x = int.Parse(Console.ReadLine());
                        x = Math.Abs(x);

                        if (x < 10)
                            Console.WriteLine("Число однозначное");
                        else
                            Console.WriteLine("f(" + x + ")= " + (x / 10 % 10));
                    }
                    else if (answer == 2)
                    {
                        static double f(double x)
                        {
                            double y;
                            if ((x * x + 2 * x + 1) < 2) y = Math.Pow(x, 2);
                            else if (2 <= (x * x + 2 * x + 1) && 3 > (x * x + 2 * x + 1)) y = 1 / (Math.Pow(x, 2) - 1);
                            else y = 0;
                            return y;
                        }
                        Console.Write("from a=");
                        double a = double.Parse(Console.ReadLine());
                        Console.Write("to b=");
                        double b = double.Parse(Console.ReadLine());
                        Console.Write("with h step=");
                        double h = double.Parse(Console.ReadLine());
                        for (double i = a; i <= b; i += h)
                            Console.WriteLine("f({0:f2})={1:f4}", i, f(i));
                    }
                    else if (answer == 3)
                    {
                        static double f(double x, out double y)
                        {
                            double yy;
                            if ((x * x + 2 * x + 1) < 2)
                            {
                                yy = Math.Pow(x, 2);
                            }
                            else if (2 <= (x * x + 2 * x + 1) && 3 > (x * x + 2 * x + 1))
                            {
                                yy = 1 / (Math.Pow(x, 2) - 1);
                            }
                            else yy = 0;
                            y = yy;
                            return yy;
                        }

                        Console.Write("from a=");
                        double a = double.Parse(Console.ReadLine());
                        Console.Write("to b=");
                        double b = double.Parse(Console.ReadLine());
                        Console.Write("with h step=");
                        double h = double.Parse(Console.ReadLine());
                        double yy, ii;
                        for (double i = a; i <= b; i += h)
                        {
                            ii = f(i, out yy);
                            Console.WriteLine("f({0:f2})={1:f4}, {2}", i, ii, yy);
                        }
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
