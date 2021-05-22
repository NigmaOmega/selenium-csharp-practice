using FluentAssertions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumPractice.AdvancePractices.BankingProject.PageObjectModel
{
    class ManagerPage : BasePage
    {
        readonly By addCustomerBtn = By.XPath("//*[@ng-class='btnClass1']");
        readonly By openAccountBtn = By.XPath("//*[@ng-class='btnClass2']");
        readonly By CustomersBtn = By.XPath("//*[@ng-class='btnClass3']");


        public ManagerPage(IWebDriver driver) {
            this.driver = driver;
            this.url = WebUrl.Manager;
        }

        public void VerifyPageIsActive() {
            var isDisplayed = driver.WaitUtil(addCustomerBtn).Displayed;

            isDisplayed.Should().BeTrue();
        }

        public AddCustomerPage GoToAddCustomer() {
            driver.WaitUtil(addCustomerBtn).Click();
            return new AddCustomerPage(driver);
        }

        public OpenAccountPage GoToOpenAccount()
        {
            driver.WaitUtil(openAccountBtn).Click();
            return new OpenAccountPage(driver);
        }

        public ListCustomersPage GoToCustomers()
        {
            driver.WaitUtil(CustomersBtn).Click();
            return new ListCustomersPage(driver);
        }
    }
}
