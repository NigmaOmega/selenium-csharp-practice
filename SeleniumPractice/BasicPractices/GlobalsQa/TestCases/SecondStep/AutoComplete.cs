using NUnit.Framework;
using SeleniumPractice.BasicPractices.GlobalsQa.PageObjectModel.LastStep;

namespace SeleniumPractice.BasicPractices.GlobalsQa.TestCases.SecondStep
{
    class AutoComplete : BaseTest
    {
        AutoCompletePage autoCompletePage;

        [SetUp]
        public void ClassSetUp()
        {
            autoCompletePage = new AutoCompletePage(driver);
            autoCompletePage.GoTo();
        }

        [Test]
        public void SearchWithoutAutocomplete()
        {
            autoCompletePage.Search("abc");
            autoCompletePage.VerifySearchBoxValue("abc");

        }

        [Test]
        public void SearchWithAutocomplte()
        {
            autoCompletePage.Search("a", "antal");
            autoCompletePage.VerifySearchBoxValue("antal");
        }

    }
}
