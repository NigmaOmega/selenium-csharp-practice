using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumPractice.SeleniumEasy.PageObjectModel
{
    class JQueryDownloadProgressBarsPage : BasePage
    {
        readonly By startDownloadBtn = By.Id("downloadButton");
        readonly By cancelDownloadBtn = By.XPath("//button[text()='Cancel Download']");
        readonly By closeBtn = By.XPath("//button[text()='Close']");
        readonly By successfulResultTxt = By.XPath("//div[text()='Complete!']");
        readonly By downloadPopUp = By.XPath("//*[@aria-labelledby='ui-id-1']");

        public JQueryDownloadProgressBarsPage(IWebDriver driver)
        {
            this.driver = driver;
            this.pageUrl = WebUrl.JQueryDownloadProgressBars;
        }

        public void StartDownload()
        {
            driver.WaitUtil(startDownloadBtn).Click();
        }

        public void CancelDownload()
        {
            driver.WaitUtil(cancelDownloadBtn).Click();
        }

        public void ClosePopup()
        {
            driver.WaitUtil(closeBtn).Click();
        }

        public void VerifyDownloadSuccessfully()
        {
            var isDisplayed = driver.WaitUtil(successfulResultTxt).Displayed;
            Assert.IsTrue(isDisplayed);
        }

        public void VerifyDownloadPopUpIsNotDisplayed()
        {
            var isDisplayed = driver.WaitUtil(downloadPopUp, WaitType.WaitUtilExist).Displayed;
            Assert.False(isDisplayed);
        }
    }
}
