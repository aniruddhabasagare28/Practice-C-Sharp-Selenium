using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace SeleniumFramework.Core
{
    public interface IWebDriverFactory
    {
        IWebDriver CreateDriver();
    }

    public class ChromeDriverFactor : IWebDriverFactory
    {
        public IWebDriver CreateDriver()
        {
            return new ChromeDriver();
        }
    }

    public class FireForxDriverFActory : IWebDriverFactory
    {
        public IWebDriver CreateDriver()
        {
            return new FirefoxDriver();
        }
    }

    public class DriverFactoryProvider
    {
        public static IWebDriverFactory GetFactoryDriver(string browserType) 
        {
            return browserType.ToLower() switch
            {
                "firefox" => new FireForxDriverFActory(),
                _ => new ChromeDriverFactor()

            };
        }
    }
}
