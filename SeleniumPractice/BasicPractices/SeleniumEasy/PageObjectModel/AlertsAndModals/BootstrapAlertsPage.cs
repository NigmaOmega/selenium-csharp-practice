using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumPractice.SeleniumEasy.PageObjectModel
{
    class BootstrapAlertsPage : BasePage
    {
        readonly By autocloseableBtn = By.Id("autoclosable-btn-success");
        readonly By normalBtn = By.Id("normal-btn-success");
        readonly By autocloseableWarningBtn = By.Id("autoclosable-btn-warning");
        readonly By normalWarningBtn = By.Id("normal-btn-warning");
        readonly By autocloseableDangerBtn = By.Id("autoclosable-btn-danger");
        readonly By normalDangerBtn = By.Id("normal-btn-danger");
        readonly By autocloseableInfoBtn = By.Id("autoclosable-btn-info");
        readonly By normalInfoBtn = By.Id("normal-btn-info");
        readonly By alertPopup = By.XPath("//div[contains(@class,'alert') and @style='display: block;']");


        public BootstrapAlertsPage(IWebDriver driver)
        {
            this.driver = driver;
            this.pageUrl = WebUrl.BootstrapAlerts;
        }

        public void ClickOnAutocloseableSuccessButton()
        {
            driver.WaitUtil(autocloseableBtn).Click();
        }

        public void ClickOnNormalSuccessButton()
        {
            driver.WaitUtil(normalBtn).Click();
        }

        public void ClickOnAutocloseableWarningButton()
        {
            driver.WaitUtil(autocloseableWarningBtn).Click();
        }

        public void ClickOnNormalWarningButton()
        {
            driver.WaitUtil(normalWarningBtn).Click();
        }

        public void ClickOnAutocloseableDangerButton()
        {
            driver.WaitUtil(autocloseableDangerBtn).Click();
        }

        public void ClickOnNormalDangerButton()
        {
            driver.WaitUtil(normalDangerBtn).Click();
        }

        public void ClickOnAutocloseableInfoButton()
        {
            driver.WaitUtil(autocloseableInfoBtn).Click();
        }

        public void ClickOnNormalInfoButton()
        {
            driver.WaitUtil(normalInfoBtn).Click();
        }

        public void VerifyAlertMessages(string message)
        {
            var currentMessage = driver.WaitUtil(alertPopup).Text.Trim();

            Assert.That(currentMessage, Does.Contain(message));
        }

        public void VerifyAlertDisapeared(int delayTime)
        {
            driver.Sleep(delayTime);
            var numberOfElement = driver.FindElements(alertPopup).Count;

            Assert.AreEqual(0, numberOfElement);
        }



    }
}
