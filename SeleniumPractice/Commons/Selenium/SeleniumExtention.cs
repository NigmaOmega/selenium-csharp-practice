using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumPractice.Commons;
using SeleniumPractice.Commons.Selenium;
using System;

namespace SeleniumPractice
{
    public static class SeleniumExtention
    {

        public static IWebElement WaitForNotVisible(this IWebDriver driver, By by, TimeSpan timeOut)
        {
            var wait = new WebDriverWait(driver, timeOut);
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(by));
            return driver.FindElement(by);
        }

        public static void WaitForNotExist(this IWebDriver driver, By by, TimeSpan timeOut)
        {
            bool success = false;
            int elapsed = 0;
            while ((!success) && (elapsed < timeOut.TotalMilliseconds))
            {
                driver.Sleep(1000);
                elapsed += 1000;
                success = driver.FindElements(by).Count == 0;
            }
        }

        public static Select Select(this IWebDriver driver, By dropdownList)
        {
            return new Select(driver, dropdownList);
        }

        public static Table Table(this IWebDriver driver, By table)
        {
            return new Table(driver, table);
        }

        public static Radio Radio(this IWebDriver driver, By table)
        {
            return new Radio(driver, table);
        }

        public static Checkbox Checkbox(this IWebDriver driver, By table)
        {
            return new Checkbox(driver, table);
        }

        public static string GetValidationMessage(this IWebDriver driver, By by)
        {
            var element = driver.WaitUtil(by, WaitType.WaitUtilExist);
         
            return driver.JsExecute("return arguments[0].validationMessage;", element).ToString();
        }

        public static void ClearAndSendkeys(this IWebElement element, object input) {
            element.Clear();
            element.SendKeys(input.ToString());
        }

        public static void DeleteStorage(this IWebDriver driver) {
            driver.JsExecute("sessionStorage.clear();");
            driver.JsExecute("localStorage.clear();");
        }
    }
}
