using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview_prep_8777
{
    public class O_n_O_1
    {

       

        public static void Main(string[] args)
        {

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

            int[] arr = { 1, 2, 3, 4, 5 };
            int target = 6;
            var result = TwoSum(arr, target);
            Console.WriteLine($"Indices: {result[0]} , {result[1]} : {arr[result[0]]} +  {arr[result[1]]} = {target}");
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