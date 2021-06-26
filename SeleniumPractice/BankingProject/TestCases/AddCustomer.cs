using NUnit.Framework;
using SeleniumPractice.AdvancePractices.BankingProject.PageObjectModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumPractice.Demo.BankingProject.TestCases
{
    [Category("Bank Project")]
    class AddCustomer : BaseTest
    {
        AddCustomerPage addCustomerPage;

        string errorMessage = "Please fill out this field.";



        [SetUp]
        public void ClassSetUp() {
            var managerPage = new ManagerPage(driver);
            managerPage.GoTo();
            addCustomerPage = managerPage.GoToAddCustomer();
        }

        [Test]
        public void AddACustomer() {
            string firstName = "W33";
            string lastName = "Haa";
            string postCode = "123";
            addCustomerPage.AddCustomer(firstName, lastName, postCode);
            addCustomerPage.VerifyAlertCustomerIsAddedAndCloseTheAlert();

            CustomerLoginPage customerLoginPage = new CustomerLoginPage(driver);
            customerLoginPage.GoTo();
            string newCustomerName = firstName + " " + lastName;
            customerLoginPage.Login(newCustomerName).VerifyTheCustomerIsLoggedIn(newCustomerName);
        }

        [Test]
        public void AddACustomerWithoutFirstName()
        {
            string firstName = "";
            string lastName = "Haa";
            string postCode = "123";
            addCustomerPage.AddCustomer(firstName, lastName, postCode);
            addCustomerPage.VerifyFirstNameValidationMessage(errorMessage);
        }

        [Test]
        public void AddACustomerWithoutLastName()
        {
            string firstName = "W33";
            string lastName = "";
            string postCode = "123";
            addCustomerPage.AddCustomer(firstName, lastName, postCode);
            addCustomerPage.VerifyLastNameValidationMessage(errorMessage);
        }


        [Test]
        public void AddACustomerWithoutPostCode()
        {
            string firstName = "W33";
            string lastName = "Haa";
            string postCode = "";
            addCustomerPage.AddCustomer(firstName, lastName, postCode);
            addCustomerPage.VerifyPostCodeValidationMessage(errorMessage);
        }

    }
}
