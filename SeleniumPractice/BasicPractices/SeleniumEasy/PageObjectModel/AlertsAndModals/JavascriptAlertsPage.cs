using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumPractice.SeleniumEasy.PageObjectModel
{
    class JavascriptAlertsPage : BasePage
    {
        readonly By clickMeAlertBoxBtn = By.XPath("//button[@onclick='myAlertFunction()']");
        readonly By clickMeConfirmBoxBtn = By.XPath("//button[@onclick='myConfirmFunction()']");
        readonly By clickMePromptBoxBtn = By.XPath("//button[@onclick='myPromptFunction()']");

        public JavascriptAlertsPage(IWebDriver driver)
        {
            this.driver = driver;
            this.pageUrl = WebUrl.JavascriptAlerts;
        }

        public void OpenAlertBox()
        {
            driver.WaitUtil(clickMeAlertBoxBtn).Click();
        }

        public void OpenConfirmBox()
        {
            driver.WaitUtil(clickMeConfirmBoxBtn).Click();
        }

        public void OpenPromptBox()
        {
            driver.WaitUtil(clickMePromptBoxBtn).Click();
        }

        public void VerifyAlertBoxIsDisplayed()
        {
            string alertContent = driver.SwitchTo().Alert().Text;
            string expectedAlertContent = "I am an alert box!";

            Assert.AreEqual(expectedAlertContent, alertContent);
        }

        public void AcceptAlert()
        {
            driver.SwitchTo().Alert().Accept();
        }

        public void VerifyConfirmBoxIsDisplayed()
        {
            string content = driver.SwitchTo().Alert().Text;
            string expectedcontent = "Press a button!";

            Assert.AreEqual(expectedcontent, content);
        }


        public void VerifyPromptBoxIsDisplayed()
        {
            string content = driver.SwitchTo().Alert().Text;
            string expectedcontent = "Please enter your name";

            Assert.AreEqual(expectedcontent, content);
        }
    }
}
