using System;
using System.Globalization;
using System.Threading;

class BankAccount
{
    public string AccountNumber { get; private set; }
    public string AccountHolderName { get; private set; }
    public double Balance { get; private set; }

    public BankAccount() : this("000000", "Dummy", 0.0)
    {
        Console.WriteLine("Default constructor called.");
    }

    public BankAccount(string accountNumber) : this(accountNumber, "Unknown", 0.0)
    {
        Console.WriteLine("Chained constructor with AccountNumber called.");
    }

    public BankAccount(string accountNumber, string accountHolderName, double balance)
    {
        if (balance < 0)
        {
            throw new ArgumentException("Balance cannot be negative.");
        }

        AccountNumber = accountNumber;
        AccountHolderName = accountHolderName;
        Balance = balance;

        Console.WriteLine("Parameterized constructor called.");
    }

    public void DisplayInfo()
    {
        Console.WriteLine("\n--- Account Information ---");
        Console.WriteLine($"Account Number     : {AccountNumber}");
        Console.WriteLine($"Account Holder Name: {AccountHolderName}");
        Console.WriteLine($"Balance            : {Balance.ToString("C", CultureInfo.CurrentCulture)}");
    }
}

class Program
{
    static void Main()
    {
        CultureInfo culture = new CultureInfo("en-US"); 
        Thread.CurrentThread.CurrentCulture = culture;
        Thread.CurrentThread.CurrentUICulture = culture;

        try
        {
            BankAccount account1 = new BankAccount();
            account1.DisplayInfo();

            Console.Write("\nEnter Account Number for chained constructor: ");
            string acNo = Console.ReadLine();
            BankAccount account2 = new BankAccount(acNo);
            account2.DisplayInfo();

            Console.Write("\nEnter Account Number       : ");
            string accNo = Console.ReadLine();

            Console.Write("Enter Account Holder Name  : ");
            string accName = Console.ReadLine();

            double accBalance;
            while (true)
            {
                Console.Write("Enter Initial Balance      : ");
                if (double.TryParse(Console.ReadLine(), out accBalance) && accBalance >= 0)
                {
                    break;
                }
                Console.WriteLine("Invalid input! Balance must be a non-negative number.");
            }

            BankAccount account3 = new BankAccount(accNo, accName, accBalance);
            account3.DisplayInfo();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError: {ex.Message}");
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}