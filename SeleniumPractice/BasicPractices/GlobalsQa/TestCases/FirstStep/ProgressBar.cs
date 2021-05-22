using NUnit.Framework;
using SeleniumPractice.BasicPractices.GlobalsQa.PageObjectModel.FirstStep;

namespace SeleniumPractice.BasicPractices.GlobalsQa.TestCases.FirstStep
{
    class ProgressBar : BaseTest
    {
        ProgressBarPage progressBarPage;

        [SetUp]
        public void ClassSetUp()
        {
            progressBarPage = new ProgressBarPage(driver);
            progressBarPage.GoTo();
            progressBarPage.Download();

        }

        [Test]
        public void Download_Successfully()
        {
            progressBarPage.VerifyVibilityOfDownloadDialog(true);
            progressBarPage.VerifyDownloadStatus("Starting download...");
            progressBarPage.VerifyDownloadIsDone();
        }

        [Test]
        public void CloseAfterDownload_Successfully()
        {
            progressBarPage.VerifyDownloadIsDone();
            progressBarPage.Close();
            progressBarPage.VerifyVibilityOfDownloadDialog(false);
        }

        [Test]
        public void CancelDownload_Successfully()
        {
            progressBarPage.CancelDownload();
            progressBarPage.VerifyVibilityOfDownloadDialog(false);
        }
    }
}
