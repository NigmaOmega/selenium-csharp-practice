using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumPractice.SeleniumEasy.PageObjectModel
{
    class JQuerySelectDropdownPage : BasePage
    {
        readonly By countrySelect = By.Id("country");
        readonly By countrySelected = By.Id("select2-country-container");
        readonly By countryOutlyingTeritory = By.XPath("//*[text()='Select US Outlying Territories :']/../span/span/span/span");
        readonly By statesSelected = By.ClassName("select2-selection__choice");
        readonly By statesSelect = By.XPath("//*[@class='js-example-basic-multiple select2-hidden-accessible']");
        readonly By outlyingTerritoriesSelect = By.XPath("//*[@class='js-example-disabled-results select2-hidden-accessible']");
        readonly By fileSelect = By.Id("files");
        readonly By outlyingTeritoryOptions = By.ClassName("select2-results__option");

        public JQuerySelectDropdownPage(IWebDriver driver)
        {
            this.driver = driver;
            this.pageUrl = WebUrl.JquerySelectDropdown;
        }

        public void SelectCountry(string value)
        {
            driver.Select(countrySelect).ByValue(value);
        }

        public void VerifySelectedCountry(string value)
        {
            var selectedItem = driver.WaitUtil(countrySelected).Text;

            Assert.AreEqual(value, selectedItem);
        }

        public void VerifySelectedTeritory(string value)
        {
            var selectedItem = driver.WaitUtil(countryOutlyingTeritory, WaitType.WaitUtilExist).Text;

            Assert.AreEqual(value, selectedItem);
        }


        public void VerifySelectedStates(List<string> states)
        {
            var currentSelectedStates = driver.FindElements(statesSelected).Select(s => s.GetAttribute("title")).ToList();

            Assert.AreEqual(states, currentSelectedStates);
        }


        public void VerifyNotSelectedStates(List<string> states)
        {
            var currentSelectedStates = driver.FindElements(statesSelected).Select(s => s.GetAttribute("title")).ToList();

            foreach (var state in states)
            {
                Assert.That(currentSelectedStates, Does.Not.Contains(state));
            }
        }

        public void SelectStates(List<string> statesText)
        {
            foreach (var text in statesText)
            {
                driver.Select(statesSelect).ByText(text);
            }
        }


        public void DeselectStates(List<string> statesText)
        {

            foreach (var text in statesText)
            {
                By statesDeselect = By.XPath("//li[text()='" + text + "']/span");
                driver.WaitUtil(statesDeselect).Click();
            }
        }

        public void SelectOutlyingTerritories(string text)
        {
            driver.Select(outlyingTerritoriesSelect).ByText(text);
        }

        public void VerifyDisabledOutlyingTeritories(List<string> outlyingTeritories)
        {
            driver.WaitUtil(countryOutlyingTeritory).Click();
            driver.WaitUtil(outlyingTeritoryOptions);
            var currentDisableItems = driver.FindElements(outlyingTeritoryOptions).Where(s => s.GetAttribute("aria-disabled") == "true").Select(s => s.Text).ToList();

            Assert.AreEqual(outlyingTeritories, currentDisableItems);
        }

        public void SelectAFile(string text)
        {
            driver.Select(fileSelect).ByText(text);
        }

        public void VerifyThatTheFileIsSelected(string fileName)
        {
            var selectedItem = driver.Select(fileSelect).GetSelected().FirstOrDefault().Text;

            Assert.AreEqual(fileName, selectedItem);
        }

    }
}
