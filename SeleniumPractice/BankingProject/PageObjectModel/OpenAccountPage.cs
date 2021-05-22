using FluentAssertions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumPractice.AdvancePractices.BankingProject.PageObjectModel
{
    class OpenAccountPage : BasePage
    {
        readonly By customerSelect = By.Id("userSelect");
        readonly By currencySelect = By.Id("currency");
        readonly By processBtn = By.XPath("//button[text()='Process']");
        public OpenAccountPage(IWebDriver driver) {
            this.driver = driver;
            this.url = WebUrl.OpenAccount;
        }

        public void SelectCustomer(string customer) {
            driver.Select(customerSelect).ByText(customer);
        }

        public void SelectCurrency(string currency)
        {
            driver.Select(currencySelect).ByText(currency);
        }

        public void ClickOnProcessButton() {
            driver.WaitUtil(processBtn).Click();
        }

        public void VerifyCustomerNameValidationMessage(string message) {
            var currentMessage = driver.GetValidationMessage(customerSelect);

            currentMessage.Should().Be(message);
        }

        public void VerifyCurrencyValidationMessage(string message)
        {
            var currentMessage = driver.GetValidationMessage(currencySelect);

            currentMessage.Should().Be(message);
        }

        public void OpenAccount(string customer, string currency) {
            SelectCustomer(customer);
            SelectCurrency(currency);
            ClickOnProcessButton();
        }

        public string GetAccountNumberIsCreatedInAlert() {
            return driver.SwitchTo().Alert().Text.ExtractNumbers()[0].ToString();
        }

        public void CloseAlert() {
            driver.SwitchTo().Alert().Accept();
        }

        public void VerifyAccountIsOpenedAndCloseAlert() {
            var currentText = driver.SwitchTo().Alert().Text;
            CloseAlert();
            var expectedText = "Account created successfully with account Number";

            currentText.Should().Contain(expectedText);
        }
    }
}
