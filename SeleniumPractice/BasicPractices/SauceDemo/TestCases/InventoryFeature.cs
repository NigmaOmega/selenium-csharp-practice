using NUnit.Framework;
using SeleniumPractice.SauceDemo.PageObjectModels;

namespace SeleniumPractice.SauceDemo.TestCases
{
    class InventoryFeature : SauceDemoBaseTest
    {
        string productName = "Sauce Labs Fleece Jacket";

        [SetUp]
        public void SetUp()
        {
            LoginPage
                .Init(driver)
                .GoTo()
                .Login(WebConstants.UserName, WebConstants.Password);

        }

        [Test]
        public void AccessInventoryPage_Successfully()
        {
            InventoryPage
                .Init(driver)
                .GoTo()
                .VerifyThisPageIsVisible();
        }

        [Test]
        public void DisplayValidInventoryItems_Successfully()
        {
            int numberOfInventoryItems = 6;
            InventoryPage
              .Init(driver)
              .GoTo()
              .VerifyHaveInventoryItem(numberOfInventoryItems)
              .VerifyHaveValidInventoryItemInformation();
        }

        [Test]
        public void SortProducByNameAToZ_Successfully()
        {
            InventoryPage
                .Init(driver)
                .GoTo()
                .SortProductsByNameAToZ()
                .VerifyItemsIsSortByNameAToZ();
        }

        [Test]
        public void SortProducByNameZToA_Successfully()
        {
            InventoryPage
               .Init(driver)
               .GoTo()
               .SortProductsByNameZToA()
               .VerifyItemsIsSortByNameZToA();
        }


        [Test]
        public void SortProducByPriceLowToHigh_Successfully()
        {
            InventoryPage
               .Init(driver)
               .GoTo()
               .SortProductsByPriceLowToHigh()
               .VerifyItemsIsSortByPriceLowToHigh();
        }

        [Test]
        public void SortProducByPriceHighToLow_Successfully()
        {
            InventoryPage
                .Init(driver)
                .GoTo()
                .SortProductsByPriceHighToLow()
                .VerifyItemsIsSortByPriceHighToLow();
        }

        [Test]
        public void AddProductToCart_Successfully()
        {
            InventoryPage
                .Init(driver)
                .GoTo()
                .AddToCartByName(productName)
                .VerifyTheItemIsAddedToCard(productName)
                //Clean Data
                .RemoveFromCartByName(productName);
        }

        [Test]
        public void RemoveProductFromCart_Successfully()
        {
            InventoryPage
                .Init(driver)
                .GoTo()
                .AddToCartByName(productName)
                .RemoveFromCartByName(productName)
                .VerifyTheItemIsRemovedFromCard(productName);
        }
    }
}