using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;

namespace AppiumTest;

public class Appium
{
    private AndroidDriver driver;
    private WebDriverWait wait;
    private string apkPath = @"D:\Practice\Practice\AppiumTest\App\app.apk";
    private string appPackage = "com.saucelabs.mydemoapp.rn";

    [SetUp]
    public void Setup()
    {
        Console.WriteLine("Setting up Appium driver...");

        // Ensure the APK file exists before installation
        if (!File.Exists(apkPath))
        {
            throw new FileNotFoundException("APK file not found at " + apkPath);
        }


        // Set up Appium options
        AppiumOptions options = new AppiumOptions
        {
            PlatformName = "Android",
            DeviceName = "Emulator:5554",  // Change to your actual device/emulator ID
            AutomationName = "UiAutomator2"
        };

        using (var tempDriver = new AndroidDriver(new Uri("http://127.0.0.1:4723"), options))
        {
            // Check if the app is installed
            if (tempDriver.IsAppInstalled(appPackage))
            {
                Console.WriteLine("App is already installed. Uninstalling...");
                tempDriver.RemoveApp(appPackage);
                Console.WriteLine("App uninstalled successfully.");
            }

            // Install the APK
            Console.WriteLine("Installing APK...");
            tempDriver.InstallApp(apkPath);
            Console.WriteLine("APK Installed Successfully.");
        }
        options.AddAdditionalAppiumOption("appPackage", appPackage);
        options.AddAdditionalAppiumOption("appActivity", ".MainActivity");

        driver = new AndroidDriver(new Uri("http://127.0.0.1:4723"), options);
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        Console.WriteLine("Appium driver initialized.");
    }

    [Test]
    public void AutomateLogin()
    {
        Console.WriteLine("Starting Appium Login Test...");

        try
        {
            // Handle any initial popups if present
            try
            {
                var element = wait.Until(drv => drv.FindElement(By.Id("android:id/button1")));
                if (element.Displayed)
                {
                    element.Click();
                }
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("No popup detected.");
            }

            // Add login automation steps here
            Console.WriteLine("Login Automation Completed!");
        }
        catch (Exception ex)
        {
            Assert.Fail("Test Failed: " + ex.Message);  // Fail the test if any exception occurs
        }
       
    }

    [TearDown]  // Runs after each test case
    public void Teardown()
    {
        Console.WriteLine("Closing Appium driver...");
        if (driver != null)
        {
            driver.Quit();
            driver.Dispose();
        }
        Console.WriteLine("Appium session closed.");
    }
}