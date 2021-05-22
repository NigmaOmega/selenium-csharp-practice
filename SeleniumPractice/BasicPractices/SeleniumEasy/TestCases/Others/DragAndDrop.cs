using NUnit.Framework;
using SeleniumPractice.SeleniumEasy.PageObjectModel;

namespace SeleniumPractice.SeleniumEasy.TestCases
{
    class DragAndDrop : BaseTest
    {
        DragAndDropPage dragAndDropPage;

        [SetUp]
        public void ClassSetUp()
        {
            dragAndDropPage = new DragAndDropPage(driver);
            dragAndDropPage.GoTo();
        }


        [Test]
        public void DragAndDrop_Successfully()
        {
            //TODO
        }
    }
}
