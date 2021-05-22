using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumPractice.SeleniumEasy.PageObjectModel
{
    class SelectDropdownListPage : BasePage
    {
        readonly By daySelect = By.Id("select-demo");
        readonly By stateSelect = By.Id("multi-select");
        readonly By selectedValueResultTxt = By.ClassName("selected-value");
        readonly By firstSelectedBtn = By.Id("printMe");
        readonly By getAllSelectedBtn = By.Id("printAll");
        readonly By multiselectResultTxt = By.ClassName("getall-selected");

        public SelectDropdownListPage(IWebDriver driver)
        {
            this.driver = driver;
            this.pageUrl = WebUrl.SelectDropdownList;
        }

        public void SelectDay(string value)
        {
            driver.Select(daySelect).ByValue(value);
        }

        public void VerifySelectedDayResult(string expectedSelectedDay)
        {
            var currentResult = driver.WaitUtil(selectedValueResultTxt).Text;

            Assert.That(currentResult, Does.Contain(expectedSelectedDay));
        }

        public void SelectStates(List<string> statesValue)
        {
            SelectMultiOptions(stateSelect, statesValue);
        }

        public void ClickInFirstSelectedBtn()
        {
            driver.WaitUtil(firstSelectedBtn).Click();
        }

        public void ClickInGetAllSelectedBtn()
        {
            driver.WaitUtil(getAllSelectedBtn).Click();
        }

        public void VerifyMultiSelectResult(string firstSelectedExpected)
        {
            var result = driver.WaitUtil(multiselectResultTxt).Text;
            Assert.That(result, Does.Contain(firstSelectedExpected));
        }

        private void SelectMultiOptions(By by, List<string> values)
        {
            var elements = driver.WaitUtil(by).FindElements(By.TagName("option"));
            Actions action = new Actions(driver);
            action.KeyDown(Keys.LeftControl);
            foreach (var value in values)
            {
                var element = elements.First(s => s.GetAttribute("value") == value);
                action.Click(element);
            }
            action.Build();
            action.Perform();
        }
    }
}
