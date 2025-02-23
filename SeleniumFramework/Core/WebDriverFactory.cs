using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace SeleniumFramework.Core
{
    public interface IWebDriverFactory
    {
        IWebDriver CreateDriver();
    }

    public class ChromeDriverFactor : IWebDriverFactory
    {
        private readonly string _gridLink;

        public ChromeDriverFactor(string gridLink = null)
        {
            _gridLink = gridLink;
        }

        public IWebDriver CreateDriver()
        {
            if (!string.IsNullOrEmpty(_gridLink))
            {
                Console.WriteLine($"Using RemoteWebDriver for Chrome with Grid: {_gridLink}");
                var options = new ChromeOptions();
                return new RemoteWebDriver(new Uri(_gridLink), options);
            }
            else
            {
                Console.WriteLine("Using Local ChromeDriver");
                return new ChromeDriver();
            }
        }
    }

    public class FirefoxDriverFactory : IWebDriverFactory
    {
        private readonly string _gridLink;

        public FirefoxDriverFactory(string gridLink = null)
        {
            _gridLink = gridLink;
        }
        public IWebDriver CreateDriver()
        {
            if (!string.IsNullOrEmpty(_gridLink))
            {
                Console.WriteLine($"Using RemoteWebDriver for Firefox with Grid: {_gridLink}");
                var options = new FirefoxOptions();
                return new RemoteWebDriver(new Uri(_gridLink), options);
            }
            else
            {
                Console.WriteLine("Using Local FirefoxDriver");
                return new FirefoxDriver();
            }
        }
    }

    public class DriverFactoryProvider
    {
        public static IWebDriverFactory GetFactoryDriver(string browserType, string gridLink = null) 
        {
            return browserType.ToLower() switch
            {
                "firefox" => new FirefoxDriverFactory(gridLink),
                _ => new ChromeDriverFactor(gridLink)

            };
        }
    }
}
