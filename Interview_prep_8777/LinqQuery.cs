using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Xml.Linq;
using static Interview_prep_8777.Coding_Prac2;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Interview_prep_8777
{
    public class LinqQuery
    {


        //public class Employee 
        //{
        //    public int EID { get; set; }
        //    public string Ename { get; set; } = null!;
        //    public double Salary { get; set; }
        //    public string Department { get; set; } = null!;
        //}
        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; } = null!;
            public string Department { get; set; } = null!;
            public decimal Salary { get; set; }
            public int Age { get; set; }
            public int? ManagerId { get; set; }
        }
        public static void Main(string[] args)
        {
//            Write a LINQ query to:
//            1.Group employees by Department.
//            2.Calculate the average salary for each department.
//            3.Return only departments whose average salary is greater than ₹75, 000.
//            4.Display the department name and average salary in descending order of average salary.


            List <Employee> employees = new()
            {
                new Employee{Id = 1, Name = "Atul p" ,Department = "IT" , Salary=10000, Age=34, ManagerId=1},
                new Employee{Id = 2, Name = "Saee p" ,Department = "MBBS" , Salary=12000, Age=13, ManagerId=1},
                new Employee{Id = 3, Name = "Swaraj p" ,Department = "IT" , Salary=11000, Age=6, ManagerId=1},
                new Employee{Id = 4, Name = "Sharayu p" ,Department = "MBBS" , Salary=12000, Age=5, ManagerId=1},
                new Employee{Id = 5, Name = "kartik I" ,Department = "IT" , Salary=15000, Age=22, ManagerId=1},
            };


            var result = employees.GroupBy(x => x.Department).
                Select(g => new
                {
                    Department = g.Key,
                    AvarageSalary = g.Average(x => x.Salary)
                }).Where(x => x.AvarageSalary > 10000).OrderByDescending(x=>x.AvarageSalary);

            foreach (var Avgsal in result)
            {
                Console.WriteLine($"AverageSalary {Avgsal.Department} : {Avgsal.AvarageSalary}\n");
            }


            //Using the same employees list, write a LINQ query to find the second-highest
            //distinct salary across all employees.
            //For your data, the distinct salaries in descending order are:


            

            var resultsndHighest = employees.Distinct().
                Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.Department,
                    x.Salary
                }).OrderByDescending(x=>x.Salary);


            foreach (var item in resultsndHighest)
            {
                Console.WriteLine($"{item.Id } {item.Name} {item.Department} {item.Salary}");
            }

            var SecondHighestsal = employees.Distinct().
                   Select(x => new
                   {
                       x.Id,
                       x.Name,
                       x.Department,
                       x.Salary

                   }).OrderByDescending(x => x.Salary).Skip(1).FirstOrDefault();

            Console.WriteLine($"Second highest {SecondHighestsal?.Id} {SecondHighestsal?.Name} {SecondHighestsal?.Department} {SecondHighestsal?.Salary}");



            //            Question 3 — Find employees earning more than their department's average
            //            Difficulty: Advanced
            //            Using the same employees list, write a LINQ query to return employees whose
            //            salary is greater than the average salary of their own department.
            //            For your sample data, the expected result is:


            var Avgsal1 = employees.Where(e => e.Salary >
            employees.Where(x => x.Department == e.Department).Average(e => e.Salary)).ToList();


            foreach (var item in Avgsal1)
            {
                Console.WriteLine($" last {item.Id} {item.Name} {item.Salary} {item.Department}");
            }

            //List<Employee> employees = new()
            //{ 
            //    new Employee{EID=1, Ename="Atul" , Salary=15000, Department="IT"},
            //    new Employee{EID=1, Ename="Saee" , Salary=16000, Department="Medicle"},
            //    new Employee{EID=1, Ename="Swaraj" , Salary=11000, Department="IT"},
            //    new Employee{EID=1, Ename="Sharayu" , Salary=14000, Department="Medicle"}
            //};

            //var result = employees.GroupBy(x => x.Department).
            //    Select(g => new
            //    {
            //        Department=g.Key,
            //        AvarageSalary = g.Average(x=>x.Salary)
            //    });
            //foreach (var results in result)
            //{
            //    Console.WriteLine($"{results.Department }: {results.AvarageSalary}");
            //}
            //int x = 5;
            //Console.WriteLine(x++);
            //Console.WriteLine(--x);


            //string str = "aabbcedde";

            //Dictionary<char, int> dict = new Dictionary<char, int>();

            //for (int i = 0; i < str.Length; i++)
            //{
            //    char c = str[i];

            //    if (!dict.ContainsKey(c))
            //    {
            //        dict.Add(c, 1);
            //    }
            //    else
            //    {
            //        dict[c]++;
            //    }
            //}

            //for (int i = 0; i < str.Length; i++)
            //{
            //    if (dict[str[i]] == 1)
            //    {
            //        Console.WriteLine(str[i]);
            //        Console.WriteLine(i +1);

            //        break;
            //    }

            //}


            //string vowel = "aeiou";
            //string str1 = "atul moni saee sharayu swaraj";
            //char[] chars = str1.ToArray();

            //for (int i = 0; i < chars.Length; i++)
            //{

            //    if (vowel.Contains(chars[i]))
            //    {
            //        chars[i] = '*';
            //    }

            //}
            //Console.WriteLine(chars);






        }
    }
}
