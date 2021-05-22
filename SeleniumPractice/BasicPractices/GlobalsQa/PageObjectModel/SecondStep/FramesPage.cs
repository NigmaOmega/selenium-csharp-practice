using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumPractice.GlobalsQa;

namespace SeleniumPractice.BasicPractices.GlobalsQa.PageObjectModel.LastStep
{
    class FramesPage : BasePage
    {
        readonly By iframe = By.Name("globalSqa");
        readonly By framePageHeading = By.TagName("h1");

        public FramesPage(IWebDriver driver)
        {
            this.driver = driver;
            this.url = WebUrl.Frames;
        }

        public void SwitchToIframe()
        {
            var frame = driver.WaitUtil(iframe);
            driver.SwitchTo().Frame(frame);
        }

        public void VerifyFrameHeading(string expectedHeadingText)
        {
            var currentHeadingText = driver.WaitUtil(framePageHeading).Text;


            Assert.AreEqual(expectedHeadingText, currentHeadingText);
        }
    }
}
