using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using SeleniumPractice.Commons.Factory;
using System;
using System.IO;

namespace SeleniumPractice
{
    public static class SeleniumHelper
    {
        private static readonly ConfigurationHelper config = ConfigurationHelper.Instance;

        private static string currentDriverFolder = Directory.GetCurrentDirectory() + "/Driver/";

        public static IWebDriver InitDriver()
        {
            var isGrid = config.IsSeleniumGrid;
            var isHeadless = config.IsHeadless;
            var browser = config.Browser;
            
            IWebDriver driver;
            if (isGrid)
            {
                string gridHubUri = config.GridHubUri;
                driver = DriverFactory.InitGridDriver(browser, gridHubUri, isHeadless);
            }
            else
            {
                driver = DriverFactory.InitDriver(browser, currentDriverFolder, isHeadless);
            }
            driver.Manage().Window.Maximize();

            return driver;
        }

    }
}