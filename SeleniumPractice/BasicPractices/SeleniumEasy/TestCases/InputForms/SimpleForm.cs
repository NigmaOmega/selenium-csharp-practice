using NUnit.Framework;
using SeleniumPractice.SeleniumEasy.PageObjectModel;

namespace SeleniumPractice.SeleniumEasy.TestCases
{
    class SimpleForm : BaseTest
    {
        SimpleFormPage simpleFormPage;
        readonly string message = "message 01";
        readonly string aValue = "1";
        readonly string bValue = "2";
        readonly int totalValue = 3;

        [SetUp]
        public void ClassSetUp()
        {
            simpleFormPage = new SimpleFormPage(driver);
            simpleFormPage.GoTo();
            simpleFormPage.TurnOfPopup();
        }

        [Test]
        public void InputIntoSingleInputField_Successfully()
        {
            simpleFormPage.EnterTheMessage(message);
            simpleFormPage.ClickOnShowMessageButton();
            simpleFormPage.VerifyYourMessageResult(message);
        }

        [Test]
        public void InputIntoTwoInputField_Successfully()
        {
            simpleFormPage.EnterAandBvalues(aValue, bValue);
            simpleFormPage.ClickOnGetTotalButton();
            simpleFormPage.VerifyTotalValue(totalValue);
        }
    }
}
