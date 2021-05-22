using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumPractice.SeleniumEasy.Model;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumPractice.SeleniumEasy.PageObjectModel
{
    class InputFormSubmitPage : BasePage
    {
        readonly By firstNameInput = By.Name("first_name");
        readonly By lastNameInput = By.Name("last_name");
        readonly By emailInput = By.Name("email");
        readonly By phoneInput = By.Name("phone");
        readonly By addressInput = By.Name("address");
        readonly By cityInput = By.Name("city");
        readonly By stateSelect = By.Name("state");
        readonly By zipCodeInput = By.Name("zip");
        readonly By websiteOrDomainNameInput = By.Name("website");
        readonly By doYouHaveHostingRadioBtn = By.Name("hosting");
        readonly By projectDescriptionInput = By.Name("comment");
        readonly By sendBtn = By.XPath("//button[text()='Send ']");

        readonly By errorMessageTxt = By.XPath("//small[@class='help-block' and @data-bv-result='INVALID']");
        public InputFormSubmitPage(IWebDriver driver)
        {
            this.driver = driver;
            this.pageUrl = WebUrl.InputFormSubmit;
        }

        public void FillUserInformationAndSend(User user)
        {
            driver.WaitUtil(firstNameInput).SendKeys(user.FirstName);
            driver.WaitUtil(lastNameInput).SendKeys(user.LastName);
            driver.WaitUtil(emailInput).SendKeys(user.Email);
            driver.WaitUtil(phoneInput).SendKeys(user.Phone);
            driver.WaitUtil(addressInput).SendKeys(user.Address);
            driver.WaitUtil(cityInput).SendKeys(user.City);
            driver.Select(stateSelect).ByText(user.State);
            driver.WaitUtil(zipCodeInput).SendKeys(user.ZipCode);
            driver.WaitUtil(websiteOrDomainNameInput).SendKeys(user.WebSiteOrDomainName);
            driver.Radio(doYouHaveHostingRadioBtn).ByValue(user.DoYouHaveHosting);
            driver.WaitUtil(projectDescriptionInput).SendKeys(user.ProjectDescription);

            driver.WaitUtil(sendBtn).Click();
        }

        public void VerifyThatNoErrorMessageIsShown()
        {
            driver.Sleep(1000);
            var currentCount = driver.FindElements(errorMessageTxt).Count;

            Assert.AreEqual(0, currentCount);
        }

        public void VerifyErrorMessage(string expectedErrorMessage)
        {
            driver.WaitUtil(errorMessageTxt);
            var errorMessages = driver.FindElements(errorMessageTxt).Select(s => s.Text).ToList();

            Assert.That(errorMessages, Does.Contain(expectedErrorMessage));
        }

        public void VerifySendButtonIsDisable()
        {
            var currentStatus = driver.WaitUtil(sendBtn).GetAttribute("disabled");
            var expectedStatus = "true";

            Assert.AreEqual(expectedStatus, currentStatus);
        }
        public void VerifyErrorMessages(List<string> expectedErrorMessage)
        {
            driver.WaitUtil(errorMessageTxt);
            var errorMessages = driver.FindElements(errorMessageTxt).Select(s => s.Text).ToList();

            Assert.AreEqual(expectedErrorMessage, errorMessages);
        }

    }
}
