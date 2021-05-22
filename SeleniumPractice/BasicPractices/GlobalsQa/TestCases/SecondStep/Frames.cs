using NUnit.Framework;
using SeleniumPractice.BasicPractices.GlobalsQa.PageObjectModel.LastStep;

namespace SeleniumPractice.BasicPractices.GlobalsQa.TestCases.SecondStep
{
    class Frames : BaseTest
    {
        FramesPage framesPage;

        [SetUp]
        public void ClassSetUp()
        {
            framesPage = new FramesPage(driver);
            framesPage.GoTo();
        }

        [Test]
        public void FrameDisplayedSuccessfully()
        {
            framesPage.SwitchToIframe();
            framesPage.VerifyFrameHeading("Trainings");
        }
    }
}
