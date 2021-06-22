﻿using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumPractice
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class BaseTest
    {
        protected IWebDriver driver;


        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            driver = SeleniumHelper.InitDriver();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
        }

    }
}