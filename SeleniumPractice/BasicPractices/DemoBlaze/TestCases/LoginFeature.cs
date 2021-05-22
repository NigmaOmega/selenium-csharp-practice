using NUnit.Framework;
using System;

namespace SeleniumPractice.DemoBlaze.TestCases
{
    public class LoginFeature : DemoBlazeBaseTest
    {
        [SetUp]
        public void Setup()
        {
            driver.DeleteAllCookies();

            homePage
                .GoTo()
                .OpenLoginPopup();
        }

        [Test]
        public void Login_Successfully()
        {
            loginPage
                .Login(WebConstants.Username, WebConstants.Password);

            homePage
                .VerifyUserIsLoggedIn(WebConstants.Username);

        }

        [Test]
        public void Login_WithoutUsername_ErrorMessage()
        {
            loginPage
                .Login(String.Empty, WebConstants.Password);

            homePage
                .VerifyMessageIsShown("Please fill out Username and Password.");
        }

        [Test]
        public void Login_WithoutPassword_ErrorMessage()
        {
            loginPage
                .Login(WebConstants.Username, String.Empty);

            homePage
                .VerifyMessageIsShown("Please fill out Username and Password.");
        }



        [Test]
        public void Login_WithIncorrectPassword_ErrorMessage()
        {
            string incorrectPassword = DataGenerator.GenerateString(10);

            loginPage
                .Login(WebConstants.Username, incorrectPassword);

            homePage
                .VerifyMessageIsShown("Wrong password.");
        }

        [Test]
        public void Login_WithNotExistUsername_ErrorMessage()
        {
            string notExistUser = "NotExistUser_" + DataGenerator.GenerateString(10);

            loginPage
                .Login(notExistUser, WebConstants.Password);

            homePage
                .VerifyMessageIsShown("User does not exist.");
        }

    }
}