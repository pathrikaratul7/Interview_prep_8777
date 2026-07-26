

public class abs_interfaceDay1
{


    // bank account Saving account & currentAccount
    // both account having check balance , withdrwal , deposit options
    // calculate interest option available only for saving account

    public abstract class BankService
    {
        public double Balance = 10000;
        public void CheckBalance() // we shared this common logic everywere (Balance)
        {
           Console.WriteLine($"Your balance is : { Balance}");
        }
        public abstract void withdraw(double amount);
        public abstract void deposit(double amount);
    
    }
    public interface IinterestCalculater
    { 
      double calculateinterest();
    }
    public class SavingAccount : BankService , IinterestCalculater
    {
        public override void withdraw(double amount)
        {
            Balance -= amount;
        }
        public override void deposit(double amount)
        {
            Balance += amount;
        }
        public double calculateinterest()
        {
            return Balance * 5;
        }
    }
    public class currentAccount : BankService
    {
        public override void withdraw(double amount)
        {
            Balance -= amount;
        }
        public override void deposit(double amount)
        {
            Balance += amount;
        }

    }

    static void Main(string[] args)

    {
        SavingAccount savacc = new SavingAccount();

        Console.WriteLine("Saving Account Details");
        savacc.CheckBalance();
        savacc.deposit(500);
        Console.WriteLine("New balance updated, please see below");
        savacc.CheckBalance();
        Console.WriteLine("New balance updated, please see below");
        savacc.withdraw(500);
        savacc.CheckBalance();
        Console.WriteLine("New balance updated, please see below");

        savacc.calculateinterest();

        Console.WriteLine("Current Account Details");
        currentAccount cuacc = new currentAccount();
        cuacc.CheckBalance();
        Console.WriteLine("New balance updated, please see below");
        cuacc.deposit(1000);
        Console.WriteLine("New balance updated, please see below");
        cuacc.CheckBalance();
        Console.WriteLine("New balance updated, please see below");
        cuacc.withdraw(700);
        cuacc.CheckBalance();

        Console.WriteLine("New balance updated, please see below");






    }

}