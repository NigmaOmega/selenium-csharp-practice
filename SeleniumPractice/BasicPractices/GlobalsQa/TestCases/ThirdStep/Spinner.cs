using NUnit.Framework;
using SeleniumPractice.BasicPractices.GlobalsQa.PageObjectModel.ThirdStep;

namespace SeleniumPractice.BasicPractices.GlobalsQa.TestCases.ThirdStep
{
    class Spinner : BaseTest
    {
        SpinnerPage spinnerPage;

        [SetUp]
        public void ClassSetUp()
        {
            spinnerPage = new SpinnerPage(driver);
            spinnerPage.GoTo();
        }

        [Test]
        public void SetValueTo5()
        {
            spinnerPage.SetValueTo5();
            spinnerPage.VerifyInputValue("5");
        }


        [Test]
        public void GetValueByButtonGetValue()
        {
            spinnerPage.SetValueTo5();
            spinnerPage.ClickOnGetValue();
            spinnerPage.VerifyInputValueAndClosePopup("5");
        }

        [Test]
        public void UpValue_Successfully()
        {
            spinnerPage.UpValue();
            spinnerPage.VerifyInputValue("1");
        }

        [Test]
        public void DownValue_Successfully()
        {
            spinnerPage.DownValue();
            spinnerPage.VerifyInputValue("-1");
        }

        [Test]
        public void DisableTheSpinner_Successfully()
        {
            spinnerPage.ClickOnToggleDiableEnableButton();
            spinnerPage.VerifyInputIsDisable();
        }


        [Test]
        public void EnableAfterDisableTheSpinner_Successfully()
        {
            spinnerPage.ClickOnToggleDiableEnableButton();
            spinnerPage.ClickOnToggleDiableEnableButton();
            spinnerPage.VerifyInputIsEnabled();
        }



        [Test]
        public void DestroyToggleWidget_Successfully()
        {
            spinnerPage.ClickOnToggleWidgetButton();
            spinnerPage.VerifyToggleIsDestroyed();
        }
    }
}
