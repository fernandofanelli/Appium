using System;
using System.Threading;
using Framework;
using Framework.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.Service;

namespace AppiumClient
{
    public class Youtube
    {
        /*
         * If you want to animate certain platforms then in the <> you will use:
         * Windows: WindowsElement
         * IOS: iOSElement
         * Android: AndroidElement
         */
        public static AndroidDriver<AndroidElement> Driver; 

        [SetUp]
        public void Setup()
        {
            var appPath = @"C:\Users\ffanelli\Desktop\APK\mobile_client.apk";
            var chromeDriver = @"C:\WebDriver\bin\chromedriver.exe";

            //start appium service
            //var builder = new AppiumServiceBuilder();
            //var appiumLocalService = builder.UsingAnyFreePort().Build();
            //appiumLocalService.Start();

            //Capabilities, here we tell the server were we want to run our automation. Which platform, device, application
            //Platform, Device, Application
            //The android options is what replaced the DesiredCapabilities, as this are deprecated
            var driverOption = new AppiumOptions();
            driverOption.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            driverOption.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Android 28");
            driverOption.AddAdditionalCapability(MobileCapabilityType.App, appPath);
            driverOption.AddAdditionalCapability(MobileCapabilityType.Udid, "emulator-5554");
            driverOption.AddAdditionalCapability(MobileCapabilityType.AutomationName, "UiAutomator2");
            driverOption.AddAdditionalCapability("autoGrantPermissions", true);
            driverOption.AddAdditionalCapability("allowSessionOverride", true);
            driverOption.AddAdditionalCapability("appPackage", "com.android.chrome");
            driverOption.AddAdditionalCapability("appActivity", "com.google.android.apps.chrome.Main");

            //the chrome driver is only requirable if we test an hybrid app
            //driverOption.AddAdditionalCapability("chromedriverExecutable", chromeDriver);

            //Here we will do the server initialization, were this android will talk too
            //the uri is the server where we will connect (where the interface is listening )
            Driver = new AndroidDriver<AndroidElement>(new Uri("http://localhost:4723/wd/hub"), driverOption);
            MiscFunctions.SetDriver(Driver);

            //Install MC
            Driver.InstallApp(appPath);

            //Click over the initial setup of chrome
            Activity.ClickById("send_report_checkbox");
            Thread.Sleep(2000);
            Activity.ClickById("terms_accept");
            Thread.Sleep(2000);
            Activity.ClickById("next_button");
            Thread.Sleep(2000);
            Activity.ClickById("negative_button");
            Thread.Sleep(2000);

            Driver.Navigate().GoToUrl("https://www.youtube.com");
            Thread.Sleep(2000);
            Activity.ClickByClassName("widget.Button", "search youtube");
            Thread.Sleep(3000);
            Activity.InputByClassName("widget.EditText", "Rick Astley");
            Thread.Sleep(3000);
            Activity.ClickByClassName("widget.Button", "search youtube");
            Thread.Sleep(3000);
            Activity.ClickByClassName("view.View", "never gonna give you up");
            Thread.Sleep(3000);
            //Driver = new AndroidDriver<AndroidElement>(appiumLocalService.ServiceUrl, driverOption);

            //to automate Native apps whe can use the accesibilityid or class name, like webpages


            //now we need the web view context to automate Hybrid apps
            //var contexts = ((IContextAware) Driver).Contexts;
            //string webviewContext = null;
            //for (var i = 0; i < contexts.Count; i++)
            //{
            //    Console.WriteLine(contexts[i]);
            //    if (contexts[i].Contains("WEBVIEW"))
            //    {
            //        webviewContext = contexts[i];
            //        break;
            //    }
            //}

            //((IContextAware) Driver).Context = webviewContext;

        }

        [Test]
        public void SearchSong()
        {
            
        }

        [TearDown]
        public void MyTearDown()
        {
            try
            {
                Driver.Quit();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);    
            }
            
        }
    }
}