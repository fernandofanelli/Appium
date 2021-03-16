using System;
using System.Threading;
using Framework;
using Framework.Errors;
using Framework.Utility;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;

using Activity = Framework.Utility.Activity;

namespace MobileClient
{
    public class MobileClient
    {
        [SetUp]
        public void Setup()
        {
            //All the things below will be replace with:
            Base.StartServer();
            Base.StartServerCMD();
            Base.StartEmulator();
            Base.SetupDriver(Share.MobileDriver.Android);
            Thread.Sleep(3000);
        }

        [Test]
        public void LoginIn()
        {
            //Click over the initial setup of MC for communication configs
            MC.SetCommunicationConfig();
            MC.Login();
            Activity.Misc.Sleep(3000);
            //Activity.CheckBox.ClickByDevice();
            MC.SelectPlatform("check1", Share.Platform.Android);
            Activity.Misc.PressKeyCode(Share.KeyCode.Back);
            Activity.Misc.Sleep(6000);
            Activity.Click.ByClassName("widget.Button", "APPLY");
            Activity.Misc.Sleep(500);
            //LaunchApp
            MC.SearchApp("Field Inventory - Cycle Count");
            Activity.Misc.Sleep(1000);
            Activity.Verify.Message("message", "No open cycle counts available");
            Activity.Click.ByClassName("widget.Button");
            //Verifies app titles 
            Activity.Verify.Title("widget.TextView", "CYCLE COUNT");
            Activity.Verify.Title("widget.TextView", "Add and Execute");
            Activity.Verify.Title("widget.TextView", "Review and Approve", false);
            //Verifies position of delete and add images
            Activity.Verify.Images();
            //Press Review and Aprrove tab to Verify position of delete and edit images
            Activity.Click.ByClassName("widget.TextView", "Review and Approve");
            Activity.Verify.Message("message", "No counts available to review and approve.");
            Activity.Click.ByClassName("widget.Button");
            Activity.Verify.Images();

            //Press Add and Execute to process the count
            Activity.Click.ByClassName("widget.TextView", "Add and Execute");
            Activity.Verify.Message("message", "No open cycle counts available");
            Activity.Click.ByClassName("widget.Button");
            Activity.Click.ByClassName("widget.Button", "Execute Count");
            Activity.Misc.Sleep(500);
            Activity.Verify.Message("message", "No row selected");
            Activity.Click.ById("button2", "android");
            
            GlobalVar.AndroidDriver.CloseApp();
        }

        [TearDown]
        public void MyTearDown()
        {
            try
            {
                var status= TestContext.CurrentContext.Result.Outcome.Status;
                if (status == TestStatus.Failed)
                {
                    var listener = new Listeners();
                    var report = TestContext.CurrentContext.Result;
                    listener.OnTestEvent(TestContext.CurrentContext.Test.Name);
                }
                Base.StopServer();
                GlobalVar.AndroidDriver.Close();
            }
            catch (Exception e)
            {
                //GlobalVar.AndroidDriver.Quit();
                Assert.Fail(e.Message);
            }
        }
    }
}