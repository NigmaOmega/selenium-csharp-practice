using NUnit.Framework;
using SeleniumPractice.BasicPractices.GlobalsQa.PageObjectModel.LastStep;

namespace SeleniumPractice.BasicPractices.GlobalsQa.TestCases.SecondStep
{
    class Dropdown : BaseTest
    {
        DropDownPage dropDownPage;

        [SetUp]
        public void ClassSetUp()
        {
            dropDownPage = new DropDownPage(driver);
            dropDownPage.GoTo();
        }

        [Test]
        public void SelectCountry()
        {
            dropDownPage.SelectCountry("Viet Nam");
            dropDownPage.VerifyCountrySelectValue("Viet Nam");
        }

    }
}
