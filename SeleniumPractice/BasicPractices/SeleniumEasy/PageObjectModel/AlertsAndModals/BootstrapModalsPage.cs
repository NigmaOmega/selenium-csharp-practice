using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumPractice.SeleniumEasy.PageObjectModel
{
    class BootstrapModalsPage : BasePage
    {
        readonly By launchModalSingleBtn = By.XPath("//div[text()='Single Modal Example']/../div/a");
        readonly By launchModalMultipleBtn = By.XPath("//div[text()='Multiple Modal Example']/../div/a");

        readonly By singleModalPupUp = By.Id("myModal0");
        readonly By multipleModalPupUp = By.Id("myModal");
        readonly By multipleModalPupUpLevel2 = By.Id("myModal2");

        readonly By singleModalTitleTxt = By.XPath("//*[@id='myModal0']//h4");
        readonly By singleModalContentTxt = By.XPath("//*[@id='myModal0']//div[@class='modal-body']");
        readonly By singleModalCloseBtn = By.XPath("//*[@id='myModal0']//a[1]");
        readonly By singleModalSaveChangesBtn = By.XPath("//*[@id='myModal0']//a[2]");

        readonly By multipleModalTitleTxt = By.XPath("//*[@id='myModal']//h4");
        readonly By multipleModalCloseBtn = By.XPath("//*[@id='myModal']//div[@class='modal-footer']/a[1]");
        readonly By multipleModalSaveChangesBtn = By.XPath("//*[@id='myModal']//div[@class='modal-footer']/a[2]");
        readonly By multipleModalLaunchModalInPopupBtn = By.XPath("//*[@id='myModal']/div/div/div[3]/a");

        readonly By multipleModalTitleLevel2Txt = By.XPath("//*[@id='myModal2']//h4");
        readonly By multipleModalCloseLevel2Btn = By.XPath("//*[@id='myModal2']//a[1]");
        readonly By multipleModalSaveChangesLevel2Btn = By.XPath("//*[@id='myModal2']//a[2]");

        public BootstrapModalsPage(IWebDriver driver)
        {
            this.driver = driver;
            this.pageUrl = WebUrl.BootstrapModals;
        }

        public void LaunchSingleModal()
        {
            driver.WaitUtil(launchModalSingleBtn).Click();
        }

        public void CloseSingleModalPopup()
        {
            driver.WaitUtil(singleModalCloseBtn).Click();
            driver.Sleep(500);
        }

        public void SaveChangesSingleModalPopup()
        {
            driver.WaitUtil(singleModalSaveChangesBtn).Click();
        }

        public void VerifySingleModalPopupIsShown()
        {
            var title = driver.WaitUtil(singleModalTitleTxt).Text;
            var contents = driver.WaitUtil(singleModalContentTxt).Text;

            string expectedTitle = "Modal Title";
            string expectedContents = "This is the place where the content for the modal dialog displays";

            Assert.AreEqual(expectedTitle, title);
            Assert.AreEqual(expectedContents, contents);
        }

        public void LaunchMultipleModal()
        {
            driver.WaitUtil(launchModalMultipleBtn).Click();
        }

        public void CloseMultipleModalPopup()
        {
            driver.WaitUtil(multipleModalCloseBtn).Click();
            driver.Sleep(500);
        }

        public void SaveChangesMultipleModalPopup()
        {
            driver.WaitUtil(multipleModalSaveChangesBtn).Click();
        }

        public void VerifyMultipleModalPopupIsShown()
        {
            var title = driver.WaitUtil(multipleModalTitleTxt).Text;
            string expectedTitle = "First Modal";

            Assert.AreEqual(expectedTitle, title);
        }

        public void LaunchMultipleModalInPopup()
        {
            driver.WaitUtil(multipleModalLaunchModalInPopupBtn).Click();
        }

        public void MultipleModalClosePopupLevel2()
        {
            driver.WaitUtil(multipleModalCloseLevel2Btn).Click();
            driver.Sleep(500);
        }

        public void MultipleModalSaveChangesPopupLevel2()
        {
            driver.WaitUtil(multipleModalSaveChangesLevel2Btn).Click();
            driver.Sleep(500);
        }

        public void VerifyMultipleModalPopupLevel2IsShown()
        {
            var title = driver.WaitUtil(multipleModalTitleLevel2Txt).Text;
            string expectedTitle = "Modal 2";

            Assert.AreEqual(expectedTitle, title);
        }

        public void VerifySingleModalPopupIsNotDisplayed()
        {
            var isDisplayed = driver.FindElement(singleModalPupUp).Displayed;

            Assert.IsFalse(isDisplayed);
        }

        public void VerifyMultipleModalPopupIsNotDisplayed()
        {
            var isDisplayed = driver.FindElement(multipleModalPupUp).Displayed;

            Assert.IsFalse(isDisplayed);
        }

        public void VerifyMultipleModalPopupLevel2IsNotDisplayed()
        {
            var isDisplayed = driver.FindElement(multipleModalPupUpLevel2).Displayed;

            Assert.IsFalse(isDisplayed);
        }

    }
}
