using NUnit.Framework;
using SeleniumPractice.SeleniumEasy.PageObjectModel;
using System.Collections.Generic;

namespace SeleniumPractice.SeleniumEasy.TestCases
{
    class TablePagination : BaseTest
    {
        TablePaginationPage tablePaginationPage;

        [SetUp]
        public void ClassSetUp()
        {
            tablePaginationPage = new TablePaginationPage(driver);
            tablePaginationPage.GoTo();
        }

        [Test]
        public void TableContainNumberOfItems_Correctly()
        {
            tablePaginationPage.VerifyAllTableData(13);
        }

        [Test]
        public void TableShowItemsInSpecificPage_Correctly()
        {
            tablePaginationPage.SetTablePage("3");
            tablePaginationPage.VerifyCurrentTableData(3);
        }

        [Test]
        public void TableShowHeaders_Correctly()
        {
            List<string> headers = new List<string>();
            headers.Add("#");
            headers.Add("Table heading 1");
            headers.Add("Table heading 2");
            headers.Add("Table heading 3");
            headers.Add("Table heading 4");
            headers.Add("Table heading 5");
            headers.Add("Table heading 6");

            tablePaginationPage.VerifyHeader(headers);
        }
    }
}
