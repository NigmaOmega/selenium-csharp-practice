using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumPractice.SeleniumEasy.PageObjectModel
{
    class CheckboxPage : BasePage
    {
        readonly By singleCheckBox = By.Id("isAgeSelected");
        readonly By singleCheckResultTxt = By.Id("txtAge");
        readonly By multipleCheckbox = By.XPath("//*[@class='cb1-element']/..");
        readonly By checkAllBtn = By.XPath("//*[@value='Check All']");
        readonly By unCheckAllBtn = By.XPath("//*[@value='Uncheck All']");

        public CheckboxPage(IWebDriver driver)
        {
            this.driver = driver;
            this.pageUrl = WebUrl.Checkbox;
        }

        public void CheckSingleCheckBox(bool isChecked = true)
        {
            var checkBox = driver.WaitUtil(singleCheckBox);
            var isSelected = checkBox.Selected;
            if (isSelected != isChecked)
            {
                checkBox.Click();
            }
        }

        public void VerifySingleCheckboxTextResult(string expectedText)
        {
            var result = driver.WaitUtil(singleCheckResultTxt).Text;

            Assert.AreEqual(expectedText, result);
        }


        public void CheckMultipleCheckbox(Dictionary<string, bool> optionsSelection)
        {
            driver.WaitUtil(multipleCheckbox);
            var multiCheckbox = driver.FindElements(multipleCheckbox);
            foreach (var option in optionsSelection)
            {
                var item = multiCheckbox.FirstOrDefault(s => s.Text.Contains(option.Key));
                item = item.FindElement(By.TagName("input"));
                if (item.Selected != option.Value)
                {
                    item.Click();
                }
            }
        }

        public void ClickOnMultipleCheckBox(List<string> optionName)
        {
            driver.WaitUtil(multipleCheckbox);
            var multiCheckbox = driver.FindElements(multipleCheckbox);
            foreach (var option in optionName)
            {
                var item = multiCheckbox.FirstOrDefault(s => s.Text == option);
                item.Click();
            }
        }

        public void ClickOnCheckAll()
        {
            driver.WaitUtil(checkAllBtn).Click();
        }

        public void ClickOnUncheckAll()
        {
            driver.WaitUtil(unCheckAllBtn).Click();
        }

        public void VerifyCheckAllButtonIsDisplayed()
        {
            var isDisplayed = driver.WaitUtil(checkAllBtn).Displayed;

            Assert.IsTrue(isDisplayed);
        }

        public void VerifyUncheckAllButtonIsDisplayed()
        {
            var isDisplayed = driver.WaitUtil(unCheckAllBtn).Displayed;

            Assert.IsTrue(isDisplayed);
        }
    }
}
