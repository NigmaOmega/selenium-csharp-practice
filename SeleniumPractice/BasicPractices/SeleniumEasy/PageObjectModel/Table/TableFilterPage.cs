using NUnit.Framework;
using OpenQA.Selenium;
using System.Linq;

namespace SeleniumPractice.SeleniumEasy.PageObjectModel
{
    class TableFilterPage : BasePage
    {
        readonly By greenBtn = By.XPath("//button[text()='Green']");
        readonly By orangeBtn = By.XPath("//button[text()='Orange']");
        readonly By redBtn = By.XPath("//button[text()='Red']");
        readonly By allBtn = By.XPath("//button[text()='All']");
        readonly By tableRows = By.XPath("//tbody/tr");


        public TableFilterPage(IWebDriver driver)
        {
            this.driver = driver;
            this.pageUrl = WebUrl.TableFilter;
        }

        public void ClickOnGreenButton()
        {
            driver.WaitUtil(greenBtn).Click();
        }
        public void ClickOnRedButton()
        {
            driver.WaitUtil(redBtn).Click();
        }

        public void ClickOnOrangeButton()
        {
            driver.WaitUtil(orangeBtn).Click();
        }

        public void ClickOnAllButton()
        {
            driver.WaitUtil(allBtn).Click();
        }

        public void VerifyColorOfTableItem(string color)
        {
            color = "color: " + color.ToLower() + ";";
            By faceIcon = By.XPath("//i[contains(@class,'media-photo')]");
            driver.WaitUtil(faceIcon, WaitType.WaitUtilExist);
            var items = driver.FindElements(faceIcon).Where(s => s.Displayed).Select(s => s.GetAttribute("style"));

            Assert.That(items, Does.Contain(color));
        }

        public void VerifyTableItems(int numberOfItem)
        {
            driver.WaitUtil(tableRows, WaitType.WaitUtilExist);
            var currentNumberOfRow = driver.FindElements(tableRows).Where(s => s.Displayed).ToList().Count;

            Assert.AreEqual(numberOfItem, currentNumberOfRow);
        }
    }
}
