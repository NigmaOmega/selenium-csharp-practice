using NUnit.Framework;
using SeleniumPractice.SeleniumEasy.PageObjectModel;

namespace SeleniumPractice.SeleniumEasy.TestCases
{
    class BootstrapProgressBar : BaseTest
    {
        BootstrapProgressBarPage bootstrapProgressBarPage;

        [SetUp]
        public void ClassSetUp()
        {
            bootstrapProgressBarPage = new BootstrapProgressBarPage(driver);
            bootstrapProgressBarPage.GoTo();
        }

        [Test]
        public void DownloadFile_Successfully()
        {
            bootstrapProgressBarPage.DownloadFile();
            driver.Sleep(30000);
            bootstrapProgressBarPage.VerifySystemDownloadSuccessfully();

        }
    }
}
