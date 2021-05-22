using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumPractice.AdvancePractices.BankingProject.PageObjectModel
{
    class HomePage : BasePage
    {
        readonly By customerLoginBtn = By.XPath("//button[text()='Customer Login']");
        readonly By bankManagerLoginPage = By.XPath("//button[text()='Bank Manager Login']");
        public HomePage(IWebDriver driver) {
            this.driver = driver;
            this.url = WebUrl.Home;
        }

        public CustomerLoginPage CustomerLogin() {
            driver.WaitUtil(customerLoginBtn).Click();

            return new CustomerLoginPage(driver);
        }

        public ManagerPage BankManagerLoginPage() {
            driver.WaitUtil(bankManagerLoginPage).Click();

            return new ManagerPage(driver);
        }
    }
}
