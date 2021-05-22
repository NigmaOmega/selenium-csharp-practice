using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumPractice.SeleniumEasy.PageObjectModel
{
    class AjaxFormSubmitPage : BasePage
    {
        readonly By nameInput = By.Id("title");
        readonly By commentInput = By.Id("description");
        readonly By submitBtn = By.Id("btn-submit");
        readonly By submitResultTxt = By.Id("submit-control");

        public AjaxFormSubmitPage(IWebDriver driver)
        {
            this.driver = driver;
            this.pageUrl = WebUrl.AjaxFormSubmit;
        }

        public void InputAjaxFormAndSubmit(string name, string comment)
        {
            driver.WaitUtil(nameInput).SendKeys(name);
            driver.WaitUtil(commentInput).SendKeys(comment);
            driver.WaitUtil(submitBtn).Click();

            driver.Sleep(1000);
        }

        public void VerifySubmitResult(string expectedResult)
        {
            driver.Sleep(4000);
            var retult = driver.WaitUtil(submitResultTxt).Text;

            Assert.AreEqual(expectedResult, retult);
        }

        public void VerifyErrorIsShow()
        {
            string errorStyle = "border: 1px solid rgb(255, 0, 0);";
            var currentStyle = driver.WaitUtil(nameInput).GetAttribute("style");

            Assert.AreEqual(errorStyle, currentStyle);
        }


    }
}
