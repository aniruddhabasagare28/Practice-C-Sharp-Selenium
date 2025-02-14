using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumPractice
{
    public class Tests
    {
        IWebDriver driver = null;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }

        [Test]
        public void ActionsOnButtons()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/buttons");
            Actions actions = new Actions(driver);

            IWebElement doubleClick = driver.FindElement(By.Id("doubleClickBtn"));
            actions.DoubleClick(doubleClick).Perform();

            IWebElement rightClick = driver.FindElement(By.Id("rightClickBtn"));
            actions.ContextClick(rightClick).Perform();
        }

        [Test]
        public void WaitForTextBox()
        {
            driver.Navigate().GoToUrl("https://demoqa.com");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement Element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//h5[text()='Elements']")));
            Element.Click();

            IWebElement textElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Text Box']")));
            textElement.Click();
        }

        [Test]
        public void WaitForButtonFluent()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/dynamic-properties");

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver)
            {
                Timeout = TimeSpan.FromSeconds(100),
                PollingInterval = TimeSpan.FromMilliseconds(500)
            };

            IWebElement enableButton = fluentWait.Until(dr =>
            {
                IWebElement button = dr.FindElement(By.Id("enableAfter"));
                return button.Enabled ? button : null;
            });
        }

        [Test]
        public void HandleTheSimpleAlert()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");
            IWebElement simplealert = driver.FindElement(By.XPath("//button[text()='Click for JS Alert']"));
            simplealert.Click();

            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
        }

        [Test]
        public void HandleThePromptAlert()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");
            IWebElement simplealert = driver.FindElement(By.XPath("//button[text()='Click for JS Prompt']"));
            simplealert.Click();

            IAlert alert = driver.SwitchTo().Alert();
            Console.WriteLine("Alert text: " + alert.Text);
            alert.SendKeys("Text");
            alert.Accept();
        }
        [Test]
        public void SwithcToWindows()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/windows");
            string mainwindow = driver.CurrentWindowHandle;

            driver.FindElement(By.LinkText("Click Here")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(dr => dr.WindowHandles.Count() > 1);

            foreach (var handle in driver.WindowHandles)
            {
                if (!handle.Equals(mainwindow))
                {
                    driver.SwitchTo().Window(handle);
                }
            }
        }
    }
}