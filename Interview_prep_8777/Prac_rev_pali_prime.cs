using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview_prep_8777
{
    

    public class Prac_rev_pali_prime
    {

        public static void ReverseString(string str)
        {
            try
            {
                string rev = "";
                bool palidrome = false;

                for (int i = 0; i < str.Length; i++)
                {
                    rev = str[i] + rev;

                }
                if (rev.Equals(str, StringComparison.OrdinalIgnoreCase))
                {
                    palidrome = true;

                }
                if (palidrome)
                {

                    Console.WriteLine("This is Palidrome");
                }
                else
                {
                    Console.WriteLine("This is Not Palidrome");
                }

                Console.WriteLine($"Reverse string is :- {rev}");
            }
            catch (Exception e)
            {


                Console.WriteLine($"Error :- {e.Message}");
            }

        }
        public static void FindDuplicateChar(string str)
        {

            try
            {
                bool IsDuplicate = false;
                string duplicate = string.Empty;
                List<string> lst = new List<string>();
                for (int i = 0; i < str.Length; i++)
                {
                    for (int j = 0; j < str.Length; j++)
                    {
                        if (i != j && Char.ToLower(str[i]) == Char.ToLower(str[j]))
                        {
                            IsDuplicate = true;
                            //  Console.WriteLine($"Duplicate values :-{str[i]}");
                            if (!lst.Contains(str[i].ToString()))
                            {
                                lst.Add(str[i].ToString());
                            }
                        }

                    }

                }
                foreach (string dup in lst)
                {

                    Console.WriteLine($"Duplicate string:- {dup}");

                }

            }

            catch (Exception e)
            {
                Console.WriteLine($"Error occured:- {e.Message}");

            }


        }
        public static void FirstNonRepeting(string str)
        {

            try
            {
                bool IsDuplicate = false;
                for (int i = 0; i < str.Length; i++)
                {
                    for (int j = 0; j < str.Length; j++)
                    {
                        if (i != j && Char.ToLower(str[i]) == Char.ToLower(str[j]))
                        {
                            IsDuplicate = true;



                        }

                    }
                    if (IsDuplicate)
                    {
                        Console.WriteLine($"First non repeting Duplicate values :- {str[i]}");
                        break;

                    }
                }



            }

            catch (Exception e)
            {
                Console.WriteLine($"Error occured:- {e.Message}");

            }


        }
        public static bool PrimeNumber(int number)
        {


            if (number < 0)
                return false;

            for (int i = 1; i < number / 2; i++)
            {
                if (number % i == 0) break;
                    return false;
                


            }
            return true;

        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter string:- ");
            string str = Console.ReadLine();
            bool IsPrime = PrimeNumber(Convert.ToInt32(str));
            Console.WriteLine(IsPrime);
            // FindDuplicateChar(str);
            // ReverseString(str);
            // FirstNonRepeting(str);
        }
    }
}
