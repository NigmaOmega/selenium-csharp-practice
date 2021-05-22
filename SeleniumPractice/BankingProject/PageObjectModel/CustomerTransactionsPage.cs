using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumPractice.AdvancePractices.BankingProject.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Transactions;

namespace SeleniumPractice.AdvancePractices.BankingProject.PageObjectModel
{
    class CustomerTransactionsPage : CustomerPage
    {
        readonly By backBtn = By.XPath("//button[text()='Back']");
        readonly By resetBtn = By.XPath("//button[text()='Reset']");
        readonly By startDatePicker = By.Id("start");
        readonly By endDatePicker = By.Id("end");
        readonly By transactionTable = By.TagName("table");

        public CustomerTransactionsPage(IWebDriver driver)
        {
            this.driver = driver;
            this.url = WebUrl.CustomerTranaction;
        }

        public void VerifyPageIsActive()
        {
            var isDisplayed = driver.WaitUtil(transactionTable).Displayed;

            isDisplayed.Should().BeTrue();
        }

        public CustomerAccountPage BackToCustomerAccountPage()
        {
            driver.WaitUtil(backBtn).Click();
            return new CustomerAccountPage(driver);
        }

        public void Reset()
        {
            driver.WaitUtil(resetBtn).Click();
        }

        public void SelectDate(string startDate, string endDate)
        {
            driver.WaitUtil(startDatePicker).Clear();
            driver.WaitUtil(startDatePicker).SendKeys(startDate);
            driver.WaitUtil(endDatePicker).Clear();
            driver.WaitUtil(endDatePicker).SendKeys(endDate);
        }

        public void VerifyInformation(CustomerTransaction customerTransaction)
        {
            var transactions = GetTransactionInformations();

            transactions.Should().ContainEquivalentOf(customerTransaction);
        }

        public List<CustomerTransaction> GetTransactionInformations()
        {
            List<CustomerTransaction> transactions = new List<CustomerTransaction>();
            var data = driver.Table(transactionTable).GetTableData();
            foreach (var row in data)
            {
                CustomerTransaction transaction = new CustomerTransaction();
                transaction.DateTime = row[0];
                transaction.Amount = row[1].ToInt();
                transaction.Type = row[2];

                transactions.Add(transaction);
            }

            return transactions;
        }

        public void VerifyNumberOfTransactions(int expectedNumber)
        {
            var numberOfTransaction = GetTransactionInformations().Count;

            numberOfTransaction.Should().Be(expectedNumber);
        }

        public void VerifyLastCustomerTransaction(int amount, string type)
        {
            var transactions = GetTransactionInformations();
            var lastTransaction = transactions.Last();

            Assert.AreEqual(amount, lastTransaction.Amount);
            Assert.AreEqual(type, lastTransaction.Type);
        }
    }
}
