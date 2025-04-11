using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumFramework.Pages;

namespace SeleniumFramework.Test
{
    [Parallelizable(ParallelScope.All)]  // Enables parallel execution
    public class LoginTests : BaseTest
    {


        [Test, Category("Regression")]
        public void Test_LoginFunctionality()
        {
            Driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");  // Dummy login site

            LoginPage loginPage = new LoginPage(Driver);
            loginPage.EnterUsername("tomsmith");
            loginPage.EnterPassword("SuperSecretPassword!");
            loginPage.ClickLogin();

            Assert.That(Driver.Url, Is.EqualTo("https://the-internet.herokuapp.com/secure"), "Login failed!");
        }
        [Test, Category("Regression")]
        public void Test_LoginFunctionality3()
        {
            Driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");  // Dummy login site

            LoginPage loginPage = new LoginPage(Driver);
            loginPage.EnterUsername("tomsmith");
            loginPage.EnterPassword("SuperSecretPassword!");
            loginPage.ClickLogin();

            Assert.That(Driver.Url, Is.EqualTo("https://the-internet.herokuapp.com/secure"), "Login failed!");
        }
        [Test, Category("Regression")]
        public void Test_LoginFunctionality1()
        {
            Driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");  // Dummy login site

            LoginPage loginPage = new LoginPage(Driver);
            loginPage.EnterUsername("tomsmith");
            loginPage.EnterPassword("SuperSecretPassword!");
            loginPage.ClickLogin();

            Assert.That(Driver.Url, Is.EqualTo("https://the-internet.herokuapp.com/secure"), "Login failed!");
        }
        [Test, Category("Regression")]
        public void Test_LoginFunctionality2()
        {
            Driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");  // Dummy login site

            LoginPage loginPage = new LoginPage(Driver);
            loginPage.EnterUsername("tomsmith");
            loginPage.EnterPassword("SuperSecretPassword!");
            loginPage.ClickLogin();

            Assert.That(Driver.Url, Is.EqualTo("https://the-internet.herokuapp.com/secure"), "Login failed!");
        }

        [Test, Category("Smoke")]
        
        public void Test_LogoutFunctionality()
        {
            Driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");  // Dummy login site

            LoginPage loginPage = new LoginPage(Driver);
            loginPage.EnterUsername("tomsmith");
            loginPage.EnterPassword("SuperSecretPassword!");
            loginPage.ClickLogin();

            Assert.That(Driver.Url, Is.EqualTo("https://the-internet.herokuapp.com/secure"), "Login failed!");
        }

        [Test, Category("Smoke")]

        public void Test_LogoutFunctionality1()
        {
            Driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");  // Dummy login site

            LoginPage loginPage = new LoginPage(Driver);
            loginPage.EnterUsername("tomsmith");
            loginPage.EnterPassword("SuperSecretPassword!");
            loginPage.ClickLogin();

            Assert.That(Driver.Url, Is.EqualTo("https://the-internet.herokuapp.com/secure"), "Login failed!");
        }

        [Test, Category("Smoke")]

        public void Test_LogoutFunctionality2()
        {
            Driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");  // Dummy login site

            LoginPage loginPage = new LoginPage(Driver);
            loginPage.EnterUsername("tomsmith");
            loginPage.EnterPassword("SuperSecretPassword!");
            loginPage.ClickLogin();

            Assert.That(Driver.Url, Is.EqualTo("https://the-internet.herokuapp.com/secure"), "Login failed!");
        }

        [Test, Category("Smoke")]

        public void Test_LogoutFunctionality3()
        {
            Driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");  // Dummy login site

            LoginPage loginPage = new LoginPage(Driver);
            loginPage.EnterUsername("tomsmith");
            loginPage.EnterPassword("SuperSecretPassword!");
            loginPage.ClickLogin();
            //test
            Assert.That(Driver.Url, Is.EqualTo("https://the-internet.herokuapp.com/secure"), "Login failed!");
        }

    }
}
