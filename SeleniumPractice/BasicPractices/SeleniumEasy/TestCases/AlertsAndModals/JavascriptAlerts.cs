using NUnit.Framework;
using SeleniumPractice.SeleniumEasy.PageObjectModel;

namespace SeleniumPractice.SeleniumEasy.TestCases
{
    class JavascriptAlerts : BaseTest
    {
        JavascriptAlertsPage javascriptAlertsPage;

        [SetUp]
        public void ClassSetUp()
        {
            javascriptAlertsPage = new JavascriptAlertsPage(driver);
            javascriptAlertsPage.GoTo();
        }

        [Test]
        public void OpenAlertBox_Successfully()
        {
            javascriptAlertsPage.OpenAlertBox();
            javascriptAlertsPage.VerifyAlertBoxIsDisplayed();
            javascriptAlertsPage.AcceptAlert();
        }

        [Test]
        public void OpenConfirmBox_Successfully()
        {
            javascriptAlertsPage.OpenConfirmBox();
            javascriptAlertsPage.VerifyConfirmBoxIsDisplayed();
            javascriptAlertsPage.AcceptAlert();
        }

        [Test]
        public void OpenPromptBox_Successfully()
        {
            javascriptAlertsPage.OpenPromptBox();
            javascriptAlertsPage.VerifyPromptBoxIsDisplayed();
            javascriptAlertsPage.AcceptAlert();
        }
    }
}
