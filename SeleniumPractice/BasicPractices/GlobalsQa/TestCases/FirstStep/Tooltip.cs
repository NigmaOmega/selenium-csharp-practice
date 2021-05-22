using NUnit.Framework;
using SeleniumPractice.BasicPractices.GlobalsQa.PageObjectModel.FirstStep;

namespace SeleniumPractice.BasicPractices.GlobalsQa.TestCases.FirstStep
{
    class Tooltip : BaseTest
    {
        TooltipPage tooltipPage;

        [SetUp]
        public void ClassSetUp()
        {
            tooltipPage = new TooltipPage(driver);
            tooltipPage.GoTo();
        }

        [Test]
        public void TooltipIsDisplayedWhenHoverOnTitle()
        {
            tooltipPage.HoverOnTitle("Vienna, Austria");
            tooltipPage.VerifyTooltipIsShown();
        }

        [Test]
        public void TooltipIsDisplayedWhenHoverOnImage()
        {
            tooltipPage.HoverOnImage();
            tooltipPage.VerifyTooltipIsShown();
        }
    }
}
