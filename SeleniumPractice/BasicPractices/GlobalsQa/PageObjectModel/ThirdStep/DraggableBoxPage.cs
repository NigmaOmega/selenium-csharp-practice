using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumPractice.GlobalsQa;
using System.Drawing;

namespace SeleniumPractice.BasicPractices.GlobalsQa.PageObjectModel.ThirdStep
{
    class DraggableBoxPage : BasePage
    {
        readonly By draggaglebox = By.Id("draggable");

        public DraggableBoxPage(IWebDriver driver)
        {
            this.driver = driver;
            this.url = WebUrl.DraggableBox;
        }

        public void DragTheBox(int offSetX, int offSetY)
        {
            driver.DragAndDropBy(draggaglebox, offSetX, offSetY);
        }

        public void VerifyThePositionOfTheBox(int x, int y)
        {
            var location = driver.WaitUtil(draggaglebox).Location;
            var expectedLocation = new Point(x, y);

            Assert.AreEqual(expectedLocation, location);
        }
    }
}
