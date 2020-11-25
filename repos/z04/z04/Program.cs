using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace z04
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int answer = -1;
                while (answer != 0)
                {
                    Console.WriteLine("1 to first task 2 to second");
                    answer = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    if (answer == 1)
                    {

                        static float a(float n)
                        {
                            float x, y;
                            x = float.Parse(Math.Pow(2, (n - 1)).ToString());
                            y = float.Parse(Math.Pow(2, n).ToString());
                            if ((x <= n) && (n <= y))
                            {
                                return n;
                            }
                            else if (n == 1) { Console.WriteLine("оу1"); return 1; }
                            else return a((n / 2) + 1);
                        }

                        {
                            float n;
                            Console.Write("n=");
                            n = float.Parse(Console.ReadLine());
                            Console.Write("a=");
                            Console.WriteLine(a(n));
                            Console.ReadKey();
                        }
                    }
                    if (answer == 2)
                    {
                        static void ttt(int nmax, int n)
                        {
                            int je;
                            if (n <= nmax)
                            {
                                for (je = 1; je <= n; je++)
                                    Console.Write(n + " ");
                                Console.WriteLine();
                                ttt(nmax, n+1);
                            }
                        }
                        Console.Write("enter final N=");
                        ttt(int.Parse(Console.ReadLine()), 1);
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception) { }
        }
        }
    }

