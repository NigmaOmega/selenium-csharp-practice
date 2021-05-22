using NUnit.Framework;
using SeleniumPractice.SeleniumEasy.Model;
using SeleniumPractice.SeleniumEasy.PageObjectModel;
using System;

namespace SeleniumPractice.SeleniumEasy.TestCases
{
    class InputFormSubmit : BaseTest
    {
        InputFormSubmitPage inputFormSubmitPage;
        User user;
        readonly string firstNameErrorMessage = "Please supply your first name";
        readonly string lastNameErrorMessage = "Please supply your last name";
        readonly string emailErrorMessage = "Please supply your email address";
        readonly string phoneErrorMessage = "Please supply your phone number";
        readonly string addressErrorMessage = "Please supply your street address";
        readonly string cityErrorMessage = "Please supply your city";
        readonly string stateErrorMessage = "Please select your state";
        readonly string zipCodeErrorMessage = "Please supply your zip code";
        readonly string projectDescriptionErrorMessage = "Please supply a description of your project";

        [SetUp]
        public void ClassSetUp()
        {
            inputFormSubmitPage = new InputFormSubmitPage(driver);
            inputFormSubmitPage.GoTo();

            user = new User();
            user.FirstName = "Nigma";
            user.LastName = "Omega";
            user.Email = "automate4fun@gmail.com";
            user.Phone = "0393062124";
            user.Address = "Ha Noi - Vietnam";
            user.City = "Ha Noi";
            user.State = "Iowa";
            user.ZipCode = "10000";
            user.WebSiteOrDomainName = "https://github.com/NigmaOmega";
            user.DoYouHaveHosting = "no";
            user.ProjectDescription = "Contact me!!!";
        }

        [Test]
        public void SendInformation_Successfully()
        {
            inputFormSubmitPage.FillUserInformationAndSend(user);
            inputFormSubmitPage.VerifyThatNoErrorMessageIsShown();
        }

        [Test]
        public void SendInfomationWithoutFirstName_ErrorMessageShown()
        {
            user.FirstName = String.Empty;
            inputFormSubmitPage.FillUserInformationAndSend(user);
            inputFormSubmitPage.VerifyErrorMessage(firstNameErrorMessage);
            inputFormSubmitPage.VerifySendButtonIsDisable();
        }

        [Test]
        public void SendInfomationWithoutLastName_ErrorMessageShown()
        {
            user.LastName = String.Empty;
            inputFormSubmitPage.FillUserInformationAndSend(user);
            inputFormSubmitPage.VerifyErrorMessage(lastNameErrorMessage);
            inputFormSubmitPage.VerifySendButtonIsDisable();
        }


        [Test]
        public void SendInfomationWithoutEmail_ErrorMessageShown()
        {
            user.Email = String.Empty;
            inputFormSubmitPage.FillUserInformationAndSend(user);
            inputFormSubmitPage.VerifyErrorMessage(emailErrorMessage);
            inputFormSubmitPage.VerifySendButtonIsDisable();
        }


        [Test]
        public void SendInfomationWithoutPhone_ErrorMessageShown()
        {
            user.Phone = String.Empty;
            inputFormSubmitPage.FillUserInformationAndSend(user);
            inputFormSubmitPage.VerifyErrorMessage(phoneErrorMessage);
            inputFormSubmitPage.VerifySendButtonIsDisable();
        }


        [Test]
        public void SendInfomationWithoutAddress_ErrorMessageShown()
        {
            user.Address = String.Empty;
            inputFormSubmitPage.FillUserInformationAndSend(user);
            inputFormSubmitPage.VerifyErrorMessage(addressErrorMessage);
            inputFormSubmitPage.VerifySendButtonIsDisable();
        }

        [Test]
        public void SendInfomationWithoutCity_ErrorMessageShown()
        {
            user.City = String.Empty;
            inputFormSubmitPage.FillUserInformationAndSend(user);
            inputFormSubmitPage.VerifyErrorMessage(cityErrorMessage);
            inputFormSubmitPage.VerifySendButtonIsDisable();
        }
        [Test]
        public void SendInfomationWithoutState_ErrorMessageShown()
        {
            user.State = "Please select your state";
            inputFormSubmitPage.FillUserInformationAndSend(user);
            inputFormSubmitPage.VerifyErrorMessage(stateErrorMessage);
            inputFormSubmitPage.VerifySendButtonIsDisable();
        }
        [Test]
        public void SendInfomationWithoutZipCode_ErrorMessageShown()
        {
            user.ZipCode = String.Empty;
            inputFormSubmitPage.FillUserInformationAndSend(user);
            inputFormSubmitPage.VerifyErrorMessage(zipCodeErrorMessage);
            inputFormSubmitPage.VerifySendButtonIsDisable();
        }
        [Test]
        public void SendInfomationWithoutProjectDescription_ErrorMessageShown()
        {
            user.ProjectDescription = String.Empty;
            inputFormSubmitPage.FillUserInformationAndSend(user);
            inputFormSubmitPage.VerifyErrorMessage(projectDescriptionErrorMessage);
            inputFormSubmitPage.VerifySendButtonIsDisable();
        }


    }
}
