using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumPractice.SeleniumEasy.PageObjectModel
{
    class TableSortAndSearchPage : BasePage
    {
        readonly By table = By.Id("example");
        readonly By searchInput = By.XPath("//div[@id='example_filter']//input");
        readonly By lengthOfTableSelect = By.Name("example_length");
        readonly By tableNumberOfItemInfoTxt = By.Id("example_info");
        public TableSortAndSearchPage(IWebDriver driver)
        {
            this.driver = driver;
            this.pageUrl = WebUrl.TableSortAndSearch;
        }

        public void InputSearchFilter(string value)
        {
            driver.WaitUtil(searchInput).SendKeys(value);
        }

        public void SelectNumberOfEntriesToShow(string numberOfEntries)
        {
            driver.Select(lengthOfTableSelect).ByValue(numberOfEntries);
        }

        public void VerifyNumberOfEntriesShowed(int numberOfEntries)
        {
            var textInformation = driver.WaitUtil(tableNumberOfItemInfoTxt).Text;
            var number = textInformation.ExtractNumbers()[1];

            Assert.AreEqual(numberOfEntries, number);
        }

        public void VerifyNumberOfEntries(int numberOfEntries)
        {
            var textInformation = driver.WaitUtil(tableNumberOfItemInfoTxt).Text;
            var number = textInformation.ExtractNumbers()[2];

            Assert.AreEqual(numberOfEntries, number);
        }


    }
}
