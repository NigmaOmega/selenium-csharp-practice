using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumPractice.GlobalsQa;

namespace SeleniumPractice.BasicPractices.GlobalsQa.PageObjectModel.ThirdStep
{
    class DragAndDropPage : BasePage
    {
        readonly By trashBox = By.XPath("//*[@id='trash']");
        readonly By gallery = By.XPath("//*[@id='gallery']");

        private By GetGalleryImageLocator(string imageName)
        {
            By image = By.XPath("//*[@id='gallery']/li/h5[text()='" + imageName + "']");

            return image;
        }

        private By GetTrashImageLocator(string imageName)
        {
            By image = By.XPath("//*[@id='trash']//li/h5[text()='" + imageName + "']/..");

            return image;
        }


        public DragAndDropPage(IWebDriver driver)
        {
            this.driver = driver;
            this.url = WebUrl.DragAndDrop;
        }

        public void MoveImageToTrash(string imageName)
        {
            By image = GetGalleryImageLocator(imageName);
            driver.DragAndDrop(image, trashBox);
        }

        public void MoveImageFromTrashOut(string imageName)
        {
            By image = GetTrashImageLocator(imageName);
            driver.DragAndDrop(image, gallery);
        }

        public void VerifyImageIsDisplayedInTrash(string imageName)
        {
            By image = GetTrashImageLocator(imageName);
            var isDisplayed = driver.WaitUtil(image).Displayed;

            Assert.IsTrue(isDisplayed);
        }

        public void VerifyImagesIsDisplayedInGallery(string imageName)
        {
            By image = GetGalleryImageLocator(imageName);
            var isDisplayed = driver.WaitUtil(image).Displayed;

            Assert.IsTrue(isDisplayed);
        }
    }
}
