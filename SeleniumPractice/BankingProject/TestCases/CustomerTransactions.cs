using FluentAssertions;
using NUnit.Framework;
using SeleniumPractice.AdvancePractices.BankingProject.Model;
using SeleniumPractice.AdvancePractices.BankingProject.PageObjectModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumPractice.Demo.BankingProject.TestCases
{
    [Category("Bank Project")]
    class CustomerTransactions : BaseTest
    {
        CustomerAccountPage customerAccountPage;

        readonly string messageExceedBalanceLitmit = "Transaction Failed. You can not withdraw amount more than the balance.";
        readonly string messageDepositSuccessfully = "Deposit Successful";
        readonly string messageWithdrawlSuccessfully = "Withdrawl Successful";

        readonly int amount = 200;
        readonly string depositType = "Credit";
        readonly string withdrawlType = "Debit";

        [SetUp]
        public void ClassSetUp()
        {
       
            CustomerLoginPage customerLoginPage = new CustomerLoginPage(driver);
            customerLoginPage.GoTo();
            customerAccountPage = customerLoginPage.Login(BankConstants.CustomerAccountValid.CustomerName);
        }

        [Test]
        public void DepositMoney()
        {
            int currentBalance = customerAccountPage.GetBalance();
            customerAccountPage.Deposit().WithAmount(amount);

            int expectedBalance = currentBalance + amount;

            customerAccountPage.Deposit().VerifyMessage(messageDepositSuccessfully);
            customerAccountPage.VerifyBalance(expectedBalance);

            customerAccountPage.Transactions().VerifyLastCustomerTransaction(amount,depositType);
        }

        [Test]
        public void WithDrawlMoneyExceedBalance() {
            customerAccountPage.Deposit().WithAmount(amount);

            int currentBalance = customerAccountPage.GetBalance();
            int exceedBalanceLimitNumber = currentBalance + 1;
            customerAccountPage.Withdrawl().WithAmount(exceedBalanceLimitNumber);

            customerAccountPage.Withdrawl().VerifyMessage(messageExceedBalanceLitmit);
            customerAccountPage.VerifyBalance(currentBalance);
        }

        [Test]
        public void WithDrawlValidAmountOfMoney() {
            customerAccountPage.Deposit().WithAmount(amount);
            int currentBalance = customerAccountPage.GetBalance();

            customerAccountPage.Withdrawl().WithAmount(amount);
            int expectedBalance = currentBalance - amount;

            customerAccountPage.Withdrawl().VerifyMessage(messageWithdrawlSuccessfully);
            customerAccountPage.VerifyBalance(expectedBalance);
            customerAccountPage.Transactions().VerifyLastCustomerTransaction(amount, withdrawlType);
        }

        [Test]
        public void ResetCustomerTransactions() {
            customerAccountPage.Deposit().WithAmount(amount);
            customerAccountPage.Deposit().WithAmount(amount);
            var transactionPage = customerAccountPage.Transactions();
            transactionPage.Reset();
            transactionPage.VerifyNumberOfTransactions(0);
        }
    }
}
