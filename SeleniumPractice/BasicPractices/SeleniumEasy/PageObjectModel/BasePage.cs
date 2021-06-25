using OpenQA.Selenium;

namespace SeleniumPractice.SeleniumEasy.PageObjectModel
{
    class BasePage
    {
        protected string pageUrl;
        protected IWebDriver driver;
        public void GoTo()
        {
            if (pageUrl == null)
            {
                throw new System.Exception("The page URL of PageObjectModel is not set!");
            }
            driver.Navigate().GoToUrl(pageUrl);
            driver.Sleep(20000);
        }
    }
}
