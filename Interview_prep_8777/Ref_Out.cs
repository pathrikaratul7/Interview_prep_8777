using System;

namespace Interview_prep_8777
{
    public class Ref_Out
    {
        public void AddInterest(ref decimal balance)
        {
            balance = balance + 1000;
        }

        public void GetAccountNumber(out int accountNumber)
        {
            accountNumber = 12345;
        }
        public static void GetAccount(ref int account, out string accountType)
        {
            // ref → existing value can be read and modified
            account = account + 1000;

            // out → must assign a value
            accountType = "Savings";
        }
        public static async Task Main(string[] args)
        {
            int account = 5000;
            string accountType;

            GetAccount(ref account, out accountType);

            Console.WriteLine(account);
            Console.WriteLine(accountType);
            string str = args.ToString() ?? "MaM";
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
            string palidrome = string.Empty;


            

            if (val.Equals(palidrome, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("palidrome");
            }
            else
            {
                Console.WriteLine("Not palidrome");
            }

                await Task.CompletedTask;
        }


    }

    public abstract class BankAccount
    {
        public int AccountId { get; set; }
        public decimal Balance { get; protected set; }

        public abstract void CalculateInterest();

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Invalid amount");

            Balance += amount;
        }
    }
    public class SavingsAccount : BankAccount
    {
        public override void CalculateInterest()
        {
            Balance += Balance * 0.04m;
        }
    }

//    Here:

//Encapsulation → balance is protected
//Abstraction → BankAccount defines required behavior
//Inheritance → SavingsAccount : BankAccount
//Polymorphism → CalculateInterest() behaves differently for different account types
}