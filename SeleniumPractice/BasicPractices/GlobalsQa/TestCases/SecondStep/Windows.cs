using NUnit.Framework;
using SeleniumPractice.BasicPractices.GlobalsQa.PageObjectModel.LastStep;

namespace SeleniumPractice.BasicPractices.GlobalsQa.TestCases.SecondStep
{
    class Windows : BaseTest
    {
        WindowsPage windowsPage;

        [SetUp]
        public void ClassSetUp()
        {
            windowsPage = new WindowsPage(driver);
            windowsPage.GoTo();
        }

        [Test]
        public void OpenNewWindows_Successfully()
        {
            string newWindowsUrl = "https://www.globalsqa.com/demo-site/frames-and-windows/#";
            windowsPage.OpenNewWindow();
            windowsPage.VerifyNewWindowIsCreated(newWindowsUrl);
        }
    }
}
