using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;


namespace SeleniumPractice.Commons.Factory
{
    class NFirefoxDriver : NDriver
    {
        public IWebDriver Init(bool isHeadLess, string currentDriverFolder)
        {
            FirefoxOptions firefoxOptions = new FirefoxOptions();
            if (isHeadLess)
            {
                firefoxOptions.AddArgument("--headless");
            }

            firefoxOptions.AddArgument("no-sandbox");

            return new FirefoxDriver(currentDriverFolder, firefoxOptions);
        }

        public IWebDriver InitGrid(bool isHeadless, string gridHubUri)
        {
            FirefoxOptions options = new FirefoxOptions();
            if (isHeadless)
            {
                options.AddArgument("--headless");
            }

            var driver = new RemoteWebDriver(new Uri(gridHubUri), options);


            return driver;
        }
    }
}
