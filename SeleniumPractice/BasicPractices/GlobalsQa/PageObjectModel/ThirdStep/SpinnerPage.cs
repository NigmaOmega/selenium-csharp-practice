using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumPractice.GlobalsQa;
using System;

namespace SeleniumPractice.BasicPractices.GlobalsQa.PageObjectModel.ThirdStep
{
    class SpinnerPage : BasePage
    {
        readonly By mainSpinner = By.Id("spinner");
        readonly By increaseValueBtn = By.ClassName("ui-spinner-up");
        readonly By decreaseValueBtn = By.ClassName("ui-spinner-down");
        readonly By toggleDiableEnableBtn = By.Id("disable");
        readonly By toggleWidgetBtn = By.Id("destroy");
        readonly By getValueBtn = By.Id("getvalue");
        readonly By setValueTo5Btn = By.Id("setvalue");
        public SpinnerPage(IWebDriver driver)
        {
            this.driver = driver;
            this.url = WebUrl.Spinner;
        }

        public void ClickOnToggleDiableEnableButton()
        {
            driver.WaitUtil(toggleDiableEnableBtn).Click();
        }

        public void ClickOnToggleWidgetButton()
        {
            driver.WaitUtil(toggleWidgetBtn).Click();
        }

        public void VerifyInputIsEnabled()
        {
            var isEnable = driver.WaitUtil(mainSpinner).Enabled;

            Assert.IsTrue(isEnable);
        }

        public void VerifyInputIsDisable()
        {
            var isEnable = driver.WaitUtil(mainSpinner).Enabled;

            Assert.False(isEnable);
        }

        public void VerifyToggleIsDestroyed()
        {
            driver.WaitForNotExist(increaseValueBtn, new TimeSpan(0, 0, 3));
        }

        public void UpValue()
        {
            driver.WaitUtil(increaseValueBtn).Click();
        }
        public void DownValue()
        {
            driver.WaitUtil(decreaseValueBtn).Click();
        }

        public void ClickOnGetValue()
        {
            driver.WaitUtil(getValueBtn).Click();
        }

        public void SetValueTo5()
        {
            driver.WaitUtil(setValueTo5Btn).Click();
        }

        public void VerifyInputValue(string value)
        {
            var currentValue = driver.WaitUtil(mainSpinner).GetAttribute("value");

            Assert.AreEqual(value, currentValue);
        }

        public void VerifyInputValueAndClosePopup(string value)
        {
            var currentValue = driver.SwitchTo().Alert().Text;
            driver.SwitchTo().Alert().Accept();

            Assert.AreEqual(value, currentValue);
        }
    }
}
