using System;
using System.Collections.Generic;
using System.Text;
using Framework.Utility;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace Framework.BaseConfig
{
    public class Capabilities
    {
        public AppiumOptions CreateCapabilities(Share.Browser browser)
        {
            AppiumOptions capabilities = null;
            switch (browser)
            {
                case Share.Browser.Chrome:
                    break;
                case Share.Browser.Edge:
                    break;
                case Share.Browser.Firefox:
                    capabilities = FireFox();
                    break;
                case Share.Browser.IE:
                    break;
                case Share.Browser.Safari:
                    break;
                case Share.Browser.Android:
                    break;
                case Share.Browser.Ipad:
                    break;
                case Share.Browser.Iphone:
                    break;
            }

            return capabilities;
        }

        private AppiumOptions FireFox()
        {
            AppiumOptions caps = new AppiumOptions();
            FirefoxOptions ffOpts = new FirefoxOptions();
            FirefoxProfile ffProfile = new FirefoxProfile();
            ffProfile.SetPreference("browser.autofocus", true);

            caps.AddAdditionalCapability(FirefoxDriver.ProfileCapabilityName, ffProfile);
            caps.AddAdditionalCapability("marionette", true);
            //var driver = new AndroidDriver<AndroidElement>(GlobalVar.Uri, caps);
            return caps;
        }

    }
}
