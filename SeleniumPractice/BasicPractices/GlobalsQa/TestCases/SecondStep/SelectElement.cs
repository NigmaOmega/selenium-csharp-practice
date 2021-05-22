using NUnit.Framework;
using SeleniumPractice.BasicPractices.GlobalsQa.PageObjectModel.LastStep;
using System.Collections.Generic;

namespace SeleniumPractice.BasicPractices.GlobalsQa.TestCases.SecondStep
{
    class SelectElement : BaseTest
    {
        SelectElementPage selectElementPage;

        [SetUp]
        public void ClassSetUp()
        {
            selectElementPage = new SelectElementPage(driver);
            selectElementPage.GoTo();
        }

        [Test]
        public void SelectItems_Successfully()
        {
            List<string> items = new List<string>();
            items.Add("Item 1");
            items.Add("Item 3");
            items.Add("Item 5");
            selectElementPage.SelectItems(items);
            selectElementPage.VerifySelectedItem(items);
        }
    }
}
