using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{

    class Program
    {
        public class employee
        {
            public int emp_id;
            public string surname;
            public int dep_id;
            public employee(int i, string s, int v)
            {
                this.emp_id = i;
                this.surname = s;
                this.dep_id = v;
            }
            public override string ToString()
            {
                return "(id=" + this.emp_id.ToString() + "; surname=" + this.surname + "; dep_id=" + this.dep_id + ")";
            }
        }

        public class department
        {
            public int dep_id;
            public string dep_name;

            public department(int i, string n)
            {
                this.dep_id = i;
                this.dep_name = n;
            }

            public override string ToString()
            {
                return "(id=" + this.dep_id.ToString() + "; name=" + this.dep_name;
            }
        }

        static List<employee> employees = new List<employee>() {
            new employee(1, "Елизаров", 3),
            new employee(2, "Кокорина", 2),
            new employee(3, "Столяров", 3),
            new employee(4, "Кривцов", 1),
            new employee(5, "Токаев", 4),
            new employee(6, "Труфанов", 2),
        };

        static List<department> departments = new List<department> {
            new department(1, "Отдел кадров"),
            new department(2, "Бухгалтерия"),
            new department(3, "Администрация"),
            new department(4, "Маркетинг"),
        };

        public class DepartmentEmployee
        {
            public int emp_id; 
            public int dep_id; 
            public DepartmentEmployee(int eID, int dID)
            {
                emp_id = eID;
                dep_id = dID;
            }
        }
        /// Эзкемпляры связи "Отдел"-"Сотрудник" вида многие-ко-многим
        static List<DepartmentEmployee> DepartmentEmployees = new List<DepartmentEmployee> {
            new DepartmentEmployee(1, 3),
            new DepartmentEmployee(2, 2),
            new DepartmentEmployee(3, 3),
            new DepartmentEmployee(4, 1),
            new DepartmentEmployee(5, 4),
            new DepartmentEmployee(6, 2),
            
        };

        static void Main(string[] args)
        {
            Console.WriteLine("ОТДЕЛ - СОТРУДНИК: 1 - М\n");
            Console.WriteLine("\nСотрудники по отделам: \n");
            var q1 = from x in departments
                     join y in employees on x.dep_id equals y.dep_id into g
                     orderby x.dep_id ascending
                     select new { Dep = x, Emps = g.OrderBy(g => g.surname) };
            foreach (var x in q1)
            {
                Console.WriteLine(x.Dep + ":");
                foreach (var y in x.Emps)
                {
                    Console.WriteLine("    " + y);
                }
            }

            Console.WriteLine("\nЧисло сотрудников в отделах:\n");
            var q2 = from x in departments
                     join y in employees on x.dep_id equals y.dep_id into g
                     select new { Dep = x.dep_name, Emps = g.Count() };
            foreach (var x in q2)
            {
                Console.WriteLine(x.Dep + ": {0}", x.Emps);
            }

            Console.WriteLine("\nСотрудники с фамилией на А:\n");
            var q3 = from x in employees
                     where x.surname[0] == 'А' //Условие
                     orderby x.surname ascending //Сортировка
                     select x;
            foreach (var x in q3)
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("\nОтделы, в которых фамилии всех сотрудников начинаются на \"А\":\n");
            var q4 = from x in departments
                     join y in employees on x.dep_id equals y.dep_id into g
                     where g.All(g => g.surname[0] == 'А')
                     select new { Dep = x.dep_name, Emps = g };
            foreach (var x in q4)
            {
                Console.WriteLine(x.Dep + ":");
                foreach (var y in x.Emps)
                {
                    Console.WriteLine("    " + y);
                }
            }

            Console.WriteLine("\nОтделы, в которых есть сотрудники с фамилией на \"А\":\n");
            var q5 = from x in departments
                     join y in employees on x.dep_id equals y.dep_id into g
                     where g.Any(g => g.surname[0] == 'А')
                     select new { Dep = x.dep_name, Emps = g };
            foreach (var x in q5)
            {
                Console.WriteLine(x.Dep + ":");
                foreach (var y in x.Emps)
                {
                    Console.WriteLine("    " + y);
                }
            }

            Console.WriteLine("\n\nОТДЕЛ - СОТРУДНИК: М - М\n");
            Console.WriteLine("\nСотрудники по отделам:\n");
            var q6 = from x in departments
                     join y in DepartmentEmployees on x.dep_id equals y.dep_id into temp1
                     from t1 in temp1
                     join z in employees on t1.emp_id equals z.emp_id into temp2
                     from t2 in temp2
                     orderby t1.dep_id, t2.surname ascending
                     group t2 by x into g
                     select g;
            foreach (var x in q6)
            {
                Console.WriteLine(x.Key + ":");
                foreach (var y in x)
                {
                    Console.WriteLine("    " + y);
                }
            }

            Console.WriteLine("\nЧисло сотрудников в отделах:\n");
            var q7 = from x in departments
                     join y in DepartmentEmployees on x.dep_id equals y.dep_id into temp1
                     from t1 in temp1
                     join z in employees on t1.emp_id equals z.dep_id into temp2
                     from t2 in temp2
                     group t2 by x.dep_name into g
                     select new { Dep = g.Key, Emps = g.Count() };
            foreach (var x in q7)
            {
                Console.WriteLine(x.Dep + ": {0}", x.Emps);
            }
            Console.ReadLine();
        }
    }
}
