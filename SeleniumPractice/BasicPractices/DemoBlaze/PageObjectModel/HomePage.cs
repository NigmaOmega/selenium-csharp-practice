using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumPractice.DemoBlaze.Model;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumPractice.DemoBlaze.PageObjectModel
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        By homePageIcon = By.XPath("//*[@id='nava']/img");
        By cardBlock = By.XPath("//*[contains(@class,'card h-100')]");
        By cardsTitleTxt = By.XPath("//h4[@class='card-title']/a");
        By cardsPrice = By.XPath("//div[@class ='card-block')]/h5");
        By cardsText = By.XPath("//p[@class = 'card-text')]");

        public HomePage GoTo()
        {
            driver.Navigate().GoToUrl(WebUrl.HomePage);
            driver.WaitForPageLoad();

            return this;
        }

        public HomePage VerifyMessageIsShown(string expectedMessage)
        {
            var message = GetAlertMessageAndAccept();
            Assert.AreEqual(expectedMessage, message);
            return this;
        }

        public HomePage SelectCategory(string categoryName)
        {
            By categoryBtn = By.XPath("//div[@class='list-group']/a[text()='" + categoryName + "']");

            driver.WaitUtil(categoryBtn).Click();
            driver.WaitForPageLoad();
            return this;
        }

        public HomePage VerifyProductIsDisplayed(Product expectedProduct)
        {
            var product = GetProductInformationByProductName(expectedProduct.Name);

            Assert.AreEqual(expectedProduct.Name, product.Name);
            Assert.AreEqual(expectedProduct.Description, product.Description);
            Assert.AreEqual(expectedProduct.Price, product.Price);
            return this;
        }


        public List<string> GetListDisplayedProductName()
        {
            List<string> result = new List<string>();
            driver.WaitUtil(cardsTitleTxt);
            result = driver.FindElements(cardsTitleTxt).Select(s => s.Text).ToList();

            return result;
        }

        public Product GetProductInformationByProductName(string productName)
        {
            Product result;
            By priceByProductNameTxt = By.XPath("//a[text()='" + productName + "']/../../h5");
            By desByProductNameTxt = By.XPath("//a[text()='" + productName + "']/../../p");

            string price = driver.WaitUtil(priceByProductNameTxt).Text;
            string description = driver.WaitUtil(desByProductNameTxt).Text;
            result = new Product(productName, price, description, null);

            return result;

        }

        public ProductDetailsPage GoToProductDetails(Product product)
        {
            By cardTitle = By.XPath("//a[text()='" + product.Name + "']");
            driver.WaitUtil(cardTitle).Click();

            return new ProductDetailsPage(driver);
        }
    }
}