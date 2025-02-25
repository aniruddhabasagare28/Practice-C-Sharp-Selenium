using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using SeleniumFramework.Config;
using SeleniumFramework.Core;

namespace SeleniumFramework.Test
{
    public class BaseTest
    {
        private static ThreadLocal<IWebDriver> _driver = new ThreadLocal<IWebDriver>();

        protected IWebDriver Driver
        {
            get { return _driver.Value; }
            set { _driver.Value = value; }
        }

        [SetUp]
        public void Setup()
        {
            string browser = ConfigReader.Get("Browser");  // Read from appsettings.json
            string gridLink = Environment.GetEnvironmentVariable("SELENIUM_GRID_URL") ?? "http://localhost:4444";


            Driver = DriverFactoryProvider.GetFactoryDriver(browser, gridLink).CreateDriver();
            Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver.Dispose();
                _driver.Value = null; // Clear the ThreadLocal storage
            }
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            if (_driver != null)
            {
                _driver.Dispose();
                _driver = null;
            }
        }
    }
}
