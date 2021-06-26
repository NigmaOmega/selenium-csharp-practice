using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumPractice.Commons.Factory
{
    class DriverFactory
    {

        public static IWebDriver InitDriver(string browserName, string currentDriverFolder, bool isHeadless)
        {
            browserName = browserName.ToLower();
            switch (browserName)
            {
                case "chrome": 
                    return new NChromeDriver().Init(isHeadless, currentDriverFolder);
                case "firefox": 
                    return new NFirefoxDriver().Init(isHeadless, currentDriverFolder);
            }

            throw new Exception("Invalid browser name!");
        }

        public static IWebDriver InitGridDriver(string browserName, string gridHubUri, bool isHeadless) {
            browserName = browserName.ToLower();

            switch (browserName)
            {
                case "chrome":
                    return new NChromeDriver().InitGrid(isHeadless, gridHubUri);
                case "firefox":
                    return new NFirefoxDriver().InitGrid(isHeadless, gridHubUri);
            }

            throw new Exception("Invalid browser name for Selenium grid!");
        }

    }
}
