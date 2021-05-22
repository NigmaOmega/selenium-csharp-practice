using NUnit.Framework;
using OpenQA.Selenium;
using System.Linq;

namespace SeleniumPractice.SeleniumEasy.PageObjectModel
{
    class DragAndDropPage : BasePage
    {
        readonly By dropHereArea = By.XPath("//*[@id='mydropzone']");
        readonly By itemsToDrag = By.XPath("//*[@id=\"todrag\"]/span[1]");
        readonly By itemsDropped = By.XPath("//*[@id='droppedlist']/span");

        public DragAndDropPage(IWebDriver driver)
        {
            this.driver = driver;
            this.pageUrl = WebUrl.DragAndDrop;
        }

        public IWebElement GetItemToDragByText(string itemName)
        {
            driver.WaitUtil(itemsToDrag);
            return driver.FindElements(itemsToDrag).FirstOrDefault(s => s.Text == itemName);
        }

        public void DragAndDropItem(string dragItemText)
        {
            var dropedArea = driver.WaitUtil(dropHereArea, WaitType.WaitUtilClickable);
            driver.JsExecute("function simulate(f,c,d,e){var b,a=null;for(b in eventMatchers)if(eventMatchers[b].test(c)){a=b;break}if(!a)return!1;document.createEvent?(b=document.createEvent(a),a==\"HTMLEvents\"?b.initEvent(c,!0,!0):b.initMouseEvent(c,!0,!0,document.defaultView,0,d,e,d,e,!1,!1,!1,!1,0,null),f.dispatchEvent(b)):(a=document.createEventObject(),a.detail=0,a.screenX=d,a.screenY=e,a.clientX=d,a.clientY=e,a.ctrlKey=!1,a.altKey=!1,a.shiftKey=!1,a.metaKey=!1,a.button=1,f.fireEvent(\"on\"+c,a));return!0} var eventMatchers={HTMLEvents:/^(?:load|unload|abort|error|select|change|submit|reset|focus|blur|resize|scroll)$/,MouseEvents:/^(?:click|dblclick|mouse(?:down|up|over|move|out))$/}; " +
                                "simulate(arguments[0],\"mousedown\",0,0); simulate(arguments[0],\"mousemove\",arguments[1],arguments[2]); simulate(arguments[0],\"mouseup\",arguments[1],arguments[2]); ",
                                itemsToDrag, dropedArea.Location.X, dropedArea.Location.Y);
        }

        public void VerifyDroppedItemsListIsDisplayed(string itemName)
        {
            driver.WaitUtil(itemsDropped);
            var count = driver.FindElements(itemsDropped).Where(s => s.Text == itemName).ToList().Count;

            Assert.Greater(count, 0);
        }

        public void VerifyDroppedItemsListIsNotDisplayed(string itemName)
        {
            driver.WaitUtil(itemsDropped);
            var count = driver.FindElements(itemsDropped).Where(s => s.Text == itemName).ToList().Count;

            Assert.AreEqual(0, count);
        }
    }
}
