using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumPractice.SeleniumEasy.PageObjectModel
{
    class RadioButtonPage : BasePage
    {
        readonly By inlineRadioOptions = By.Name("optradio");
        readonly By getCheckedValueBtn = By.Id("buttoncheck");
        readonly By inlineRadioResultTxt = By.ClassName("radiobutton");
        readonly By genderRadioOptions = By.Name("gender");
        readonly By ageGroupRadioOptions = By.Name("ageGroup");
        readonly By getValueBtn = By.XPath("//button[text()='Get values']");
        readonly By groupRadioResultTxt = By.ClassName("groupradiobutton");

        public RadioButtonPage(IWebDriver driver)
        {
            this.driver = driver;
            this.pageUrl = WebUrl.RadioButton;
        }

        public void SelectInlineRadioGender(string gender)
        {
            driver.Radio(inlineRadioOptions).ByValue(gender);
        }

        public void ClickOnGetCheckedValueButton()
        {
            driver.WaitUtil(getCheckedValueBtn).Click();
        }

        public void VerifyInlineRadioResult(string expectedResult)
        {
            var currentResult = driver.WaitUtil(inlineRadioResultTxt).Text;

            Assert.That(currentResult, Does.Contain(expectedResult));
        }

        public void SelectGroupRadioButtons(string gender, string ageGroup)
        {
            driver.Radio(genderRadioOptions).ByValue(gender);
            driver.Radio(ageGroupRadioOptions).ByValue(ageGroup);
        }

        public void ClickOnGetValuesButton()
        {
            driver.WaitUtil(getValueBtn).Click();
        }

        public void VerifyGroupRadionButtonsResult(string expectedGender, string expectedAgeGroup)
        {
            var currentResult = driver.WaitUtil(groupRadioResultTxt).Text;

            Assert.That(currentResult, Does.Contain(expectedGender));
            Assert.That(currentResult, Does.Contain(expectedAgeGroup));
        }



    }
}
