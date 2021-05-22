using NUnit.Framework;
using SeleniumPractice.BasicPractices.GlobalsQa.PageObjectModel.FirstStep;

namespace SeleniumPractice.BasicPractices.GlobalsQa.TestCases.FirstStep
{
    class Tabs : BaseTest
    {
        TabsPage tabsPage;

        [SetUp]
        public void ClassSetUp()
        {
            tabsPage = new TabsPage(driver);
            tabsPage.GoTo();
        }

        [Test]
        public void TabsHaveTheOpenedDefaultTab()
        {
            string tabName = "Section 1";
            tabsPage.VerifyActivationOfTab(tabName);
        }

        [Test]
        public void SelectOtherTab()
        {
            string tabName = "Section 1";
            string tabName2 = "Section 2";
            tabsPage.SelectTab(tabName2);
            driver.Sleep(1000);
            tabsPage.VerifyActivationOfTab(tabName, false);
            tabsPage.VerifyVisibilityOfTabContent(tabName, false);
            tabsPage.VerifyActivationOfTab(tabName2);
            tabsPage.VerifyVisibilityOfTabContent(tabName2, true);
        }

        [Test]
        public void SelectCurrentActiceTab()
        {
            string tabName = "Section 1";
            tabsPage.SelectTab(tabName);
            driver.Sleep(1000);
            tabsPage.VerifyActivationOfTab(tabName, false);
            tabsPage.VerifyVisibilityOfTabContent(tabName, false);
        }


    }
}
