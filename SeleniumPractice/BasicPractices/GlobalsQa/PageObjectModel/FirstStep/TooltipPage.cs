using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumPractice.GlobalsQa;

namespace SeleniumPractice.BasicPractices.GlobalsQa.PageObjectModel.FirstStep
{
    class TooltipPage : BasePage
    {
        readonly By images = By.XPath("//a/img");


        public TooltipPage(IWebDriver driver)
        {
            this.driver = driver;
            this.url = WebUrl.Tooltip;
        }

        private By GetTitleLocator(string titleText)
        {
            return By.XPath("//h3/a[text()='" + titleText + "']");
        }

        public void HoverOnTitle(string titleText)
        {
            var titleTxt = GetTitleLocator(titleText);
            driver.Hover(titleTxt);
        }

        public void HoverOnImage()
        {
            driver.Hover(images);
        }



        public void VerifyTooltipIsShown()
        {
            var tooltip = driver.WaitUtil(By.XPath("//div[@role='tooltip']"));
            var isDisplayed = tooltip.Displayed;

            Assert.IsTrue(isDisplayed);
        }
    }
}
