using NUnit.Framework;
using SeleniumPractice.BasicPractices.GlobalsQa.PageObjectModel.ThirdStep;

namespace SeleniumPractice.BasicPractices.GlobalsQa.TestCases.ThirdStep
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
        public void MoveImageToTrash_Successfully()
        {
            string imageName = "High Tatras";
            dragAndDropPage.MoveImageToTrash(imageName);
            dragAndDropPage.VerifyImageIsDisplayedInTrash(imageName);
        }

        [Test]
        public void MoveImageOutFromTrash_Successfully()
        {
            string imageName = "High Tatras";
            dragAndDropPage.MoveImageToTrash(imageName);
            dragAndDropPage.MoveImageFromTrashOut(imageName);
            dragAndDropPage.VerifyImagesIsDisplayedInGallery(imageName);
        }
    }
}
