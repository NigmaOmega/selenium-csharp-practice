using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumPractice.GlobalsQa;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumPractice.BasicPractices.GlobalsQa.PageObjectModel.LastStep
{
    class SelectElementPage : BasePage
    {
        readonly By itemOptions = By.TagName("li");
        public SelectElementPage(IWebDriver driver)
        {
            this.driver = driver;
            this.url = WebUrl.SelectElements;
        }

        public void SelectItems(List<string> items)
        {
            driver.WaitUtil(itemOptions);
            var options = driver.FindElements(itemOptions).ToList();

            var optionsToSelect = options.Where(s => items.Contains(s.Text)).ToList();

            Actions action = new Actions(driver);
            action.KeyDown(Keys.Control);
            action.Perform();

            foreach (var item in optionsToSelect)
            {
                item.Click();
            }
        }

        public void VerifySelectedItem(List<string> items)
        {
            driver.WaitUtil(itemOptions);
            var currentItems = driver.FindElements(itemOptions).Where(s => s.GetAttribute("class").Contains("ui-selected")).Select(s => s.Text).ToList();

            Assert.AreEqual(items, currentItems);
        }
    }
}
