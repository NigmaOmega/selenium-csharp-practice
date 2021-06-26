using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumPractice.Commons.Factory
{
    interface NDriver
    {
        IWebDriver Init(bool isHeadLess, string currentDriverFolder);
        IWebDriver InitGrid(bool isHeadless, string gridHubUri);
    }
}
