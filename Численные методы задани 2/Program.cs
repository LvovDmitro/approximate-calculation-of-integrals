using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Численные_методы_задани_2
{
    class Program
    {
        static double Series(double x, double Eps)//вычисление ряда как в прошлом задании
        {
            double a0 = (-Math.Pow(x, 2)) / 4, a1 = 0, sum = a0, q;
            int i = 1;

            while (!(Math.Abs(a1) < Eps && a1 != 0))
            {
                q = ((-1) * x * x * i) / ((i + 1) * (2 * i + 1) * (2 * i + 2));
                a1 = a0 * q;
                sum += a1;
                a0 = a1;
                i++;
            }

            return sum;
        }

        static int n = 2;

        static double RightRectangle(double x, double Eps)//правых прямоугольников
        {
            double b2 = x, a2 = 0, sum1 = 0, sum2 = 0;
            n = 2;

            while (!(n == 1024 || (Math.Abs(sum2 - sum1) < Eps && (sum1 != 0 && sum2 != 0))))
            {
                sum1 = sum2;
                sum2 = 0;
                double h2 = (b2 - a2) / n, t = 0;

                for (int i = 0; i <= n; i++)
                {
                    t = a2 + i * h2;
                    if (t != 0)
                    {
                        sum2 += h2 * ((Math.Cos(t) - 1) / t);
                    }
                    else
                    {
                        sum2 += 0;
                    }
                }

                n *= 2;
            }

            return sum2;
        }



        static double MediumRectangle(double x, double Eps)//центральных
        {
            double b2 = x, a2 = 0, sum1 = 0, sum2 = 0;
            n = 2;

            while (!(n == 1024 || Math.Abs(sum2 - sum1) < Eps && (sum1 != 0 && sum2 != 0)))
            {
                sum1 = sum2;
                sum2 = 0;
                double h2 = (b2 - a2) / n, t = 0;

                for (int i = 0; i < n; i++)
                {
                    t = a2 + i * h2;
                    sum2 += h2 * (Math.Cos((t + (t + h2)) / 2) - 1) / ((t + (t + h2)) / 2);
                }

                n *= 2;
            }

            return sum2;
        }

        static double Trapeze(double x, double Eps)//трапеции
        {
            double b2 = x, a2 = 0, sum1 = 0, sum2 = 0;
            n = 2;

            while (!(n == 1024 || Math.Abs(sum2 - sum1) < Eps && (sum1 != 0 && sum2 != 0)))
            {
                sum1 = sum2;
                sum2 = 0;
                double h2 = (b2 - a2) / n, t = 0;

                for (int i = 0; i < n; i++)
                {
                    t = a2 + i * h2;
                    if (t != 0)
                    {
                        sum2 += h2 / 2 * ((Math.Cos(t) - 1) / t + (Math.Cos(t + h2) - 1) / (t + h2));
                    }
                    else
                    {
                        sum2 += h2 / 2 * (0 + (Math.Cos(t + h2) - 1) / (t + h2));
                    }
                }

                n *= 2;
            }

            return sum2;
        }

        static double Simpson(double x, double Eps)//симпсона
        {
            double b2 = x, a2 = 0, sum1 = 0, sum2 = 0;
            n = 2;

            while (!(n == 1024 || Math.Abs(sum2 - sum1) < Eps && (sum1 != 0 && sum2 != 0)))
            {
                sum1 = sum2;
                sum2 = 0;
                double h2 = (b2 - a2) / n, t = 0;

                for (int i = 0; i < n; i++)
                {
                    t = a2 + i * h2;
                    if (t != 0)
                    {
                        sum2 += h2 / 6 * ((Math.Cos(t) - 1) / t + (Math.Cos(t + h2) - 1) / (t + h2) + 4 * ((Math.Cos((t + (t + h2)) / 2) - 1) / ((t + (t + h2)) / 2)));
                    }
                    else
                    {
                        sum2 += h2 / 6 * (0 + (Math.Cos(t + h2) - 1) / (t + h2) + 4 * ((Math.Cos((t + (t + h2)) / 2) - 1) / ((t + (t + h2)) / 2)));
                    }
                }

                n *= 2;
            }

            return sum2;
        }

        static double Gaus(double x, double Eps)//гауса
        {
            double b2 = x, a2 = 0, sum1 = 0, sum2 = 0;
            n = 2;

            while (!(n == 1024 || Math.Abs(sum2 - sum1) < Eps && (sum1 != 0 && sum2 != 0)))
            {
                sum1 = sum2;
                sum2 = 0;
                double h2 = (b2 - a2) / n, t = 0;

                for (int i = 0; i < n; i++)
                {
                    t = a2 + i * h2;
                    sum2 += h2 / 2 * ((Math.Cos(t + h2 / 2 * (1 - 1 / Math.Sqrt(3))) - 1) / (t + h2 / 2 * (1 - 1 / Math.Sqrt(3))) + (Math.Cos(t + h2 / 2 * (1 + 1 / Math.Sqrt(3))) - 1) / (t + h2 / 2 * (1 + 1 / Math.Sqrt(3))));
                }

                n *= 2;
            }

            return sum2;
        }

        static void Main(string[] args)
        {
            double Eps = Math.Pow(10, -6), a1 = 0.4, b1 = 4.0, h1 = (b1 - a1) / 10;

            Console.WriteLine("Для правых прямоугольников:\n");
            Console.WriteLine("x:           S(x):                 Y(x):                n            Z:");
            for (double x = a1; x <= b1; x += h1)
            {

                Console.WriteLine("{0:f2}        {1:f11}        {2:f11}        {3}         {4:f11}", x, Series(x, Eps), RightRectangle(x, Eps), n, Math.Abs(Series(x, Eps) - RightRectangle(x, Eps)));
            }

            Console.WriteLine("\nДля средних прямоугольников:\n");
            Console.WriteLine("x:           S(x):                 Y(x):                n            Z:");
            for (double x = a1; x <= b1; x += h1)
            {

                Console.WriteLine("{0:f2}        {1:f11}        {2:f11}        {3}         {4:f11}", x, Series(x, Eps), MediumRectangle(x, Eps), n / 2, Math.Abs(Series(x, Eps) - MediumRectangle(x, Eps)));
            }

            Console.WriteLine("\nДля трапеций:\n");
            Console.WriteLine("x:           S(x):                 Y(x):                n            Z:");
            for (double x = a1; x <= b1; x += h1)
            {
                Console.WriteLine("{0:f2}        {1:f11}        {2:f11}        {3}         {4:f11}", x, Series(x, Eps), Trapeze(x, Eps), n / 2, Math.Abs(Series(x, Eps) - Trapeze(x, Eps)));
            }

            Console.WriteLine("\nДля Симпсона:\n");
            Console.WriteLine("x:           S(x):                 Y(x):                n            Z:");
            for (double x = a1; x <= b1; x += h1)
            {
                Console.WriteLine("{0:f2}        {1:f11}        {2:f11}        {3}         {4:f11}", x, Series(x, Eps), Simpson(x, Eps), n / 2, Math.Abs(Series(x, Eps) - Simpson(x, Eps)));
            }

            Console.WriteLine("\nДля Гаусса:\n");
            Console.WriteLine("x:           S(x):                 Y(x):                n            Z:");
            for (double x = a1; x <= b1; x += h1)
            {
                Console.WriteLine("{0:f2}        {1:f11}        {2:f11}        {3}         {4:f11}", x, Series(x, Eps), Gaus(x, Eps), n / 2, Math.Abs(Series(x, Eps) - Gaus(x, Eps)));
            }

            Console.ReadKey();
        }
    }
}
