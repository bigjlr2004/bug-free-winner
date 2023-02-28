//This file will contain the definition of a bank account.
//The bank account supports this behavior.

// 1) It has a 10-digit number that uniquely identifies the bank account.
// 2) It has a string that stores the name or names of the owners.
// 3) The balance can be retrieved.
// 4) It accepts deposits.
// 5) It accepts withdrawls.
// 6) The intial balance must be positive.
// 7) Withdrawals can't result in a negative balance.

using System;
using System.Collections.Generic;
public class BankAccount
{
    private static int accountNumberSeed = 1234567890;
    public string Number { get; }
    public string Owner { get; set; }
    public decimal Balance
    {
        get
        {

            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }
    }
    public BankAccount(string name, decimal initialBalance)
    {
        this.Owner = name;
        MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
        this.Number = accountNumberSeed.ToString();
        accountNumberSeed++;
    }
    private List<Transaction> allTransactions = new List<Transaction>();

    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
        }
        var deposit = new Transaction(amount, date, note);
        allTransactions.Add(deposit);
    }

    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
        }
        if (Balance - amount < 0)
        {
            throw new InvalidOperationException("Not sufficient funds for this withdrawal");
        }
        var withdrawal = new Transaction(-amount, date, note);
        allTransactions.Add(withdrawal);
    }
    public string GetAccountHistory()
    {
        var report = new System.Text.StringBuilder();

        decimal balance = 0;
        report.AppendLine("Date\t\tAmount\tBalance\tNote");
        foreach (var item in allTransactions)
        {
            balance += item.Amount;
            report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
        }

        return report.ToString();
    }
}