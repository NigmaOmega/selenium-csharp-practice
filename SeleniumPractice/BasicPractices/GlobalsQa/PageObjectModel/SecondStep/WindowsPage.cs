using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumPractice.GlobalsQa;
using System.Linq;

namespace SeleniumPractice.BasicPractices.GlobalsQa.PageObjectModel.LastStep
{
    class WindowsPage : BasePage
    {
        readonly By clickHereBtn = By.XPath("//*[@rel-title='Open New Window']/a");

        public WindowsPage(IWebDriver driver)
        {
            this.driver = driver;
            this.url = WebUrl.Windows;
        }
        public new void GoTo()
        {
            By openNewWindowTab = By.Id("Open New Window");
            driver.Navigate().GoToUrl(url);
            driver.WaitUtil(openNewWindowTab).Click();
        }

        public void OpenNewWindow()
        {
            driver.WaitUtil(clickHereBtn).Click();
        }

        public void VerifyNewWindowIsCreated(string windowUrl)
        {
            var currentWindow = driver.WindowHandles.Last();
            driver.SwitchTo().Window(currentWindow);
            var currentUrl = driver.Url;

            Assert.AreEqual(windowUrl, currentUrl);
        }

    }
}
