using FluentAssertions;
using OpenQA.Selenium;
using SeleniumPractice.Demo.BankingProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumPractice.AdvancePractices.BankingProject.PageObjectModel
{
    class AddCustomerPage : BasePage
    {
        readonly By firstNameInput = By.XPath("//input[@ng-model='fName']");
        readonly By lastNameInput = By.XPath("//input[@ng-model='lName']");
        readonly By postCodeInput = By.XPath("//input[@ng-model='postCd']");
        readonly By submitBtn = By.XPath("//button[text()='Add Customer']");
        public AddCustomerPage(IWebDriver driver) {
            this.driver = driver;
            this.url = WebUrl.AddCustomer;
        }

        public void AddCustomer(string firstName, string lastName, string postCode) {
            driver.WaitUtil(firstNameInput).SendKeys(firstName);
            driver.WaitUtil(lastNameInput).SendKeys(lastName);
            driver.WaitUtil(postCodeInput).SendKeys(postCode);
            driver.WaitUtil(submitBtn).Click();    
        }

        public void AddCustomer(Customer customer) {
            AddCustomer(customer.FirstName, customer.LastName, customer.PostCode);
        }

        public void VerifyFirstNameValidationMessage(string message) {
            var currentmessage = driver.GetValidationMessage(firstNameInput);

            currentmessage.Should().Be(message);
        }

        public void VerifyLastNameValidationMessage(string message)
        {
            var currentmessage = driver.GetValidationMessage(lastNameInput);

            currentmessage.Should().Be(message);
        }

        public void VerifyPostCodeValidationMessage(string message)
        {
            var currentmessage = driver.GetValidationMessage(postCodeInput);

            currentmessage.Should().Be(message);
        }

        public void VerifyAlertCustomerIsAddedAndCloseTheAlert() {
            string addedsuccessfullyMessage = "Customer added successfully with customer id";
            var currentAlertContent = driver.SwitchTo().Alert().Text;
            driver.SwitchTo().Alert().Accept();

            currentAlertContent.Should().Contain(addedsuccessfullyMessage);
        }
    }
}
