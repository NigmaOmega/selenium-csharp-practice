using NUnit.Framework;
using SeleniumPractice.SeleniumEasy.PageObjectModel;

namespace SeleniumPractice.SeleniumEasy.TestCases
{
    class JQueryDatePicker : BaseTest
    {
        JQueryDatePickerPage jQueryDatePickerPage;
        readonly string validDate = "12/23/2020";

        [SetUp]
        public void ClassSetUp()
        {
            jQueryDatePickerPage = new JQueryDatePickerPage(driver);
            jQueryDatePickerPage.GoTo();
        }


        [Test]
        public void DisableAllDateThatGreaterThanEndDateWhenSelectStartDate_Successfully()
        {
            jQueryDatePickerPage.SelectStartDate(validDate);
            jQueryDatePickerPage.VerifyDisableCorrectEndDate(validDate);
        }

        [Test]
        public void DisableAllDateThatLowerThanStartDateWhenSelectEndDate_Successfully()
        {
            jQueryDatePickerPage.SelectEndDate(validDate);
            jQueryDatePickerPage.VerifyDisableCorrectStartDate(validDate);
        }

    }
}
