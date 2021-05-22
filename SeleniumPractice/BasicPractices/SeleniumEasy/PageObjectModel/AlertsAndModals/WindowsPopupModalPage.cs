using NUnit.Framework;
using OpenQA.Selenium;
using System.Linq;

namespace SeleniumPractice.SeleniumEasy.PageObjectModel
{
    class WindowsPopupModalPage : BasePage
    {
        readonly By followOnTwitterBtn = By.XPath("//*[text()='  Follow On Twitter ']");
        readonly By likeUsOnFacebookBtn = By.XPath("//*[text()='  Like us On Facebook ']");
        readonly By followTwitterAndFacebookBtn = By.XPath("//*[text()='Follow Twitter & Facebook']");
        readonly By followAllBtn = By.Id("followall");

        readonly string expectedTwitterUrl = "https://twitter.com/intent/follow?screen_name=seleniumeasy";
        readonly string expectedFacebookUrl = "https://www.facebook.com/seleniumeasy";
        readonly string expectedGoogleUrl = "https://accounts.google.com/";
        public WindowsPopupModalPage(IWebDriver driver)
        {
            this.driver = driver;
            this.pageUrl = WebUrl.WindowsPopupModal;
        }


        public void FollowOnTwitter()
        {
            driver.WaitUtil(followOnTwitterBtn).Click();
        }

        public void LikeOnFacebook()
        {
            driver.WaitUtil(likeUsOnFacebookBtn).Click();
        }

        public void FollowOnTwitterAndFacebook()
        {
            driver.WaitUtil(followTwitterAndFacebookBtn).Click();
        }

        public void FollowAll()
        {
            driver.WaitUtil(followAllBtn).Click();
        }

        public void VerifyTwiterPageIsShown()
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            string currentUrl = driver.Url;

            Assert.AreEqual(expectedTwitterUrl, currentUrl);
        }

        public void VerifyFacebookPageIsShown()
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            string currentUrl = driver.Url;

            Assert.AreEqual(expectedFacebookUrl, currentUrl);
        }

        public void VerifyTwiterAndFacebookPagesAreShown()
        {

            driver.SwitchTo().Window(driver.WindowHandles.Last());
            string currentUrl = driver.Url;
            Assert.AreEqual(expectedTwitterUrl, currentUrl);

            driver.SwitchTo().Window(driver.WindowHandles.ElementAt(driver.WindowHandles.Count - 2));
            currentUrl = driver.Url;
            Assert.AreEqual(expectedFacebookUrl, currentUrl);
        }

        public void VerifyFacebookAndTwitterAndGooglePlusPagesAreShown()
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            string currentUrl = driver.Url;
            Assert.AreEqual(expectedFacebookUrl, currentUrl);

            driver.SwitchTo().Window(driver.WindowHandles.ElementAt(driver.WindowHandles.Count - 2));
            currentUrl = driver.Url;
            Assert.AreEqual(expectedTwitterUrl, currentUrl);

            driver.SwitchTo().Window(driver.WindowHandles.ElementAt(driver.WindowHandles.Count - 3));
            currentUrl = driver.Url;
            Assert.That(currentUrl, Does.Contain(expectedGoogleUrl));
        }
    }
}
