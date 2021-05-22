using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumPractice.DemoBlaze.PageObjectModel.SubPage;

namespace SeleniumPractice.DemoBlaze.PageObjectModel
{
    public class BasePage
    {
        protected IWebDriver driver;
        //  private LoginPage loginPage;

        private By loginBtn = By.Id("login2");
        private By signUpBtn = By.Id("signin2");
        private By nameOfUserNav = By.Id("nameofuser");
        private By cartBtn = By.XPath("//a[text()='Cart']");

        public LoginPage OpenLoginPopup()
        {
            driver.WaitUtil(loginBtn).Click();

            return new LoginPage(driver);
        }

        public SignUpPage OpenSignUpPopup()
        {
            driver.WaitUtil(signUpBtn).Click();

            return new SignUpPage(driver);
        }

        public CartPage GoToCart()
        {
            driver.WaitUtil(cartBtn).Click();
            driver.WaitForPageLoad();
            return new CartPage(driver);
        }


        public BasePage VerifyUserIsLoggedIn(string username)
        {

            driver.WaitForPageLoad();
            string userNameNav = driver.WaitUtil(nameOfUserNav).Text;

            Assert.AreEqual("Welcome " + username, userNameNav);

            return this;
        }

        public string GetAlertMessageAndAccept()
        {
            driver.WaitForAlert();
            var alert = driver.SwitchTo().Alert();
            var message = alert.Text;
            alert.Accept();

            return message;
        }

    }
}