using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumPractice.GlobalsQa;

namespace SeleniumPractice.BasicPractices.GlobalsQa.PageObjectModel.FirstStep
{
    class ProgressBarPage : BasePage
    {

        readonly By downloadBtn = By.Id("downloadButton");
        readonly By cancelDownloadBtn = By.XPath("//button[text()='Cancel Download']");
        readonly By closeBtn = By.XPath("//div[@class='ui-dialog-buttonset']/button[text()='Close']");
        readonly By downloadStatusTxt = By.ClassName("progress-label");
        readonly By downloadDialog = By.XPath("//body/div[2]");
        public ProgressBarPage(IWebDriver driver)
        {
            this.driver = driver;
            this.url = WebUrl.ProgressBar;
        }

        public void Download()
        {
            driver.WaitUtil(downloadBtn).Click();
        }

        public void CancelDownload()
        {
            driver.WaitUtil(cancelDownloadBtn).Click();
        }

        public void Close()
        {
            driver.WaitUtil(closeBtn).Click();
        }

        public void VerifyDownloadStatus(string downloadStatus)
        {
            var currentStatus = driver.WaitUtil(downloadStatusTxt).Text;

            Assert.AreEqual(downloadStatus, currentStatus);
        }

        public void VerifyDownloadIsDone()
        {
            var isDisplayed = driver.WaitUtil(closeBtn).Displayed;
            VerifyDownloadStatus("Complete!");

            Assert.IsTrue(isDisplayed);
        }

        public void VerifyVibilityOfDownloadDialog(bool isDisplayed)
        {
            driver.Sleep(500);
            var currentStatus = driver.FindElement(downloadDialog).Displayed;

            Assert.AreEqual(isDisplayed, currentStatus);
        }

    }
}
