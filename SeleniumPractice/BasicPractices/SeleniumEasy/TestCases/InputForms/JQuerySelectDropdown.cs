using NUnit.Framework;
using SeleniumPractice.SeleniumEasy.PageObjectModel;
using System.Collections.Generic;

namespace SeleniumPractice.SeleniumEasy.TestCases
{
    class JQuerySelectDropdown : BaseTest
    {
        JQuerySelectDropdownPage jQuerySelectDropdownPage;
        readonly string country = "Japan";
        readonly string State1 = "Alaska";
        readonly string State2 = "Iowa";
        readonly string outlyingTeritory = "American Samoa";
        readonly string disabledOutlyingTeritory1 = "Guam";
        readonly string disabledOutlyingTeritory2 = "United States Minor Outlying Islands";
        readonly string fileName = "Java";

        [SetUp]
        public void ClassSetUp()
        {
            jQuerySelectDropdownPage = new JQuerySelectDropdownPage(driver);
            jQuerySelectDropdownPage.GoTo();
        }

        [Test]
        public void SelectCountry_Successfully()
        {
            jQuerySelectDropdownPage.SelectCountry(country);
            jQuerySelectDropdownPage.VerifySelectedCountry(country);
        }


        [Test]
        public void SelectStates_Successfully()
        {
            List<string> states = new List<string>();
            states.Add(State1);
            states.Add(State2);
            jQuerySelectDropdownPage.SelectStates(states);
            jQuerySelectDropdownPage.VerifySelectedStates(states);
        }

        [Test]
        public void SelectAndDeselectStates_Successfully()
        {
            List<string> states = new List<string>();
            states.Add(State1);
            states.Add(State2);
            jQuerySelectDropdownPage.SelectStates(states);
            jQuerySelectDropdownPage.VerifySelectedStates(states);
            jQuerySelectDropdownPage.DeselectStates(states);
            jQuerySelectDropdownPage.VerifyNotSelectedStates(states);
        }

        [Test]
        public void SelectEnableOutlyingTeritory_Successfully()
        {
            jQuerySelectDropdownPage.SelectOutlyingTerritories(outlyingTeritory);
            jQuerySelectDropdownPage.VerifySelectedTeritory(outlyingTeritory);
        }


        [Test]
        public void OutlyingTeritoryItemsIsDisabled_Successfully()
        {
            List<string> disableTeritories = new List<string>();
            disableTeritories.Add(disabledOutlyingTeritory1);
            disableTeritories.Add(disabledOutlyingTeritory2);
            jQuerySelectDropdownPage.VerifyDisabledOutlyingTeritories(disableTeritories);
        }

        [Test]
        public void SelectAFile_Successfully()
        {
            jQuerySelectDropdownPage.SelectAFile(fileName);
            jQuerySelectDropdownPage.VerifyThatTheFileIsSelected(fileName);
        }
    }
}
