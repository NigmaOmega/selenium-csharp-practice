using NUnit.Framework;
using SeleniumPractice.AdvancePractices.BankingProject.Model;
using SeleniumPractice.AdvancePractices.BankingProject.PageObjectModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumPractice.Demo.BankingProject.TestCases
{
    class CustomerAccount : BaseTest
    {
        CustomerAccountPage customerAccountPage;
        Account account;


        [SetUp]
        public void ClassSetUp() {
            account = BankConstants.CustomerAccountValid;
            CustomerLoginPage customerLoginPage = new CustomerLoginPage(driver);
            customerLoginPage.GoTo();
            customerAccountPage = customerLoginPage.Login(account.CustomerName);
        }

        [Test]
        public void CustomerAccountPageDisplayedCorrectInformation() {
            customerAccountPage.VerifyTheCustomerInformation(account);
        }

        [Test]
        public void ChooseOtherAccountOfTheCustomer() {
            customerAccountPage.SelectAccount(BankConstants.CustomerAccountValidOther.AccountNumber);
            customerAccountPage.VerifyTheCustomerInformation(BankConstants.CustomerAccountValidOther);
        }
    }
}
