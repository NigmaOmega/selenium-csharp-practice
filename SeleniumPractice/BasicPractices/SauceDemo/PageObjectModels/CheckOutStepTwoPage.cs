using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumPractice.SauceDemo.PageObjectModels
{
    public class CheckOutStepTwoPage
    {
        IWebDriver driver;

        By subHeaderTextBox = By.ClassName("title");
        By inventoryItemName = By.ClassName("inventory_item_name");
        By subtotalTextBox = By.ClassName("summary_subtotal_label");
        By taxTextBox = By.ClassName("summary_tax_label");
        By totalTextBox = By.ClassName("summary_total_label");
        By finishButton = By.Id("finish");
        By cancelButton = By.Id("cancel");

        CheckOutStepTwoPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public static CheckOutStepTwoPage Init(IWebDriver driver)
        {
            return new CheckOutStepTwoPage(driver);
        }

        public CheckOutStepTwoPage VerifyCheckOutStepTwoPageIsDisplayedSuccessfully()
        {
            var subHeader = driver.WaitUtil(subHeaderTextBox).Text;

            Assert.AreEqual("CHECKOUT: OVERVIEW", subHeader);

            return this;
        }

        public CheckOutStepTwoPage VerifyInformationIsShownSuccessfully(List<string> inventoryitems, string itemTotalFee, string taxFee, string totalFee)
        {
            foreach (var item in inventoryitems)
            {
                VerifyInventoryItemIsDisplay(item);
            }

            var subTotal = driver.WaitUtil(subtotalTextBox).Text;
            Assert.That(subTotal, Does.Contain(itemTotalFee));

            var tax = driver.WaitUtil(taxTextBox).Text;
            Assert.That(tax, Does.Contain(taxFee));

            var total = driver.WaitUtil(totalTextBox).Text;
            Assert.That(total, Does.Contain(totalFee));

            return this;
        }

        public CheckOutCompletePage Finish()
        {
            driver.WaitUtil(finishButton).Click();

            return CheckOutCompletePage.Init(driver);
        }

        public InventoryPage Cancel()
        {
            driver.WaitUtil(cancelButton).Click();

            return InventoryPage.Init(driver);
        }

        private CheckOutStepTwoPage VerifyInventoryItemIsDisplay(string inventoryItem)
        {
            driver.WaitUtil(inventoryItemName);
            var items = driver.FindElements(inventoryItemName).Select(s => s.Text).ToList();

            Assert.Contains(inventoryItem, items);

            return this;
        }
    }
}