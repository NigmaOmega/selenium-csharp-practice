using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumPractice.AdvancePractices.BankingProject.Model
{
    class Account
    {
        public Account(string customerName, string accountNumber, int balance, string currency)
        {
            CustomerName = customerName;
            AccountNumber = accountNumber;
            Balance = balance;
            Currency = currency;
        }

        public Account(string customerName, string accountNumber, string currency)
        {
            CustomerName = customerName;
            AccountNumber = accountNumber;
            Currency = currency;
        }


        public string CustomerName { get; set; }
        public string AccountNumber { get; set; }
        public int Balance { get; set; }
        public string Currency { get; set; }
    }
}
