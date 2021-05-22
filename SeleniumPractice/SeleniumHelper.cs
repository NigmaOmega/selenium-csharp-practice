using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;

namespace SeleniumPractice
{
    public static class SeleniumHelper
    {
        private static readonly ConfigurationHelper config = ConfigurationHelper.Instance;


        public static IWebDriver InitDriver()
        {
            var isGrid = config.IsSeleniumGrid;
            IWebDriver driver;
            if (isGrid)
            {
                driver = InitGridDriver();
            }
            else
            {
                driver = InitNormalDriver();
            }
            driver.Manage().Window.Maximize();

            return driver;
        }

        private static IWebDriver InitNormalDriver()
        {
            switch (config.Browser)
            {
                case "Chrome":
                    return InitNormalChromeDriver();
                default:
                    return InitNormalChromeDriver();
            }
        }

        private static IWebDriver InitNormalChromeDriver()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            if (config.IsHeadless)
            {
                chromeOptions.AddArgument("--headless");
            }

            chromeOptions.AddArgument("no-sandbox");
            return new ChromeDriver(chromeOptions);
        }

        private static IWebDriver InitGridDriver()
        {
            switch (config.Browser)
            {
                case "Chrome":
                    return InitChromeGridDriver();
                default:
                    return InitChromeGridDriver();
            }
        }

        private static IWebDriver InitChromeGridDriver()
        {
            ChromeOptions options = new ChromeOptions();
            if (config.IsHeadless)
            {
                options.AddArgument("--headless");
            }

            var driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub/"), options);


            return driver;
        }
    }
}