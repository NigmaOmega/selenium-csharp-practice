using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumPractice.SeleniumEasy.PageObjectModel
{
    class BootstrapListBoxPage : BasePage
    {
        readonly By selectAllListLeftCheckbox = By.XPath("//*[contains(@class,'list-left')]//*[@title='select all']");
        readonly By selectAllListRightCheckbox = By.XPath("//*[contains(@class,'list-right')]//*[@title='select all']");
        readonly By searchLeftInput = By.XPath("//*[contains(@class,'list-left')]//*[@name='SearchDualList']");
        readonly By searchRightInput = By.XPath("//*[contains(@class,'list-right')]//*[@name='SearchDualList']");
        readonly By leftItems = By.XPath("//*[contains(@class,'list-left')]//li[not(@style='display: none;')]");
        readonly By rightItems = By.XPath("//*[contains(@class,'list-right')]//li[not(@style='display: none;')]");
        readonly By moveLeftBtn = By.XPath("//*[contains(@class,'move-left')]");
        readonly By moveRightBtn = By.XPath("//*[contains(@class,'move-right')]");
        public BootstrapListBoxPage(IWebDriver driver)
        {
            this.driver = driver;
            this.pageUrl = WebUrl.BootstrapListBox;
        }

        public void CheckLeftItem(List<string> items)
        {
            driver.WaitUtil(leftItems);
            var elements = driver.FindElements(leftItems).ToList();

            foreach (var item in items)
            {
                elements.FirstOrDefault(s => s.Text == item && !s.GetAttribute("class").Equals("active")).Click();
            }

        }

        public void VerifyLeftItemsIsChecked(int numberOfItem)
        {
            var numberOfCurrentLeftItems = driver.FindElements(leftItems).Where(s => s.GetAttribute("class").Contains("active")).ToList().Count;

            Assert.AreEqual(numberOfItem, numberOfCurrentLeftItems);
        }

        public void VerifyRightItemsIsChecked(int numberOfItem)
        {
            var numberOfCurrentLeftItems = driver.FindElements(rightItems).Where(s => s.GetAttribute("class").Contains("active")).ToList().Count;

            Assert.AreEqual(numberOfItem, numberOfCurrentLeftItems);
        }

        public void UncheckLeftItem(List<string> items)
        {
            driver.WaitUtil(leftItems);
            var elements = driver.FindElements(leftItems).ToList();

            foreach (var item in items)
            {
                elements.FirstOrDefault(s => s.Text == item && s.GetAttribute("class").Equals("active")).Click();
            }

        }

        public void CheckRightItem(List<string> items)
        {
            driver.WaitUtil(rightItems);
            var elements = driver.FindElements(rightItems).ToList();

            foreach (var item in items)
            {
                elements.FirstOrDefault(s => s.Text == item && !s.GetAttribute("class").Equals("active")).Click();
            }

        }

        public void UncheckRightItem(List<string> items)
        {
            driver.WaitUtil(rightItems);
            var elements = driver.FindElements(rightItems).ToList();

            foreach (var item in items)
            {
                elements.FirstOrDefault(s => s.Text == item && s.GetAttribute("class").Equals("active")).Click();
            }
        }

        public void ClickOnCheckAllLeftItems()
        {
            driver.WaitUtil(selectAllListLeftCheckbox).Click();
        }

        public void ClickOnCheckAllRightItems()
        {
            driver.WaitUtil(selectAllListRightCheckbox).Click();
        }

        public void MoveRightItems(List<string> items)
        {
            CheckLeftItem(items);
            driver.WaitUtil(moveRightBtn).Click();
        }

        public void MoveLeftItems(List<string> items)
        {
            CheckRightItem(items);
            driver.WaitUtil(moveLeftBtn).Click();
        }

        public void MoveLeftAllItems()
        {
            ClickOnCheckAllRightItems();
            driver.WaitUtil(moveLeftBtn).Click();
        }

        public void MoveRightAllItems()
        {
            ClickOnCheckAllLeftItems();
            driver.WaitUtil(moveRightBtn).Click();
        }

        public void SearchLeft(string input)
        {
            driver.WaitUtil(searchLeftInput).SendKeys(input);
        }

        public void SearchRight(string input)
        {
            driver.WaitUtil(searchRightInput).SendKeys(input);
        }

        public void VerifyLeftItems(int numberOfItem)
        {
            driver.Sleep(1000);
            var currentNumberOfItem = driver.FindElements(leftItems).Count;

            Assert.AreEqual(numberOfItem, currentNumberOfItem);
        }

        public void VerifyRightItems(int numberOfItem)
        {
            driver.WaitUtil(rightItems);
            var currentNumberOfItem = driver.FindElements(rightItems).Count;

            Assert.AreEqual(numberOfItem, currentNumberOfItem);
        }
    }
}
