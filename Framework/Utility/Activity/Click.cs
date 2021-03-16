using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Android;
using Framework.Utility.Core;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using static Framework.Utility.Share;

namespace Framework.Utility.Activity
{
    public static class Click
    {


        // ************ DATE 10/16/2020 ************
        // ***** IMPORTANT: All Click by CLASSNAME will search an element and then click it.
        // ************ --------------- ************
        #region BY CLASSNAME


        /// <summary>
        /// Finds the first element in the screen that matches the className criteria and clicks it.
        /// </summary>
        /// <param name="className">ClassName to find the object</param>
        public static void ByClassName(string className)
        {
            try
            {
                var element = GetControl.ByClass(className);
                element.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("ClickByClassName threw an exception: " + ex.Message);
            }
        }


        /// <summary>
        /// Finds a collection of elements and then iterates every element till the text matches (completely or partial) and clicks it.
        /// </summary>
        /// <param name="className">ClassName to find the object</param>
        /// <param name="text">Text to match a specific element</param>
        public static void ByClassName(string className, string text)
        {
            try
            {
                var elements = GetControl.CollectionByClass(className);
                foreach (var elem in elements)
                {
                    if (elem.Text.Contains(text))
                        elem.Click();
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("ClickByClassName threw an exception: " + ex.Message);
            }
        }


        #endregion END OF BY CLASSNAME


        // ************ DATE 10/16/2020 ************
        // ***** IMPORTANT: All Click by ID will search an element and then click it.
        // ************ --------------- ************
        #region BY ID


        /// <summary>
        /// Finds the first element in the screen that matches the id criteria and then click it.
        /// </summary>
        /// <param name="id">Id to find the object</param>
        public static void ById(string id)
        {
            try
            {
                AppiumWebElement element = GetControl.ById(id);
                element.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("ClickById threw an exception: " + ex.Message);
            }
        }


        /// <summary>
        /// Finds the first element in the screen that matches the id criteria and then click it.
        /// </summary>
        /// <param name="id">Id to find the object</param>
        /// <param name="text">Text to match a specific element</param>
        public static void ById(string id, string text)
        {
            try
            {
                var elements = GetControl.CollectionById(id);
                foreach (var elem in elements)
                {
                    if (elem.Text.Contains(text))
                        elem.Click();
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("ClickById threw an exception: " + ex.Message);
            }
        }


        #endregion END OF BY ID


        // ************ DATE 10/16/2020 ************
        // ***** IMPORTANT: All Click by XPATH will search an element and then click it.
        // ************ --------------- ************
        #region BY XPATH


        /// <summary>
        /// Finds the first element in the screen that matches the xPath criteria and then click it.
        /// </summary>
        /// <param name="position">Position to match a specific element</param>
        /// <param name="elem">Represents the Enum in Share class</param>
        /// <param name="widget">boolean if this is a widget</param>
        public static void ByXPath(int position, Share.Element elem = Share.Element.EditText, bool widget = true)
        {
            try
            {
                AppiumWebElement element = GetControl.ByXPath(position, elem, widget);
                element.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("ClickByXPath threw an exception: " + ex.Message);
            }
        }


        /// <summary>
        /// Finds the first element in the screen that matches the xPath criteria and then click it.
        /// </summary>
        /// <param name="text">text to match the element to be found</param>
        /// <param name="elem">Represents the Enum in Share class</param>
        /// <param name="widget">boolean if this is a widget</param>
        public static void ByXPath(string text, Share.Element elem = Share.Element.EditText, bool widget = true)
        {
            try
            {
                var elements = GetControl.CollectionByXPath(elem, widget);
                foreach (var element in elements)
                {
                    if (element.Text.Contains(text))
                        element.Click();
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("ClickByXPath threw an exception: " + ex.Message);
            }
        }


        #endregion END OF BY XPATH


        // ************ DATE 10/16/2020 ************
        // ***** IMPORTANT: All Click by UIAUTOMATOR will search an element and then click it.
        // ************ --------------- ************
        #region BY UIAUTOMATOR


        /// <summary>
        /// Finds the first element in the screen that matches the UiAutomator criteria and click it.
        /// </summary>
        /// <param name="attribute">All the possible attributes that an element has, like text</param>
        /// <param name="value">The value to match with the attribute</param>
        public static void ByUiAutomator(string attribute, string value)
        {
            try
            {
                var element = GetControl.ByUiAutomator(attribute, value);
                element.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("ClickByUiAutomator threw an exception: " + ex.Message);
            }
        }


        // ************ DATE 10/16/2020 ************
        // All the possible Selectors to search for a single element till date.
        // ************ --------------- ************
        #region USING SINGLE SELECTORS


        /// <summary>
        /// Finds the first element in the screen that matches the UiAutomator criteria using a UiSelector and click it.
        /// </summary>
        /// <param name="selector"> Represents the Enum in Share class </param>
        /// <param name="value"> the boolean value of an element to be found </param>
        /// <param name="position"> position of an object on the layout hierarchy </param>
        public static void ByUiAutomatorSingleSelector(Share.Selector selector, bool value, int position = 0)
        {
            try
            {
                var element = GetControl.ByUiAutomatorSingleSelector(selector, value, position);
                element.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("ClickByUiAutomatorSingleSelector threw an exception: " + ex.Message);
            }
        }


        /// <summary>
        /// Finds the first element in the screen that matches the UiAutomator criteria using a UiSelector and click it.
        /// </summary>
        /// <param name="selector"> Represents the Enum in Share class </param>
        /// <param name="text"> the partial/complete text of an element to be found </param>
        /// <param name="position"> position of an object on the layout hierarchy </param>
        public static void ByUiAutomatorSingleSelector(Share.Selector selector, string text, int position = 0)
        {
            try
            {
                var element = GetControl.ByUiAutomatorSingleSelector(selector, text, position);
                element.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("ClickByUiAutomatorSingleSelector threw an exception: " + ex.Message);
            }
        }


        /// <summary>
        /// Finds a collection of elements in the screen that matches the UiAutomator criteria using a UiSelector and click it.
        /// </summary>
        /// <param name="selector"> Represents the Enum in Share class </param>
        /// <param name="value"> the boolean value of an element to be found </param>
        /// <param name="text"> text to found the element to be click</param>
        /// <param name="position"> position of an object on the layout hierarchy </param>
        public static void CollectionByUiAutomatorSingleSelector(Share.Selector selector, bool value, string text, int position = 0)
        {
            try
            {
                var elements = GetControl.CollectionByUiAutomatorSingleSelector(selector, value, position);
                foreach (var element in elements)
                {
                    if (element.Text.Contains(text))
                        element.Click();
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("ClickCollectionByUiAutomatorSingleSelector threw an exception: " + ex.Message);
            }
        }


        #endregion END OF USING SINGLE SELECTORS


        // ************ DATE 10/16/2020 ************
        // All the possible Selectors to search for a child element till date.
        // ************ --------------- ************
        #region USING CHILD SELECTORS


        /// <summary>
        /// Finds the first element in the screen that matches the UiAutomator criteria using a Child UiSelector and click it.
        /// </summary>
        /// <param name="selector"> Represents the Enum in Share class </param>
        /// <param name="value"> the boolean value of an element to be found </param>
        /// <param name="text"> text to found the element</param>
        /// <param name="position"> position of an object on the layout hierarchy </param>
        public static void ByUiAutomatorChildSelector(Share.Selector selector, bool value, string text, int position = 0)
        {
            try
            {
                var element = GetControl.ByUiAutomatorChildSelector(selector, value, position);
                element.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("ClickByUiAutomatorChildSelector threw an exception: " + ex.Message);
            }
        }


        /// <summary>
        /// Finds the first element in the screen that matches the UiAutomator criteria using a Child UiSelector and click it.
        /// </summary>
        /// <param name="selector"> Represents the Enum in Share class </param>
        /// <param name="text"> the partial/complete text of an element to be found </param>
        /// <param name="position"> position of an object on the layout hierarchy </param>
        public static void ByUiAutomatorChildSelector(Share.Selector selector, string text, int position = 0)
        {
            try
            {
                var element = GetControl.ByUiAutomatorChildSelector(selector, text, position);
                element.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("ClickByUiAutomatorChildSelector threw an exception: " + ex.Message);
            }
        }


        /// <summary>
        /// Finds a collection of elements in the screen that matches the UiAutomator criteria using a Child UiSelector.
        /// </summary>
        /// <param name="selector"> Represents the Enum in Share class </param>
        /// <param name="value"> the boolean value of an element to be found </param>
        /// <param name="text"> text to found the element to be click</param>
        /// <param name="position"> position of an object on the layout hierarchy </param>
        public static void CollectionByUiAutomatorChildSelector(Share.Selector selector, bool value, string text, int position = 0)
        {
            try
            {
                var elements = GetControl.CollectionByUiAutomatorChildSelector(selector, value, position);
                foreach (var element in elements)
                {
                    if (element.Text.Contains(text))
                        element.Click();
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("ClickCollectionByUiAutomatorChildSelector threw an exception: " + ex.Message);
            }
        }


        #endregion END OF USING CHILD SELECTORS


        // ************ DATE 10/16/2020 ************
        // All the possible Selectors to search for a parent element till date.
        // ************ --------------- ************
        #region USING PARENT SELECTORS


        /// <summary>
        /// Finds the first element in the screen that matches the UiAutomator criteria using a Parent UiSelector and click it.
        /// </summary>
        /// <param name="selector"> Represents the Enum in Share class </param>
        /// <param name="value"> the boolean value of an element to be found </param>
        /// <param name="position"> position of an object on the layout hierarchy </param>
        public static void ByUiAutomatorParentSelector(Share.Selector selector, bool value, int position = 0)
        {
            try
            {
                var element = GetControl.ByUiAutomatorParentSelector(selector, value, position);
                element.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("ClickByUiAutomatorParentSelector threw an exception: " + ex.Message);
            }
        }


        /// <summary>
        /// Finds the first element in the screen that matches the UiAutomator criteria using a Parent UiSelector and click it.
        /// </summary>
        /// <param name="selector"> Represents the Enum in Share class </param>
        /// <param name="text"> the partial/complete text of an element to be found </param>
        /// <param name="position"> position of an object on the layout hierarchy </param>
        public static void ByUiAutomatorParentSelector(Share.Selector selector, string text, int position = 0)
        {
            try
            {
                var element = GetControl.ByUiAutomatorParentSelector(selector, text, position);
                element.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("ClickByUiAutomatorParentSelector threw an exception: " + ex.Message);
            }
        }


        /// <summary>
        /// Finds a collection of elements in the screen that matches the UiAutomator criteria using a Parent UiSelector.
        /// </summary>
        /// <param name="selector"> Represents the Enum in Share class </param>
        /// <param name="value"> the boolean value of an element to be found </param>
        /// <param name="position"> position of an object on the layout hierarchy </param>
        public static void CollectionByUiAutomatorParentSelector(Share.Selector selector, bool value, string text, int position = 0)
        {
            try
            {
                var elements = GetControl.CollectionByUiAutomatorParentSelector(selector, value, position);
                foreach (var element in elements)
                {
                    if (element.Text.Contains(text))
                        element.Click();
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("ClicksCollectionByUiAutomatorParentSelector threw an exception: " + ex.Message);
            }
        }


        #endregion END OF USING PARENT SELECTORS


        #endregion END OF BY UIAUTOMATOR


    }
}
