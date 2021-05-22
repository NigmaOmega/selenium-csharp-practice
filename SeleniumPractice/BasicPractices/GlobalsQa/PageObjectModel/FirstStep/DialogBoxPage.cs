using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumPractice.GlobalsQa;
using System.Collections.Generic;

namespace SeleniumPractice.BasicPractices.GlobalsQa.PageObjectModel.FirstStep
{
    class DialogBoxPage : BasePage
    {
        readonly By createNewUserBtn = By.Id("create-user");
        readonly By createAnAccountBtn = By.XPath("//button[text()='Create an account']");
        readonly By cancelBtn = By.XPath("//button[text()='Cancel']");
        readonly By nameInput = By.Id("name");
        readonly By emailInput = By.Id("email");
        readonly By passwordInput = By.Id("password");
        readonly By errorMessageTxt = By.ClassName("validateTips");
        readonly By userTable = By.Id("users");
        readonly By dialogForm = By.Id("dialog-form");
        public DialogBoxPage(IWebDriver driver)
        {
            this.driver = driver;
            this.url = WebUrl.DialogBox;
        }

        public void VerifyErrorMessage(string errorMessage)
        {
            var currentErrorMessage = driver.WaitUtil(errorMessageTxt).Text;

            Assert.AreEqual(errorMessage, currentErrorMessage);
        }

        public void CreateNewUser(string name, string email, string password)
        {
            ClickOnCreateNewUserButton();
            FillDataIntoUserCreatingPopup(name, email, password);
            ClickOnCreateAnAccountButton();
        }

        public void ClickOnCreateNewUserButton()
        {
            driver.WaitUtil(createNewUserBtn).Click();
        }

        public void FillDataIntoUserCreatingPopup(string name, string email, string password)
        {
            driver.WaitUtil(nameInput).Clear();
            driver.WaitUtil(nameInput).SendKeys(name);
            driver.WaitUtil(emailInput).Clear();
            driver.WaitUtil(emailInput).SendKeys(email);
            driver.WaitUtil(passwordInput).Clear();
            driver.WaitUtil(passwordInput).SendKeys(password);
        }
        public void ClickOnCreateAnAccountButton()
        {
            driver.WaitUtil(createAnAccountBtn).Click();
        }
        public void ClickOnCancelButton()
        {
            driver.WaitUtil(cancelBtn).Click();
        }

        public void VerifyUserIsCreated(string name, string email, string password)
        {
            var listUsersInfo = driver.Table(userTable).GetTableData();

            var expectedUserInfo = new List<string> { name, email, password };

            Assert.That(listUsersInfo, Does.Contain(expectedUserInfo));
        }

        public void VerifyVisibilityOfDialogForm(bool isDisplayed)
        {
            var currentStatus = driver.WaitUtil(dialogForm, WaitType.WaitUtilExist).Displayed;

            Assert.AreEqual(isDisplayed, currentStatus);
        }
    }
}
