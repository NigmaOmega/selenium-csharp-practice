using NUnit.Framework;
using SeleniumPractice.BasicPractices.GlobalsQa.PageObjectModel.FirstStep;
using System;

namespace SeleniumPractice.BasicPractices.GlobalsQa.TestCases.FirstStep
{
    class DialogBox : BaseTest
    {
        DialogBoxPage dialogBoxPage;

        [SetUp]
        public void ClassSetUp()
        {
            dialogBoxPage = new DialogBoxPage(driver);
            dialogBoxPage.GoTo();
        }

        [Test]
        public void CreateNewUser_Successfully()
        {
            dialogBoxPage.CreateNewUser("W33", "W33HaaPro@Gmail.com", "123456");
            dialogBoxPage.VerifyUserIsCreated("W33", "W33HaaPro@Gmail.com", "123456");
        }

        [Test]
        public void CreateNewUserWithIncorrectPassword_ErrorMessage()
        {
            dialogBoxPage.CreateNewUser("W33", "W33HaaPro@Gmail.com", "@@123456");
            dialogBoxPage.VerifyErrorMessage("Password field only allow : a-z 0-9");
        }

        [Test]
        public void CreateNewUserWithoutPassword_ErrorMessage()
        {
            dialogBoxPage.CreateNewUser("W33", "W33HaaPro@Gmail.com", String.Empty);
            dialogBoxPage.VerifyErrorMessage("Length of password must be between 5 and 16.");
        }

        [Test]
        public void CreateNewUserWithPasswordExceedLimitRange_ErrorMessage()
        {
            dialogBoxPage.CreateNewUser("W33", "W33HaaPro@Gmail.com", DataGenerator.GenerateString(17));
            dialogBoxPage.VerifyErrorMessage("Length of password must be between 5 and 16.");
        }

        [Test]
        public void CreateNewUserWithPasswordLowerThanMinLimit_ErrorMessage()
        {
            dialogBoxPage.CreateNewUser("W33", "W33HaaPro@Gmail.com", DataGenerator.GenerateString(4));
            dialogBoxPage.VerifyErrorMessage("Length of password must be between 5 and 16.");
        }

        [Test]
        public void CreateNewUserWithoutName_ErrorMessage()
        {
            dialogBoxPage.CreateNewUser("", "W33HaaPro@Gmail.com", DataGenerator.GenerateString(7));
            dialogBoxPage.VerifyErrorMessage("Length of username must be between 3 and 16.");
        }

        [Test]
        public void CreateNewUserWithNameExceedLimitRange_ErrorMessage()
        {
            dialogBoxPage.CreateNewUser(DataGenerator.GenerateString(17), "W33HaaPro@Gmail.com", DataGenerator.GenerateString(7));
            dialogBoxPage.VerifyErrorMessage("Length of username must be between 3 and 16.");
        }

        [Test]
        public void CreateNewUserWithNameLowerThanMinLimit_ErrorMessage()
        {
            dialogBoxPage.CreateNewUser(DataGenerator.GenerateString(2), "W33HaaPro@Gmail.com", DataGenerator.GenerateString(7));
            dialogBoxPage.VerifyErrorMessage("Length of username must be between 3 and 16.");
        }

        [Test]
        public void CreateNewUserWithoutEmail_ErrorMessage()
        {
            dialogBoxPage.CreateNewUser("W33", "", "1234567");
            dialogBoxPage.VerifyErrorMessage("Length of email must be between 6 and 80.");
        }

        [Test]
        public void CreateNewUserWithEmailExceedLimitRange_ErrorMessage()
        {
            dialogBoxPage.CreateNewUser(DataGenerator.GenerateString(3), DataGenerator.GenerateString(5), DataGenerator.GenerateString(7));
            dialogBoxPage.VerifyErrorMessage("Length of email must be between 6 and 80.");
        }

        [Test]
        public void CreateNewUserWithEmailLowerThanMinLimit_ErrorMessage()
        {
            dialogBoxPage.CreateNewUser(DataGenerator.GenerateString(3), DataGenerator.GenerateString(81), DataGenerator.GenerateString(7));
            dialogBoxPage.VerifyErrorMessage("Length of email must be between 6 and 80.");
        }

        [Test]
        public void CreateNewUserWithInvalidEmail_ErrorMessage()
        {
            dialogBoxPage.CreateNewUser(DataGenerator.GenerateString(3), DataGenerator.GenerateString(10), DataGenerator.GenerateString(7));
            dialogBoxPage.VerifyErrorMessage("eg. ui@jquery.com");
        }
    }
}
