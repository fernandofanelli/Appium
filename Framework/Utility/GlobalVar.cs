using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using OpenQA.Selenium;
using static Framework.Utility.Share;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;

namespace Framework.Utility
{
    public static class GlobalVar
    {
        //*************** <<APPIUM>> ***************
        public static AndroidDriver<AndroidElement> AndroidDriver = null;
        public static AppiumDriver<IOSElement> IosDriver = null;
        public static AppiumDriver<IWebElement> WebDriver = null;
        public static AndroidDriver<AndroidElement> Driver;

        public static string LanguageEng = "en";
        public static string LanguageSpa = "es";

        public static int TimeSpan = 10;
        //public static TimeSpan TimeSpan = new TimeSpan(0,0,TimeSpan);


        //*************** <<APPIUM OPTIONS>> ***************
        public static string PlatformName = "Android";
        public static string DeviceName = "Android 28";
        public static int Timeout = 500000;
        public static string Udid = "emulator-5554";
        public static string AutomationName = "UiAutomator2";
        public static bool Permissions = true;
        public static bool SessionOverride = false;
        public static string AppPackage = "com.dsiglobal.mobileclient";
        public static string AppActivity = "com.dsiglobal.mobileclient.screens.";
        public static string ApkPath = @"C:\Users\ffanelli\Desktop\APK\mobile_client.apk";
        public static string ApkPathDemos = @"C:\Users\ffanelli\Desktop\APK\ApiDemos-debug.apk";


        //*************** <<APPIUM SERVER>> ***************
        public static Uri Uri = new Uri("http://localhost:4723/wd/hub");
        public static int Port = 4723;
        // Get Host IP Adress that is used to establish a connection, so we get an IP: 127.0.0.1
        //If a host has multiple addresses, u will get the first one.
        public static IPHostEntry Host = Dns.GetHostEntry("localhost");
        public static IPAddress IPAddress = Host.AddressList[1];
        public static IPEndPoint LocalEndPoint = new IPEndPoint(IPAddress, Port);
        public static Socket Socket = new Socket(IPAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);


        //*************** <<Activity Variables>> ***************
        public static string Device = "android";


        //*************** <<USER INFO>> ***************
        public static string UserId = "****";

        //*************** <<DEVICES>> ***************
        public static string PixelEmulator = @"C:\Users\ffanelli\Desktop\AndroidEmulators\pixelapi28.bat";
        public static string NexusEmulator = @"C:\Users\ffanelli\Desktop\AndroidEmulators\nexusapi28";
    }
}
