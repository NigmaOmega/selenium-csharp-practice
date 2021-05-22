using NUnit.Framework;
using SeleniumPractice.AdvancePractices.BankingProject.PageObjectModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumPractice.Demo.BankingProject.TestCases
{
    class OpenAccount : BaseTest
    {
        OpenAccountPage openAccountPage;

        string validationMessage = "Please select an item in the list.";


        [SetUp]
        public void ClassSetUp() {
            openAccountPage = new OpenAccountPage(driver);
            openAccountPage.GoTo();
        }

        [Test]
        public void OpenAnAccount() {
            openAccountPage.OpenAccount(BankConstants.CustomerAccountValid.CustomerName, BankConstants.CustomerAccountValid.Currency);
            var newAccountNumber = openAccountPage.GetAccountNumberIsCreatedInAlert();
            openAccountPage.VerifyAccountIsOpenedAndCloseAlert();

            HomePage homePage = new HomePage(driver);
            homePage.GoTo();
            var customerLoginPage = homePage.CustomerLogin();
            CustomerAccountPage customerAccountPage = customerLoginPage.Login(BankConstants.CustomerAccountValid.CustomerName);
            customerAccountPage.VerifyCutomerHaveAccount(newAccountNumber);
        }


        [Test]
        public void OpenAnAccountWithoutSelectCustomerName()
        {
            openAccountPage.SelectCurrency(BankConstants.CustomerAccountValid.Currency);
            openAccountPage.ClickOnProcessButton();
            openAccountPage.VerifyCustomerNameValidationMessage(validationMessage);
        }

        [Test]
        public void OpenAnAccountWithoutSelectCurrency()
        {
            openAccountPage.SelectCustomer(BankConstants.CustomerAccountValid.CustomerName);
            openAccountPage.ClickOnProcessButton();
            openAccountPage.VerifyCurrencyValidationMessage(validationMessage);
        }
    }
}
