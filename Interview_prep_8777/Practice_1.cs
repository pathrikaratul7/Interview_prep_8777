using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview_prep_8777
{
    public class Practice_1
    {

        // how to use abstract class and interface both in C#
        // example :- Banking App (Balance , Deposit , Withdraw , Interest Calculation)
        // Saving account - Check Balance, Balance , Deposit , Withdraw , Interest Calculation with 5 %)(Balance * 5)
        // Current account - Check Balance, Balance , Deposit , Withdraw (No Interest Calculation)
        // Salary account - Check Balance, Balance , Deposit , Withdraw , Interest Calculation with 10 %)(Balance * 10 / 100)

        // we have common functionality in all the account like check balance , deposit, withdraw so we can create an abstract class and implement it in all the account classes


        public abstract class BankService
        {
            private double _balance = 10000; // we are protecting this variable from outside the class by making it private and we also encpasulate this

            protected double Balance // we have created a protected property to access the private variable from derived classes
            {
                get { return _balance; }
                set { _balance = value; }
            }

            public void CheckBalance() // we have created a method to check the balance from outside the class
            {
                Console.WriteLine($"Balance : {Balance}");
            }

            public double GetBalance() // we have created a method to get the balance from outside the class
            { 
               return Balance;
            }

            public void SetBalance(double amount) // we have created a method to set the balance from outside the class
            { 
              Balance = amount;
            }

            public abstract void Deposit(double amount); // common functionality in all the account classes so we have created an abstract method to implement it in derived classes
            public abstract void Withdraw(double amount);

        }
        public interface IinterestCalculater
        {
            void calculateinterest();
        }

        public class  SavingAccount : BankService , IinterestCalculater
        {
            public override void Deposit(double amount)
            {
                CheckBalance();
                SetBalance(GetBalance() + amount);
                Console.WriteLine($"Deposited {amount} to Saving Account. New Balance: {GetBalance()}");
            }
            public override void Withdraw(double amount)
            {
                CheckBalance();
                SetBalance(GetBalance() - amount);
                Console.WriteLine($"Withdrew {amount} from Saving Account. New Balance: {GetBalance()}");
            }
            public void calculateinterest()
            {
                double interest = GetBalance() * 5 / 100;
                SetBalance(GetBalance() + interest);
                Console.WriteLine($"Interest calculated for Saving Account. New Balance: {GetBalance()}");

            }

        }
        public class CurrentAccount : BankService
        {
            public override void Deposit(double amount)
            {
                CheckBalance();
                SetBalance(GetBalance() + amount);
                Console.WriteLine($"Deposited {amount} to Current Account. New Balance: {GetBalance()}");
            }
            public override void Withdraw(double amount)
            {
                CheckBalance();
                SetBalance(GetBalance() - amount);
                Console.WriteLine($"Withdrew {amount} from Current Account. New Balance: {GetBalance()}");
            }
          

        }

        public class OpenClosed_Principle_BAD
        {
            public class SavingAccount
            {
                public void CalculateInterest(string accountType)
                {
                    if (accountType == "Saving")
                    {

                        // AccountBalance = Accountbalance * 5 /100;

                    }
                    else if (accountType == "salary") // now here we are violating the open closed principle because we are adding new functionality in the existing class which is not allowed in open closed principle
                    {
                        // AccountBalance = Accountbalance * 10 /100;

                    }

                }
            }
        }
            public class OpenClosed_Principle_Good
            {

                public interface Iinterescalculater
                {
                    void calculateinterest();
                }

                public class SavingAccount_Good : Iinterescalculater
                {
                    public void calculateinterest()
                    {
                        // AccountBalance = Accountbalance * 5 /100;

                    }
                }
            public class SalaryAccount_Good : Iinterescalculater
            {
                public void calculateinterest()
                {
                    // AccountBalance = Accountbalance * 10 /100;
                }
            }
            }
                static void Main(string[] args)
        {

            Console.WriteLine("--===Saving Account Operations===--");
            SavingAccount account; 

            account = new SavingAccount();
            account.Deposit(5000);
            account.Withdraw(2000);

            IinterestCalculater Ical = (IinterestCalculater)account;

            Ical.calculateinterest();
            Console.WriteLine("--===Saving Account Operations===--");

            Console.WriteLine("--===Current Account Operations===--");
            CurrentAccount curr;
            curr = new CurrentAccount();
            curr.Deposit(10000);
            curr.Withdraw(5000);


            Console.WriteLine("--===Current Account Operations===--");


        }

    }
}
