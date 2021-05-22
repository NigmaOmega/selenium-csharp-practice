using NUnit.Framework;
using SeleniumPractice.SeleniumEasy.PageObjectModel;

namespace SeleniumPractice.SeleniumEasy.TestCases
{
    class BootstrapAlerts : BaseTest
    {
        BootstrapAlertsPage bootstrapAlertsPage;

        string autocloseableSuccessMessage = "I'm an autocloseable success message. I will hide in 5 seconds.";
        string normalSuccessMessage = "I'm a normal success message. To close use the appropriate button.";
        string autocloseableWarningMessage = "I'm an autocloseable warning message. I will hide in 3 seconds.";
        string normalWarningMessage = "I'm a normal warning message. To close use the appropriate button.";
        string autocloseableDangerMessage = "I'm an autocloseable danger message. I will hide in 5 seconds.";
        string normalDangerMessage = "I'm a normal danger message. To close use the appropriate button.";
        string autocloseableInfoMessage = "I'm an autocloseable info message. I will hide in 6 seconds.";
        string normalInfoMessage = "I'm a normal info message. To close use the appropriate button.";

        [SetUp]
        public void ClassSetUp()
        {
            bootstrapAlertsPage = new BootstrapAlertsPage(driver);
        }

        [Test]
        public void OpenAutocloseableSuccessMessage_Successfully()
        {
            bootstrapAlertsPage.GoTo();
            bootstrapAlertsPage.ClickOnAutocloseableSuccessButton();
            bootstrapAlertsPage.VerifyAlertMessages(autocloseableSuccessMessage);
            bootstrapAlertsPage.VerifyAlertDisapeared(5000);
        }

        [Test]
        public void OpenNormalSuccessMessage_Successfully()
        {
            bootstrapAlertsPage.GoTo();
            bootstrapAlertsPage.ClickOnNormalSuccessButton();
            bootstrapAlertsPage.VerifyAlertMessages(normalSuccessMessage);
        }

        [Test]
        public void OpenAutocloseableWarningMessage_Successfully()
        {
            bootstrapAlertsPage.GoTo();
            bootstrapAlertsPage.ClickOnAutocloseableWarningButton();
            bootstrapAlertsPage.VerifyAlertMessages(autocloseableWarningMessage);
            bootstrapAlertsPage.VerifyAlertDisapeared(3000);
        }

        [Test]
        public void OpenNormalWarningMessage_Successfully()
        {
            bootstrapAlertsPage.GoTo();
            bootstrapAlertsPage.ClickOnNormalWarningButton();
            bootstrapAlertsPage.VerifyAlertMessages(normalWarningMessage);
        }

        [Test]
        public void OpenAutocloseableDangerMessage_Successfully()
        {
            bootstrapAlertsPage.GoTo();
            bootstrapAlertsPage.ClickOnAutocloseableDangerButton();
            bootstrapAlertsPage.VerifyAlertMessages(autocloseableDangerMessage);
            bootstrapAlertsPage.VerifyAlertDisapeared(5000);
        }

        [Test]
        public void OpenNormalDangerMessage_Successfully()
        {
            bootstrapAlertsPage.GoTo();
            bootstrapAlertsPage.ClickOnNormalDangerButton();
            bootstrapAlertsPage.VerifyAlertMessages(normalDangerMessage);
        }


        [Test]
        public void OpenAutocloseableInfoMessage_Successfully()
        {
            bootstrapAlertsPage.GoTo();
            bootstrapAlertsPage.ClickOnAutocloseableInfoButton();
            bootstrapAlertsPage.VerifyAlertMessages(autocloseableInfoMessage);
            bootstrapAlertsPage.VerifyAlertDisapeared(6000);
        }

        [Test]
        public void OpenNormalInfoMessage_Successfully()
        {
            bootstrapAlertsPage.GoTo();
            bootstrapAlertsPage.ClickOnNormalInfoButton();
            bootstrapAlertsPage.VerifyAlertMessages(normalInfoMessage);
        }
    }
}
