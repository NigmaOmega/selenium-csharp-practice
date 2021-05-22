using NUnit.Framework;
using SeleniumPractice.SauceDemo.PageObjectModels;
using System;

namespace SeleniumPractice.SauceDemo.TestCases
{
    [TestFixture]
    class LoginFeature : SauceDemoBaseTest
    {
        readonly string lockedOutUser = "locked_out_user";
        readonly string incorrectPassword = "invalid-password";
        readonly string invalidUsername = "invalid-username";

        readonly string lockUserErrorMessage = "Epic sadface: Sorry, this user has been locked out.";
        readonly string emptyUsernameErrorMessage = "Epic sadface: Username is required";
        readonly string emptyPasswordErrorMessage = "Epic sadface: Password is required";
        readonly string incorrectUsernameOrPasswordErrorMessage = "Epic sadface: Username and password do not match any user in this service";


        [Test]
        public void Login_Successfully()
        {
            LoginPage
                .Init(driver)
                .GoTo()
                .Login(WebConstants.UserName, WebConstants.Password);
            InventoryPage
                .Init(driver)
                .VerifyThisPageIsVisible();
        }

        [Test]
        public void Login_WithLockOutUser_ErrorMessageShown()
        {
            LoginPage
                .Init(driver)
                .GoTo()
                .Login(lockedOutUser, WebConstants.Password)
                .VerifyErrorMessageContain(lockUserErrorMessage);
        }


        [Test]
        public void Login_WithEmptyUsername_ErrorMessageShown()
        {
            LoginPage
               .Init(driver)
               .GoTo()
               .Login(String.Empty, WebConstants.Password)
               .VerifyErrorMessageContain(emptyUsernameErrorMessage);
        }

        [Test]
        public void Login_WithEmptyPassword_ErrorMessageShown()
        {
            LoginPage
               .Init(driver)
               .GoTo()
               .Login(WebConstants.UserName, String.Empty)
               .VerifyErrorMessageContain(emptyPasswordErrorMessage);
        }

        [Test]
        public void Login_WithIncorrectPassword_ErrorMessageShown()
        {
            LoginPage
               .Init(driver)
               .GoTo()
               .Login(WebConstants.UserName, incorrectPassword)
               .VerifyErrorMessageContain(incorrectUsernameOrPasswordErrorMessage);
        }


        [Test]
        public void Login_WithInvalidEmail_ErrorMessageShown()
        {
            LoginPage
               .Init(driver)
               .GoTo()
               .Login(invalidUsername, WebConstants.Password)
               .VerifyErrorMessageContain(incorrectUsernameOrPasswordErrorMessage);
        }
    }
}
