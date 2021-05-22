using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumPractice.GlobalsQa;


namespace SeleniumPractice.BasicPractices.GlobalsQa.PageObjectModel.FirstStep
{
    class TabsPage : BasePage
    {
        public TabsPage(IWebDriver driver)
        {
            this.driver = driver;
            this.url = WebUrl.Tabs;
        }

        private By GetTabLocator(string tabName)
        {
            return By.XPath("//h3[text()='" + tabName + "']");
        }

        private By GetTabContentLocator(string tabName)
        {
            var tab = GetTabLocator(tabName);
            var tabId = driver.WaitUtil(tab).GetAttribute("Id");
            return By.XPath("//div[@aria-labelledby='" + tabId + "']");
        }

        public void SelectTab(string tabName)
        {
            var tab = GetTabLocator(tabName);
            driver.WaitUtil(tab).Click();
        }

        public void VerifyActivationOfTab(string tabName, bool isActive = true)
        {
            var tab = GetTabLocator(tabName);
            var currentActiveStatus = driver.WaitUtil(tab).GetAttribute("class").Contains("ui-state-active");

            Assert.AreEqual(isActive, currentActiveStatus);
        }

        public void VerifyVisibilityOfTabContent(string tabName, bool isDisplayed)
        {
            var tabcontent = GetTabContentLocator(tabName);
            var currentStatus = driver.WaitUtil(tabcontent, WaitType.WaitUtilExist).Displayed;

            Assert.AreEqual(isDisplayed, currentStatus);
        }
    }
}
