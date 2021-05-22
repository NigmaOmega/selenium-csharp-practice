using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumPractice.SeleniumEasy.PageObjectModel
{
    class DynamicDataLoadingPage : BasePage
    {
        readonly By getNewUserBtn = By.Id("save");
        readonly By userImage = By.XPath("//*[@id='loading']/img");
        readonly By userInfoTxt = By.XPath("//*[@id='loading']");
        readonly By loadingStatus = By.XPath("//*[contains(text(),' loading...')]");
        public DynamicDataLoadingPage(IWebDriver driver)
        {
            this.driver = driver;
            this.pageUrl = WebUrl.DynamicDataLoading;
        }

        public void GetNewUser()
        {
            driver.WaitUtil(getNewUserBtn).Click();
        }

        public void VerifyLoadingStatusIsShown()
        {
            var isDisplayed = driver.WaitUtil(loadingStatus).Displayed;

            Assert.IsTrue(isDisplayed);
        }

        public void WaitForGetNewUser()
        {
            driver.WaitForNotExist(loadingStatus, new System.TimeSpan(0, 1, 0));
        }

        public void VerifyUserInformationIsShowm()
        {
            var imageSrc = driver.WaitUtil(userImage).GetAttribute("src");

            Assert.That(imageSrc, Does.Contain("https://randomuser.me/api/portraits"));

            var userInfo = driver.WaitUtil(userInfoTxt).Text;

            Assert.That(userInfo, Does.Contain("First Name :"));
            Assert.That(userInfo, Does.Contain("Last Name :"));
        }
    }
}
