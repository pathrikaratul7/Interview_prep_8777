using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview_prep_8777
{
    public class Program_Coding7
    {
        public static void reversestring(string str) 
        {
            string rev = string.Empty;
            for (int i = 0; i < str.Length; i++)
            {
                rev = str[i] + rev;
            }
            Console.WriteLine(rev);
         }

        public static void reversestringwithbuffer(string str)
        {
            StringBuilder sb = new StringBuilder();
            for(int i = str.Length -1 ; i>=0;i--)
            {
                sb.Append(str[i]);

            }
            Console.WriteLine(sb.ToString());

        }
        public class Employee
        { 
            public int EMPID { get; set; }
            public string? EMPName { get; set; }
            public Decimal Salary { get; set; }
        }
        public static void Main(string[] args)
        {
            string str = "Sharayu atul pathrikar";

            reversestring(str);
            reversestringwithbuffer(str);

            List<Employee> emp = new List<Employee>
           {
             new   Employee { EMPID = 1, EMPName = "Sharayu", Salary = 50000 },
             new   Employee { EMPID = 2, EMPName = "Atul", Salary = 60000 },
             new  Employee { EMPID = 3, EMPName = "Pathrikar", Salary = 70000 }
           };

            int nthhighsal = 4;

            var NthSal = emp.Select(x => x.Salary)
                            .Distinct()
                            .OrderByDescending(x => x)
                            .Skip(nthhighsal - 1)
                            .FirstOrDefault();

            var FinalList = emp.Where(x=> x.Salary== NthSal).ToList();
            if (FinalList != null && FinalList.Count > 0)
            {
                foreach (var item in FinalList)
                {
                    Console.WriteLine($"Employee ID: {item.EMPID}, Employee Name: {item.EMPName}, Salary: {item.Salary}");
                }

            }
            else
            {
                Console.WriteLine($"No employee found with the {nthhighsal}th highest salary.");
            }
        }
       
    }
}
