using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumPractice.GlobalsQa;

namespace SeleniumPractice.BasicPractices.GlobalsQa.PageObjectModel.LastStep
{
    class DropDownPage : BasePage
    {
        readonly By countrySelect = By.TagName("select");

        public DropDownPage(IWebDriver driver)
        {
            this.driver = driver;
            this.url = WebUrl.DropDown;
        }

        public void SelectCountry(string countryName)
        {
            driver.Select(countrySelect).ByText(countryName);
        }

        public void VerifyCountrySelectValue(string expectedSelectedTextItem)
        {
            var element = driver.WaitUtil(countrySelect);
            SelectElement countryElement = new SelectElement(element);
            var currentSelectedItem = countryElement.SelectedOption.Text;

            Assert.AreEqual(expectedSelectedTextItem, currentSelectedItem);
        }
    }
}
