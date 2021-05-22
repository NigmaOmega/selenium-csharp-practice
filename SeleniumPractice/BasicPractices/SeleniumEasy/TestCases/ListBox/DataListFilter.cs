using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumPractice.SeleniumEasy.PageObjectModel;

namespace SeleniumPractice.SeleniumEasy.TestCases
{
    class DataListFilter : BaseTest
    {
        DataListFilterPage dataListFilterPage;

        [SetUp]
        public void ClassSetUp()
        {
            dataListFilterPage = new DataListFilterPage(driver);
            dataListFilterPage.GoTo();
        }

        [Test]
        public void ShowsInfoBlocks_Correctly()
        {
            dataListFilterPage.VerifyInfoBlocks(6);
        }

        [Test]
        public void ShowsInfoBlocksForSeaching_Correctly()
        {
            dataListFilterPage.InputIntoSearchField("Ty");
            dataListFilterPage.VerifyInfoBlocks(1);
        }
        [Test]
        public void ShowsInfoBlocksForClearSeaching_Correctly()
        {
            dataListFilterPage.InputIntoSearchField("Ty");
            dataListFilterPage.InputIntoSearchField(Keys.Backspace + Keys.Backspace);
            dataListFilterPage.VerifyInfoBlocks(6);
        }
    }
}
