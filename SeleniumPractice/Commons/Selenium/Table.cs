using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumPractice.Commons
{
    public class Table
    {
        readonly IWebElement element;
        public Table(IWebDriver driver, By table)
        {
            element = driver.WaitUtil(table);
        }

        public List<List<string>> GetTableData()
        {
            var result = new List<List<string>>();
            List<IWebElement> rows = null;
            try {
                rows = element.FindElement(By.TagName("tbody")).FindElements(By.TagName("tr")).ToList();
            }
            catch {
                return result;
            }

            foreach (var row in rows)
            {
                List<string> cells = row.FindElements(By.TagName("td")).Select(s => s.Text).ToList();
                result.Add(cells);
            }

            return result;
        }

        public List<List<string>> GetTableDisplayedData()
        {
            var result = new List<List<string>>();
            var rows = element.FindElement(By.TagName("tbody")).FindElements(By.TagName("tr")).Where(s => s.Displayed).ToList();

            foreach (var row in rows)
            {
                List<string> cells = row.FindElements(By.TagName("td")).Select(s => s.Text).ToList();
                result.Add(cells);
            }

            return result;
        }
    }
}
