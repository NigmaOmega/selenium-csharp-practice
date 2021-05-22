using NUnit.Framework;
using SeleniumPractice.BasicPractices.GlobalsQa.PageObjectModel.SecondStep;

namespace SeleniumPractice.BasicPractices.GlobalsQa.TestCases.SecondStep
{
    class TabsBrowser : BaseTest
    {
        TabsBrowserPage tabsBrowserPage;

        [SetUp]
        public void ClassSetUP()
        {
            tabsBrowserPage = new TabsBrowserPage(driver);
            tabsBrowserPage.GoTo();
        }

        [Test]
        public void OpenNewTab_Successfully()
        {
            string newTabUrl = "https://www.globalsqa.com/demo-site/frames-and-windows/#";
            tabsBrowserPage.OpenNewTab();
            tabsBrowserPage.VerifyNewTabIsOpen(newTabUrl);
        }
    }
}
