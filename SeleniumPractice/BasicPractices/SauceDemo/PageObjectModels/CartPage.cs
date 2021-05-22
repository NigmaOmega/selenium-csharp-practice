using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace SeleniumPractice.SauceDemo.PageObjectModels
{
    public class CartPage
    {
        IWebDriver driver;

        By continueShoppingButton = By.Id("continue-shopping");
        By checkoutButton = By.Id("checkout");
        By subHeaderTextBox = By.XPath("//*[@class='title']");

        CartPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public static CartPage Init(IWebDriver driver)
        {
            return new CartPage(driver);
        }

        public CartPage GoTo()
        {
            driver.Navigate().GoToUrl(WebUrl.CartPage);

            return this;
        }

        public InventoryPage ContinueShopping()
        {
            driver.WaitUtil(continueShoppingButton).Click();

            return InventoryPage.Init(driver);
        }

        public CartPage RemoveItemByName(string itemName)
        {
            var removeButton = By.XPath("//*[text()='" + itemName + "']/../..//button");
            driver.WaitUtil(removeButton).Click();

            return this;
        }

        public CartPage VerifyItemIsRemoved(string itemName)
        {
            var itemTitle = By.XPath("//*[text()='" + itemName + "']");
            driver.Sleep(1000);
            var elements = driver.FindElements(itemTitle).ToList();

            Assert.AreEqual(0, elements.Count);

            return this;
        }

        public CartPage VerifyItemIsAddedInTheCart(string itemName)
        {
            var itemTitle = By.XPath("//*[text()='" + itemName + "']");
            var element = driver.WaitUtil(itemTitle);

            Assert.IsNotNull(element);

            return this;
        }

        public CheckOutStepOnePage Checkout()
        {
            Thread.Sleep(1000);
            driver.WaitUtil(checkoutButton).Click();

            return CheckOutStepOnePage.Init(driver);
        }

        public CartPage VerifyPageIsDisplayed()
        {
            var subHeader = driver.WaitUtil(subHeaderTextBox).Text;
            Assert.AreEqual("YOUR CART", subHeader);

            return this;
        }

    }
}