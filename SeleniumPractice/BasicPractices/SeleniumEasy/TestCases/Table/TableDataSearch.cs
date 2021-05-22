using NUnit.Framework;
using SeleniumPractice.SeleniumEasy.PageObjectModel;

namespace SeleniumPractice.SeleniumEasy.TestCases
{
    class TableDataSearch : BaseTest
    {
        TableDataSearchPage tableDataSearchPage;
        readonly string taskFilter = "W";

        [SetUp]
        public void ClassSetUp()
        {
            tableDataSearchPage = new TableDataSearchPage(driver);
            tableDataSearchPage.GoTo();
        }

        [Test]
        public void TaskTableDisplay_Correctly()
        {
            tableDataSearchPage.VerifyTasksData(7);
        }

        [Test]
        public void TaskTableDisplayWithFilter_Correctly()
        {
            tableDataSearchPage.SetTaskFilter(taskFilter);
            tableDataSearchPage.VerifyTasksData(2);
        }


        [Test]
        public void ListUsersTableDisplay_Correctly()
        {
            tableDataSearchPage.VerifyListUsersData(5);
        }


        [Test]
        public void ListUsersTableDisplayWithIdFilter_Correctly()
        {
            tableDataSearchPage.SetListedUsersFilter("1", null, null, null);
            tableDataSearchPage.VerifyListUsersData(1);
        }

        [Test]
        public void ListUsersTableDisplayWithUserNameFilter_Correctly()
        {
            tableDataSearchPage.SetListedUsersFilter(null, "M", null, null);
            tableDataSearchPage.VerifyListUsersData(2);
        }

        [Test]
        public void ListUsersTableDisplayWithFirstNameFilter_Correctly()
        {
            tableDataSearchPage.SetListedUsersFilter(null, null, "o", null);
            tableDataSearchPage.VerifyListUsersData(3);
        }

        [Test]
        public void ListUsersTableDisplayWithLastNameNameFilter_Correctly()
        {
            tableDataSearchPage.SetListedUsersFilter(null, null, "K", null);
            tableDataSearchPage.VerifyListUsersData(1);
        }


        [Test]
        public void ListUsersTableDisplayWithoutResultWhenFilter_ShowNotContent()
        {
            tableDataSearchPage.SetListedUsersFilter(null, null, "XXX", null);
            tableDataSearchPage.VerifyNoResultMessageIsShownOnListUsersTable();
        }


        [Test]
        public void FilterTableDisplayWithoutResultWhenFilter_ShowNotContent()
        {
            tableDataSearchPage.SetTaskFilter("xxx");
            tableDataSearchPage.VerifyNoResultMessageIsShownOnFilterTable();
        }
    }
}
