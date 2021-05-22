using OpenQA.Selenium;

namespace SeleniumPractice.DemoBlaze.PageObjectModel.SubPage
{
    public class LoginPage
    {
        IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        private readonly By usernameInput = By.Id("loginusername");
        private readonly By passwordInput = By.Id("loginpassword");
        private readonly By logInButton = By.XPath("//button[text()='Log in']");
        private readonly By closeButton = By.XPath("//*[@id='logInModalLabel']/../..//button[text()='Close']");

        public LoginPage Login(string username, string password)
        {
            driver.WaitUtil(usernameInput).SendKeys(username);
            driver.WaitUtil(passwordInput).SendKeys(password);
            driver.WaitUtil(logInButton).Click();
            return this;
        }

        public LoginPage Close()
        {
            driver.WaitUtil(closeButton).Click();

            return this;
        }
    }
}