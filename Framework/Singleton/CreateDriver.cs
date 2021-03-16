using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Framework.Utility;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace Framework.Android.Singleton
{
    /// <summary>
    /// With this we will force the user to use the same object for all the instances where the Driver is required.
    /// Also the Driver will never get out of Sync during the run.
    /// </summary>
    public class CreateDriver
    {
        private static CreateDriver _instance = null;

        // using ThreadLocal to create multi-threading
        private ThreadLocal<AndroidDriver<AndroidElement>> _androidDriver = new ThreadLocal<AndroidDriver<AndroidElement>>();
        private ThreadLocal<IOSDriver<IOSElement>> _iosDriver = new ThreadLocal<IOSDriver<IOSElement>>();
        private ThreadLocal<IWebDriver> _webDriver = new ThreadLocal<IWebDriver>();

        private ThreadLocal<string> _sessionId = new ThreadLocal<string>();
        private ThreadLocal<string> _sessionBrowser = new ThreadLocal<string>();
        private ThreadLocal<string> _sessionPlatform = new ThreadLocal<string>();
        private ThreadLocal<string> _sessionVersion = new ThreadLocal<string>();
        private string _getEnv = null;

        private CreateDriver() { }

        /// <summary>
        /// method to retrieve active driver instance
        /// </summary>
        /// <returns>CreateDriver</returns>
        public static CreateDriver GetInstance()
        {
            return _instance ??= new CreateDriver();
        }

        public void SetDriver(Share.Browser browser, string environment, string platform)
        {
            AppiumOptions capabilities = null;
            var localHub = "http://localhost:4723/wd/hub";
            string getPlatform = null;

            switch (browser)
            {
                case Share.Browser.Chrome:
                    break;
                case Share.Browser.Edge:
                    break;
                case Share.Browser.Firefox:
                    break;
                case Share.Browser.IE:
                    break;
                case Share.Browser.Safari:
                    break;
                case Share.Browser.Android:
                    capabilities = Base.CreateMobileCapabilities();
                    _androidDriver.Value = new AndroidDriver<AndroidElement>(GlobalVar.Uri, capabilities);
                    break;
                case Share.Browser.Ipad:
                case Share.Browser.Iphone:
                    capabilities = Base.CreateMobileCapabilities();
                    _iosDriver.Value = new IOSDriver<IOSElement>(GlobalVar.Uri, capabilities);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(browser), browser, null);
            }
        }

        public void SetDriver(AndroidDriver<AndroidElement> driver)
        {
            _androidDriver.Value = driver;
            _sessionId.Value = _androidDriver.Value.SessionId.ToString();
            _sessionBrowser.Value = (string) _androidDriver.Value.Capabilities.GetCapability(MobileCapabilityType.BrowserName);
            _sessionPlatform.Value = (string) _androidDriver.Value.Capabilities.GetCapability(MobileCapabilityType.PlatformName);
            
        }

        public void SetDriver(IOSDriver<IOSElement> driver)
        {
            _iosDriver.Value = driver;
            _sessionId.Value = _androidDriver.Value.SessionId.ToString();
            _sessionBrowser.Value = (string)_androidDriver.Value.Capabilities.GetCapability(MobileCapabilityType.BrowserName);
            _sessionPlatform.Value = (string)_androidDriver.Value.Capabilities.GetCapability(MobileCapabilityType.PlatformName);
        }

        /// <summary>
        /// Method will retrieve the active _android driver
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns>AndroidDriver<AndroidElement> </returns>
        public AndroidDriver<AndroidElement> GetDriver(bool mobile)
        {
            return _androidDriver.Value;
        }

        //public IOSDriver<IOSElement> GetDriver(bool mobile)
        //{
        //    return _iosDriver.Value;
        //}

        public string GetSessionBrowser()
        {
            return _sessionBrowser.ToString();
        }


        public AndroidDriver<AndroidElement> GetCurrentDriver()
        {
            var browser = GetInstance().GetSessionBrowser();
            if (browser.Contains("Android") || browser.Contains("Ipad") || browser.Contains("Iphone"))
                return GetInstance().GetDriver(true);
            return null;
        }

        public void CloseDriver()
        {
            try
            {
                GetCurrentDriver().Quit();
            }

            catch (Exception ex)
            {
                Assert.Fail("CloseDrive throw an error: " + ex.Message);
            }
        }
    }
}
