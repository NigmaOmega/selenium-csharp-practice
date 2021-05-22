using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumPractice.AdvancePractices.BankingProject.PageObjectModel
{
    class CustomerLoginPage : BasePage
    {
        readonly By yourNameSelect = By.Id("userSelect");
        readonly By loginBtn = By.XPath("//button[text()='Login']");
        public CustomerLoginPage(IWebDriver driver)
        {
            this.driver = driver;
            this.url = WebUrl.CustomerLogin;
        }

        public CustomerAccountPage Login(string yourName)
        {
            SelectYourName(yourName);
            driver.WaitUtil(loginBtn).Click();

            return new CustomerAccountPage(driver);
        }

        public void VerifyLoginButtonDisplayed(bool displayed)
        {
            var isDisplayed = driver.WaitUtil(loginBtn, WaitType.WaitUtilExist).Displayed;

            Assert.AreEqual(displayed, isDisplayed);
        }

        public void VerifyPageIsActive() {
            var isDisplayed = driver.WaitUtil(yourNameSelect).Displayed;

            isDisplayed.Should().BeTrue();

        }

        public void SelectYourName(string yourName)
        {
            driver.Select(yourNameSelect).ByText(yourName);
        }
    }
}
