using System;
using System.Collections.Generic;
using System.Text;
using static Framework.Utility.Share;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.iOS;

namespace Framework.Utility
{
    public static class MiscFunctions
    {

        public static AndroidDriver<AndroidElement> GetDriver()
        {
            try
            {
                if (GlobalVar.AndroidDriver == null)
                    Assert.Fail("The instance of driver was not initialized");
                return GlobalVar.AndroidDriver;
            }
            catch (Exception ex)
            {
                Assert.Fail("GetDriver threw an exception:" + ex.Message);
            }

            return null;
        }

        public static void SetDriver(AndroidDriver<AndroidElement> driver)
        {
            GlobalVar.AndroidDriver = driver;
        }
    }
}
