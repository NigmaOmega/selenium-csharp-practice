using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumPractice.AdvancePractices.BankingProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeleniumPractice.AdvancePractices.BankingProject.PageObjectModel
{
    class CustomerAccountPage : CustomerPage
    {
        readonly By customerNameTxt = By.ClassName("fontBig");
        readonly By accountSelect = By.Id("accountSelect");
        readonly By accountNumberTxt = By.XPath("//*[@ng-hide='noAccount']/strong[1]");
        readonly By balanceTxt = By.XPath("//*[@ng-hide='noAccount']/strong[2]");
        readonly By currencyTxt = By.XPath("//*[@ng-hide='noAccount']/strong[3]");
        readonly By transactionBtn = By.XPath("//*[@ng-class='btnClass1']");
        readonly By depositBtn = By.XPath("//*[@ng-class='btnClass2']");
        readonly By withdrawlBtn = By.XPath("//*[@ng-class='btnClass3']");

        public CustomerAccountPage(IWebDriver driver)
        {
            this.driver = driver;
            this.url = WebUrl.CustomerAccount;
        }

        public DepositPanel Deposit()
        {
            driver.WaitUtil(depositBtn).Click();
            driver.Sleep(1500);
            return new DepositPanel(driver);
        }

        public void VerifyCutomerHaveAccount(string accountNumber) {
            var accounts = driver.WaitUtil(accountSelect).FindElements(By.TagName("option")).Select(s => s.Text).ToList();

            accounts.Should().Contain(accountNumber);
        }

        public WithdrawlPanel Withdrawl()
        {
            driver.WaitUtil(withdrawlBtn).Click();
            driver.Sleep(1500);
            return new WithdrawlPanel(driver);
        }

        public int GetBalance()
        {
            return driver.WaitUtil(balanceTxt).Text.ToInt();
        }

        public void VerifyBalance(int expectedBalance)
        {
            var currentBalance = GetBalance();
            currentBalance.Should().Equals(expectedBalance);
        }

        public Account GetAccountInformation()
        {
            var customerName = driver.WaitUtil(customerNameTxt).Text;
            var accountNumber = driver.WaitUtil(accountNumberTxt).Text;
            var balance = GetBalance();
            var currency = driver.WaitUtil(currencyTxt).Text;

            Account result = new Account(customerName, accountNumber, balance, currency);
            return result;
        }

        public void SelectAccount(string accountId)
        {
            driver.Select(accountSelect).ByText(accountId);
        }

        public CustomerTransactionsPage Transactions()
        {
            driver.WaitUtil(transactionBtn).Click();
            return new CustomerTransactionsPage(driver);
        }
        public void VerifyTheCustomerIsLoggedIn(string customerName)
        {
            var userName = driver.WaitUtil(customerNameTxt).Text;
            Assert.AreEqual(customerName, userName);
        }

        public void VerifyTheCustomerInformation(Account account)
        {
            var currentAccount = GetAccountInformation();

            currentAccount.Should().Equals(account);
        }
    }

    class DepositPanel : BasePage
    {
        readonly By amountInput = By.XPath("//input[@ng-model='amount']");
        readonly By depositBtn = By.XPath("//form[@name='myForm']/button");
        readonly By errorMessageTxt = By.ClassName("error");

        public DepositPanel(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void WithAmount(int amount)
        {
            driver.WaitUtil(amountInput).SendKeys(amount.ToString());
            driver.WaitUtil(depositBtn).Click();
        }

        public void VerifyMessage(string expectedMessage) {
            var currentmessage = driver.WaitUtil(errorMessageTxt).Text;

            currentmessage.Should().Equals(expectedMessage);
        }
    }

    class WithdrawlPanel : BasePage
    {
        readonly By amountInput = By.XPath("//input[@ng-model='amount']");
        readonly By withdrawlBtn = By.XPath("//form[@name='myForm']/button");
        readonly By errorMessageTxt = By.ClassName("error");

        public WithdrawlPanel(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void WithAmount(int amount)
        {
            driver.WaitUtil(amountInput).SendKeys(amount.ToString());
            driver.WaitUtil(withdrawlBtn).Click();
        }
        public void VerifyMessage(string expectedErrorMessage)
        {
            var currentErrorMessage = driver.WaitUtil(errorMessageTxt).Text;

            currentErrorMessage.Should().Equals(expectedErrorMessage);
        }
    }
}
