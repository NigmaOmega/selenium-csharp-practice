using NUnit.Framework;
using SeleniumPractice.BasicPractices.GlobalsQa.PageObjectModel.ThirdStep;

namespace SeleniumPractice.BasicPractices.GlobalsQa.TestCases.ThirdStep
{
    class DraggableBox : BaseTest
    {
        DraggableBoxPage draggableBoxPage;

        [SetUp]
        public void ClassSetUp()
        {
            draggableBoxPage = new DraggableBoxPage(driver);
            draggableBoxPage.GoTo();
        }

        [Test]
        public void DragTheBox_Successfully()
        {
            draggableBoxPage.DragTheBox(100, 200);
            draggableBoxPage.VerifyThePositionOfTheBox(108, 208);

        }
    }
}
