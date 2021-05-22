using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Linq;

namespace SeleniumPractice.SeleniumEasy.PageObjectModel
{
    class DragAndDropSliderPage : BasePage
    {
        readonly By firstSlider = By.XPath("//*[@id='slider1']/div/input");
        readonly By firstSliderShowedValue = By.XPath("//*[@id='slider1']/div/output");

        public DragAndDropSliderPage(IWebDriver driver)
        {
            this.driver = driver;
            this.pageUrl = WebUrl.DragAndDropSlider;
        }

        public void MoveTheFirstSlideTo(int value)
        {
            MoveTheSlide(firstSlider, value);
        }

        public void VerifyFirstSliderValue(int value)
        {
            var currentValue = driver.WaitUtil(firstSliderShowedValue).Text;

            Assert.AreEqual(value.ToString(), currentValue);
        }

        private void MoveTheSlide(By slider, int value)
        {
            var element = driver.WaitUtil(slider);
            element.Click();
            var currentValue = element.GetAttribute("value").ToInt();
            var diff = value - currentValue;
            string stackKeys = "";
            if (diff > 0)
            {
                stackKeys = string.Concat(Enumerable.Repeat(Keys.ArrowRight, diff));
            }

            if (diff < 0)
            {
                stackKeys = string.Concat(Enumerable.Repeat(Keys.ArrowLeft, -diff));
            }

            element.SendKeys(stackKeys);
        }


        public static int GetPixelsToMove(IWebElement Slider, decimal Amount, decimal SliderMax, decimal SliderMin)
        {
            int pixels = 0;
            decimal tempPixels = Slider.Size.Width;
            tempPixels = tempPixels / (SliderMax - SliderMin);
            tempPixels = tempPixels * (Amount - SliderMin);
            pixels = Convert.ToInt32(tempPixels);
            return pixels;
        }
    }
}
