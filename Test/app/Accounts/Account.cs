using System;

namespace app.Accounts
{
    public class Account
    {
        public Account(decimal balance)
        {
            Balance = balance;
        }

        public decimal Balance { get; }

        public double CalculateInterestRate()
        {
            if (Balance >= 50000) return 0.03;
            if (Balance >= 10000) return 0.025;
            if (Balance >= 5000) return 0.02;
            if (Balance >= 1000) return 0.015;
            if (Balance >= 0) return 0.01;
            return 0.0;
        }

        public decimal CalculateInterestPaid()
        {
            return Math.Round(Balance * (decimal)CalculateInterestRate() ,2);
        }
    }
}
