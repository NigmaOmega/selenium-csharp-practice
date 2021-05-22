using NUnit.Framework;
using SeleniumPractice.SauceDemo.PageObjectModels;
using System.Collections.Generic;

namespace SeleniumPractice.SauceDemo.TestCases
{
    public class CheckOutFeature : SauceDemoBaseTest
    {
        string productName = "Sauce Labs Backpack";

        [SetUp]
        public void SetUp()
        {
            LoginPage
                .Init(driver)
                .GoTo()
                .Login(WebConstants.UserName, WebConstants.Password);
        }

        [Test]
        public void OrderItem_Successfully()
        {
            string firstName = "firstName";
            string lastName = "lastName";
            string portalCode = "portalCode";
            List<string> items = new List<string>();
            items.Add(productName);

            InventoryPage
                .Init(driver)
                .GoTo()
                .AddToCartByName(productName)
                .GoToCart()
                //Cart page
                .Checkout()
                .FillDataAndContinue(firstName, lastName, portalCode)
                //Step two page
                .VerifyCheckOutStepTwoPageIsDisplayedSuccessfully()
                .VerifyInformationIsShownSuccessfully(items, "$29.99", "$2.40", "$32.39")
                .Finish()
                //Complete page
                .VerifyCompletePageIsDisplayedSuccessfully()
                .VerifyItemsIsOrderdSuccessfully();
        }

        [Test]
        public void CancelItemInStepOneCheckOut_Successfully()
        {
            List<string> items = new List<string>();
            items.Add(productName);

            InventoryPage
                .Init(driver)
                .GoTo()
                .AddToCartByName(productName)
                .GoToCart()
                //Cart page
                .Checkout()
                .Cancel()
                .VerifyPageIsDisplayed()
                //Clean up data
                .ContinueShopping()
                .RemoveFromCartByName(productName);
        }

        [Test]
        public void CancelItemInStepTwoCheckOut_Successfully()
        {
            string firstName = "firstName";
            string lastName = "lastName";
            string portalCode = "portalCode";
            List<string> items = new List<string>();
            items.Add(productName);

            InventoryPage
                .Init(driver)
                .GoTo()
                .AddToCartByName(productName)
                .GoToCart()
                //Cart page
                .Checkout()
                .FillDataAndContinue(firstName, lastName, portalCode)
                //Step two page
                .Cancel()
                .VerifyThisPageIsVisible()
                //Clean up data
                .RemoveFromCartByName(productName);
        }
    }
}