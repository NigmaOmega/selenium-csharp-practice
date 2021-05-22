using NUnit.Framework;
using SeleniumPractice.SeleniumEasy.PageObjectModel;
using System;

namespace SeleniumPractice.SeleniumEasy.TestCases
{
    class AjaxFormSubmit : BaseTest
    {
        AjaxFormSubmitPage ajaxFormSubmitPage;
        readonly string name = "Nigma";
        readonly string comment = "This is NigmaOmega!!!";
        readonly string result = "Form submited Successfully!";

        [SetUp]
        public void ClassSetUp()
        {
            ajaxFormSubmitPage = new AjaxFormSubmitPage(driver);
        }

        [Test]
        public void SubmitForm_Successfully()
        {
            ajaxFormSubmitPage.GoTo();
            ajaxFormSubmitPage.InputAjaxFormAndSubmit(name, comment);
            ajaxFormSubmitPage.VerifySubmitResult(result);
        }

        [Test]
        public void SubmitForm_WithoutName_ErrorShow()
        {
            ajaxFormSubmitPage.GoTo();
            ajaxFormSubmitPage.InputAjaxFormAndSubmit(String.Empty, comment);
            ajaxFormSubmitPage.VerifyErrorIsShow();
        }
    }
}
