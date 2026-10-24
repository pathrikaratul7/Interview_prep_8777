using System;
using System.Collections.Generic;
using System.Linq;
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


            string str = "aabbcedde";

            Dictionary<char, int> dict = new Dictionary<char, int>();

            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];

                if (!dict.ContainsKey(c))
                {
                    dict.Add(c, 1);
                }
                else
                {
                    dict[c]++;
                }
            }

            for (int i = 0; i < str.Length; i++)
            {
                if (dict[str[i]] == 1)
                {
                    Console.WriteLine(str[i]);
                    Console.WriteLine(i +1);
                    
                    break;
                }
                
            }


            string vowel = "aeiou";
            string str1 = "atul moni saee sharayu swaraj";
            char[] chars = str1.ToArray();

            for (int i = 0; i < chars.Length; i++)
            {

                if (vowel.Contains(chars[i]))
                {
                    chars[i] = '*';
                }
            
            }
            Console.WriteLine(chars);






        }
    }
}
