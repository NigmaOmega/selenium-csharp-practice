using OpenQA.Selenium;

namespace SeleniumPractice.GlobalsQa
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