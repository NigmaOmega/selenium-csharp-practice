using OpenQA.Selenium;

namespace SeleniumPractice.AdvancePractices.BankingProject.PageObjectModel
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected string url;

        public void GoTo()
        {
            driver.Navigate().GoToUrl(url);
        }

    }
}