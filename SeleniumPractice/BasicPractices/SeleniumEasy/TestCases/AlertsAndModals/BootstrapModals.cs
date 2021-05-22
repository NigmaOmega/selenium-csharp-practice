using NUnit.Framework;
using SeleniumPractice.SeleniumEasy.PageObjectModel;

namespace SeleniumPractice.SeleniumEasy.TestCases
{
    class BootstrapModals : BaseTest
    {
        BootstrapModalsPage bootstrapModalsPage;

        [SetUp]
        public void ClassSetUp()
        {
            bootstrapModalsPage = new BootstrapModalsPage(driver);
            bootstrapModalsPage.GoTo();
        }

        [Test]
        public void LaunchSingleModal_Successfully()
        {
            bootstrapModalsPage.LaunchSingleModal();
            bootstrapModalsPage.VerifySingleModalPopupIsShown();
        }

        [Test]
        public void CloseSingleModal_Successfully()
        {
            bootstrapModalsPage.LaunchSingleModal();
            bootstrapModalsPage.CloseSingleModalPopup();
            bootstrapModalsPage.VerifySingleModalPopupIsNotDisplayed();
        }

        [Test]
        public void SaveChangesSingleModal_Successfully()
        {
            bootstrapModalsPage.LaunchSingleModal();
            bootstrapModalsPage.SaveChangesSingleModalPopup();
            bootstrapModalsPage.VerifySingleModalPopupIsNotDisplayed();
            bootstrapModalsPage.VerifyMultipleModalPopupIsNotDisplayed();
        }

        [Test]
        public void LaunchMultipleModal_Successfully()
        {
            bootstrapModalsPage.LaunchMultipleModal();
            bootstrapModalsPage.VerifyMultipleModalPopupIsShown();
        }

        [Test]
        public void CloseMultipleModal_Successfully()
        {
            bootstrapModalsPage.LaunchMultipleModal();
            bootstrapModalsPage.CloseMultipleModalPopup();
            bootstrapModalsPage.VerifyMultipleModalPopupIsNotDisplayed();
        }

        [Test]
        public void SaveChangesMultipleModal_Successfully()
        {
            bootstrapModalsPage.LaunchMultipleModal();
            bootstrapModalsPage.SaveChangesMultipleModalPopup();
            bootstrapModalsPage.VerifyMultipleModalPopupIsNotDisplayed();
        }

        [Test]
        public void LaunchMultipleModalLevel2_Successfully()
        {
            bootstrapModalsPage.LaunchMultipleModal();
            bootstrapModalsPage.LaunchMultipleModalInPopup();
            bootstrapModalsPage.VerifyMultipleModalPopupLevel2IsShown();
        }

        [Test]
        public void CloseMultipleModalLevel2_Successfully()
        {
            bootstrapModalsPage.LaunchMultipleModal();
            bootstrapModalsPage.LaunchMultipleModalInPopup();
            bootstrapModalsPage.MultipleModalClosePopupLevel2();
            bootstrapModalsPage.VerifyMultipleModalPopupLevel2IsNotDisplayed();
        }

        [Test]
        public void SaveChangesMultipleModalLevel2_Successfully()
        {
            bootstrapModalsPage.LaunchMultipleModal();
            bootstrapModalsPage.LaunchMultipleModalInPopup();
            bootstrapModalsPage.MultipleModalSaveChangesPopupLevel2();
            bootstrapModalsPage.VerifyMultipleModalPopupLevel2IsNotDisplayed();
            bootstrapModalsPage.VerifyMultipleModalPopupIsNotDisplayed();
        }
    }
}
