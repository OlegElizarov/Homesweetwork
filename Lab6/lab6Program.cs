using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    public delegate double Calc(int p1, int p2, double p3);
    class Program
    {
        public static double PlusMinus(int p1, int p2, double p3)
        {
            return p1 + p2 - p3;
        }
        public static double MinusMinus(int p1, int p2, double p3)
        {
            return p1 - p2 - p3;
        }

        public static double PlusDivide(int p1, int p2, double p3)
        {
            return (p1 + p2) / p3;
        }

        public static void CalcMethod(int p1, int p2, double p3, Calc c)
        {
            double result = c(p1, p2, p3);
            Console.WriteLine(result);
        }

        public static void CalcFuncMethod(int p1, int p2, double p3, Func<int, int, double, double> f)
        {
            double result = f(p1, p2, p3);
            Console.WriteLine(result);
        }

        static void Main(string[] args)
        {
        /*    // часть 1
            int i1 = 10, i2 = 5;
            double i3 = 2;
            Console.WriteLine("Вызовы методов, принимающих обыкновенный делегат.");
            CalcMethod(i1, i2, i3, PlusMinus);
            CalcMethod(i1, i2, i3, MinusMinus);
            CalcMethod(i1, i2, i3, PlusDivide);
            CalcMethod(i1, i2, i3, (int x, int y, double z) => {
                double res = (x * y) / z;
                return res;
            });
            Console.WriteLine("Вызовы методов, принимающих обобщенный делегат типа Func.");
            CalcFuncMethod(i1, i2, i3, PlusMinus);
            CalcFuncMethod(i1, i2, i3, MinusMinus);
            CalcFuncMethod(i1, i2, i3, PlusDivide);
            CalcFuncMethod(i1, i2, i3, (int x, int y, double z) => {
                double res = (x * y) / z;
                return res;
            });
            Console.ReadLine(); */

            // часть 2
            Circle obj = new Circle(3.5);
            Type t = obj.GetType();
            Console.WriteLine("Рефлексия.\n\nИнформация о типе: ");
            Console.WriteLine($"Пространство имён {t.Namespace}\nИмя: {t.FullName}\nСборка: {t.AssemblyQualifiedName}");
            Console.WriteLine("\nКонструкторы:");
            foreach (var x in t.GetConstructors())
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("\nПоля:");
            foreach (var x in t.GetFields())
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("\nСвойства:");
            foreach (var x in t.GetProperties())
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("\nМетоды:");
            foreach (var x in t.GetMethods())
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("\nСвойства с атрибутами:");
            foreach (var x in t.GetProperties())
            {
                if (x.GetCustomAttributes(typeof(PropAttr), false).Length > 0)
                {
                    Console.WriteLine(x + " " + PropAttr.Description);
                }
            }
            string method = "ToString";
            Console.WriteLine($"\nВызов метода {method} с помощью рефлексии:");
            object result = t.InvokeMember(method, System.Reflection.BindingFlags.InvokeMethod, null, obj, null);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }

}
    
