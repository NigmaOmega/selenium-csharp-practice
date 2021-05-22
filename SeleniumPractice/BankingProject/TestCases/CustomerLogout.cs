using NUnit.Framework;
using SeleniumPractice.AdvancePractices.BankingProject.PageObjectModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumPractice.Demo.BankingProject.TestCases
{
    class CustomerLogout : BaseTest
    {
        CustomerLoginPage customerLoginPage;

        [SetUp]
        public void ClassSetUp() {
            customerLoginPage = new CustomerLoginPage(driver);
            customerLoginPage.GoTo();
            customerLoginPage.Login(BankConstants.CustomerAccountValid.CustomerName);
        }

        [Test]
        public void CustomerLogoutFromAccountPage() {
            CustomerAccountPage customerAccountPage = new CustomerAccountPage(driver);
            customerAccountPage.GoTo();
            customerAccountPage.Logout();
            customerLoginPage.VerifyPageIsActive();
        }

        [Test]
        public void CustomerLogoutFromTransactionsPage() {
            CustomerTransactionsPage customerTransactionPage = new CustomerTransactionsPage(driver);
            customerTransactionPage.GoTo();
            customerTransactionPage.Logout();
            customerLoginPage.VerifyPageIsActive();
        }
    }
}
