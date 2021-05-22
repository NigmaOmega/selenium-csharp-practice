using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumPractice.Commons.Selenium
{
    public class Radio
    {
        List<IWebElement> options;
        public Radio(IWebDriver driver, By radioOptions)
        {
            options = driver.FindElements(radioOptions).ToList();
        }

        public void ByValue(string value)
        {
            options.First(s => s.GetAttribute("value") == value).Click();
        }
        public IWebElement GetSelectedOption()
        {
            return options.First(s => s.Selected);
        }
    }
}
