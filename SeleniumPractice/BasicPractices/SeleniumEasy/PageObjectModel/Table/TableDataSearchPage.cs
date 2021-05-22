using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumPractice.SeleniumEasy.PageObjectModel
{
    class TableDataSearchPage : BasePage
    {
        readonly By taskTable = By.Id("task-table");
        readonly By noResultMessageListUsersTable = By.ClassName("no-result");
        readonly By noResultMessageFilterTable = By.ClassName("filterTable_no_results");
        readonly By taskTableFilter = By.Id("task-table-filter");
        readonly By listUserTable = By.XPath("//*[contains(@class,'filterable')]//table");
        readonly By listUserFilterBtn = By.XPath("//*[contains(@class,'btn-filter')]");
        readonly By listUserFilterInputs = By.XPath("//*[@class='filters']//input[@class='form-control']");


        public TableDataSearchPage(IWebDriver driver)
        {
            this.driver = driver;
            this.pageUrl = WebUrl.TableDataSearch;
        }

        public void VerifyTasksData(int expectedRowNumber)
        {
            var currentRowNumber = driver.Table(taskTable).GetTableDisplayedData().Count;

            Assert.AreEqual(expectedRowNumber, currentRowNumber);
        }

        public void SetTaskFilter(string filterValue)
        {
            driver.WaitUtil(taskTableFilter).SendKeys(filterValue);
        }

        public void VerifyListUsersData(int expectedRowNumber)
        {
            var currentRowNumber = driver.Table(listUserTable).GetTableDisplayedData().Count;

            Assert.AreEqual(expectedRowNumber, currentRowNumber);
        }

        public void VerifyNoResultMessageIsShownOnListUsersTable()
        {
            string noResultMessage = "No result found";
            var currentMessage = driver.WaitUtil(noResultMessageListUsersTable).Text;
            Assert.AreEqual(noResultMessage, currentMessage);
        }

        public void VerifyNoResultMessageIsShownOnFilterTable()
        {
            string noResultMessage = "No results found";
            var currentMessage = driver.WaitUtil(noResultMessageFilterTable).Text;
            Assert.AreEqual(noResultMessage, currentMessage);
        }

        public void SetListedUsersFilter(string index, string username, string firstName, string lastName)
        {
            driver.WaitUtil(listUserFilterBtn).Click();
            driver.WaitUtil(listUserFilterInputs, WaitType.WaitUtilClickable);

            var elements = driver.FindElements(listUserFilterInputs).ToList();
            SendKeysSkipNull(elements[0], index);
            SendKeysSkipNull(elements[1], username);
            SendKeysSkipNull(elements[2], firstName);
            SendKeysSkipNull(elements[3], lastName);
        }
        private void SendKeysSkipNull(IWebElement element, string value)
        {
            if (value != null)
            {
                element.SendKeys(value);
            }
        }
    }
}
