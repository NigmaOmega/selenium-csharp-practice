using NUnit.Framework;
using SeleniumPractice.SeleniumEasy.PageObjectModel;

namespace SeleniumPractice.SeleniumEasy.TestCases
{
    class RadioButton : BaseTest
    {
        RadioButtonPage radioButtonPage;
        readonly string gender = "Male";
        readonly string ageGroup = "5 - 15";

        [SetUp]
        public void ClassSetUp()
        {
            radioButtonPage = new RadioButtonPage(driver);
            radioButtonPage.GoTo();
        }

        [Test]
        public void SelectGender_Successfully()
        {
            radioButtonPage.SelectInlineRadioGender(gender);
            radioButtonPage.ClickOnGetCheckedValueButton();
            radioButtonPage.VerifyInlineRadioResult(gender);
        }

        [Test]
        public void SelectSexAndAgeGroupOfGroupRadioButtons_Successfully()
        {
            radioButtonPage.SelectGroupRadioButtons(gender, ageGroup);
            radioButtonPage.ClickOnGetValuesButton();
            radioButtonPage.VerifyGroupRadionButtonsResult(gender, ageGroup);
        }
    }
}
