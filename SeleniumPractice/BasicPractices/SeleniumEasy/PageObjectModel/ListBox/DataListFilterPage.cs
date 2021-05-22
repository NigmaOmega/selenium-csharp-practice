using NUnit.Framework;
using OpenQA.Selenium;
using System.Linq;

namespace SeleniumPractice.SeleniumEasy.PageObjectModel
{
    class DataListFilterPage : BasePage
    {
        readonly By infoBlock = By.XPath("//*[contains(@class,'info-block')]");
        readonly By searchInput = By.Id("input-search");

        public DataListFilterPage(IWebDriver driver)
        {
            this.driver = driver;
            this.pageUrl = WebUrl.DataListFilter;
        }

        public void InputIntoSearchField(string value)
        {
            driver.WaitUtil(searchInput).SendKeys(value);
        }

        public void VerifyInfoBlocks(int numberOfBlock)
        {
            driver.WaitUtil(infoBlock);
            var currentNumberOfBlock = driver.FindElements(infoBlock).Where(s => s.Displayed).ToList().Count;

            Assert.AreEqual(numberOfBlock, currentNumberOfBlock);
        }
    }
}
