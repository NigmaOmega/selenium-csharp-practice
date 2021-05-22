using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumPractice.Commons.Selenium
{
    public class Checkbox
    {
        readonly List<IWebElement> options;
        public Checkbox(IWebDriver driver, By checkboxOptions)
        {
            options = driver.FindElements(checkboxOptions).ToList();
        }

        public void ByValues(List<string> values)
        {
            var optionsToSelect = options.Where(s => values.Contains(s.GetAttribute("value"))).ToList();
            foreach (var option in optionsToSelect)
            {
                option.Click();
            }
        }

        public List<IWebElement> GetCheckedOptions()
        {
            return options.Where(s => s.Selected).ToList();
        }
    }
}
