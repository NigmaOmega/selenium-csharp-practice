using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumPractice.SeleniumEasy.PageObjectModel
{
    class TablePaginationPage : BasePage
    {
        readonly By table = By.TagName("table");
        readonly By tableBody = By.Id("myTable");
        readonly By pageSelecterBtn = By.XPath("//ul[@id='myPager']//a");
        public TablePaginationPage(IWebDriver driver)
        {
            this.driver = driver;
            this.pageUrl = WebUrl.TablePagination;
        }

        public void VerifyAllTableData(int numberOfData)
        {
            var currentNumberOfRow = driver.Table(table).GetTableData().Count;

            Assert.AreEqual(numberOfData, currentNumberOfRow);
        }

        public void VerifyCurrentTableData(int numberOfData)
        {
            var currentNumberOfRow = driver.Table(table).GetTableDisplayedData().Count;

            Assert.AreEqual(numberOfData, currentNumberOfRow);
        }

        public void SetTablePage(string pageName)
        {
            driver.WaitUtil(pageSelecterBtn, WaitType.WaitUtilExist);
            driver.FindElements(pageSelecterBtn).First(s => s.Text == pageName).Click();
        }

        public void VerifyHeader(List<string> headers)
        {
            var currentheaders = driver.WaitUtil(table).FindElements(By.TagName("th")).Select(s => s.Text).ToList();

            Assert.AreEqual(headers, currentheaders);
        }

    }
}
