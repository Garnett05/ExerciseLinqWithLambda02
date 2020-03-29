using System;
using LinqWithLambdaExercise02.Entities;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Linq;

namespace LinqWithLambdaExercise02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();
            List<Employee> emp = new List<Employee>();

            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] fields = sr.ReadLine().Split(';');
                        string name = fields[0];
                        string email = fields[1];
                        double salary = double.Parse(fields[2], CultureInfo.InvariantCulture);
                        emp.Add(new Employee(name, email, salary));
                    }
                }
                Console.Write("Enter salary: ");
                double imputSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.WriteLine("Email of people whose salary is more than 2000.00: ");
                var c1 = emp.Where(x => x.Salary > 2000.00).OrderBy(x => x.Name).Select(x => x.Email);
                foreach (string x in c1)
                {
                    Console.WriteLine(x);
                }

                Console.Write("Sum of salary of people whose name starts wih 'M': ");
                var c2 = emp.Where(x => x.Name[0] == 'M').Sum(x => x.Salary);
                Console.WriteLine(c2.ToString("F2", CultureInfo.InvariantCulture));
            }
            catch (IOException e)
            {
                Console.Write("An error accurred: ");
                Console.WriteLine(e.Message);
            }
        }
    }
}
