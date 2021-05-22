using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumPractice.SauceDemo.PageObjectModels
{
    public class LoginPage
    {
        readonly IWebDriver driver;

        private readonly By userNameInput = By.Id("user-name");
        private readonly By passwordInput = By.Id("password");
        private readonly By loginButton = By.Id("login-button");
        private readonly By errorMessagelabel = By.XPath("//*[@data-test=\"error\"]");

        LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public static LoginPage Init(IWebDriver driver)
        {
            return new LoginPage(driver);
        }

        public LoginPage GoTo()
        {
            driver.Navigate().GoToUrl(WebUrl.LoginPage);

            return this;
        }

        public LoginPage Login(string username, string password)
        {
            driver.WaitUtil(userNameInput).SendKeys(username);
            driver.WaitUtil(passwordInput).SendKeys(password);
            driver.WaitUtil(loginButton).Click();

            return this;
        }

        public LoginPage VerifyErrorMessageContain(string expectedErrorMessage)
        {
            var actualErrorMessage = driver.WaitUtil(errorMessagelabel).Text;
            Assert.That(actualErrorMessage, Does.Contain(expectedErrorMessage));

            return this;

        }


    }
}
