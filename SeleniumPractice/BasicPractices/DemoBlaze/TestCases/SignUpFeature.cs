using NUnit.Framework;
using System;

namespace SeleniumPractice.DemoBlaze.TestCases
{

    public class SignUpFeature : DemoBlazeBaseTest
    {
        string validPassword = "Password@123";
        string validRandomUsername = "User_" + DataGenerator.GenerateString(10);
        string validUsername = "admin";

        [Test]
        public void SignUp_Successfully()
        {
            homePage
                .GoTo()
                .OpenSignUpPopup();

            signUpPage
                .SignUp(validRandomUsername, validPassword);

            homePage
                .VerifyMessageIsShown("Sign up successful.");

        }

        [Test]
        public void SignUp_WithoutUsername_ErrorMessage()
        {
            homePage
                .GoTo()
                .OpenSignUpPopup();

            signUpPage
                .SignUp(String.Empty, validPassword);

            homePage
                .VerifyMessageIsShown("Please fill out Username and Password.");
        }

        [Test]
        public void SignUp_WithoutPassword_ErrorMessage()
        {
            homePage
                .GoTo()
                .OpenSignUpPopup();

            signUpPage
                .SignUp(validRandomUsername, String.Empty);

            homePage
                .VerifyMessageIsShown("Please fill out Username and Password.");
        }


        [Test]
        public void SignUp_WithExistanceUsername_ErrorMessage()
        {
            homePage
                 .GoTo()
                 .OpenSignUpPopup();

            signUpPage
                 .SignUp(validUsername, String.Empty);

            homePage
                .VerifyMessageIsShown("Please fill out Username and Password.");
        }


    }

}