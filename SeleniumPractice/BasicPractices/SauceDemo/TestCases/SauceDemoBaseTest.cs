using NUnit.Framework;

namespace SeleniumPractice.SauceDemo.TestCases
{
    public class SauceDemoBaseTest : BaseTest
    {
        [SetUp]
        public void FixturesSetUp()
        {
            driver.DeleteAllCookies();
        }

    }
}
