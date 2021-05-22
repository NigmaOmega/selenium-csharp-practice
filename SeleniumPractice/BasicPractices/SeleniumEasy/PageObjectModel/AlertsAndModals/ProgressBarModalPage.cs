using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumPractice.SeleniumEasy.PageObjectModel
{
    class ProgressBarModalPage : BasePage
    {
        readonly By simpleDialogBtn = By.ClassName("btn-primary");
        readonly By customMessageDialogBtn = By.ClassName("btn-success");
        readonly By customSettingDialogBtn = By.ClassName("btn-warning");
        readonly By dialogPopup = By.XPath("//div[@class='modal-header']/h3");

        public ProgressBarModalPage(IWebDriver driver)
        {
            this.driver = driver;
            this.pageUrl = WebUrl.ProgressBarModal;
        }
        public void OpenSimpleDialog()
        {
            driver.WaitUtil(simpleDialogBtn).Click();
        }

        public void OpenCustomMessageDialog()
        {
            driver.WaitUtil(customMessageDialogBtn).Click();
        }

        public void OpenCustomSettingDialog()
        {
            driver.WaitUtil(customSettingDialogBtn).Click();
        }

        public void VerifyDialogIsShown(string dialogTitle)
        {
            var currentTitle = driver.WaitUtil(dialogPopup).Text;

            Assert.AreEqual(dialogTitle, currentTitle);
        }
    }
}
