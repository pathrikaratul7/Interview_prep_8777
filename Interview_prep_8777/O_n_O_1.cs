using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Interview_prep_8777
{
    public class O_n_O_1
    {

        public record Employee(string Name, int Age);
        public record EmployeeDto(int Id,string Name,decimal Salary);
        #region Reverse a string without using Reverse()
        public static void Reverse(string txtvalue)
        {
            string rev = string.Empty;
            if (!string.IsNullOrEmpty(txtvalue))
            {
                for (int i = 0; i < txtvalue.Length; i++)
                {
                    rev = txtvalue[i] + rev;
                }
                Console.WriteLine($"Reverce string : {rev}");


                StringBuilder sb = new StringBuilder();
                for (int i = txtvalue.Length - 1; i >= 0; i--)
                {
                    sb.Append(txtvalue[i]);

                }
                Console.WriteLine($"Reverce string using StringBuilder : {sb.ToString()}");
            }


            

        }
        #endregion

        #region Find duplicate characters in a string.
        public static void FindDuplicate(string txtvalue)
        {
           

            for (int i = 0; i < txtvalue.Length; i++)
            {
                for (int j = i + 1; j < txtvalue.Length; j++)
                {
                    if (char.ToLower(txtvalue[i]) == char.ToLower(txtvalue[j]))
                    {
                        Console.WriteLine($"Duplicate Characters : {txtvalue[i]}");

                    }

                }

            }


            //  Console.WriteLine($"Duplicate Characters : {dup}");

        



        }
        #endregion

        #region Find the first non-repeating character.

        public static void FirstNonRepeting(string txtvalue)
        {

            for (int i = 0; i < txtvalue.Length; i++)
            {
                bool isduplicate = false;
                for (int j = 0; j < txtvalue.Length; j++)
                {
                    if (1 != j && char.ToLower(txtvalue[i]) == char.ToLower(txtvalue[j]))
                    {
                        isduplicate = true;
                        break;
                    
                    }
                
                
                }
                if (!isduplicate)
                {
                    Console.WriteLine($"First non repeting character is : {txtvalue[i]}");
                
                }
            
            
            }

        }

        #endregion

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter a string:");
            string txtvalue = Console.ReadLine() ?? string.Empty;
            
            Reverse(txtvalue);
            FindDuplicate(txtvalue);
            FirstNonRepeting(txtvalue);


            //var employee1 = new EmployeeDto(1, "Atul", 50000);

            //var employee2 = employee1 with
            //{
            //    Salary = 60000
            //};
            //Employee employee1 = new Employee("John", 30);
            //List<int> numbers = new List<int>
            //{
            //    10, 20, 30, 40, 50
            //};
            //Console.WriteLine(numbers[4]);// in futore we have n mumbers of elements in list and we want to access the 10000 then
            // it will slow our application
            // because it will take O(n) time to access the 10000th
            // element in list but if we use array then it will take O(1)
            // time to access the 10000th element in array.

            //     int value = numbers[3];

            //int[] arr = { 1, 2, 3, 4, 5 };
            //int target = 6;
            //var result = TwoSum(arr, target);
            //Console.WriteLine($"Indices: {result[0]} , {result[1]} : {arr[result[0]]} +  {arr[result[1]]} = {target}");
        }

        public static int[] TwoSum(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (dict.ContainsKey(complement))
                {
                    return new int[] { dict[complement], i };
                }
                dict[nums[i]] = i;
            }
            throw new ArgumentException("No two sum solution");
        }
    }
}