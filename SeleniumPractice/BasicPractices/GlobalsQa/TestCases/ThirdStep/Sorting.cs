using NUnit.Framework;
using SeleniumPractice.BasicPractices.GlobalsQa.PageObjectModel.ThirdStep;

namespace SeleniumPractice.BasicPractices.GlobalsQa.TestCases.ThirdStep
{
    class Sorting : BaseTest
    {
        SortingPage sortingPage;

        [SetUp]
        public void ClassSetUp()
        {
            sortingPage = new SortingPage(driver);
            sortingPage.GoTo();
        }

        [Test]
        public void MoveItemInList()
        {
            sortingPage.MoveItem("Item 7", "Item 2");
            sortingPage.VerifyIndexOfItem("Item 7", 1);

        }
    }
}
