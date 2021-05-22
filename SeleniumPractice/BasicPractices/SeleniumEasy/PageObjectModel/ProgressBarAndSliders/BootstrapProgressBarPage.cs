using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumPractice.SeleniumEasy.PageObjectModel
{
    class BootstrapProgressBarPage : BasePage
    {
        readonly By downloadBtn = By.Id("cricle-btn");
        readonly By percentageInformationTxt = By.ClassName("percenttext");

        public BootstrapProgressBarPage(IWebDriver driver)
        {
            this.driver = driver;
            this.pageUrl = WebUrl.BootstrapProgressBar;
        }

        public void DownloadFile()
        {
            driver.WaitUtil(downloadBtn).Click();
        }

        public int GetPercentageProgress()
        {
            return driver.WaitUtil(percentageInformationTxt).Text.ExtractNumbers()[0];
        }

        public void VerifySystemDownloadSuccessfully()
        {

            var percentage = GetPercentageProgress();

            Assert.AreEqual(100, percentage);
        }
    }
}
