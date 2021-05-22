using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumPractice.AdvancePractices.BankingProject.PageObjectModel
{
    class CustomerPage : BasePage
    {
        readonly By homeBtn= By.ClassName("home");
        readonly By LogoutBtn = By.ClassName("logout");

        public void GotoHomePage() {
            driver.WaitUtil(homeBtn).Click();
        }

        public CustomerLoginPage Logout() {
            driver.WaitUtil(LogoutBtn).Click();

            return new CustomerLoginPage(driver);
        }


    }
}
