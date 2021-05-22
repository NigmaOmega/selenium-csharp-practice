using NUnit.Framework;
using SeleniumPractice.SauceDemo.PageObjectModels;

namespace SeleniumPractice.SauceDemo.TestCases
{
    class InventoryItemFeature : SauceDemoBaseTest
    {
        string productName = "Test.allTheThings() T-Shirt (Red)";
        InventoryItemPage inventoryItemPage;
        [SetUp]
        public void SetUp()
        {
            LoginPage
                .Init(driver)
                .GoTo()
                .Login(WebConstants.UserName, WebConstants.Password);

            inventoryItemPage = InventoryPage
                .Init(driver)
                .GoTo()
                .AccessInventoryDetails(productName);
        }

        [Test]
        public void AccessInventoryItem_Successfully()
        {
            inventoryItemPage
                .VerifyPageDisplaysCorrectItem(productName)
                .VerifyPageDisplaysContentCorrectly();
        }

        [Test]
        public void AddToCartItem_Successfully()
        {
            inventoryItemPage
                .AddToCartItem()
                .VerifyTheItemIsAddedToCart()
                //Clean Data
                .RemoveItemFromCart();
        }

        [Test]
        public void RemoveItemFromCart_Successfully()
        {
            inventoryItemPage
                .AddToCartItem()
                .RemoveItemFromCart()
                .VerifyTheItemIsRemovedFromCart();
        }

        [Test]
        public void BackToInventoryPage_Successfully()
        {
            inventoryItemPage
                .BackToInventoryPage()
                //InventoryPage Here
                .VerifyThisPageIsVisible();
        }

    }
}