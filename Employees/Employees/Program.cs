using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    //Class for storing employees datas
    class Employee 
    {
        private int id;
        private string name;
        private int age;
        private int salary;
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public int Salary { get => salary; set => salary = value; }

        public Employee(int id, string name, int age, int salary)
        {
            Id = id;
            Name = name;
            Age = age;
            Salary = salary;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //List for storing employee objects
            List<Employee> employees = new List<Employee>();

            //Reading txt data
            string[] lines = File.ReadAllLines("tulajdonsagok_100sor.txt");

            //Creating employee objects and adding them to the list
            Console.WriteLine("Összes alkalmazott neve:\n");
            foreach (var line in lines)
            {
                string[] splitLine = line.Split(';');
                Employee employee = new Employee(int.Parse(splitLine[0]), splitLine[1], int.Parse(splitLine[2]), int.Parse(splitLine[3]));
                employees.Add(employee);
                //Writing every employees name to console
                Console.WriteLine($"{employee.Name}");
            }

            //Writing the top 3 salaries to console
            Console.WriteLine("\nTop 3 keresettel rendelkező alkalmazott neve, id-ja:\n");
            employees.OrderByDescending(x => x.Salary).Take(3).ToList().ForEach(x => Console.WriteLine($"{x.Name}, {x.Id}"));

            //Writing the employees who have 10 years left to retire to console
            Console.WriteLine("\nAlkalmazottak akiknek 10 évük van a nyugdíjig:\n");
            employees.Where(x => x.Age == 55).ToList().ForEach(x => Console.WriteLine(x.Name));

            //Counting how many employee has a salary over 50000 HUF
            Console.WriteLine($"\n{employees.Count(x => x.Salary > 50000)} db alkalmazott keres 50000 Ft felett.\n");
        }
    }
}
