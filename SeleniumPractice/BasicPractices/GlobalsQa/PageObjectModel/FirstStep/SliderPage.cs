using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumPractice.GlobalsQa;

namespace SeleniumPractice.BasicPractices.GlobalsQa.PageObjectModel.FirstStep
{
    class SliderPage : BasePage
    {
        readonly By redSlider = By.XPath("//*[@id='red']/span");
        readonly By greenSlider = By.XPath("//*[@id='green']/span");
        readonly By blueSlider = By.XPath("//*[@id='blue']/span");
        readonly By resultColorSquare = By.Id("swatch");
        public SliderPage(IWebDriver driver)
        {
            this.driver = driver;
            this.url = WebUrl.Slider;
        }

        public void MoveRedSlider(int pixel)
        {
            driver.DragAndDropBy(redSlider, pixel, 0);
        }

        public void MoveGreenSlider(int pixel)
        {
            driver.DragAndDropBy(greenSlider, pixel, 0);
        }

        public void MoveBlueSlider(int pixel)
        {
            driver.DragAndDropBy(blueSlider, pixel, 0);
        }

        public string GetResultColor()
        {
            return driver.WaitUtil(resultColorSquare).GetAttribute("style");
        }

        public void VerifyResultColor(string r, string g, string b)
        {
            var currentColor = GetResultColor();
            string expectedColor = "background-color: rgb(" + r + ", " + g + ", " + b + ");";
            Assert.AreEqual(expectedColor, currentColor);
        }
    }
}
