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
        protected IWebDriver Driver;

        [SetUp]
        public void Setup()
        {
            string browser = ConfigReader.Get("Browser");  // Read from appsettings.json
            string gridLink = ConfigReader.Get("GridURL"); 
            Driver = DriverFactoryProvider.GetFactoryDriver(browser, gridLink).CreateDriver();
            Driver.Manage().Window.Maximize();
            //Logger.Log("Browser launched: " + browser);
        }

        [TearDown]
        public void TearDown()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver.Dispose();
                ///Logger.Log("Browser closed.");
            }
        }
    }
}
