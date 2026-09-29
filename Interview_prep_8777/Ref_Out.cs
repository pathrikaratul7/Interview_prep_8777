using System;

namespace Interview_prep_8777
{
    public class Ref_Out
    {
        public static async Task Main(string[] args)
        {
            string str = "cadgaghyadafgha";
            string newVal = string.Empty;
            int a = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i].ToString() == "a")
                {
                    a++;
                    newVal += a;
                }
                else
                { 
                     newVal += str[i];
                }
            
            }
            string val = string.Empty;
            for (int i = 0; i < str.Length; i++)
            {

                val = str[i] + val;
            
            }


            Console.WriteLine($"Modify values {newVal} reverse strings:- {val}");

            await Task.CompletedTask;
        }
    }
}