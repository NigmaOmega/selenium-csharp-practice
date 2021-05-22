using NUnit.Framework;
using SeleniumPractice.SeleniumEasy.PageObjectModel;

namespace SeleniumPractice.SeleniumEasy.TestCases
{
    class TableFilter : BaseTest
    {
        TableFilterPage tableFilterPage;

        [SetUp]
        public void ClassSetUp()
        {
            tableFilterPage = new TableFilterPage(driver);
            tableFilterPage.GoTo();
        }

        [Test]
        public void TableIsShown_Successfully()
        {
            tableFilterPage.VerifyTableItems(5);
        }

        [Test]
        public void TableIsShownWhenChooseFilterToAll_ShownContentCorrectly()
        {
            tableFilterPage.ClickOnAllButton();
            tableFilterPage.VerifyTableItems(5);
        }

        [Test]
        public void TableIsShownWhenChooseFilterToRed_ShownContentCorrectly()
        {
            tableFilterPage.ClickOnRedButton();
            tableFilterPage.VerifyColorOfTableItem("Red");
            tableFilterPage.VerifyTableItems(1);
        }

        [Test]
        public void TableIsShownWhenChooseFilterToGreen_ShownContentCorrectly()
        {
            tableFilterPage.ClickOnGreenButton();
            tableFilterPage.VerifyColorOfTableItem("Green");
            tableFilterPage.VerifyTableItems(2);
        }

        [Test]
        public void TableIsShownWhenChooseFilterToOrange_ShownContentCorrectly()
        {
            tableFilterPage.ClickOnOrangeButton();
            tableFilterPage.VerifyColorOfTableItem("Orange");
            tableFilterPage.VerifyTableItems(2);
        }
    }
}
