using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumPractice.Commons
{
    public class Select
    {
        readonly SelectElement selectElement;
        public Select(IWebDriver driver, By dropdownList)
        {
            var element = driver.WaitUtil(dropdownList, WaitType.WaitUtilExist);
            selectElement = new SelectElement(element);
        }

        public void ByValue(string value)
        {
            selectElement.SelectByValue(value);
        }

        public void ByValue(List<string> values)
        {
            foreach (var value in values)
            {
                ByValue(value);
            }
        }

        public void ByText(string text)
        {
            selectElement.SelectByText(text);
        }

        public void ByText(List<string> textes)
        {
            foreach (var text in textes)
            {
                ByText(text);
            }

        }

        public void ByIndex(int index)
        {
            selectElement.SelectByIndex(index);
        }

        public void ByIndex(List<int> indexes)
        {
            foreach (var index in indexes)
            {
                ByIndex(index);
            }
        }

        public List<IWebElement> GetSelected()
        {
            return selectElement.AllSelectedOptions.ToList();
        }
    }
}
