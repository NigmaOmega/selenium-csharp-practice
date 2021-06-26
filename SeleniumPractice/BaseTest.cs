using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumPractice
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class BaseTest
    {
        protected IWebDriver driver;


        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            driver = SeleniumHelper.InitDriver();
        }

        [TearDown]
        public void CleanDriver() {
            driver.DeleteStorage();
            driver.Navigate().Refresh();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
        }

    }
}
