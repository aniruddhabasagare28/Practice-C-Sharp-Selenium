using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium.DevTools.V130.Browser;

namespace SeleniumFramework.Config
{
    public class ConfigReader
    {
        private static readonly JObject configuration;

        static ConfigReader()
        {
            string configFile = "appsettings.json";

            if (File.Exists(configFile))
            {
                configuration = JObject.Parse( File.ReadAllText(configFile));
            }
            else 
            {
                throw new FileNotFoundException(configFile);
            }
        }
        public static string Get(string key) => configuration[key]?.ToString() ?? null;
        public static string GetBrowser() => configuration["Browser"]?.ToString() ?? "chrome";
        public static string GetBaseUrl() => configuration["BaseUrl"]?.ToString() ?? "https://example.com";
    }
}
