using NUnit.Framework;
using SeleniumPractice.SauceDemo.PageObjectModels;

namespace SeleniumPractice.SauceDemo.TestCases
{
    public class CartFeature : SauceDemoBaseTest
    {

        string productName = "Sauce Labs Bike Light";

        [SetUp]
        public void SetUp()
        {
            LoginPage
                .Init(driver)
                .GoTo()
                .Login(WebConstants.UserName, WebConstants.Password);

        }

        [Test]
        public void AccessToCart_Successfully()
        {
            CartPage
                .Init(driver)
                .GoTo()
                .VerifyPageIsDisplayed();
        }

        [Test]
        public void AddItemIntoCart_Successfully()
        {
            InventoryPage
                .Init(driver)
                .GoTo()
                .AddToCartByName(productName)
                .GoToCart()
                //CartPage
                .VerifyItemIsAddedInTheCart(productName)
                //Clean Data
                .RemoveItemByName(productName);

        }

        [Test]
        public void RemovetemFromCart_Successfully()
        {
            InventoryPage
                .Init(driver)
                .GoTo()
                .AddToCartByName(productName)
                .GoToCart()
                //CartPage
                .RemoveItemByName(productName)
                .VerifyItemIsRemoved(productName);
        }

        [Test]
        public void ContinueShopping_Successfully()
        {
            CartPage
                .Init(driver)
                .GoTo()
                .ContinueShopping()
                //InventoryPage
                .VerifyThisPageIsVisible();
        }

        [Test]
        public void Checkout_Successfully()
        {
            CartPage
                .Init(driver)
                .GoTo()
                .Checkout()
                //checkout-step-one
                .VerifyCheckOutStepOnePageIsDisplayedSuccessfully();
        }

    }
}