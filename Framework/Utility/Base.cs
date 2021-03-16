using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Core;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using Framework.Errors;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Microsoft.VisualStudio.TestPlatform.CoreUtilities.Helpers;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Chrome;
using static Framework.Utility.GlobalVar;
using static Framework.Utility.MiscFunctions;
using static Framework.Utility.Share;

namespace Framework.Utility
{
    public static class Base
    {
        private static Process _process = null;


        public static void SetupOptions()
        {
            var driverOption = new AppiumOptions();
            driverOption.AddAdditionalCapability(MobileCapabilityType.PlatformName, PlatformName);
            driverOption.AddAdditionalCapability(MobileCapabilityType.DeviceName, DeviceName);
            driverOption.AddAdditionalCapability(MobileCapabilityType.NewCommandTimeout, Timeout);
            driverOption.AddAdditionalCapability(MobileCapabilityType.App, ApkPath);
            driverOption.AddAdditionalCapability(MobileCapabilityType.Udid, Udid);
            driverOption.AddAdditionalCapability(MobileCapabilityType.AutomationName, GlobalVar.AutomationName);
            driverOption.AddAdditionalCapability("autoGrantPermissions", Permissions);
            driverOption.AddAdditionalCapability("allowSessionOverride", SessionOverride);
            driverOption.AddAdditionalCapability("appPackage", AppPackage);
            driverOption.AddAdditionalCapability("appActivity", AppActivity + "EntryActivity");
            Driver = new AndroidDriver<AndroidElement>(GlobalVar.Uri, driverOption);
        }

        public static AppiumOptions CreateMobileCapabilities()
        {
            var driverOption = new AppiumOptions();
            driverOption.AddAdditionalCapability(MobileCapabilityType.PlatformName, PlatformName);
            driverOption.AddAdditionalCapability(MobileCapabilityType.DeviceName, DeviceName);
            driverOption.AddAdditionalCapability(MobileCapabilityType.NewCommandTimeout, Timeout);
            driverOption.AddAdditionalCapability(MobileCapabilityType.App, ApkPath);
            driverOption.AddAdditionalCapability(MobileCapabilityType.Udid, Udid);
            driverOption.AddAdditionalCapability(MobileCapabilityType.AutomationName, GlobalVar.AutomationName);
            driverOption.AddAdditionalCapability("autoGrantPermissions", Permissions);
            driverOption.AddAdditionalCapability("allowSessionOverride", SessionOverride);
            driverOption.AddAdditionalCapability("appPackage", AppPackage);
            driverOption.AddAdditionalCapability("appActivity", AppActivity + "EntryActivity");
            return driverOption;
        }

        public static AppiumOptions CreateWebCapabilities()
        {
            var driverOption = new AppiumOptions();
            driverOption.AddAdditionalCapability(MobileCapabilityType.PlatformName, PlatformName);
            driverOption.AddAdditionalCapability(MobileCapabilityType.DeviceName, DeviceName);
            driverOption.AddAdditionalCapability(MobileCapabilityType.NewCommandTimeout, Timeout);
            driverOption.AddAdditionalCapability(MobileCapabilityType.App, ApkPath);
            driverOption.AddAdditionalCapability(MobileCapabilityType.Udid, Udid);
            driverOption.AddAdditionalCapability(MobileCapabilityType.AutomationName, GlobalVar.AutomationName);
            driverOption.AddAdditionalCapability("autoGrantPermissions", Permissions);
            driverOption.AddAdditionalCapability("allowSessionOverride", SessionOverride);
            driverOption.AddAdditionalCapability("appPackage", AppPackage);
            driverOption.AddAdditionalCapability("appActivity", AppActivity + "EntryActivity");
            return driverOption;
        }


        /// <summary>
        /// Switch context in the driver, like Native or Web apps. Used this when you have an app that opens a web
        /// application (e.g: google), so you need to switch context to target the correct API.
        /// </summary>
        /// <param name="context">Name of the context you need to switch.</param>
        public static void ContextSwitch(string context = "NATIVE_APP")
        {
            var contexts = GlobalVar.AndroidDriver.Contexts;
            foreach (var c in contexts)
            {
                if (c.Contains(context))
                {
                    GlobalVar.AndroidDriver.Context = c;
                    break;
                }
            }
        }

        public static void StartServer()
        {
            var appiumLocalService = new AppiumServiceBuilder();
            appiumLocalService.UsingPort(GlobalVar.Port);
            appiumLocalService.WithIPAddress(GlobalVar.IPAddress.ToString());
            appiumLocalService.Build().Start();
        }

        public static void StartServerCMD()
        {
            if (!IsServerRunning())
            {
                _process = new Process();
                //var fileName = @"C:\Users\ffanelli\AppData\Roaming\npm\appium.cmd";
                var startInfo = new ProcessStartInfo("Cmd");
                //startInfo.FileName = fileName;
                startInfo.UseShellExecute = true;
                // Use the line below if cmd is closing after it executes the task... also comment all fileName uses if u do this
                startInfo.Arguments = @"/k \Users\ffanelli\AppData\Roaming\npm\appium.cmd -a 127.0.0.1 -p 4723";
                _process.StartInfo = startInfo;
                _process.Start();
            }
            else
            {
                // this command will kill the instance of Node.exe, should be the PID 11316
                Process.Start("Cmd", "taskkill /f /im node.exe");
                //If u want to check then run through cmd "netstat -nao|findstr 4723" and u can see the PID which was using Appium server
                
                //Need to check if this works
                StartServerCMD();
            }
        }


        /// <summary>
        /// THIS NEEDS TO BE CHECKED, LA CAGUE EN ALGUN LADO
        /// Check if appium server is still running.
        /// </summary>
        /// <returns><see langword="true"/> if server is not running; otherwise <see langword="false"/></returns>
        public static bool IsServerRunning()
        {
            try
            {
                var serverSocket = GlobalVar.Socket;
                // Poll: returns true if connected is closed, reset, terminated or pending (no active connection) or connection is active and there is data available for reading.
                var cond1 = serverSocket.Poll(1000, SelectMode.SelectRead);
                // Available: returns number of bytes available for reading
                var cond2 = serverSocket.Available == 0;
                // Connected: check in case socket has not been initialized
                if ((cond1 && cond2) || !serverSocket.Connected)
                    return false;

                var socket = new TcpListener(GlobalVar.IPAddress, GlobalVar.Port);
                // Poll: returns true if connected is closed, reset, terminated or pending (no active connection) or connection is active and there is data available for reading.
                cond1 = socket.Server.Poll(1000, SelectMode.SelectRead);
                // Available: returns number of bytes available for reading
                cond2 = socket.Server.Available == 0;
                // Connected: check in case socket has not been initialized
                if ((cond1 && cond2) || !socket.Server.Connected)
                    return false;
            }
            catch
            {
                return true;
            }

            return false;
        }

        public static void StopServer()
        {
            _process.Kill();
            //The one below perform a clean-up logic, but maybe the process is still running if it chooses to ignore the request (pretty lazy) 
            //or do nothing if the process does not have a main window (in case u decide to use appium without cmd console open)
            //_process.CloseMainWindow();
        }

        public static void StartEmulator()
        {
            if (IsEmulatorRunning())
            {
                var fileName = GlobalVar.PixelEmulator;
                Process.Start(fileName);
            }
        }

        public static bool IsEmulatorRunning()
        {
            try
            {
                var device = (string) GlobalVar.AndroidDriver.Capabilities.GetCapability(MobileCapabilityType.DeviceName);
                if (device.Contains(GlobalVar.DeviceName))
                    return true;
            }
            catch {} //If an error occurs then that means that the driver is not istanciated or the emulator is not started, so return false

            return false;
        }


        /// <summary>
        /// Kills a specific process.
        /// </summary>
        /// <param name="serviceName">Process to kill.</param>
        public static void KillProcess(string serviceName)
        {
            try
            {
                var processes = Process.GetProcesses();
                foreach (var proc in processes)
                {
                    var processName = proc.ProcessName;
                    if (processName.ToLowerInvariant().Contains(serviceName.ToLowerInvariant()))
                    {
                        proc.Kill();
                        proc.WaitForExit();
                    }
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("KillProcess threw an exception: " + ex.Message);
            }
        }

        public static void SetupDriver(MobileDriver driverType, bool installApp = false)
        {
            string ErrMsg;

            switch (driverType)
            {
                case MobileDriver.Android:
                    SetupOptions();
                    MiscFunctions.SetDriver(Driver);

                    //Install MC apk
                    if (installApp)
                        Driver.InstallApp(GlobalVar.ApkPath);
                    break;
                case MobileDriver.Ios:
                    break;
                case MobileDriver.Web:
                    //killProcess(out ErrMsg, "chrome");
                    //killProcess(out ErrMsg, "chromedriver");
                    break;
            }
        }



        #region ERROR


        /// <summary>
        /// Check the status of the test that is running. If it fails then it calls Listener class.
        /// </summary>
        public static void CheckStatus()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            if (status == TestStatus.Failed)
            {
                var listener = new Listeners();
                var report = TestContext.CurrentContext.Result;
                listener.OnTestEvent(TestContext.CurrentContext.Test.Name);
            }
        }


        /// <summary>
        /// Take a screen shot and save it on a folder name Screenshots.
        /// </summary>
        /// <param name="testName">Test name of the test that is running.</param>
        /// <param name="path">Path were one wants to save all the images.</param>
        public static void GetScreenShot(string testName, string path)
        {
            try
            {
                var timeStamp = DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss");
                // Need to cast, so that android knows he needs to take a pic. If I don't cast my driver, getscreenshot may not work
                var screenShot = ((ITakesScreenshot)GlobalVar.AndroidDriver).GetScreenshot();
                var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                //One thngs that need an update is if the folde of screenshots does not exits, then I must create it.
                screenShot.SaveAsFile(Path.Combine(directory, @"..\..\..\", "Screenshots", timeStamp + " " + testName + ".png"), ScreenshotImageFormat.Png);
                //screenShot.SaveAsFile(Path.Combine(path, timeStamp + " " + testName + ".png"), ScreenshotImageFormat.Png);
            }
            catch (Exception e)
            {
            }
            //Or I can try ussing this, need to check which one is better
            //screenShot.SaveAsFile($"{path}{timeStamp} {testName}", ScreenshotImageFormat.Tiff);
        }


        #endregion


        #region REPORTERS


        public static void Report(IExtentReporter report)
        {
            var extent = new ExtentReports();
            extent.AttachReporter(report);
        }


        public static void BuildHtmlReport()
        {
            //Build my own reports
            var htmlReport = new ExtentHtmlReporter(@"C:\Users\ffanelli\Desktop\ExtentReport\testReport.html");
            htmlReport.Config.Theme = Theme.Dark;
            htmlReport.Config.DocumentTitle = "Test Report | Fernando";
            htmlReport.Config.ReportName = "Test Report Name | Fernando";

            var extent = new ExtentReports();
            extent.AttachReporter(htmlReport);

            //var loggerReport = new ExtentLoggerReporter("VER Q FOLDER USO");
            ////Send the report to be attached to a specific location
            //Report(htmlReport);
            //Report(loggerReport);
        }


        public static void ExtentReport()
        {

        }


        #endregion
    }
}
