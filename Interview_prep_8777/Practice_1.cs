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
            private decimal _balance = 10000; // we are protecting this variable from outside the class by making it private and we also encpasulate this

            protected decimal Balance // we have created a protected property to access the private variable from derived classes
            {
                get { return _balance; }
                set { _balance = value; }
            }

            public void CheckBalance() // we have created a method to check the balance from outside the class
            {
                Console.WriteLine($"Balance : {Balance}");
            }

            public decimal GetBalance() // we have created a method to get the balance from outside the class
            { 
               return Balance;
            }

            public void SetBalance(decimal amount) // we have created a method to set the balance from outside the class
            { 
              Balance = amount;
            }

            public abstract void Deposit(decimal amount); // common functionality in all the account classes so we have created an abstract method to implement it in derived classes
            public abstract void Withdraw(decimal amount);

        }
        public interface IinterestCalculater
        {
            void calculateinterest();
        }

        public class  SavingAccount : BankService , IinterestCalculater
        {
            public override void Deposit(decimal amount)
            {
                CheckBalance();
                SetBalance(GetBalance() + amount);
                Console.WriteLine($"Deposited {amount} to Saving Account. New Balance: {GetBalance()}");
            }
            public override void Withdraw(decimal amount)
            {
                CheckBalance();
                SetBalance(GetBalance() - amount);
                Console.WriteLine($"Withdrew {amount} from Saving Account. New Balance: {GetBalance()}");
            }
            public void calculateinterest()
            {
                decimal interest = GetBalance() * 5 / 100;
                SetBalance(GetBalance() + interest);
                Console.WriteLine($"Interest calculated for Saving Account. New Balance: {GetBalance()}");

            }

        }
        public class CurrentAccount : BankService
        {
            public override void Deposit(decimal amount)
            {
                CheckBalance();
                SetBalance(GetBalance() + amount);
                Console.WriteLine($"Deposited {amount} to Current Account. New Balance: {GetBalance()}");
            }
            public override void Withdraw(decimal amount)
            {
                CheckBalance();
                SetBalance(GetBalance() - amount);
                Console.WriteLine($"Withdrew {amount} from Current Account. New Balance: {GetBalance()}");
            }
          

        }

        #region BAD example of open closed principle
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
        #endregion

        #region GOOD example of open closed principle
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

        #endregion

        #region BAD example of Liskov Substitution Principle
        public class Liskovsubstitution_Principle_BAD
        {
            public class  Saccount : BankService
            {
                public override void Deposit(decimal amount)
                {
                    throw new NotImplementedException(); // here we are violating the Liskov Substitution Principle because we are not implementing the deposit method in the derived class which is not allowed in Liskov Substitution Principle
                }
                public override void Withdraw(decimal amount)
                {
                    SetBalance(GetBalance() - amount);
                }
            }
                
            

        }

        #endregion

        #region BAD example of Interface Segregation Principle
        public interface IBank
        {
            void Deposit(decimal amount);
            void Withdraw(decimal amount);
            
            void CalculateInterest();
            void ApplyOverdraft();
            void PrintPassbook();
            
            
        }

        public class SavingAccount_ISP_BAD : IBank
        {
            public void Deposit(decimal amount)
            {
             // deposit logic
            }
            public void Withdraw(decimal amount)
            {
                // withdraw logic
            }
            public void CalculateInterest()
            {
                // AccountBalance = Accountbalance * 5 /100;
            }
            public void ApplyOverdraft()
            {
                throw new NotImplementedException(); // here we are violating the Interface Segregation Principle because we are not implementing the ApplyOverdraft method in the derived class which is not allowed in Interface Segregation Principle
            }
            public void PrintPassbook()
            {
               // print passbook logic
            }
        }

        #endregion
        #region Good example of Interface Segregation Principle

        public interface IBank_ISP
        { 
        void Deposit(decimal amount);
            void Withdraw(decimal amount);

        }
        public interface IPrintPassbook
        {
           void PrintPassbook();
        }
        public interface IApplyOverdraft
        {
            void ApplyOverdraft();
        }

        public class SavingAccount_ISP_Good : IBank_ISP , IPrintPassbook
        {
            public void Deposit(decimal amount)
            {
                // deposit logic
            }
            public void Withdraw(decimal amount)
            {
                // withdraw logic
            }
            public void PrintPassbook()
            { 
               // Print Passbook logic
            }
        }


        #endregion

        #region BAD example of Dependency Inversion Principle

        public class Bank_BAD 
        {
            SavingAccount account = new SavingAccount();     // here we are violating the Dependency Inversion Principle because the high-level module (Bank) is depending on the low-level module (SavingAccount) directly instead of through an abstraction (BankService)
            
        }

        #endregion

        #region GOOD example of Dependency Inversion Principle

        public class Bank_Good
        { 

            private readonly BankService _account;
            public Bank_Good(BankService account) // here we are following the Dependency Inversion Principle because the high-level module (Bank) is depending on the low-level module (SavingAccount) through an abstraction (BankService)
            {
                _account = account;
                
            }
            public void DepositMoney(decimal amount)
            {
                _account.Deposit(amount);
            }

        }
        #endregion
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
            
            Bank_Good bk = new Bank_Good(account);
            bk.DepositMoney(1000);

        }

    }
}
