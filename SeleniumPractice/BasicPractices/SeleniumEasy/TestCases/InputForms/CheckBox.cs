using NUnit.Framework;
using SeleniumPractice.SeleniumEasy.PageObjectModel;
using System.Collections.Generic;

namespace SeleniumPractice.SeleniumEasy.TestCases
{
    class CheckBox : BaseTest
    {
        CheckboxPage checkBoxPage;

        [SetUp]
        public void ClassSetUp()
        {
            checkBoxPage = new CheckboxPage(driver);
            checkBoxPage.GoTo();
        }

        [Test]
        public void CheckSingleCheckbox_Successfully()
        {
            var result = "Success - Check box is checked";
            checkBoxPage.CheckSingleCheckBox();
            checkBoxPage.VerifySingleCheckboxTextResult(result);
        }

        [Test]
        public void CheckAllItemsMultipleSelect_Successfully()
        {
            checkBoxPage.ClickOnCheckAll();
            checkBoxPage.VerifyUncheckAllButtonIsDisplayed();
        }

        [Test]
        public void UnCheckAnItemAfterCheckAllItems_DisplayCheckAllButton()
        {
            Dictionary<string, bool> options = new Dictionary<string, bool>();
            options.Add("Option 1", false);
            checkBoxPage.ClickOnCheckAll();
            checkBoxPage.CheckMultipleCheckbox(options);
            checkBoxPage.VerifyCheckAllButtonIsDisplayed();
        }
    }
}
