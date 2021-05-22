using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumPractice.DemoBlaze.Model;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumPractice.DemoBlaze.PageObjectModel
{
    public class CartPage : BasePage
    {
        readonly By placeHolderBtn = By.XPath("//button[text()='Place Order']");
        readonly By productTable = By.Id("tbodyid");


        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public CartPage VerifyProductIsShown(List<Product> products)
        {
            products.ForEach(s => s.Category = null);
            products.ForEach(s => s.Description = null);
            var table = driver.WaitUtil(productTable);
            var rows = table.FindElements(By.TagName("tr"));
            foreach (var row in rows)
            {
                var title = row.FindElement(By.XPath("//td[2]")).Text;
                var price = "$" + row.FindElement(By.XPath("//td[3]")).Text;

                var productExpected = products.Where(s => s.Name == title).ToList()[0];
                Assert.AreEqual(productExpected.Name, title);
                Assert.AreEqual(productExpected.Price, price);
            }

            return this;
        }
    }
}