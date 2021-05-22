using NUnit.Framework;
using SeleniumPractice.SeleniumEasy.PageObjectModel;

namespace SeleniumPractice.SeleniumEasy.TestCases
{
    class ProgressBarModal : BaseTest
    {
        ProgressBarModalPage progressBarModalPage;
        readonly string simpleDialogTitle = "Loading";
        readonly string customMessageDialogTitle = "Custom message";
        readonly string customSettingDialogTitle = "Hello Mr. Alert !";

        [SetUp]
        public void ClassSetUp()
        {
            progressBarModalPage = new ProgressBarModalPage(driver);
            progressBarModalPage.GoTo();
        }

        [Test]
        public void OpenSimpleDialog_Successfully()
        {
            progressBarModalPage.OpenSimpleDialog();
            progressBarModalPage.VerifyDialogIsShown(simpleDialogTitle);
        }

        [Test]
        public void OpenCustomMessageDialog_Successfully()
        {
            progressBarModalPage.OpenCustomMessageDialog();
            progressBarModalPage.VerifyDialogIsShown(customMessageDialogTitle);
        }

        [Test]
        public void OpenCustomSettingDialog_Successfully()
        {
            progressBarModalPage.OpenCustomSettingDialog();
            progressBarModalPage.VerifyDialogIsShown(customSettingDialogTitle);
        }
    }
}
