using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumPractice.SeleniumEasy.PageObjectModel
{
    class BootstapDatePickerPage : BasePage
    {
        readonly By dateDp = By.XPath("//*[@id='sandbox-container1']//input");
        readonly By dateIconBtn = By.XPath("//*[@id='sandbox-container1']/div/span");
        readonly By startDateDp = By.XPath("//*[@id='datepicker']/input[1]");
        readonly By endDateDp = By.XPath("//*[@id='datepicker']/input[2]");
        readonly By dateTodayBtn = By.XPath("//th[text()='Today']");
        readonly By dateClearBtn = By.XPath("//th[text()='Clear']");


        public BootstapDatePickerPage(IWebDriver driver)
        {
            this.driver = driver;
            this.pageUrl = WebUrl.BootstrapDatePicker;
        }

        public void SelectDate(string dateTime)
        {
            SelectDatePicker(dateDp, dateTime);
        }

        public void SelectDateToday()
        {
            driver.WaitUtil(dateIconBtn).Click();
            driver.WaitUtil(dateTodayBtn).Click();
        }


        public void ClearDate()
        {
            driver.WaitUtil(dateDp).Click();
            driver.WaitUtil(dateClearBtn).Click();
        }

        public void VerifyDateValue(string dateTime)
        {
            var currentDate = driver.WaitUtil(dateDp).GetAttribute("value");

            Assert.AreEqual(dateTime, currentDate);
        }


        public void VerifyEndDateValue(string dateTime)
        {
            var currentDate = driver.WaitUtil(endDateDp).GetAttribute("value");

            Assert.AreEqual(dateTime, currentDate);
        }

        public void VerifyStartDateValue(string dateTime)
        {
            var currentDate = driver.WaitUtil(startDateDp).GetAttribute("value");

            Assert.AreEqual(dateTime, currentDate);
        }

        public void SelectStartDate(string startDate)
        {
            SelectDatePicker(startDateDp, startDate);
        }

        public void SelectEndDate(string endDate)
        {
            SelectDatePicker(endDateDp, endDate);
        }


        private void SelectDatePicker(By datePicker, string dateTime)
        {
            var element = driver.WaitUtil(datePicker);
            element.Click();
            element.Clear();
            element.SendKeys(dateTime);
        }


    }
}
