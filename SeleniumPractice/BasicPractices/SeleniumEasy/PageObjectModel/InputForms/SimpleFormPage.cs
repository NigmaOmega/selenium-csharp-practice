using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace SeleniumPractice.SeleniumEasy.PageObjectModel
{
    class SimpleFormPage : BasePage
    {
        readonly By messageInput = By.XPath("//input[@id='user-message']");
        readonly By showMessageBtn = By.XPath("//*[@id='get-input']/button");
        readonly By messageTxt = By.XPath("//span[@id='display']");
        readonly By aInput = By.Id("sum1");
        readonly By bInput = By.Id("sum2");
        readonly By getTotalBtn = By.XPath("//*[@id='gettotal']/button");
        readonly By totalTxt = By.Id("displayvalue");
        readonly By noThankBtn = By.XPath("//*[@id='at-cv-lightbox-button-holder']/a[2]");


        public SimpleFormPage(IWebDriver driver)
        {
            this.driver = driver;
            pageUrl = WebUrl.SimpleForm;
        }

        public void TurnOfPopup()
        {
            try
            {
                driver.WaitUtil(noThankBtn, WaitType.WaitUtilVisible, 2).Click();
            }
            catch
            {
                Console.WriteLine("No popup is shown!");
            }

        }

        public void EnterTheMessage(string value)
        {
            driver.WaitUtil(messageInput).SendKeys(value);
        }

        public void ClickOnShowMessageButton()
        {
            driver.WaitUtil(showMessageBtn).Click();
        }

        public void VerifyYourMessageResult(string expectedMessage)
        {
            var currentMessage = driver.WaitUtil(messageTxt).Text;

            Assert.AreEqual(expectedMessage, currentMessage);
        }

        public void EnterAandBvalues(string aValue, string bValue)
        {
            driver.WaitUtil(aInput).SendKeys(aValue);
            driver.WaitUtil(bInput).SendKeys(bValue);
        }

        public void ClickOnGetTotalButton()
        {
            driver.WaitUtil(getTotalBtn).Click();
        }


        public void VerifyTotalValue(int totalValueExpected)
        {
            int currentTotalValue = driver.WaitUtil(totalTxt).Text.ExtractNumbers()[0];

            Assert.AreEqual(totalValueExpected, currentTotalValue);
        }





    }
}
