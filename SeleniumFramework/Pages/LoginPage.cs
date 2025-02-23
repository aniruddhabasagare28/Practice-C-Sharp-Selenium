using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumFramework.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Elements
        private IWebElement Username => _driver.FindElement(By.Id("username"));
        private IWebElement Password => _driver.FindElement(By.Id("password"));
        private IWebElement LoginButton => _driver.FindElement(By.XPath("//button"));
        private IWebElement LogoutButton => _driver.FindElement(By.XPath("//a[contains(@href,'logout')]"));

        // Actions
        public void EnterUsername(string username) => Username.SendKeys(username);
        public void EnterPassword(string password) => Password.SendKeys(password);
        public void ClickLogin() => LoginButton.Click();
    }
}
