using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Framework.Android;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using static Framework.Utility.Share;
using By = OpenQA.Selenium.By;

namespace Framework.Utility.Activity
{
    public static class Misc
    {

        #region BUILDERS FOR SEARCHERS


        /// <summary>
        /// Creates a string mostly used to search elements using FindElement method.
        /// </summary>
        /// <param name="isWidget">True if it is a Widget, false if it's a View.</param>
        /// <param name="element">Represents the Enum in Share class.</param>
        /// <returns>The string used to search element. Ex: android.widget.Button</returns>
        private static string StringCreation(bool isWidget = true, Element element = Element.EditText)
        {
            var genericString = GlobalVar.Device;
            genericString += (isWidget) ? ".widget." :  ".view.";

            switch (element)
            {
                case Element.ActionMenuView:
                    return genericString += Element.ActionMenuView;
                case Element.AdapterView:
                    return genericString += Element.AdapterView;
                case Element.Button:
                    return genericString += Element.Button;
                case Element.CalendarView:
                    return genericString += Element.CalendarView;
                case Element.CheckBox:
                    return genericString += Element.CheckBox;
                case Element.DatePicker:
                    return genericString += Element.DatePicker;
                case Element.EditText:
                    return genericString += Element.EditText;
                case Element.ExpandableListView:
                    return genericString += Element.ExpandableListView;
                case Element.ImageButton:
                    return genericString += Element.ImageButton;
                case Element.ImageView:
                    return genericString += Element.ImageView;
                case Element.LinearLayout:
                    return genericString += Element.LinearLayout;
                case Element.ListView:
                    return genericString += Element.ListView;
                case Element.RadioButton:
                    return genericString += Element.RadioButton;
                case Element.RelativeLayout:
                    return genericString += Element.RelativeLayout;
                case Element.ScrollView:
                    return genericString += Element.ScrollView;
                case Element.TableLayout:
                    return genericString += Element.TableLayout;
                case Element.TextView:
                    return genericString += Element.TextView;
                case Element.Toast:
                    return genericString += Element.Toast;
            }

            return null;
        }


        /// <summary>
        /// Returns the complete string to be used to search using the FindElement method.
        /// </summary>
        /// <param name="text">Use it if you need to concatenate something at the start of the string</param>
        /// <param name="isWidget">True if it is a Widget, false if it's a View.</param>
        /// <param name="element">Represents the Enum in Share class.</param>
        /// <returns>The string used to search element. Ex: android.widget.Button or //android.widget.TextView</returns>
        private static string Builder(string text, bool isWidget = true, Element element = Element.EditText)
        {
            return text + StringCreation(isWidget, element);
        }


        /// <summary>
        /// Creates an XPath to be used in the FindElement method using a By.XPath locator.
        /// </summary>
        /// <param name="isWidget">True if it is a Widget, false if it's a View.</param>
        /// <param name="element">Represents the Enum in Share class.</param>
        /// <returns>The string used to search element. Ex: //android.widget.TextView</returns>
        public static string BuildXPath(bool isWidget = true, Element element = Element.EditText)
        {
            return Builder("//", isWidget, element);
        }


        /// <summary>
        /// Creates an attribute locator to be used in the FindElement method.
        /// </summary>
        /// <param name="isWidget">True if it is a Widget, false if it's a View.</param>
        /// <param name="element">Represents the Enum in Share class.</param>
        /// <returns>The string used to search element. Ex: android.widget.TextView</returns>
        public static string BuildElement(bool isWidget = true, Element element = Element.EditText)
        {
            return Builder("", isWidget, element);
        }
        

        #endregion END OF BUILDERS FOR SEARCHERS


        #region ANDROID EXTRA FUNCTIONS


        /// <summary>
        /// Hide the Android Keyboard.
        /// </summary>
        public static void HideKeyboard()
        {
            GlobalVar.AndroidDriver.HideKeyboard();
        }


        /// <summary>
        /// Depending on the given parameter it will emulate a Key Event.
        /// </summary>
        /// <param name="keyCode">Represents the Enum in Share class.</param>
        public static void PressKeyCode(KeyCode keyCode = KeyCode.Back)
        {
            try
            {
                switch (keyCode)
                {
                    case KeyCode.Back:
                        GlobalVar.AndroidDriver.PressKeyCode(AndroidKeyCode.Back);
                        break;
                    case KeyCode.Delete:
                        GlobalVar.AndroidDriver.PressKeyCode(AndroidKeyCode.Del);
                        break;
                    case KeyCode.Enter:
                        GlobalVar.AndroidDriver.PressKeyCode(AndroidKeyCode.Enter);
                        break;
                    case KeyCode.Home:
                        GlobalVar.AndroidDriver.PressKeyCode(AndroidKeyCode.Home);
                        break;
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("PressKeyCode threw an exception: " + ex.Message);
            }
        }


        #region SCROLL FUNCTIONS


        #region TO PARTIAL VIEW WITH SINGLE SCROLLABLES


        /// <summary>
        /// It will scroll till it finds the element based on the given scrollable. If you need something that is below that
        /// element, this will not work, as this will stop scrolling when it finds the element. In this case use the
        /// ScrollToFullView method.
        /// </summary>
        /// <param name="scrollable">Represents the Enum in Share class.</param>
        /// <returns>The <see cref="AppiumWebElement"/> of the element found</returns>
        public static AppiumWebElement ScrollToPartialView(Scrollable scrollable)
        {
            GlobalVar.AndroidDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVar.TimeSpan);
            var uiAutomator = new UiScrollable().Build(scrollable);
            try
            {
                return GlobalVar.AndroidDriver.FindElementByAndroidUIAutomator(uiAutomator);
            }
            catch (Exception ex)
            {
                Assert.Fail("ScrollToPartialView threw an exception: " + ex.Message);
            }
            return null;
        }


        /// <summary>
        /// It will scroll till it finds the element based on the given direction. If you need something that is below that
        /// element, this will not work, as this will stop scrolling when it finds the element. In this case use the
        /// ScrollToFullView method.
        /// </summary>
        /// <param name="direction">Represents the Enum in Share class.</param>
        /// <returns>The <see cref="AppiumWebElement"/> of the element found</returns>
        public static AppiumWebElement ScrollToPartialView(ListDirection direction)
        {
            GlobalVar.AndroidDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVar.TimeSpan);
            var uiAutomator = new UiScrollable().Build(direction);
            try
            {
                return GlobalVar.AndroidDriver.FindElementByAndroidUIAutomator(uiAutomator);
            }
            catch (Exception ex)
            {
                Assert.Fail("ScrollToPartialView threw an exception: " + ex.Message);
            }
            return null;
        }


        /// <summary>
        /// It will scroll till it finds the element based on the given scrollable and text. If you need something that is below that
        /// element, this will not work, as this will stop scrolling when it finds the element. In this case use the
        /// ScrollToFullView method.
        /// </summary>
        /// <param name="scrollable">Represents the Enum in Share class.</param>
        /// <param name="text">The text to match the element to be found.</param>
        /// <returns>The <see cref="AppiumWebElement"/> of the element found</returns>
        public static AppiumWebElement ScrollToPartialView(Scrollable scrollable, string text)
        {
            GlobalVar.AndroidDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVar.TimeSpan);
            var uiAutomator = new UiScrollable().Build(scrollable, text);
            try
            {
                return GlobalVar.AndroidDriver.FindElementByAndroidUIAutomator(uiAutomator);
            }
            catch (Exception ex)
            {
                Assert.Fail("ScrollToPartialView threw an exception: " + ex.Message);
            }
            return null;
        }


        /// <summary>
        /// It will scroll till it finds the element based on the given selector and text. If you need something that is below that
        /// element, this will not work, as this will stop scrolling when it finds the element. In this case use the
        /// ScrollToFullView method.
        /// </summary>
        /// <param name="selector">Represents the Enum in Share class.</param>
        /// <param name="text">The text to match the element to be found.</param>
        /// <param name="useFirst">Use true, if the string created did not worked, then use false</param>
        /// <returns>The <see cref="AppiumWebElement"/> of the element found</returns>
        public static AppiumWebElement ScrollToPartialView(Selector selector, string text, bool useFirst)
        {
            GlobalVar.AndroidDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVar.TimeSpan);
            var uiAutomator = new UiScrollable().Build(selector, text, useFirst);
            try
            {
                return GlobalVar.AndroidDriver.FindElementByAndroidUIAutomator(uiAutomator);
            }
            catch (Exception ex)
            {
                Assert.Fail("ScrollToPartialView threw an exception: " + ex.Message);
            }
            return null;
        }


        /// <summary>
        /// It will scroll till it finds the element based on the given parameter. If you need something that is below that
        /// element, this will not work, as this will stop scrolling when it finds the element. In this case use the
        /// ScrollToFullView method.
        /// </summary>
        /// <param name="noSwipeZone">Percentage of dead zone when swiping</param>
        /// <returns>The <see cref="AppiumWebElement"/> of the element found</returns>
        public static AppiumWebElement ScrollToPartialView(double noSwipeZone)
        {
            GlobalVar.AndroidDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVar.TimeSpan);
            var uiAutomator = new UiScrollable().Build(noSwipeZone);
            try
            {
                return GlobalVar.AndroidDriver.FindElementByAndroidUIAutomator(uiAutomator);
            }
            catch (Exception ex)
            {
                Assert.Fail("ScrollToPartialView threw an exception: " + ex.Message);
            }
            return null;
        }


        /// <summary>
        /// It will scroll till it finds the element based on the given scrollable and value. If you need something that is below that
        /// element, this will not work, as this will stop scrolling when it finds the element. In this case use the
        /// ScrollToFullView method.
        /// </summary>
        /// <param name="scrollable">Represents the Enum in Share class.</param>
        /// <param name="value">The amount of swipes/flings to be done.</param>
        /// <returns>The <see cref="AppiumWebElement"/> of the element found</returns>


        /// <summary>
        /// It will scroll till it finds the element based on the given scrollable,steps and swipes. If you need something that is below that
        /// element, this will not work, as this will stop scrolling when it finds the element. In this case use the
        /// ScrollToFullView method.
        /// </summary>
        /// <param name="scrollable">Represents the Enum in Share class.</param>
        /// <param name="steps">The amount of steps to be done.</param>
        /// <param name="swipes">The amount of swipes to be done.</param>
        /// <returns>The <see cref="AppiumWebElement"/> of the element found</returns>
        public static AppiumWebElement ScrollToPartialView(Scrollable scrollable, int steps, int swipes)
        {
            GlobalVar.AndroidDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVar.TimeSpan);
            var uiAutomator = new UiScrollable().Build(scrollable, steps, swipes);
            try
            {
                return GlobalVar.AndroidDriver.FindElementByAndroidUIAutomator(uiAutomator);
            }
            catch (Exception ex)
            {
                Assert.Fail("ScrollToPartialView threw an exception: " + ex.Message);
            }
            return null;
        }


        #endregion END OF TO PARTIAL VIEW WITH SINGLE SCROLLABLES


        #region TO PARTIAL VIEW WITH CHILD SCROLLABLES


        /// <summary>
        /// It will scroll till it finds the child element based on the given selector and instance. If you need something that is below that
        /// element, this will not work, as this will stop scrolling when it finds the element. In this case use the
        /// ScrollToFullView method.
        /// </summary>
        /// <param name="selector">Represents the Enum in Share class.</param>
        /// <param name="instance">instance of the element you want to find, most of times is 0.</param>
        public static AppiumWebElement ScrollToPartialView(Selector selector, int instance = 0)
        {
            GlobalVar.AndroidDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVar.TimeSpan);
            var uiAutomator = new UiScrollable().BuildChild(selector, instance);
            try
            {
                return GlobalVar.AndroidDriver.FindElementByAndroidUIAutomator(uiAutomator);
            }
            catch (Exception ex)
            {
                Assert.Fail("ScrollToPartialView threw an exception: " + ex.Message);
            }
            return null;
        }


        /// <summary>
        /// It will scroll till it finds the child element based on the given scrollable, selector and text. If you need something that is below that
        /// element, this will not work, as this will stop scrolling when it finds the element. In this case use the
        /// ScrollToFullView method.
        /// </summary>
        /// <param name="scrollable">Represents the Enum in Share class.</param>
        /// <param name="selector">Represents the Enum in Share class.</param>
        /// <param name="text">The text to match the element to be found.</param>
        /// <param name="allowScrollSearch">Set to true if scrolling is allow on the object.</param>
        public static AppiumWebElement ScrollToPartialView(Scrollable scrollable, Selector selector, string text, bool allowScrollSearch)
        {
            GlobalVar.AndroidDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVar.TimeSpan);
            var uiAutomator = new UiScrollable().BuildChild(scrollable, selector, text, allowScrollSearch);
            try
            {
                return GlobalVar.AndroidDriver.FindElementByAndroidUIAutomator(uiAutomator);
            }
            catch (Exception ex)
            {
                Assert.Fail("ScrollToPartialView threw an exception: " + ex.Message);
            }
            return null;
        }


        #endregion END OF TO PARTIAL VIEW WITH CHILD SCROLLABLES


        #region TO FULL VIEW WITH SINGLE SCROLLABLES


        /// <summary>
        /// It will scroll till it finds and shows the full element based on the given parameters.
        /// </summary>
        /// <param name="selector1">Represents the Enum in Share class.</param>
        /// <param name="attribute">The attribute to use, I recommend to use Id.</param>
        /// <param name="selector2">Represents the Enum in Share class.</param>
        /// <param name="text">The text to match the element to be found.</param>
        /// <param name="useFirst">Set to true if scrolling is allow on the object.</param>
        public static AppiumWebElement ScrollToFullView(Selector selector1, string attribute, Selector selector2 , string text, bool useFirst)
        {
            GlobalVar.AndroidDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVar.TimeSpan);
            var uiAutomator = new UiScrollable(selector1, attribute).Build(selector2, text, useFirst);
            try
            {
                return GlobalVar.AndroidDriver.FindElementByAndroidUIAutomator(uiAutomator);
            }
            catch (Exception ex)
            {
                Assert.Fail("ScrollToFullView threw an exception: " + ex.Message);
            }
            return null;
        }

        #endregion END OF TO FULL VIEW WITH SINGLE SCROLLABLES


        #endregion END OF SCROLL FUNCTIONS


        #region TOAST FUNCTIONS


        /// <summary>
        /// It will get the attribute of the toast message by using the given parameters.
        /// </summary>
        /// <param name="attribute">Attribute to retrieve from the Toast Message.</param>
        /// <param name="position">Position of the Toast Message</param>
        /// <param name="elem">Represents the Enum in the Share class.</param>
        /// <param name="widget">True if it is a Widget, false if it is a View.</param>
        public static string ToastMessage(string attribute, int position = 1, Element elem = Element.Toast, bool widget = true)
        {
            GlobalVar.AndroidDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVar.TimeSpan);
            var xPath = BuildXPath(widget, elem);
            try
            {
                var element = GlobalVar.AndroidDriver.FindElementByXPath(xPath + "[" + position + "]");
                return element.GetAttribute(attribute);
            }
            catch (Exception ex)
            {
                Assert.Fail("ToastMessage threw an exception: " + ex.Message);
            }

            return null;
        }


        /// <summary>
        /// It will get the element of the toast message by using the given parameters.
        /// </summary>
        /// <param name="text">The text to match the element to be found.</param>
        /// <param name="elem">Represents the Enum in the Share class.</param>
        /// <param name="widget">True if it is a Widget, false if it is a View.</param>
        public static AppiumWebElement ToastMessage(string text, Element elem = Element.Toast, bool widget = true)
        {
            GlobalVar.AndroidDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVar.TimeSpan);
            var xPath = BuildXPath(widget, elem);
            AppiumWebElement element = null;
            try
            {
                element = GlobalVar.AndroidDriver.FindElementByXPath(xPath + "[@text='" + text + "']");
            }
            catch (Exception ex)
            {
                Assert.Fail("ToastMessage threw an exception: " + ex.Message);
            }

            return element;
        }


        /// <summary>
        /// It will get the element of the toast message using the given text.
        /// </summary>
        /// <param name="text">The text to match the element to be found.</param>
        /// <param name="elem">Represents the Enum in the Share class.</param>
        /// <param name="widget">True if it is a Widget, false if it is a View.</param>
        public static AppiumWebElement ToastMessageByText(string text, Element elem = Element.Toast, bool widget = true)
        {
            GlobalVar.AndroidDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVar.TimeSpan);
            var xPath = BuildXPath(widget, elem);
            try
            {
                var elements = GlobalVar.AndroidDriver.FindElementsByXPath(xPath);
                foreach (var element in elements)
                {
                    if (element.Text.Contains(text))
                        return element;
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("ToastMessageByText threw an exception: " + ex.Message);
            }

            return null;
        }


        #endregion TOAST FUNCTIONS


        #endregion ANDROID EXTRA FUNCTIONS


        // ************ DATE 10/16/2020 ************
        // All the Builders used till date.
        // ***** IMPORTANT: This Builder return a new class of type By from OpenQA.Selenium
        // ************ --------------- ************
        #region BUILDERS


        /// <summary>
        /// Builds a By object using the enum pass 
        /// </summary>
        /// <param name="by">Represents the Enum in Share class.</param>
        /// <param name="value">Value used to find the element.</param>
        /// <param name="element">The element type.</param>
        /// <param name="isWidget">True if it is a widget, false if it is a View.</param>
        public static By BuildBy(Share.By by, Share.Element element, bool isWidget = true)
        {
            var attribute = Misc.BuildElement(isWidget, element);
            By _by = null;
            switch (by)
            {
                case Share.By.ClassName:
                    _by = By.ClassName(attribute);
                    break;
                case Share.By.CssSelector:
                    _by = By.CssSelector(attribute);
                    break;
                case Share.By.Id:
                    _by = By.Id(attribute);
                    break;
                case Share.By.LinkText:
                    _by = By.LinkText(attribute);
                    break;
                case Share.By.Name:
                    _by = By.Name(attribute);
                    break;
                case Share.By.PartialLinkText:
                    _by = By.PartialLinkText(attribute);
                    break;
                case Share.By.TagName:
                    _by = By.TagName(attribute);
                    break;
                case Share.By.XPath:
                    _by = By.XPath(attribute);
                    break;
            }
            return _by;
        }


        #endregion END OF BUILDERS


        public static void Sleep(int ms)
        {
            Thread.Sleep(ms);
        }
    }
}
