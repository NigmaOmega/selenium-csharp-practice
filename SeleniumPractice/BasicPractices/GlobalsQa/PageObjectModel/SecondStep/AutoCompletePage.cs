using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumPractice.GlobalsQa;
using System.Linq;

namespace SeleniumPractice.BasicPractices.GlobalsQa.PageObjectModel.LastStep
{
    class AutoCompletePage : BasePage
    {
        readonly By searchInput = By.Id("search");
        readonly By searchAutoCompleteItems = By.ClassName("ui-menu-item-wrapper");


        public AutoCompletePage(IWebDriver driver)
        {
            this.driver = driver;
            this.url = WebUrl.AutoComplete;
        }

        public void Search(string text)
        {
            driver.WaitUtil(searchInput).SendKeys(text);
        }

        public void Search(string searchKey, string ItemToMatch)
        {
            driver.WaitUtil(searchInput).SendKeys(searchKey);
            driver.FindElements(searchAutoCompleteItems).First(s => s.Text == ItemToMatch).Click();
        }

        public void VerifySearchBoxValue(string expectedValue)
        {
            var currentValue = driver.WaitUtil(searchInput).GetAttribute("value");

            Assert.AreEqual(expectedValue, currentValue);
        }
    }
}
