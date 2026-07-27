using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview_prep_8777
{
    public class SOLID_Day2
    {

        public abstract class BankService // best abstract example
        {
            // BAD example of Open/Closed principle, this class is not open for extension and closed for modification, if we want to add new functionality we have to modify this class, so we can create a new class for each functionality and inject it into the BankService class
            #region BAN example of Open/Closed principle
            public void CalculateInterest(string accountType)
            {
                if (accountType == "Saving")
                {
                }
                else if (accountType == "Current")
                {
                }
                else if (accountType == "Salary")
                {
                }
            }
            #endregion

            private double _balance = 10000; // accesible within class only

            protected double Balance     // exposing the private variable to derived classes
            {
                get { return _balance; }
                set { _balance = value; }
            }

            public double GetBalance() // get balance method to access the balance from outside the class
            {
                return Balance;
            }

            protected void SetBalance(double amount)// set balance method to access the balance from outside the class
            {
                Balance = amount;
            }

            public void CheckBalance() // method to check the balance from outside the class
            {
                Console.WriteLine($"Balance : {Balance}");
            }

            public abstract void withdraw(double amount); // this method is abstract and must be implemented by derived classes
            public abstract void deposit(double amount); // this method is abstract and must be implemented by derived classes
        }
        public interface IinterestCalculater // best interface example
        {
            double calculateinterest(); // declare method to calculate interest, this method must be implemented by classes that implement this interface
        }
        public class SavingAccount : BankService, IinterestCalculater // inheriting abstract class and implementing interface
        {

            // saving account doing multiple job so it's voilating the single responsibility principle, so we can create a new class for interest calculation and inject it into the saving account class
            public override void deposit(double amount) // best polymorphism overriding the abstract method deposit from BankService class
            {
                SetBalance(GetBalance() + amount); // using the SetBalance method to update the balance
            }

            public override void withdraw(double amount) // best polymorphism overriding the abstract method deposit from BankService class
            {
                SetBalance(GetBalance() - amount); // using the SetBalance method to update the balance
            }
            public double calculateinterest() // implementing the method from IinterestCalculater interface
            {
                return Balance * 5; // calculating interest as 5% of the balance
            }
            // BAD
            public void SendEmail()
            {
                Console.WriteLine("Email Sent");
            }

            // BAD
            public void GeneratePdfStatement()
            {
                Console.WriteLine("PDF Generated");
            }

            // BAD
            public void SaveToDatabase()
            {
                Console.WriteLine("Saved");
            }
        }
        public class currentAccount : BankService // best example of inheritance, inheriting the abstract class BankService
        {
            public override void withdraw(double amount) // best polymorphism overriding the abstract method deposit from BankService class
            {
                SetBalance(GetBalance() - amount); // using the SetBalance method to update the balance
            }
            public override void deposit(double amount) // best polymorphism overriding the abstract method deposit from BankService class
            {
                SetBalance(GetBalance() + amount); // using the SetBalance method to update the balance
            }

        }
        // good example of SRP

        #region GOOD example of Single responsibilty principle 

        public class EmailService
        {
            public void SendEmail()
            {
            }
        }

        public class StatementService
        {
            public void GeneratePdf()
            {
            }
        }
        #endregion

        #region GOOD example of Open/Closed principle
        public class salaryAccount : BankService, IinterestCalculater
        {
            public override void deposit(double amount)
            {
                SetBalance(GetBalance() + amount);
            }
            public override void withdraw(double amount)
            {
                SetBalance(GetBalance() - amount);
            }
            public double calculateinterest()
            {

                return Balance * 6 / 100;
            }

        }

        #endregion

        #region BAD Example of Liskov subtitution principle

        public class CurrentAccount_BAD : BankService
        {
            public override void deposit(double amount)
            {
                throw new NotImplementedException();
            }
            public override void withdraw(double amount)
            {
                SetBalance(GetBalance() - amount);
            }
        }
        #endregion

        #region GOOD Example of Liskov subtitution principle

        public class CurrentAccount_good : BankService
        {
            public override void deposit(double amount)
            {
                SetBalance(GetBalance() + amount);
            }
            public override void withdraw(double amount)
            {
                SetBalance(GetBalance() - amount);
            }
        }
        #endregion

        #region 4. I - Interface Segregation Principle (ISP)

        public interface IBank
        {
            void Deposit();

            void Withdraw();

            
        }
        public interface ILoan
        {
            void ApplyLoan();
        }
        public interface IgenerateFD
        {
            void GenerateFD();
        }
        public interface IgenerateInsurance
        {
            void GenerateInsurance();
        }
        public class CurrentAccount_ISP : IBank
        {
            public void Deposit()
            {
                // Implementation for deposit
            }
            public void Withdraw()
            {
                // Implementation for withdraw
            }
          
        }
        #endregion

        #region 5. D - Dependency Inversion Principle (DIP)

        #region BAD example of Dependency Inversion Principle
        public class Bank
        {
            SavingAccount account = new SavingAccount();
        }

        #endregion
        #region GOOD example of Dependency Inversion Principle
        public  class Bank_Good
        {

            // High-level modules should not depend on low-level modules. Both should depend on abstractions.
            private BankService account;

            public Bank_Good(BankService account)
            {
                this.account = account;
            }

            public void DepositMoney()
            {
                account.deposit(500);
            }
        }

        #endregion

        #endregion
        static void Main(string[] args)
        {

            BankService account;
            EmailService emailService = new EmailService();
            emailService.SendEmail();

            StatementService statementService = new StatementService();
            statementService.GeneratePdf();


            #region BAD Example of Liskov subtitution principle
            account = new CurrentAccount_good();
            account.deposit(1000); // consumer will get an exception because the method is not implemented, so we can create a new class for each functionality and inject it into the BankService class
            account.withdraw(500); 
            #endregion

            Bank_Good bank = new Bank_Good(new SavingAccount());
            bank.DepositMoney();

        }
    }
}
