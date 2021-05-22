using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SeleniumPractice.SauceDemo.PageObjectModels
{
    public class InventoryPage
    {
        readonly IWebDriver driver;

        readonly By titleLabel = By.ClassName("title");
        readonly By inventoryItem = By.ClassName("inventory_item");
        readonly By inventoryItem_Name = By.ClassName("inventory_item_name");
        readonly By inventoryItem_Description = By.ClassName("inventory_item_desc");
        readonly By inventoryItem_Price = By.ClassName("inventory_item_price");
        readonly By inventoryItem_AddToCardButton = By.CssSelector(".btn_primary.btn_inventory");
        readonly By productSortSelect = By.ClassName("product_sort_container");
        readonly By cartIcon = By.ClassName("shopping_cart_container");

        InventoryPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public static InventoryPage Init(IWebDriver driver)
        {
            return new InventoryPage(driver);
        }

        public InventoryPage GoTo()
        {
            driver.Navigate().GoToUrl(WebUrl.InventoryPage);

            return this;
        }

        public CartPage GoToCart()
        {
            driver.WaitUtil(cartIcon).Click();

            return CartPage.Init(driver);
        }


        public InventoryPage VerifyThisPageIsVisible()
        {
            var title = driver.WaitUtil(titleLabel).Text;
            Assert.AreEqual("PRODUCTS", title);

            return this;
        }

        public InventoryPage VerifyHaveInventoryItem(int numberOfItem)
        {
            driver.WaitUtil(inventoryItem);
            var inventories = driver.FindElements(inventoryItem).ToList();
            Assert.AreEqual(numberOfItem, inventories.Count);

            return this;
        }

        public InventoryPage VerifyHaveValidInventoryItemInformation()
        {
            driver.WaitUtil(inventoryItem);
            var inventories = driver.FindElements(inventoryItem).ToList();
            foreach (var item in inventories)
            {
                var nameText = item.FindElement(inventoryItem_Name).Text;
                var descriptionText = item.FindElement(inventoryItem_Description).Text;
                var priceText = item.FindElement(inventoryItem_Price).Text;
                var buttontext = item.FindElement(inventoryItem_AddToCardButton).Text;
                var expectedButtonText = "ADD TO CART";

                Assert.IsNotEmpty(nameText);
                Assert.IsNotEmpty(descriptionText);
                Assert.IsNotEmpty(priceText);
                Assert.That(priceText, Does.Contain("$"));
                Assert.AreEqual(expectedButtonText, buttontext);
            }

            return this;
        }

        public InventoryPage SortProductsByNameAToZ()
        {
            string optionValue = "az";
            return SortProductBy(optionValue);
        }

        public InventoryPage SortProductsByNameZToA()
        {
            string optionValue = "za";
            return SortProductBy(optionValue);
        }

        public InventoryPage SortProductsByPriceLowToHigh()
        {
            string optionValue = "lohi";
            return SortProductBy(optionValue);
        }
        public InventoryPage SortProductsByPriceHighToLow()
        {
            string optionValue = "hilo";
            return SortProductBy(optionValue);
        }

        public InventoryPage SortProductBy(string value)
        {
            var selectElement = new SelectElement(driver.WaitUtil(productSortSelect));
            selectElement.SelectByValue(value);
            return this;
        }

        public InventoryPage VerifyItemsIsSortByNameZToA()
        {
            List<string> inventoryItemsName = driver.FindElements(inventoryItem_Name).ToList().Select(s => s.Text).ToList();
            List<string> sortedItem = new List<string>(inventoryItemsName);
            sortedItem.OrderByDescending(s => s);

            Assert.AreEqual(inventoryItemsName, sortedItem);

            return this;
        }

        public InventoryPage VerifyItemsIsSortByNameAToZ()
        {
            List<string> inventoryItemsName = driver.FindElements(inventoryItem_Name).ToList().Select(s => s.Text).ToList();
            var sortedItem = inventoryItemsName.OrderBy(s => s).ToList();

            Assert.AreEqual(inventoryItemsName, sortedItem);

            return this;
        }

        public InventoryPage VerifyItemsIsSortByPriceHighToLow()
        {
            List<double> inventoryItemsPrice = driver.FindElements(inventoryItem_Price).ToList().Select(s => Convert.ToDouble(s.Text.Replace("$", ""))).ToList();
            var sortedItem = inventoryItemsPrice.OrderByDescending(s => s).ToList();

            Assert.AreEqual(inventoryItemsPrice, sortedItem);

            return this;
        }

        public InventoryPage VerifyItemsIsSortByPriceLowToHigh()
        {
            List<double> inventoryItemsPrice = driver.FindElements(inventoryItem_Price).ToList().Select(s => Convert.ToDouble(s.Text.Replace("$", ""))).ToList();

            var sortedItem = inventoryItemsPrice.OrderBy(s => s).ToList();

            Assert.AreEqual(inventoryItemsPrice, sortedItem);

            return this;
        }


        public InventoryItemPage AccessInventoryDetails(string inventoryItemName)
        {
            GetInvenrotyItemTitleByName(inventoryItemName).Click();

            return InventoryItemPage.Init(driver);
        }

        public InventoryPage AddToCartByName(string inventoryItemName)
        {
            var element = GetAddOrRemoveFromCartButtonByName(inventoryItemName);
            var text = element.Text;
            if (text.Equals("ADD TO CART"))
            {
                element.Click();
            }
            else
            {
                throw new Exception(inventoryItemName + " item is already added to cart!!!");
            }

            return this;
        }

        public InventoryPage RemoveFromCartByName(string inventoryItemName)
        {
            var element = GetAddOrRemoveFromCartButtonByName(inventoryItemName);

            if (element.Text.Equals("REMOVE"))
            {
                element.Click();
            }
            else
            {
                throw new Exception("The item is not added in cart!!!");
            }

            return this;
        }

        public InventoryPage VerifyTheItemIsAddedToCard(string inventoryItemName)
        {
            var element = GetAddOrRemoveFromCartButtonByName(inventoryItemName);
            Assert.AreEqual("REMOVE", element.Text);

            return this;
        }

        public InventoryPage VerifyTheItemIsRemovedFromCard(string inventoryItemName)
        {
            var element = GetAddOrRemoveFromCartButtonByName(inventoryItemName);
            Assert.AreEqual("ADD TO CART", element.Text);

            return this;
        }

        private IWebElement GetAddOrRemoveFromCartButtonByName(string inventoryItemName)
        {
            By inventoryItemButton = By.XPath("//*[text()='" + inventoryItemName + "']/../../..//button");

            return driver.WaitUtil(inventoryItemButton);
        }

        private IWebElement GetInvenrotyItemTitleByName(string inventoryItemName)
        {
            By inventoryItem = By.XPath("//*[text()='" + inventoryItemName + "']");

            return driver.WaitUtil(inventoryItem);
        }




    }
}
