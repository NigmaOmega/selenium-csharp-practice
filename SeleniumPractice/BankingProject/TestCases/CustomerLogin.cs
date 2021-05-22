using NUnit.Framework;
using SeleniumPractice.AdvancePractices.BankingProject.PageObjectModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumPractice.Demo.BankingProject.TestCases
{
    class CustomerLogin : BaseTest
    {
        CustomerLoginPage customerLoginPage;
        readonly string yourName = BankConstants.CustomerAccountValid.CustomerName;
        readonly string yourNameDefaultValue = "---Your Name---";
        [SetUp]
        public void ClassSetUp() {
            customerLoginPage = new CustomerLoginPage(driver);
            customerLoginPage.GoTo();
        }

        [Test]
        public void LoginButtonDoNotDisplayedWhenDoNotChooseYourName() {
            customerLoginPage.VerifyLoginButtonDisplayed(false);
        }

        [Test]
        public void LoginButtonDisapearedWhenDeselectYourName()
        {
            customerLoginPage.SelectYourName(yourName);
            customerLoginPage.SelectYourName(yourNameDefaultValue);
            customerLoginPage.VerifyLoginButtonDisplayed(false);
        }

        [Test]
        public void LoginButtonDisplayedWhenSelectYourName() {
            customerLoginPage.SelectYourName(yourName);
            customerLoginPage.VerifyLoginButtonDisplayed(true);
        }

        [Test]
        public void Login_Successfully() {
            CustomerAccountPage customerAccountPage = customerLoginPage.Login(yourName);
            customerAccountPage.VerifyTheCustomerIsLoggedIn(yourName);
        }
    }
}
