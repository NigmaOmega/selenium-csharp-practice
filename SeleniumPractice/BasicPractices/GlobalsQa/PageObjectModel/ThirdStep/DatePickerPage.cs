using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumPractice.GlobalsQa;
using System.Linq;

namespace SeleniumPractice.BasicPractices.GlobalsQa.PageObjectModel.ThirdStep
{
    class DatePickerPage : BasePage
    {
        readonly By dateBox = By.Id("datepicker");
        readonly By monthSelect = By.ClassName("ui-datepicker-month");
        readonly By yearSelect = By.ClassName("ui-datepicker-year");
        readonly By daysSelect = By.XPath("//*[@data-handler='selectDay']/a");

        public DatePickerPage(IWebDriver driver)
        {
            this.driver = driver;
            this.url = WebUrl.DatePicker;
        }

        public void SendkeysToDateBox(string date)
        {
            driver.WaitUtil(dateBox).SendKeys(date);
        }

        public void SelectDateBox(string day, string month, string year)
        {
            driver.WaitUtil(dateBox).Click();
            driver.Select(monthSelect).ByValue((month.ToInt() - 1).ToString());
            driver.Select(yearSelect).ByValue(year);
            driver.FindElements(daysSelect).First(s => s.Text == day).Click();
        }

        public void VerifyDateValue(string date)
        {
            var currentDateValue = driver.WaitUtil(dateBox).GetAttribute("value");

            Assert.AreEqual(date, currentDateValue);
        }

    }
}
