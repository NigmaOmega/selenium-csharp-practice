using NUnit.Framework;
using SeleniumPractice.SeleniumEasy.PageObjectModel;

namespace SeleniumPractice.SeleniumEasy.TestCases
{
    class DragAndDropSlider : BaseTest
    {
        DragAndDropSliderPage dragAndDropSlider;

        [SetUp]
        public void ClassSetUp()
        {
            dragAndDropSlider = new DragAndDropSliderPage(driver);
            dragAndDropSlider.GoTo();
        }


        [Test]
        public void DragAndDropSlider_Successfully()
        {
            int targetValue = 70;
            dragAndDropSlider.MoveTheFirstSlideTo(targetValue);
            dragAndDropSlider.VerifyFirstSliderValue(targetValue);
        }
    }
}
