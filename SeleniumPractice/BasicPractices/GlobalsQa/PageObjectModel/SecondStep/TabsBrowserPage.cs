using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumPractice.GlobalsQa;
using System.Linq;

namespace SeleniumPractice.BasicPractices.GlobalsQa.PageObjectModel.SecondStep
{
    class TabsBrowserPage : BasePage
    {
        readonly By clickHereBtn = By.XPath("//*[@rel-title='Open New Tab']/a");

        public TabsBrowserPage(IWebDriver driver)
        {
            this.driver = driver;
            this.url = WebUrl.TabsBrowser;
        }

        public void OpenNewTab()
        {
            driver.WaitUtil(clickHereBtn).Click();
        }

        public void VerifyNewTabIsOpen(string tabUrl)
        {
            var currentTab = driver.WindowHandles.Last();
            driver.SwitchTo().Window(currentTab);
            var currentUrl = driver.Url;

            Assert.AreEqual(tabUrl, currentUrl);
        }
    }
}
