using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumPractice.Commons.Factory
{
    class NChromeDriver : NDriver
    {
        public IWebDriver Init(bool isHeadLess, string currentDriverFolder)
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            if (isHeadLess)
            {
                chromeOptions.AddArgument("--headless");
            }

            chromeOptions.AddArgument("no-sandbox");
            return new ChromeDriver(currentDriverFolder, chromeOptions);
        }

        public IWebDriver InitGrid(bool isHeadless, string gridHubUri)
        {
            ChromeOptions options = new ChromeOptions();
            if (isHeadless)
            {
                options.AddArgument("--headless");
            }

            var driver = new RemoteWebDriver(new Uri(gridHubUri), options);


            return driver;
        }
    }
}
