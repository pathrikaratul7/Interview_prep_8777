using System;

namespace Interview_prep_8777
{
    public class Coding_Prac2
    {
        #region ER linq query related to employee and department

        public class Employee
        {
            public int EmpId { get; set; }
            public string? EmpName { get; set; }
            public decimal Salary { get; set; }
            public int DeptId { get; set; }
        }
        public class Department
        {
            public int DeptId { get; set; }
            public string? DeptName { get; set; }
        }


        #endregion
        public static  void ReverseString(string str)
        {
            string rev = string.Empty;
            for (int i = 0; i < str.Length; i++)
            {
                rev = str[i] + rev;

            }
            if (rev.Equals(str, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Given string is palindrome : {rev}");
            }
            else
            { 
              Console.WriteLine($"Given string is not palindrome : {rev}");
            }


                Console.WriteLine($"Reverce string : {rev}");


        }
        public static List<string> duplicateChars = new List<string>();
        public static void FindDuplicate(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = 0; j < str.Length; j++)
                {
                    if (i != j && char.ToLower(str[i]) == char.ToLower(str[j]))
                    {

                        //Console.WriteLine($"Duplicate Characters : {str[i]} count: {cnt}");
                        duplicateChars.Add(str[i].ToString());
                        
                    }
                }
            
            
            }
        
        
        }

        public static void FindFirstnonrepetingchar(string str)
        {
            bool isnonretern = false;
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = 0; j < str.Length; j++)
                { 
                   if(i!=j && char.ToLower(str[i]) == char.ToLower(str[j]))
                    {
                        isnonretern = true;
                        break;
                    }

                }
                if (isnonretern)
                {
                      Console.WriteLine($"First non repeting character is : {str[i]}");
                    break;
                }
            
            
            }
        
        
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter a string");
            string txtinput = Console.ReadLine() ?? "Sharayu";

            ReverseString(txtinput);
            FindDuplicate(txtinput);
            FindFirstnonrepetingchar(txtinput);

            foreach (var item in duplicateChars.Distinct())
            {
                Console.WriteLine($"Duplicate Characters : {item} : Count: {duplicateChars.Count(x => x == item)}");
            }
            var employees = new List<Employee>
        {
            new Employee { EmpId = 1, EmpName = "Saee", Salary = 50000, DeptId = 1 },
            new Employee { EmpId = 2, EmpName = "Swaraj", Salary = 60000, DeptId = 2 },
            new Employee { EmpId = 3, EmpName = "Sharayu", Salary = 70000, DeptId = 1 },
            new Employee { EmpId = 4, EmpName = "Atul", Salary = 80000, DeptId = 3 }
        };
            var departments = new List<Department>
        {
            new Department { DeptId = 1, DeptName = "IT" },
            new Department { DeptId = 2, DeptName = "HR" },
            new Department { DeptId = 3, DeptName = "Finance" }
        };

            // print all employee details with their department;

            //var EmpDetails = employees.Join(departments, emp => emp.DeptId, d => d.DeptId, (emp, d) => new
            //{
            //    emp.EmpId,
            //    emp.EmpName,
            //    emp.Salary,
            //    DepartmentName = d.DeptName
            //});

            //var result = EmpDetails.ToList();

            var empDetails = from emp in employees
                             join d in departments on emp.DeptId equals d.DeptId
                             where (d.DeptName == "8777")
                             select new
                             {
                                 emp.EmpId,
                                    emp.EmpName,
                                    emp.Salary,
                                    DepartmentName = d.DeptName

                             };

           

            var em = employees.Join(departments, em => em.DeptId, d => d.DeptId, (em, d) => new
            {
                em.EmpId,
                em.EmpName,
                em.Salary,
                DepartmentName = d.DeptName

            }).Where(departments => departments.DepartmentName == "IT");

#if !DEBUG

            foreach (var emp in em)
            {
                Console.WriteLine($"From Join {nameof(emp.EmpId)} : {emp.EmpId}\n{nameof(emp.EmpName)} : {emp.EmpName}\n{nameof(emp.Salary)} : {emp.Salary}\n{nameof(emp.DepartmentName)} : {emp.DepartmentName}\n");
            }
            foreach (var emp in empDetails)
            {
                Console.WriteLine($"{nameof(emp.EmpId)} : {emp.EmpId}\n{nameof(emp.EmpName)} : {emp.EmpName}\n{nameof(emp.Salary)} : {emp.Salary}\n{nameof(emp.DepartmentName)} : {emp.DepartmentName}\n");
            }

            var empgroup = employees.GroupBy(emp => emp.DeptId).Select(e=> new {
                DeptId = e.Key,
                Count = e.Count()
            });

            foreach (var emp in empgroup)
            {
                Console.WriteLine($"Salary : {emp} Count : {emp.Count}");
            }
#endif

        }
    }
}
