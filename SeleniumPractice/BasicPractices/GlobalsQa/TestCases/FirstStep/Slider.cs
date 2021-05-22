using NUnit.Framework;
using SeleniumPractice.BasicPractices.GlobalsQa.PageObjectModel.FirstStep;

namespace SeleniumPractice.BasicPractices.GlobalsQa.TestCases.FirstStep
{
    class Slider : BaseTest
    {
        SliderPage sliderPage;

        [SetUp]
        public void ClassSetUp()
        {
            sliderPage = new SliderPage(driver);
            sliderPage.GoTo();
        }

        [Test]
        public void MoveSliders_ColorChanged()
        {
            sliderPage.MoveRedSlider(-40);
            sliderPage.MoveGreenSlider(-20);
            sliderPage.MoveBlueSlider(50);
            sliderPage.VerifyResultColor("221", "123", "103");
        }
    }
}
