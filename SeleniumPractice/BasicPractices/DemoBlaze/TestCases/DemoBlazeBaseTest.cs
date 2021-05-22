using NUnit.Framework;
using SeleniumPractice.DemoBlaze.PageObjectModel;
using SeleniumPractice.DemoBlaze.PageObjectModel.SubPage;

namespace SeleniumPractice.DemoBlaze
{
    [Parallelizable(ParallelScope.Fixtures)]
    public class DemoBlazeBaseTest : BaseTest
    {
        protected HomePage homePage;
        protected LoginPage loginPage;
        protected CartPage cartPage;
        protected SignUpPage signUpPage;
        protected ProductDetailsPage productDetailsPage;

        [OneTimeSetUp]
        public void DbOneTimeSetup()
        {
            homePage = new HomePage(driver);
            loginPage = new LoginPage(driver);
            signUpPage = new SignUpPage(driver);
            cartPage = new CartPage(driver);
            productDetailsPage = new ProductDetailsPage(driver);
        }
    }
}
