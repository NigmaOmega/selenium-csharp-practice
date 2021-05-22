using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace SeleniumPractice.SeleniumEasy.PageObjectModel
{
    class JQueryDatePickerPage : BasePage
    {
        readonly By fromDp = By.Id("from");
        readonly By toDp = By.Id("to");

        public JQueryDatePickerPage(IWebDriver driver)
        {
            this.driver = driver;
            this.pageUrl = WebUrl.JQueryDatePicker;
        }

        public void SelectStartDate(string date)
        {
            driver.WaitUtil(fromDp).Click();
            SelectDate(date);
            driver.Sleep(1000);
        }

        public void SelectEndDate(string date)
        {

            driver.WaitUtil(toDp).Click();
            SelectDate(date);
        }

        public void VerifyStartDate(string expectedDate)
        {
            driver.Sleep(1000);
            var currentDate = driver.WaitUtil(fromDp).GetAttribute("value");

            Assert.AreEqual(expectedDate, currentDate);
        }

        public void VerifyEndDate(string expectedDate)
        {
            driver.Sleep(1000);
            var currentDate = driver.WaitUtil(toDp).GetAttribute("value");

            Assert.AreEqual(expectedDate, currentDate);
        }

        public void VerifyDisableCorrectEndDate(string date)
        {
            var items = date.Split("/");
            int month = items[0].ToInt();
            int day = items[1].ToInt();
            int year = items[2].ToInt();

            driver.WaitUtil(toDp).Click();

            SelectYearAndMonth(year, month);

            //Verify
            By disabledOptions = By.XPath("//*[@id='ui-datepicker-div']//td[contains(@class,'ui-datepicker-unselectable ui-state-disabled')]/span");
            By enableOptions = By.XPath("//*[@id='ui-datepicker-div']//td[@data-handler='selectDay']/a");

            var disabledDays = driver.FindElements(disabledOptions).ToList();
            var enabledDays = driver.FindElements(enableOptions).ToList();
            Assert.AreEqual(DateTime.DaysInMonth(year, month) - day + 1, enabledDays.Count);
            Assert.AreEqual(day - 1, disabledDays.Count);


        }
        public void VerifyDisableCorrectStartDate(string date)
        {
            var items = date.Split("/");
            int month = items[0].ToInt();
            int day = items[1].ToInt();
            int year = items[2].ToInt();

            driver.WaitUtil(fromDp).Click();

            SelectYearAndMonth(year, month);

            //Verify
            By disabledOptions = By.XPath("//*[@id='ui-datepicker-div']//td[contains(@class,'ui-datepicker-unselectable ui-state-disabled')]/span");
            By enableOptions = By.XPath("//*[@id='ui-datepicker-div']//td[@data-handler='selectDay']/a");

            var disabledDays = driver.FindElements(disabledOptions).ToList();
            var enabledDays = driver.FindElements(enableOptions).ToList();
            Assert.AreEqual(DateTime.DaysInMonth(year, month) - day, disabledDays.Count);
            Assert.AreEqual(day, enabledDays.Count);


        }


        private void SelectDate(string date)
        {
            var items = date.Split("/");
            int month = items[0].ToInt();
            int day = items[1].ToInt();
            int year = items[2].ToInt();

            SelectYearAndMonth(year, month);
            SelectDay(day);
        }

        private void SelectDay(int day)
        {
            var datePicking = driver.WaitUtil(By.Id("ui-datepicker-div"));

            datePicking.FindElement(By.XPath("//a[text()='" + day + "']")).Click();
        }

        private void SelectYearAndMonth(int year, int month)
        {
            var datePicking = driver.WaitUtil(By.Id("ui-datepicker-div"));

            //Move calendar to current year
            //Select year
            int currentYearInCalendar;
            do
            {
                currentYearInCalendar = datePicking.FindElement(By.ClassName("ui-datepicker-year")).Text.ToInt();

                if (year > currentYearInCalendar)
                {
                    datePicking.FindElement(By.ClassName("ui-datepicker-next")).Click();
                }
                else if (year < currentYearInCalendar)
                {
                    datePicking.FindElement(By.ClassName("ui-datepicker-prev")).Click();
                }
            } while (year != currentYearInCalendar);

            //Select Month

            driver.Select(By.ClassName("ui-datepicker-month")).ByValue((month - 1).ToString());
        }
    }
}
