using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] k = new int[4] { 0, 0, 0, 0 };
            int d = 0;
            string str;
            for (int i = 0; i < 4; i++)
            {
                str = Console.ReadLine();
                if (int.TryParse(str, out k[i]))
                {

                }
                else
                {
                    k[i] = 0;
                    Console.WriteLine("Ошибка ввода коэффициента");
                }
            }
            k[2] = k[2] - k[3];
            d = k[1] * k[1] - 4 * k[0] * k[2];

            if (d > 0)
            {
                double x1 = -k[1] + d;
                x1 = x1 / 2;
                x1 = x1 / k[0];
                double x2 = -k[1] - d;
                x2 = x2 / 2;
                x2 = x2 / k[0];
                Console.WriteLine("Корни вашего уравнения ");
                Console.WriteLine(x1);
                Console.WriteLine(x2);
            }
            else
            {
                if (d == 0)
                {
                    double x = -k[1] / 2;
                    x = x / k[0];
                    Console.WriteLine("Корни вашего уравнения совпадают и являются  ");
                    Console.WriteLine(x);
                }
                else
                {
                    Console.WriteLine("Данное уравнение имеет только комплексные корни");
                }
                Console.ReadLine();
            }
        }
    }
}
