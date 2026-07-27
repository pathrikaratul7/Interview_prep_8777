

public class abs_interfaceDay1
{


    // bank account Saving account & currentAccount
    // both account having check balance , withdrwal , deposit options
    // calculate interest option available only for saving account

    public abstract class BankService // best abstract example
    {
        
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
    public class SavingAccount : BankService , IinterestCalculater // inheriting abstract class and implementing interface
    {
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

    static void Main(string[] args)

    {
        BankService savacc;
        savacc = new SavingAccount();

        Console.WriteLine("Saving Account Details");
        savacc.CheckBalance();
        savacc.deposit(500);
        Console.WriteLine("New balance updated, please see below");
        savacc.CheckBalance();
        Console.WriteLine("New balance updated, please see below");
        savacc.withdraw(500);
        savacc.CheckBalance();
        Console.WriteLine("New balance updated, please see below");


        IinterestCalculater Ical = new SavingAccount();
        Ical.calculateinterest();

        Console.WriteLine("Current Account Details");
        savacc = new currentAccount();
        savacc.CheckBalance();
        Console.WriteLine("New balance updated, please see below");
        savacc.deposit(1000);
        Console.WriteLine("New balance updated, please see below");
        savacc.CheckBalance();
        Console.WriteLine("New balance updated, please see below");
        savacc.withdraw(700);
        savacc.CheckBalance();

        Console.WriteLine("New balance updated, please see below");






    }

}