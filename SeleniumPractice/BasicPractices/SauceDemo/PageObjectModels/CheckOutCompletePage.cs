using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumPractice.SauceDemo.PageObjectModels
{
    public class CheckOutCompletePage
    {
        IWebDriver driver;

        By subHeaderTextBox = By.ClassName("title");
        By completeHeaderTextBox = By.ClassName("complete-header");
        CheckOutCompletePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public static CheckOutCompletePage Init(IWebDriver driver)
        {
            return new CheckOutCompletePage(driver);
        }

        public CheckOutCompletePage VerifyItemsIsOrderdSuccessfully()
        {
            var completeHeader = driver.WaitUtil(completeHeaderTextBox).Text;

            Assert.AreEqual("THANK YOU FOR YOUR ORDER", completeHeader);

            return this;
        }

        public CheckOutCompletePage VerifyCompletePageIsDisplayedSuccessfully()
        {
            var subHeader = driver.WaitUtil(subHeaderTextBox).Text;

            Assert.AreEqual("CHECKOUT: COMPLETE!", subHeader);

            return this;
        }
    }
}