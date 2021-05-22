using NUnit.Framework;
using SeleniumPractice.SeleniumEasy.PageObjectModel;
using System;

namespace SeleniumPractice.SeleniumEasy.TestCases
{
    class BootstapDatePicker : BaseTest
    {
        readonly string validDate = "23/12/2020";
        readonly string today = DateTime.Now.ToString("dd/MM/yyyy");
        BootstapDatePickerPage bootstapDatePickerPage;

        [SetUp]
        public void ClassSetUp()
        {
            bootstapDatePickerPage = new BootstapDatePickerPage(driver);
        }

        [Test]
        public void SelectDate_Successfully()
        {
            bootstapDatePickerPage.GoTo();
            bootstapDatePickerPage.SelectDate(validDate);
            bootstapDatePickerPage.VerifyDateValue(validDate);
        }


        [Test]
        public void ClearDate_Successfully()
        {
            bootstapDatePickerPage.GoTo();
            bootstapDatePickerPage.SelectDate(validDate);
            bootstapDatePickerPage.ClearDate();
            bootstapDatePickerPage.VerifyDateValue(String.Empty);
        }

        [Test]
        public void SelectDateToday_Successfully()
        {
            bootstapDatePickerPage.GoTo();
            bootstapDatePickerPage.SelectDate(validDate);
            bootstapDatePickerPage.SelectDateToday();
            bootstapDatePickerPage.VerifyDateValue(today);
        }

        [Test]
        public void SelectStartDate_EndDateIsAutoSetSuccessfully()
        {
            bootstapDatePickerPage.GoTo();
            bootstapDatePickerPage.SelectStartDate(validDate);
            bootstapDatePickerPage.VerifyEndDateValue(today);
        }

    }
}
