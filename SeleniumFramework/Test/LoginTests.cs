using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumFramework.Pages;

namespace SeleniumFramework.Test
{
    public class LoginTests : BaseTest
    {
        [Test]
        public void TestLoginFunctionality()
        {
            Driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");  // Dummy login site

            LoginPage loginPage = new LoginPage(Driver);
            loginPage.EnterUsername("tomsmith");
            loginPage.EnterPassword("SuperSecretPassword!");
            loginPage.ClickLogin();

            Assert.That(Driver.Url, Is.EqualTo("https://the-internet.herokuapp.com/secure"), "Login failed!");
        }

        [Test]
        public void TestLogoutFunctionality()
        {
            Driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");  // Dummy login site

            LoginPage loginPage = new LoginPage(Driver);
            loginPage.EnterUsername("tomsmith");
            loginPage.EnterPassword("SuperSecretPassword!");
            loginPage.ClickLogin();

            Assert.That(Driver.Url, Is.EqualTo("https://the-internet.herokuapp.com/secure"), "Login failed!");
        }
    }
}
