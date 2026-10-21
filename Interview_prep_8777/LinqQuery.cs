using System;
using System.Collections.Generic;
using System.Text;

namespace Interview_prep_8777
{
    public class LinqQuery
    {


        public class Employee 
        {
            public int EID { get; set; }
            public string Ename { get; set; } = null!;
            public double Salary { get; set; }
            public string Department { get; set; } = null!;
        }
        public static void Main(string[] args)
        {
            List<Employee> employees = new()
            { 
                new Employee{EID=1, Ename="Atul" , Salary=15000, Department="IT"},
                new Employee{EID=1, Ename="Saee" , Salary=16000, Department="Medicle"},
                new Employee{EID=1, Ename="Swaraj" , Salary=11000, Department="IT"},
                new Employee{EID=1, Ename="Sharayu" , Salary=14000, Department="Medicle"}
            };

            var result = employees.GroupBy(x => x.Department).
                Select(g => new
                {
                    Department=g.Key,
                    AvarageSalary = g.Average(x=>x.Salary)
                });
            foreach (var results in result)
            {
                Console.WriteLine($"{results.Department }: {results.AvarageSalary}");
            }
        
        }
    }
}
