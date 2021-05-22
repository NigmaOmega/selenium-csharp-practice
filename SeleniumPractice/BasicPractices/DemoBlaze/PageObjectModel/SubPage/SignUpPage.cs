using OpenQA.Selenium;

namespace SeleniumPractice.DemoBlaze.PageObjectModel.SubPage
{
    public class SignUpPage
    {
        IWebDriver driver;

        public SignUpPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        private readonly By usernameInput = By.Id("sign-username");
        private readonly By passwordInput = By.Id("sign-password");
        private readonly By signUpButton = By.XPath("//button[text()='Sign up']");
        private readonly By closeButton = By.XPath("//h5[text()='Sign up']/../..//button[text()='Close']");

        public SignUpPage SignUp(string username, string password)
        {
            driver.WaitUtil(usernameInput).SendKeys(username);
            driver.WaitUtil(passwordInput).SendKeys(password);
            driver.WaitUtil(signUpButton).Click();


            return this;
        }

        public SignUpPage AcceptAlert()
        {

            var alert = driver.WaitForAlert();
            alert.Accept();

            return this;
        }

        public SignUpPage Close()
        {
            driver.WaitUtil(closeButton).Click();

            return this;
        }
    }
}