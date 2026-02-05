using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Represents a bank transaction.
/// </summary>
public class Transaction
{
    public string TransactionId { get; set; }
    public DateTime TransactionDate { get; set; }
    public string Type { get; set; } // Deposit, Withdrawal, Transfer
    public double Amount { get; set; }
    public string Description { get; set; }
}

/// <summary>
/// Represents a bank account.
/// </summary>
public class Account
{
    public string AccountNumber { get; set; }
    public string AccountHolder { get; set; }
    public string AccountType { get; set; } // Savings, Current, Fixed
    public double Balance { get; set; }
    public List<Transaction> TransactionHistory { get; set; } = new List<Transaction>();
}

/// <summary>
/// Manages bank accounts and transactions.
/// </summary>
public class BankManager
{
    private List<Account> accounts = new List<Account>();
    private int accountCounter = 1000;

    /// <summary>
    /// Creates a new account.
    /// </summary>
    public void CreateAccount(string holder, string type, double initialDeposit)
    {
        if (string.IsNullOrWhiteSpace(holder))
        {
            Console.WriteLine("Account holder name cannot be empty.");
            return;
        }

        if (initialDeposit < 0)
        {
            Console.WriteLine("Initial deposit cannot be negative.");
            return;
        }

        var account = new Account
        {
            AccountNumber = "ACC" + accountCounter++,
            AccountHolder = holder,
            AccountType = type,
            Balance = initialDeposit
        };

        account.TransactionHistory.Add(new Transaction
        {
            TransactionId = Guid.NewGuid().ToString(),
            TransactionDate = DateTime.Now,
            Type = "Deposit",
            Amount = initialDeposit,
            Description = "Initial Deposit"
        });

        accounts.Add(account);
        Console.WriteLine($"Account created successfully! Account Number: {account.AccountNumber}");
    }

    /// <summary>
    /// Deposits amount into an account.
    /// </summary>
    public bool Deposit(string accountNumber, double amount)
    {
        var account = accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        if (account == null)
        {
            Console.WriteLine("Account not found.");
            return false;
        }

        if (amount <= 0)
        {
            Console.WriteLine("Deposit amount must be positive.");
            return false;
        }

        account.Balance += amount;
        account.TransactionHistory.Add(new Transaction
        {
            TransactionId = Guid.NewGuid().ToString(),
            TransactionDate = DateTime.Now,
            Type = "Deposit",
            Amount = amount,
            Description = "Deposit"
        });

        Console.WriteLine($"Deposited {amount:C} to {account.AccountNumber}. New Balance: {account.Balance:C}");
        return true;
    }

    /// <summary>
    /// Withdraws amount from an account.
    /// </summary>
    public bool Withdraw(string accountNumber, double amount)
    {
        var account = accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        if (account == null)
        {
            Console.WriteLine("Account not found.");
            return false;
        }

        if (amount <= 0 || amount > account.Balance)
        {
            Console.WriteLine("Invalid withdrawal amount.");
            return false;
        }

        account.Balance -= amount;
        account.TransactionHistory.Add(new Transaction
        {
            TransactionId = Guid.NewGuid().ToString(),
            TransactionDate = DateTime.Now,
            Type = "Withdrawal",
            Amount = amount,
            Description = "Withdrawal"
        });

        Console.WriteLine($"Withdrew {amount:C} from {account.AccountNumber}. New Balance: {account.Balance:C}");
        return true;
    }

    /// <summary>
    /// Groups accounts by type (Savings/Current/Fixed).
    /// </summary>
    public Dictionary<string, List<Account>> GroupAccountsByType()
    {
        return accounts
            .GroupBy(a => a.AccountType)
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    /// <summary>
    /// Retrieves account statement within a date range.
    /// </summary>
    public List<Transaction> GetAccountStatement(string accountNumber, DateTime from, DateTime to)
    {
        var account = accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        if (account == null)
        {
            Console.WriteLine("Account not found.");
            return new List<Transaction>();
        }

        return account.TransactionHistory
                      .Where(t => t.TransactionDate >= from && t.TransactionDate <= to)
                      .OrderBy(t => t.TransactionDate)
                      .ToList();
    }
}

/// <summary>
/// Example usage of the BankManager system.
/// </summary>
public class Program
{
    public static void Main()
    {
        BankManager bank = new BankManager();

        bank.CreateAccount("Alice Johnson", "Savings", 5000);
        bank.CreateAccount("Bob Smith", "Current", 10000);

        bank.Deposit("ACC1000", 2000);
        bank.Withdraw("ACC1000", 1000);

        Console.WriteLine("\nAccounts Grouped by Type:");
        var grouped = bank.GroupAccountsByType();
        foreach (var group in grouped)
        {
            Console.WriteLine($"{group.Key}: {group.Value.Count} accounts");
        }

        Console.WriteLine("\nTransaction Statement for ACC1000:");
        var statement = bank.GetAccountStatement("ACC1000", DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1));
        foreach (var t in statement)
        {
            Console.WriteLine($"{t.TransactionDate}: {t.Type} of {t.Amount:C} - {t.Description}");
        }
    }
}
