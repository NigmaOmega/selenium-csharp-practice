using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumPractice.DemoBlaze.Model;

namespace SeleniumPractice.DemoBlaze.PageObjectModel
{
    public class ProductDetailsPage : BasePage
    {
        By addToCartBtn = By.XPath("//a[text()='Add to cart']");
        By productNameTxt = By.XPath("//div[@id='tbodyid']/h2");
        By descriptionTxt = By.XPath("//div[@id='more-information']/p");
        By priceTxt = By.XPath("//h3[@class='price-container']");

        public ProductDetailsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public ProductDetailsPage AddToCart()
        {
            driver.WaitUtil(addToCartBtn).Click();

            driver.WaitForAlert().Accept();

            return this;
        }

        public ProductDetailsPage VerifyProductDetailsIsShownCorrectly(Product product)
        {
            string name = driver.WaitUtil(productNameTxt).Text;
            string description = driver.WaitUtil(descriptionTxt).Text;
            string price = driver.WaitUtil(priceTxt).Text;

            Assert.AreEqual(product.Name, name);
            Assert.AreEqual(product.Description, description);
            Assert.That(price, Does.Contain(product.Price));

            return this;
        }

    }
}