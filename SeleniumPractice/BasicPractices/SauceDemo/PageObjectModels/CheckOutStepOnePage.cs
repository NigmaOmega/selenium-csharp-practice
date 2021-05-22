using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace SeleniumPractice.SauceDemo.PageObjectModels
{
    public class CheckOutStepOnePage
    {
        IWebDriver driver;

        By subHeaderTextBox = By.ClassName("title");
        By firstNameInput = By.Id("first-name");
        By lastnameInput = By.Id("last-name");
        By portalCodeInput = By.Id("postal-code");
        By cancelButton = By.Id("cancel");
        By continueButton = By.Id("continue");
        CheckOutStepOnePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public static CheckOutStepOnePage Init(IWebDriver driver)
        {
            return new CheckOutStepOnePage(driver);
        }

        public CheckOutStepOnePage VerifyCheckOutStepOnePageIsDisplayedSuccessfully()
        {
            var subHeader = driver.WaitUtil(subHeaderTextBox).Text;

            Assert.AreEqual("CHECKOUT: YOUR INFORMATION", subHeader);

            return this;
        }

        public CheckOutStepTwoPage FillDataAndContinue(string firstName, string lastName, string portalCode)
        {
            SetText(firstNameInput, firstName);
            SetText(lastnameInput, lastName);
            SetText(portalCodeInput, portalCode);
            Thread.Sleep(1000);
            driver.WaitUtil(continueButton).Click();

            return CheckOutStepTwoPage.Init(driver);
        }

        public CartPage Cancel()
        {
            driver.WaitUtil(cancelButton).Click();

            return CartPage.Init(driver);
        }

        private void SetText(By by, string text)
        {
            if (text != null)
            {
                driver.WaitUtil(by).SendKeys(text);
            }
            else
            {
                Console.WriteLine("Skip item " + by.ToString());
            }
        }

    }
}