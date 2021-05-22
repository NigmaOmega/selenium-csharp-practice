using NUnit.Framework;
using SeleniumPractice.SeleniumEasy.PageObjectModel;
using System.Collections.Generic;

namespace SeleniumPractice.SeleniumEasy.TestCases
{
    class SelectDropdownList : BaseTest
    {
        SelectDropdownListPage selectDropdownListPage;
        readonly string day = "Sunday";
        readonly string state1 = "Florida";
        readonly string state2 = "Texas";


        [SetUp]
        public void ClassSetUp()
        {
            selectDropdownListPage = new SelectDropdownListPage(driver);
            selectDropdownListPage.GoTo();
        }

        [Test]
        public void SelectDay_Successfully()
        {
            selectDropdownListPage.SelectDay(day);
            selectDropdownListPage.VerifySelectedDayResult(day);
        }

        [Test]
        public void SelectStates_ShowFirstSelectedSuccessfully()
        {
            List<string> states = new List<string>();
            states.Add(state1);
            states.Add(state2);
            selectDropdownListPage.SelectStates(states);
            selectDropdownListPage.ClickInFirstSelectedBtn();
            selectDropdownListPage.VerifyMultiSelectResult(state1);
        }

        [Test]
        public void SelectStates_ShowLastSelectedSuccessfully()
        {
            List<string> states = new List<string>();
            states.Add(state1);
            states.Add(state2);
            selectDropdownListPage.SelectStates(states);
            selectDropdownListPage.ClickInGetAllSelectedBtn();
            selectDropdownListPage.VerifyMultiSelectResult(state2);
        }
    }
}
