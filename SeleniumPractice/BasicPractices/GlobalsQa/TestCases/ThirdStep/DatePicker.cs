using NUnit.Framework;
using SeleniumPractice.BasicPractices.GlobalsQa.PageObjectModel.ThirdStep;

namespace SeleniumPractice.BasicPractices.GlobalsQa.TestCases.ThirdStep
{
    class DatePicker : BaseTest
    {
        DatePickerPage datePickerPage;

        [SetUp]
        public void ClassSetUp()
        {
            datePickerPage = new DatePickerPage(driver);
            datePickerPage.GoTo();
        }

        [Test]
        public void SelectDatePicker_Successfully()
        {
            datePickerPage.SelectDateBox("10", "10", "2013");
            datePickerPage.VerifyDateValue("10/10/2013");
        }

        [Test]
        public void SedkeysToDatePicker_Successfully()
        {
            datePickerPage.SendkeysToDateBox("10/10/2013");
            datePickerPage.VerifyDateValue("10/10/2013");
        }
    }
}
