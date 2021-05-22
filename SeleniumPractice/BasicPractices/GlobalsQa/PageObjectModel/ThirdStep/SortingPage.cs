using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumPractice.GlobalsQa;
using System.Linq;

namespace SeleniumPractice.BasicPractices.GlobalsQa.PageObjectModel.ThirdStep
{
    class SortingPage : BasePage
    {
        readonly By items = By.TagName("li");
        public SortingPage(IWebDriver driver)
        {
            this.driver = driver;
            this.url = WebUrl.Sorting;
        }

        public void MoveItem(string sourceItemName, string targetItemName)
        {
            By source = By.XPath("//li[text()='" + sourceItemName + "']");
            By target = By.XPath("//li[text()='" + targetItemName + "']");
            driver.DragAndDrop(source, target);
        }

        public void VerifyIndexOfItem(string itemName, int index)
        {
            var listItems = driver.FindElements(items).Select(s => s.Text).ToList();
            var currentIndex = listItems.IndexOf(itemName);

            Assert.AreEqual(index, currentIndex);

        }
    }
}
