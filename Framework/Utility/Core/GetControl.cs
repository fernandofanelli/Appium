using System;
using System.Collections.Generic;
using System.Text;
using Framework.Android;
using Framework.Utility.Activity;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using static Framework.Utility.Share;
using By = OpenQA.Selenium.By;
using ExpectedConditions = Framework.Utility.Activity.ExpectedConditions;

namespace Framework.Utility.Core
{
    public static class GetControl
    {


        // ************ DATE 10/16/2020 ************
        // ***** IMPORTANT: All GetControl by CLASSNAME return either a AppiumWebElement or a Collection of AppiumWebElement.
        // ************ --------------- ************
        #region BY CLASSNAME


        /// <summary>
        /// Finds the first element in the screen that matches the className criteria.
        /// </summary>
        /// <param name="className">ClassName to find the object</param>
        /// <see cref="OpenQA.Selenium.By.ClassName" />
        public static AppiumWebElement ByClass(string className)
        {
            GlobalVar.AndroidDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVar.TimeSpan);
            AppiumWebElement element = null;
            try
            {
                element = GlobalVar.AndroidDriver.FindElementByClassName(GlobalVar.Device + "." + className);
            }
            catch (Exception ex)
            {
                Assert.Fail("GetControlByClass threw an exception: " + ex.Message);
            }
            return element;
        }


        /// <summary>
        /// Finds a collection of elements and then iterates every element till the text matches (completely or partial).
        /// </summary>
        /// <param name="className">ClassName to find the object</param>
        /// <param name="text">Text to match a specific element</param>
        /// <see cref="OpenQA.Selenium.By.ClassName" />
        public static AppiumWebElement ByClass(string className, string text)
        {
            GlobalVar.AndroidDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVar.TimeSpan);
            try
            {
                IEnumerable<AppiumWebElement> elements = GlobalVar.AndroidDriver.FindElementsByClassName(GlobalVar.Device + "." + className);
                foreach (var elem in elements)
                {
                    if (elem.Text.ToLower().Contains(text.ToLower()))
                        return elem;
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("GetControlByClass threw an exception: " + ex.Message);
            }
            return null;
        }


        /// <summary>
        /// Finds a collection of elements that matches the className criteria.
        /// </summary>
        /// <param name="className">ClassName to find the objects</param>
        /// <see cref="OpenQA.Selenium.By.ClassName" />
        public static IEnumerable<AppiumWebElement> CollectionByClass(string className)
        {
            GlobalVar.AndroidDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVar.TimeSpan);
            IEnumerable<AppiumWebElement> elements = null;

            try
            {
                elements = GlobalVar.AndroidDriver.FindElementsByClassName(GlobalVar.Device + "." + className);
            }
            catch (Exception ex)
            {
                Assert.Fail("GetControlCollectionByClass threw an exception: " + ex.Message);
            }

            return elements;
        }


        #endregion END OF BY CLASSNAME


        // ************ DATE 10/16/2020 ************
        // ***** IMPORTANT: All GetControl by ID return either a AppiumWebElement or a Collection of AppiumWebElement.
        // ************ --------------- ************
        #region BY ID


        /// <summary>
        /// Finds the first element in the screen that matches the id criteria.
        /// </summary>
        /// <param name="id">Id to find the object</param>
        /// <see cref="OpenQA.Selenium.By.Id" />
        public static AppiumWebElement ById(string id)
        {
            GlobalVar.AndroidDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVar.TimeSpan);
            AppiumWebElement element = null;
            try
            {
                element = GlobalVar.AndroidDriver.FindElementById(id);
            }
            catch (Exception ex)
            {
                Assert.Fail("GetControlById threw an exception: " + ex.Message);
            }
            return element;
        }


        /// <summary>
        /// Finds the first element in the screen that matches the id criteria.
        /// </summary>
        /// <param name="id">Id to find the object</param>
        /// <param name="text">Text to match a specific element</param>
        /// <see cref="OpenQA.Selenium.By.Id" />
        public static AppiumWebElement ById(string id, string text)
        {
            GlobalVar.AndroidDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVar.TimeSpan);
            try
            {
                IEnumerable<AppiumWebElement> elements = GlobalVar.AndroidDriver.FindElementsById(id);
                foreach (var elem in elements)
                {
                    if (elem.Text.ToLower().Contains(text.ToLower()))
                        return elem;
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("GetControlById threw an exception: " + ex.Message);
            }
            return null;
        }


        /// <summary>
        /// Finds a collection of elements that matches the id criteria.
        /// </summary>
        /// <param name="id">id to find the objects</param>
        /// <see cref="OpenQA.Selenium.By.Id" />
        public static IEnumerable<AppiumWebElement> CollectionById(string id)
        {
            GlobalVar.AndroidDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVar.TimeSpan);
            IEnumerable<AppiumWebElement> elements = null;
            try
            {
                elements = GlobalVar.AndroidDriver.FindElementsById(id);
            }
            catch (Exception ex)
            {
                Assert.Fail("GetControlCollectionById threw an exception: " + ex.Message);
            }
            return elements;
        }

        #endregion END OF BY ID


        // ************ DATE 10/16/2020 ************
        // ***** IMPORTANT: All GetControl by XPATH return either a AppiumWebElement or a Collection of AppiumWebElement.
        // ************ --------------- ************
        #region BY XPATH


        /// <summary>
        /// Finds the first element in the screen that matches the xPath criteria.
        /// </summary>
        /// <param name="text">Text to match a specific element</param>
        /// <param name="elem">Represents the Enum in Share class</param>
        /// <param name="widget">boolean if this is a widget</param>
        /// <see cref="OpenQA.Selenium.By.XPath" />
        public static AppiumWebElement ByXPath(string text, Element elem = Element.EditText, bool widget = true)
        {
            GlobalVar.AndroidDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVar.TimeSpan);
            var xPath = Misc.BuildXPath(widget, elem);
            AppiumWebElement element = null;
            try
            {
                element = GlobalVar.AndroidDriver.FindElementByXPath(xPath + "[@text='"+ text + "']" );
            }
            catch (Exception ex)
            {
                Assert.Fail("GetControlByXPath threw an exception: " + ex.Message);
            }
            return element;
        }


        /// <summary>
        /// Finds the first element in the screen that matches the xPath criteria.
        /// </summary>
        /// <param name="position">Position to match a specific element</param>
        /// <param name="elem">Represents the Enum in Share class</param>
        /// <param name="widget">boolean if this is a widget</param>
        /// <see cref="OpenQA.Selenium.By.XPath" />
        public static AppiumWebElement ByXPath(int position, Element elem = Element.EditText, bool widget = true)
        {
            GlobalVar.AndroidDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVar.TimeSpan);
            var xPath = Misc.BuildXPath(widget, elem);
            AppiumWebElement element = null;
            try
            {
                element = GlobalVar.AndroidDriver.FindElementByXPath("(" + xPath + ")" + "[" + position + "]");
            }
            catch (Exception ex)
            {
                Assert.Fail("GetControlByXPath threw an exception: " + ex.Message);
            }
            return element;
        }


        /// <summary>
        /// Finds a collection of elements that matches the xPath criteria.
        /// </summary>
        /// <param name="elem">Represents the Enum in Share class</param>
        /// <param name="widget">boolean if this is a widget</param>
        /// <see cref="OpenQA.Selenium.By.XPath" />
        public static IEnumerable<AppiumWebElement> CollectionByXPath(Element elem = Element.EditText, bool widget = true)
        {
            GlobalVar.AndroidDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVar.TimeSpan);
            var xPath = Misc.BuildXPath(widget, elem);
            IEnumerable<AppiumWebElement> elements = null;
            try
            {
                elements = GlobalVar.AndroidDriver.FindElementsByXPath("(" + xPath + ")");
            }
            catch (Exception ex)
            {
                Assert.Fail("GetControlCollectionByXPath threw an exception: " + ex.Message);
            }
            return elements;
        }


        #endregion END OF BY XPATH


        // ************ DATE 10/16/2020 ************
        // ***** IMPORTANT: All GetControl by UIAUTOMATOR return either a AppiumWebElement or a Collection of AppiumWebElement.
        // ************ --------------- ************
        #region BY UIAUTOMATOR


        /// <summary>
        /// Finds the first element in the screen that matches the UiAutomator criteria.
        /// </summary>
        /// <param name="attribute">All the possible attributes that an element has, like text</param>
        /// <param name="value">The value to match with the attribute</param>
        public static AppiumWebElement ByUiAutomator(string attribute, string value)
        {
            GlobalVar.AndroidDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVar.TimeSpan);
            AppiumWebElement element = null;
            try
            {
                element = GlobalVar.AndroidDriver.FindElementByAndroidUIAutomator(attribute + "(\"" + value + "\")");
            }
            catch (Exception ex)
            {
                Assert.Fail("GetControlByUiAutomator threw an exception: " + ex.Message);
            }
            return element;
        }


        // ************ DATE 10/16/2020 ************
        // All the possible Selectors to search for a single element till date.
        // ************ --------------- ************
        #region USING SINGLE SELECTORS


        /// <summary>
        /// Finds the first element in the screen that matches the UiAutomator criteria using a UiSelector.
        /// </summary>
        /// <param name="selector"> Represents the Enum in Share class </param>
        /// <param name="value"> the boolean value of an element to be found </param>
        /// <param name="position"> position of an object on the layout hierarchy </param>
        public static AppiumWebElement ByUiAutomatorSingleSelector(Selector selector, bool value, int position = 0)
        {
            GlobalVar.AndroidDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVar.TimeSpan);
            AppiumWebElement element = null;
            var uiAutomator = new UiSelector().Build(selector, value, position);
            try
            {
                element = GlobalVar.AndroidDriver.FindElementByAndroidUIAutomator(uiAutomator);
            }
            catch (Exception ex)
            {
                Assert.Fail("GetControlByUiAutomatorSingleSelector threw an exception: " + ex.Message);
            }
            return element;
        }


        /// <summary>
        /// Finds the first element in the screen that matches the UiAutomator criteria using a UiSelector.
        /// </summary>
        /// <param name="selector"> Represents the Enum in Share class </param>
        /// <param name="text"> the partial/complete text of an element to be found </param>
        /// <param name="position"> position of an object on the layout hierarchy </param>
        public static AppiumWebElement ByUiAutomatorSingleSelector(Selector selector, string text, int position = 0)
        {
            GlobalVar.AndroidDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVar.TimeSpan);
            AppiumWebElement element = null;
            var uiAutomator = new UiSelector().Build(selector, text, position);
            try
            {
                element = GlobalVar.AndroidDriver.FindElementByAndroidUIAutomator(uiAutomator);
            }
            catch (Exception ex)
            {
                Assert.Fail("GetControlByUiAutomatorSingleSelector threw an exception: " + ex.Message);
            }
            return element;
        }


        /// <summary>
        /// Finds a collection of elements in the screen that matches the UiAutomator criteria using a UiSelector.
        /// </summary>
        /// <param name="selector"> Represents the Enum in Share class </param>
        /// <param name="value"> the boolean value of an element to be found </param>
        /// <param name="position"> position of an object on the layout hierarchy </param>
        public static IReadOnlyCollection<AndroidElement> CollectionByUiAutomatorSingleSelector(Selector selector, bool value, int position = 0)
        {
            GlobalVar.AndroidDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVar.TimeSpan);
            IReadOnlyCollection<AndroidElement> elements = null;
            var uiAutomator = new UiSelector().Build(selector, value, position);
            try
            {
                elements = GlobalVar.AndroidDriver.FindElementsByAndroidUIAutomator(uiAutomator);
            }
            catch (Exception ex)
            {
                Assert.Fail("GetControlCollectionByUiAutomatorSingleSelector threw an exception: " + ex.Message);
            }
            return elements;
        }


        /// <summary>
        /// Finds a collection of elements in the screen that matches the UiAutomator criteria using a UiSelector.
        /// </summary>
        /// <param name="selector"> Represents the Enum in Share class </param>
        /// <param name="text"> the partial/complete text of an element to be found </param>
        /// <param name="position"> position of an object on the layout hierarchy </param>
        public static IReadOnlyCollection<AndroidElement> CollectionByUiAutomatorSingleSelector(Selector selector, string text, int position = 0)
        {
            GlobalVar.AndroidDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVar.TimeSpan);
            IReadOnlyCollection<AndroidElement> elements = null;
            var uiAutomator = new UiSelector().Build(selector, text, position);
            try
            {
                elements = GlobalVar.AndroidDriver.FindElementsByAndroidUIAutomator(uiAutomator);
            }
            catch (Exception ex)
            {
                Assert.Fail("GetControlCollectionByUiAutomatorSingleSelector threw an exception: " + ex.Message);
            }
            return elements;
        }


        #endregion END OF USING SINGLE SELECTORS


        // ************ DATE 10/16/2020 ************
        // All the possible Selectors to search for a child element till date.
        // ************ --------------- ************
        #region USING CHILD SELECTORS


        /// <summary>
        /// Finds the first element in the screen that matches the UiAutomator criteria using a Child UiSelector.
        /// </summary>
        /// <param name="selector"> Represents the Enum in Share class </param>
        /// <param name="value"> the boolean value of an element to be found </param>
        /// <param name="position"> position of an object on the layout hierarchy </param>
        public static AppiumWebElement ByUiAutomatorChildSelector(Selector selector, bool value, int position = 0)
        {
            GlobalVar.AndroidDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVar.TimeSpan);
            AppiumWebElement element = null;
            var uiAutomator = new UiSelector().BuildChildSelector(selector, value, position);
            try
            {
                element = GlobalVar.AndroidDriver.FindElementByAndroidUIAutomator(uiAutomator);
            }
            catch (Exception ex)
            {
                Assert.Fail("GetControlByUiAutomatorChildSelector threw an exception: " + ex.Message);
            }
            return element;
        }


        /// <summary>
        /// Finds the first element in the screen that matches the UiAutomator criteria using a Child UiSelector.
        /// </summary>
        /// <param name="selector"> Represents the Enum in Share class </param>
        /// <param name="text"> the partial/complete text of an element to be found </param>
        /// <param name="position"> position of an object on the layout hierarchy </param>
        public static AppiumWebElement ByUiAutomatorChildSelector(Selector selector, string text, int position = 0)
        {
            GlobalVar.AndroidDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVar.TimeSpan);
            AppiumWebElement element = null;
            var uiAutomator = new UiSelector().BuildChildSelector(selector, text, position);
            try
            {
                element = GlobalVar.AndroidDriver.FindElementByAndroidUIAutomator(uiAutomator);
            }
            catch (Exception ex)
            {
                Assert.Fail("GetControlByUiAutomatorChildSelector threw an exception: " + ex.Message);
            }
            return element;
        }


        /// <summary>
        /// Finds a collection of elements in the screen that matches the UiAutomator criteria using a Child UiSelector.
        /// </summary>
        /// <param name="selector"> Represents the Enum in Share class </param>
        /// <param name="value"> the boolean value of an element to be found </param>
        /// <param name="position"> position of an object on the layout hierarchy </param>
        public static IReadOnlyCollection<AndroidElement> CollectionByUiAutomatorChildSelector(Selector selector, bool value, int position = 0)
        {
            GlobalVar.AndroidDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVar.TimeSpan);
            IReadOnlyCollection<AndroidElement> elements = null;
            var uiAutomator = new UiSelector().BuildChildSelector(selector, value, position);
            try
            {
                elements = GlobalVar.AndroidDriver.FindElementsByAndroidUIAutomator(uiAutomator);
            }
            catch (Exception ex)
            {
                Assert.Fail("GetControlCollectionByUiAutomatorChildSelector threw an exception: " + ex.Message);
            }
            return elements;
        }


        /// <summary>
        /// Finds a collection of elements in the screen that matches the UiAutomator criteria using a Child UiSelector.
        /// </summary>
        /// <param name="selector"> Represents the Enum in Share class </param>
        /// <param name="text"> the partial/complete text of an element to be found </param>
        /// <param name="position"> position of an object on the layout hierarchy </param>
        public static IReadOnlyCollection<AndroidElement> CollectionByUiAutomatorChildSelector(Selector selector, string text, int position = 0)
        {
            GlobalVar.AndroidDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVar.TimeSpan);
            IReadOnlyCollection<AndroidElement> elements = null;
            var uiAutomator = new UiSelector().BuildChildSelector(selector, text, position);
            try
            {
                elements = GlobalVar.AndroidDriver.FindElementsByAndroidUIAutomator(uiAutomator);
            }
            catch (Exception ex)
            {
                Assert.Fail("GetControlCollectionByUiAutomatorChildSelector threw an exception: " + ex.Message);
            }
            return elements;
        }


        #endregion END OF USING CHILD SELECTORS


        // ************ DATE 10/16/2020 ************
        // All the possible Selectors to search for a parent element till date.
        // ************ --------------- ************
        #region USING PARENT SELECTORS


        /// <summary>
        /// Finds the first element in the screen that matches the UiAutomator criteria using a Parent UiSelector.
        /// </summary>
        /// <param name="selector"> Represents the Enum in Share class </param>
        /// <param name="value"> the boolean value of an element to be found </param>
        /// <param name="position"> position of an object on the layout hierarchy </param>
        public static AppiumWebElement ByUiAutomatorParentSelector(Selector selector, bool value, int position = 0)
        {
            GlobalVar.AndroidDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVar.TimeSpan);
            AppiumWebElement element = null;
            var uiAutomator = new UiSelector().BuildParentSelector(selector, value, position);
            try
            {
                element = GlobalVar.AndroidDriver.FindElementByAndroidUIAutomator(uiAutomator);
            }
            catch (Exception ex)
            {
                Assert.Fail("GetControlByUiAutomatorParentSelector threw an exception: " + ex.Message);
            }
            return element;
        }


        /// <summary>
        /// Finds the first element in the screen that matches the UiAutomator criteria using a Parent UiSelector.
        /// </summary>
        /// <param name="selector"> Represents the Enum in Share class </param>
        /// <param name="text"> the partial/complete text of an element to be found </param>
        /// <param name="position"> position of an object on the layout hierarchy </param>
        public static AppiumWebElement ByUiAutomatorParentSelector(Selector selector, string text, int position = 0)
        {
            GlobalVar.AndroidDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVar.TimeSpan);
            AppiumWebElement element = null;
            var uiAutomator = new UiSelector().BuildParentSelector(selector, text, position);
            try
            {
                element = GlobalVar.AndroidDriver.FindElementByAndroidUIAutomator(uiAutomator);
            }
            catch (Exception ex)
            {
                Assert.Fail("GetControlByUiAutomatorParentSelector threw an exception: " + ex.Message);
            }
            return element;
        }


        /// <summary>
        /// Finds a collection of elements in the screen that matches the UiAutomator criteria using a Parent UiSelector.
        /// </summary>
        /// <param name="selector"> Represents the Enum in Share class </param>
        /// <param name="value"> the boolean value of an element to be found </param>
        /// <param name="position"> position of an object on the layout hierarchy </param>
        public static IReadOnlyCollection<AndroidElement> CollectionByUiAutomatorParentSelector(Selector selector, bool value, int position = 0)
        {
            GlobalVar.AndroidDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVar.TimeSpan);
            IReadOnlyCollection<AndroidElement> elements = null;
            var uiAutomator = new UiSelector().BuildParentSelector(selector, value, position);
            try
            {
                elements = GlobalVar.AndroidDriver.FindElementsByAndroidUIAutomator(uiAutomator);
            }
            catch (Exception ex)
            {
                Assert.Fail("GetControlsCollectionByUiAutomatorParentSelector threw an exception: " + ex.Message);
            }
            return elements;
        }


        /// <summary>
        /// Finds a collection of elements in the screen that matches the UiAutomator criteria using a Parent UiSelector.
        /// </summary>
        /// <param name="selector"> Represents the Enum in Share class </param>
        /// <param name="text"> the partial/complete text of an element to be found </param>
        /// <param name="position"> position of an object on the layout hierarchy </param>
        public static IReadOnlyCollection<AndroidElement> CollectionByUiAutomatorParentSelector(Selector selector, string text, int position = 0)
        {
            GlobalVar.AndroidDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVar.TimeSpan);
            IReadOnlyCollection<AndroidElement> elements = null;
            var uiAutomator = new UiSelector().BuildParentSelector(selector, text, position);
            try
            {
                elements = GlobalVar.AndroidDriver.FindElementsByAndroidUIAutomator(uiAutomator);
            }
            catch (Exception ex)
            {
                Assert.Fail("GetControlsCollectionByUiAutomatorParentSelector threw an exception: " + ex.Message);
            }
            return elements;
        }


        #endregion END OF USING PARENT SELECTORS


        #endregion END OF BY UIAUTOMATOR


        // ************ DATE 10/16/2020 ************
        // ***** IMPORTANT: All GetControl by GENERIC return either a AppiumWebElement or a Collection of AppiumWebElement.
        // ************ --------------- ************
        #region BY GENERIC SEARCHER


        public static AppiumWebElement FindBy(By by)
        {
            GlobalVar.AndroidDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVar.TimeSpan);
            AppiumWebElement element = null;
            try
            {
                element = GlobalVar.AndroidDriver.FindElement(by);
            }
            catch (Exception ex)
            {
                Assert.Fail("GetControlFindBy threw an exception: " + ex.Message);
            }
            return element;
        }


        public static AppiumWebElement FindBy(By by, string text)
        {
            GlobalVar.AndroidDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVar.TimeSpan);
            try
            {
                var elements = GlobalVar.AndroidDriver.FindElements(by);
                foreach (var elem in elements)
                {
                    if (elem.Text.Contains(text))
                        return elem;
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("GetControlFindBy threw an exception: " + ex.Message);
            }
            return null;
        }

        public static IEnumerable<AppiumWebElement> CollectionFindBy(By by)
        {
            GlobalVar.AndroidDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVar.TimeSpan);
            IEnumerable<AppiumWebElement> elements = null;
            try
            {
                elements = GlobalVar.AndroidDriver.FindElements(by);
                return elements;
            }
            catch (Exception ex)
            {
                Assert.Fail("GetControlCollectionFindBy threw an exception: " + ex.Message);
            }
            return elements;
        }


        #endregion

    }
}