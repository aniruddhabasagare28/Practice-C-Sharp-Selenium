using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Appium.Service;

namespace AppiumTest;

public class Appium
{
    private AndroidDriver driver;
    private WebDriverWait wait;
    private string apkPath = @"D:\Practice\Practice\AppiumTest\App\app.apk";
    private string appPackage = "com.saucelabs.mydemoapp.rn";
    private AppiumLocalService appiumService;  // Appium server instance

    [SetUp]
    public void Setup()
    {
        Console.WriteLine("Setting up Appium driver...");

        // Start Appium server programmatically
        appiumService = new AppiumServiceBuilder()
            .UsingAnyFreePort()
            .WithLogFile(new FileInfo("appium.log"))  // Save logs to a file
            .Build();
        appiumService.Start();
        // Wait for Appium to be ready
        Thread.Sleep(5000); // Wait 5 seconds (adjust if needed)

        // Check if the server is actually running
        if (!appiumService.IsRunning)
        {
            throw new Exception("Failed to start Appium server.");
        }

        Console.WriteLine("Appium server started on: " + appiumService.ServiceUrl);

        // Ensure the APK file exists before installation
        if (!File.Exists(apkPath))
        {
            throw new FileNotFoundException("APK file not found at " + apkPath);
        }


        // Set up Appium options
        AppiumOptions options = new AppiumOptions
        {
            PlatformName = "Android",
            DeviceName = "Phone:5554",  // Change to your actual device/emulator ID
            AutomationName = "UiAutomator2"
        };

        using (var tempDriver = new AndroidDriver(new Uri(appiumService.ServiceUrl.ToString()), options))
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

        driver = new AndroidDriver(new Uri(appiumService.ServiceUrl.ToString()), options);
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
            appiumService.Dispose();
            driver.Dispose();
        }
        Console.WriteLine("Appium session closed.");
    }
}