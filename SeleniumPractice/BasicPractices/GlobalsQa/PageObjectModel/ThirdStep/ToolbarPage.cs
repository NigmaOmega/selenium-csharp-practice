using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumPractice.GlobalsQa;
using System.Linq;

namespace SeleniumPractice.BasicPractices.GlobalsQa.PageObjectModel.ThirdStep
{
    class ToolbarPage : BasePage
    {
        readonly By runLastOptionsBtn = By.XPath("//button[text()='Run last option']");
        readonly By openGroupItemsBtn = By.Id("ui-id-1-button");
        readonly By optionsItemsBtn = By.XPath("//*[@id='ui-id-1-menu']/li/div");
        readonly By outputItems = By.XPath("//*[@class='output']/li");

        public ToolbarPage(IWebDriver driver)
        {
            this.driver = driver;
            this.url = WebUrl.Toolbar;
        }

        public void RunLastOptions()
        {
            driver.WaitUtil(runLastOptionsBtn).Click();
        }

        public void SelectOptionItem(string itemText)
        {
            driver.WaitUtil(openGroupItemsBtn).Click();
            driver.WaitUtil(optionsItemsBtn);
            driver.FindElements(optionsItemsBtn).First(s => s.Text == itemText).Click();
        }

        public void VerifyOutputIsShown(string expectedText)
        {
            driver.WaitUtil(outputItems);
            var outputs = driver.FindElements(outputItems).Select(s => s.Text);

            Assert.That(outputs, Does.Contain(expectedText));
        }
    }
}
