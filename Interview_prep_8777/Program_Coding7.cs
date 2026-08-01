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
        public static void Main(string[] args)
        {
            string str = "Sharayu atul pathrikar";

            reversestring(str);
            reversestringwithbuffer(str);
        }
       
    }
}
