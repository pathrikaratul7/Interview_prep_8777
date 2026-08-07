using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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


       
public abstract class BankAccount
    {
            public BankAccount()
            {
                    
            }
            public BankAccount(decimal initialBalance)
            {
                _balance = initialBalance;
            }
            // Encapsulation:
            // Private field cannot be accessed directly from outside.
            private decimal _balance = 10000;

        // Protected property:
        // Derived classes can read the balance.
        // Only BankService can modify it.
        protected decimal Balance
        {
            get { return _balance; }
            private set { _balance = value; }
        }

        // Public method:
        // Allows outside classes to check the balance.
        public void CheckBalance()
        {
            Console.WriteLine($"Balance: {Balance}");
        }

        // Public method:
        // Allows outside classes to read the balance.
        public decimal GetBalance()
        {
            return Balance;
        }

            // Protected method:
            // Adds money to the account.
            protected void AddBalance(decimal amount)
            {
                if (ValidateAmount(amount, out string msg))
                {

                    Balance += amount;
                }
                else
                {
                    Console.WriteLine(msg);
                }
            }
            private bool ValidateAmount(decimal amount, out string msg)
            {
                if (amount <= 0)
                {

                    msg = "Withdrawal amount must be greater than zero.";
                    return false;
                }
                msg = string.Empty;
                return true;
              
            }
            private bool ValidateSufficientBalance(decimal amount, out string msg)
            {
                if (Balance < amount)
                { 
                    msg = "Insufficient balance.";
                    return false;
                }
                msg = string.Empty;
                return true;
            }
                    
            // Protected method:
            // Removes money from the account.
            protected void DeductBalance(decimal amount)
        {
           if (ValidateAmount(amount, out string msg) && ValidateSufficientBalance(amount, out msg))
           {
                Balance -= amount;
           }
           else
           {
                Console.WriteLine(msg);
           }
        }

        // Common operation for all account types.
        // Each derived class must provide its own implementation.
        public abstract void Deposit(decimal amount);

        public abstract void Withdraw(decimal amount);

        // Method overloading.
        public void Deposit(decimal amount, string type)
        {
            Console.WriteLine(
                $"{type} deposit of {amount}"
            );
        }
    }


    // Interface:
    // Defines a contract for accounts that support interest calculation.
    public interface IInterestCalculator
    {
        void CalculateInterest();
    }


    // Saving Account
    public class SavingAccount : BankAccount, IInterestCalculator
    {
        public override void Deposit(decimal amount)
        {
            AddBalance(amount);

            Console.WriteLine(
                $"Deposited {amount} to Saving Account. " +
                $"New Balance: {GetBalance()}"
            );
        }

        public override void Withdraw(decimal amount)
        {
            DeductBalance(amount);

            Console.WriteLine(
                $"Withdrew {amount} from Saving Account. " +
                $"New Balance: {GetBalance()}"
            );
        }

        public void CalculateInterest()
        {
            decimal interest = GetBalance() * 5 / 100;

            AddBalance(interest);

            Console.WriteLine(
                $"Interest calculated at 5%. " +
                $"Interest: {interest}. " +
                $"New Balance: {GetBalance()}"
            );
        }
    }


    // Current Account
    public class CurrentAccount : BankAccount
    {
        public override void Deposit(decimal amount)
        {
            AddBalance(amount);

            Console.WriteLine(
                $"Deposited {amount} to Current Account. " +
                $"New Balance: {GetBalance()}"
            );
        }

        public override void Withdraw(decimal amount)
        {
            DeductBalance(amount);

            Console.WriteLine(
                $"Withdrew {amount} from Current Account. " +
                $"New Balance: {GetBalance()}"
            );
        }
    }




        #region BAD example of Single Responsibility Principle

        public class Bank
        {
            private decimal Balance = 10000;
            public void Deposit(decimal amount)
            { 
             Balance += amount;
            }
            public void Withdraw(decimal amount)
            { 
               Balance -= amount;

            }
            public void Interestcalculater()
            { 
              Balance = Balance * 5 / 100;
            }
            public void SendEmail()
            {
                // send email logic
            }

        }

        #endregion
        #region GOOD example of Single Responsibility Principle

        public class BankService_SRP
        {
            public decimal Balance = 10000;
            public void Depsoit(decimal amount)
            { 
              Balance += amount;
            }
            public void Withdraw(decimal amount)
            { 
              Balance -= amount;
            }


        }
        public class InterestCalculator_SRP
        {
              public void CalculateInterest(decimal balance)
              {
                // interest calvultor logic
              }
        }
        public class EmailService
        {
            public void SendEmail()
            {
                // send email logic
            }
        }
        static void Main_SRP(string[] args)
        {
            BankService_SRP b = new BankService_SRP();
            b.Depsoit(1000);
            b.Withdraw(4000);
           
            InterestCalculator_SRP i = new InterestCalculator_SRP();
            i.CalculateInterest(b.Balance);


            EmailService e = new EmailService();
            e.SendEmail();


        }
        #endregion

        #region BAD example of open closed principle
        public class OpenClosed_Principle_BAD
        {
            public class InterestCalculator
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
        } // in future if we want to add new account type like current account then we have to modify the existing class which is not allowed in open closed principle so we have to create a new class for current account and implement the interest calculation logic in that class
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
            public class  FixedAccount : Iinterescalculater
            {
                public void calculateinterest()
                {
                    // AccountBalance = Accountbalance * 15 /100;
                }
            }
        }

        #endregion

        #region BAD example of Liskov Substitution Principle
        public class Liskovsubstitution_Principle_BAD
        {
            public class  FixedDeposit : BankAccount
            {
                public override void Deposit(decimal amount)
                {
                   // UpdateBalance(GetBalance() + amount);
                   
                }
                public override void Withdraw(decimal amount)
                {
                    throw new NotImplementedException(); // here we are violating the Liskov Substitution Principle because we are not implementing the deposit method in the derived class which is not allowed in Liskov Substitution Principle
                }
            }
                
            

        }

        #endregion
        #region GOOD example of Liskov Substitution Principle
        public interface IDeposit
       {
            void Deposit(decimal amount);
        }
        public interface IWithdraw
        {
            void Withdraw(decimal amount);
        }
        public class SavingsAccount : IDeposit, IWithdraw
        {
            public void Deposit(decimal amount)
            {
                Console.WriteLine($"Savings Deposit: {amount}");
            }

            public void Withdraw(decimal amount)
            {
                Console.WriteLine($"Savings Withdraw: {amount}");
            }
        }
        public class FixedDepositAccount : IDeposit
        {
            public void Deposit(decimal amount)
            {
                Console.WriteLine($"Fixed Deposit: {amount}");
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

            private readonly BankAccount _account;
            public Bank_Good(BankAccount account) // here we are following the Dependency Inversion Principle because the high-level module (Bank) is depending on the low-level module (SavingAccount) through an abstraction (BankService)
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
            BankAccount account;
            account = new SavingAccount();

            account.CheckBalance();
            // Balance: 10000

            account.Deposit(5000);
            // Deposited 5000 to Saving Account. New Balance: 15000

            account.Withdraw(3000);
            // Withdrew 3000 from Saving Account. New Balance: 12000
            IInterestCalculator interestCalculator = (IInterestCalculator)account;
            interestCalculator.CalculateInterest();
            // Interest calculated at 5%. Interest: 600. New Balance: 12600
            account.Withdraw(99999999);
            account.Deposit(-121);

            account = new CurrentAccount();

            account.CheckBalance();
            account.Deposit(2000);
            account.Withdraw(1000);




        }

    }
}
