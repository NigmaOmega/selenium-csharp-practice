using NUnit.Framework;
using SeleniumPractice.SeleniumEasy.PageObjectModel;

namespace SeleniumPractice.SeleniumEasy.TestCases
{
    class JQueryDownloadProgressBars : BaseTest
    {
        JQueryDownloadProgressBarsPage jQueryDownloadProgressBarsPage;

        [SetUp]
        public void ClassSetUp()
        {
            jQueryDownloadProgressBarsPage = new JQueryDownloadProgressBarsPage(driver);
            jQueryDownloadProgressBarsPage.GoTo();
        }

        [Test]
        public void Download_Successfully()
        {
            jQueryDownloadProgressBarsPage.StartDownload();
            jQueryDownloadProgressBarsPage.VerifyDownloadSuccessfully();
        }


        [Test]
        public void DownloadAndCancel_Successfully()
        {
            jQueryDownloadProgressBarsPage.StartDownload();
            jQueryDownloadProgressBarsPage.CancelDownload();
            jQueryDownloadProgressBarsPage.VerifyDownloadPopUpIsNotDisplayed();
        }

        [Test]
        public void DownloadAndThenClose_Successfully()
        {
            jQueryDownloadProgressBarsPage.StartDownload();
            jQueryDownloadProgressBarsPage.ClosePopup();
            jQueryDownloadProgressBarsPage.VerifyDownloadPopUpIsNotDisplayed();
        }
    }
}
