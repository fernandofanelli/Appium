using System;
using System.Threading;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using Framework.Errors;
using Framework.Utility;
using Framework.Utility.Helper;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Support.UI;
using Core = Framework.Utility.Core;
using Activity = Framework.Utility.Activity;


namespace ActivityGetControl
{
    //THIS WILL ONLY TEST THE FUNCTIONS OF ==> namespace Framework.Utility.Activity.GetControl
    public class GetControl
    {
        [SetUp]
        public void Setup()
        {
            SetupOptions();
            Thread.Sleep(3000);
        }

        #region TEST BY CLASSNAME

        /// <summary>
        /// Get the title app using only the className of an element
        /// </summary>
        [Test]
        public void ElementByClassName()
        {
            try
            {
                //var titleApp = Activity.GetControl.ByClass("widget.TextView");
                var titleApp = "";
                UsingHelper("TextView");

                //titleApp = ByClass("android.widget.TextView");


                //if (!titleApp.Text.Contains("API Demos"))
                //    Assert.Fail("It brought: " + titleApp.Text);
            }
            catch (Exception ex)
            {
                Assert.Fail("ElementByClassName test fail due to: " + ex.Message);
            }
        }

        /// <summary>
        /// Get the TextView for User using the className and text of an element
        /// </summary>
        [Test]
        public void ElementByClassNameAndText()
        {
            var htmlReport = new ExtentHtmlReporter(@"C:\Users\ffanelli\Desktop\ExtentReport\testReport.html");
            htmlReport.Config.Theme = Theme.Dark;
            htmlReport.Config.DocumentTitle = "Test Report | Fernando";
            htmlReport.Config.ReportName = "Test Report Name | Fernando";

            var extent = new ExtentReports();
            extent.AttachReporter(htmlReport);
            var test = extent.CreateTest("Failing Test");
            try
            {
                var accesibility = Core.GetControl.ByClass("widget.Tt", "Accessibility");
                if (!accesibility.Text.Contains("Accessibility"))
                    Assert.Fail("It brought: " + accesibility.Text);

                accesibility.Click();
            }
            catch (Exception ex)
            {
                //Assert.Fail("ElementByClassNameAndText test fail due to: " + ex.Message);
                test.Fail(ex.StackTrace);
            }
            extent.Flush();
        }

        /// <summary>
        /// Get a list of EditText for User & Password using only the className of an element
        /// </summary>
        [Test]
        public void ListOfElementByClassName()
        {
            Assert.Pass();
        }

        /// <summary>
        /// Get a list of TextView for User & Password using the className and text of an element
        /// </summary>
        [Test]
        public void ListOfElementByClassNameAndText()
        {
            Assert.Pass();
        }

        #endregion END OF TEST BY CLASSNAME


        public static string AppPackage = "io.appium.android.apis";
        public static void SetupOptions(bool installApp = false)
        {
            var driverOption = new AppiumOptions();
            driverOption.AddAdditionalCapability(MobileCapabilityType.PlatformName, GlobalVar.PlatformName);
            driverOption.AddAdditionalCapability(MobileCapabilityType.DeviceName, GlobalVar.DeviceName);
            driverOption.AddAdditionalCapability(MobileCapabilityType.NewCommandTimeout, GlobalVar.Timeout);
            driverOption.AddAdditionalCapability(MobileCapabilityType.App, GlobalVar.ApkPathDemos);
            driverOption.AddAdditionalCapability(MobileCapabilityType.Udid, GlobalVar.Udid);
            driverOption.AddAdditionalCapability(MobileCapabilityType.AutomationName, GlobalVar.AutomationName);
            driverOption.AddAdditionalCapability("autoGrantPermissions", GlobalVar.Permissions);
            driverOption.AddAdditionalCapability("allowSessionOverride", GlobalVar.SessionOverride);
            driverOption.AddAdditionalCapability("appPackage", AppPackage);
            //driverOption.AddAdditionalCapability("appActivity", GlobalVar.AppActivity + "EntryActivity");
            GlobalVar.Driver = new AndroidDriver<AndroidElement>(GlobalVar.Uri, driverOption);
            MiscFunctions.SetDriver(GlobalVar.Driver);

            //Install API DEMOS apk
            if (installApp)
                GlobalVar.Driver.InstallApp(GlobalVar.ApkPathDemos);
        }

        public static void UsingHelper(string value)
        {
            var by = Activity.Misc.BuildBy(Share.By.ClassName, Share.Element.TextView);
            Helpers.SendKeys(by, value);
            
        }


        [TearDown]
        public void MyTearDown()
        {
            try
            {
                Base.CheckStatus();
                Base.StopServer();
                GlobalVar.AndroidDriver.Close();
            }
            catch (Exception e)
            {
                //GlobalVar.AndroidDriver.Quit();
                //Assert.Fail(e.Message);
            }
        }
    }
}