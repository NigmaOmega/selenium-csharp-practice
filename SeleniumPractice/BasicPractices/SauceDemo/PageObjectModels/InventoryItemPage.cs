using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumPractice.SauceDemo.PageObjectModels
{
    public class InventoryItemPage
    {
        IWebDriver driver;

        By inventoryItemImage = By.ClassName("inventory_details_img");
        By inventoryDetailsNameTextBox = By.ClassName("inventory_details_name");
        By inventoryDetailsDescriptionTextBox = By.ClassName("inventory_details_desc");
        By inventoryDetailsPriceTextBox = By.ClassName("inventory_details_price");
        By addToCardButton = By.XPath("//button[contains(@id,'add-to-cart')]");
        By removeButton = By.XPath("//button[contains(@id,'remove')]");
        By backButton = By.ClassName("inventory_details_back_button");

        InventoryItemPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public static InventoryItemPage Init(IWebDriver driver)
        {
            return new InventoryItemPage(driver);
        }

        public InventoryItemPage GoTo(string itemId)
        {
            var url = WebUrl.InventoryItemPage.Replace("{item_id}", itemId);
            driver.Navigate().GoToUrl(url);

            return this;
        }

        public InventoryItemPage VerifyPageDisplaysCorrectItem(string itemName)
        {
            string actualItemnName = driver.WaitUtil(inventoryDetailsNameTextBox).Text;
            Assert.AreEqual(itemName, actualItemnName);

            return this;
        }

        public InventoryItemPage VerifyPageDisplaysContentCorrectly()
        {
            var src = driver.WaitUtil(inventoryItemImage).GetAttribute("src");
            Assert.IsNotNull(src);

            var price = driver.WaitUtil(inventoryDetailsPriceTextBox).Text;
            Assert.That(price, Does.Contain("$"));
            Assert.That(price, Does.Contain("."));

            var description = driver.WaitUtil(inventoryDetailsDescriptionTextBox).Text;
            Assert.IsNotNull(description);

            return this;
        }

        public InventoryItemPage AddToCartItem()
        {
            driver.WaitUtil(addToCardButton).Click();

            return this;
        }

        public InventoryItemPage RemoveItemFromCart()
        {
            driver.WaitUtil(removeButton).Click();

            return this;
        }

        public InventoryPage BackToInventoryPage()
        {
            driver.WaitUtil(backButton).Click();

            return InventoryPage.Init(driver);
        }

        public InventoryItemPage VerifyTheItemIsAddedToCart()
        {
            var element = GetAddOrRemoveFromCartButton();
            Assert.AreEqual("REMOVE", element.Text);

            return this;
        }

        public InventoryItemPage VerifyTheItemIsRemovedFromCart()
        {
            var element = GetAddOrRemoveFromCartButton();
            Assert.AreEqual("ADD TO CART", element.Text);

            return this;
        }



        private IWebElement GetAddOrRemoveFromCartButton()
        {
            By inventoryItemButton = By.XPath("//*[@class=\"inventory_details_desc_container\"]//button");

            return driver.WaitUtil(inventoryItemButton);
        }






    }
}