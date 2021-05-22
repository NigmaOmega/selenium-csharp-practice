using NUnit.Framework;
using SeleniumPractice.SeleniumEasy.PageObjectModel;

namespace SeleniumPractice.SeleniumEasy.TestCases
{
    class TableSortAndSearch : BaseTest
    {
        TableSortAndSearchPage tableSortAndSearchPage;

        [SetUp]
        public void ClassSetUp()
        {
            tableSortAndSearchPage = new TableSortAndSearchPage(driver);
            tableSortAndSearchPage.GoTo();
        }

        [Test]
        public void SelectMaximumEntriesShownOnTable_Successfully()
        {
            tableSortAndSearchPage.SelectNumberOfEntriesToShow("25");
            tableSortAndSearchPage.VerifyNumberOfEntriesShowed(25);
        }

        [Test]
        public void TableShownNumberOfEntries_Successfully()
        {
            tableSortAndSearchPage.VerifyNumberOfEntries(32);
        }



        [Test]
        public void SearchItemInTheTable_Successfully()
        {
            string searchKeyWords = "Co";
            tableSortAndSearchPage.InputSearchFilter(searchKeyWords);
            tableSortAndSearchPage.VerifyNumberOfEntries(8);
        }

    }
}
