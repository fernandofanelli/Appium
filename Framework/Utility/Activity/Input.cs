using System;
using System.Collections.Generic;
using System.Text;
using Framework.Utility.Core;
using NUnit.Framework;
using OpenQA.Selenium.Appium;

namespace Framework.Utility.Activity
{
    public static class Input
    {


        // ************ DATE 10/16/2020 ************
        // ***** IMPORTANT: All Input by CLASSNAME will search an element and then simulates typing text into the element.
        // ************ --------------- ************
        #region BY CLASSNAME


        /// <summary>
        /// Finds the first element in the screen that matches the className criteria and then simulates typing text into the element.
        /// </summary>
        /// <param name="className">ClassName to find the object</param>
        /// <param name="inputText">The text to type into the element.</param>
        public static void ByClassName(string className, string inputText)
        {
            try
            {
                var element = GetControl.ByClass(className);
                element.Clear();
                element.SendKeys(inputText);
            }
            catch (Exception ex)
            {
                Assert.Fail("InputByClassName threw an exception: " + ex.Message);
            }
        }


        /// <summary>
        /// Finds the first element in the screen that matches the className criteria and then simulates typing text into the element.
        /// </summary>
        /// <param name="className">ClassName to find the object</param>
        /// <param name="text">Text to match a specific element</param>
        /// <param name="inputText">The text to type into the element.</param>
        public static void ByClassName(string className, string text, string inputText)
        {
            try
            {
                var element = GetControl.ByClass(className, text);
                element.Clear();
                element.SendKeys(inputText);
            }
            catch (Exception ex)
            {
                Assert.Fail("InputByClassName threw an exception: " + ex.Message);
            }
        }


        #endregion END OF BY CLASSNAME


        // ************ DATE 10/16/2020 ************
        // ***** IMPORTANT: All Input by ID will search an element and then simulates typing text into the element.
        // ************ --------------- ************
        #region BY ID


        /// <summary>
        /// Finds the first element in the screen that matches the id criteria and then simulates typing text into the element.
        /// </summary>
        /// <param name="id">Id to find the object</param>
        /// <param name="inputText">The text to type into the element.</param>
        public static void ById(string id, string inputText)
        {
            try
            {
                var element = GetControl.ById(id);
                element.Clear();
                element.SendKeys(inputText);
            }
            catch (Exception ex)
            {
                Assert.Fail("InputById threw an exception: " + ex.Message);
            }
        }


        /// <summary>
        /// Finds the first element in the screen that matches the id criteria and then simulates typing text into the element.
        /// </summary>
        /// <param name="id">Id to find the object</param>
        /// <param name="text">Text to match a specific element</param>
        /// <param name="inputText">The text to type into the element.</param>
        public static void ById(string id, string text, string inputText)
        {
            try
            {
                var element = GetControl.ById(id, text);
                element.Clear();
                element.SendKeys(inputText);
            }
            catch (Exception ex)
            {
                Assert.Fail("InputById threw an exception: " + ex.Message);
            }
        }


        #endregion END OF BY ID


        // ************ DATE 10/16/2020 ************
        // ***** IMPORTANT: All Input by XPATH will search an element and then simulates typing text into the element.
        // ************ --------------- ************
        #region BY XPATH


        /// <summary>
        /// Finds the first element in the screen that matches the xPath criteria and then simulates typing text into the element.
        /// </summary>
        /// <param name="inputText">The text to type into the element.</param>
        /// <param name="position">Position to match a specific element</param>
        /// <param name="elem">Represents the Enum in Share class</param>
        /// <param name="widget">boolean if this is a widget</param>
        public static void ByXPath(string inputText, int position, Share.Element elem = Share.Element.EditText, bool widget = true)
        {
            try
            {
                AppiumWebElement element = GetControl.ByXPath(position, elem, widget);
                element.Clear();
                element.SendKeys(inputText);
            }
            catch (Exception ex)
            {
                Assert.Fail("InputByXPath threw an exception: " + ex.Message);
            }
        }


        /// <summary>
        /// Finds the first element in the screen that matches the xPath criteria and then simulates typing text into the element.
        /// </summary>
        /// <param name="inputText">The text to type into the element.</param>
        /// <param name="text">text to match the element to be found</param>
        /// <param name="elem">Represents the Enum in Share class</param>
        /// <param name="widget">boolean if this is a widget</param>
        public static void ByXPath(string inputText, string text, Share.Element elem = Share.Element.EditText, bool widget = true)
        {
            try
            {
                var elements = GetControl.CollectionByXPath(elem, widget);
                foreach (var element in elements)
                {
                    if (element.Text.Contains(text))
                    {
                        element.Clear();
                        element.SendKeys(inputText);
                    }
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("InputByXPath threw an exception: " + ex.Message);
            }
        }


        #endregion END OF BY XPATH


        // ************ DATE 10/16/2020 ************
        // ***** IMPORTANT: All Input by UIAUTOMATOR will search an element and then simulates typing text into the element.
        // ************ --------------- ************
        #region BY UIAUTOMATOR


        /// <summary>
        /// Finds the first element in the screen that matches the UiAutomator criteria and then simulates typing text into the element.
        /// </summary>
        /// <param name="inputText">The text to type into the element.</param>
        /// <param name="attribute">All the possible attributes that an element has, like text</param>
        /// <param name="value">The value to match with the attribute</param>
        public static void ByUiAutomator(string inputText, string attribute, string value)
        {
            try
            {
                var element = GetControl.ByUiAutomator(attribute, value);
                element.Clear();
                element.SendKeys(inputText);
            }
            catch (Exception ex)
            {
                Assert.Fail("InputByUiAutomator threw an exception: " + ex.Message);
            }
        }


        // ************ DATE 10/16/2020 ************
        // All the possible Selectors to search for a single element till date.
        // ************ --------------- ************
        #region USING SINGLE SELECTORS


        /// <summary>
        /// Finds the first element in the screen that matches the UiAutomator criteria using a UiSelector and then simulates typing text into the element.
        /// </summary>
        /// <param name="inputText">The text to type into the element.</param>
        /// <param name="selector"> Represents the Enum in Share class </param>
        /// <param name="value"> the boolean value of an element to be found </param>
        /// <param name="position"> position of an object on the layout hierarchy </param>
        public static void ByUiAutomatorSingleSelector(string inputText, Share.Selector selector, bool value, int position = 0)
        {
            try
            {
                var element = GetControl.ByUiAutomatorSingleSelector(selector, value, position);
                element.Clear();
                element.SendKeys(inputText);
            }
            catch (Exception ex)
            {
                Assert.Fail("InputByUiAutomatorSingleSelector threw an exception: " + ex.Message);
            }
        }


        /// <summary>
        /// Finds the first element in the screen that matches the UiAutomator criteria using a UiSelector and then simulates typing text into the element.
        /// </summary>
        /// <param name="inputText">The text to type into the element.</param>
        /// <param name="selector"> Represents the Enum in Share class </param>
        /// <param name="text"> the partial/complete text of an element to be found </param>
        /// <param name="position"> position of an object on the layout hierarchy </param>
        public static void ByUiAutomatorSingleSelector(string inputText, Share.Selector selector, string text, int position = 0)
        {
            try
            {
                var element = GetControl.ByUiAutomatorSingleSelector(selector, text, position);
                element.Clear();
                element.SendKeys(inputText);
            }
            catch (Exception ex)
            {
                Assert.Fail("InputByUiAutomatorSingleSelector threw an exception: " + ex.Message);
            }
        }


        /// <summary>
        /// Finds a collection of elements in the screen that matches the UiAutomator criteria using a UiSelector and then simulates typing text into the element.
        /// </summary>
        /// <param name="inputText">The text to type into the element.</param>
        /// <param name="selector"> Represents the Enum in Share class </param>
        /// <param name="value"> the boolean value of an element to be found </param>
        /// <param name="text"> text to found the element to be Input</param>
        /// <param name="position"> position of an object on the layout hierarchy </param>
        public static void CollectionByUiAutomatorSingleSelector(string inputText, Share.Selector selector, bool value, string text, int position = 0)
        {
            try
            {
                var elements = GetControl.CollectionByUiAutomatorSingleSelector(selector, value, position);
                foreach (var element in elements)
                {
                    if (element.Text.Contains(text))
                    {
                        element.Clear();
                        element.SendKeys(inputText);
                    }
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("InputCollectionByUiAutomatorSingleSelector threw an exception: " + ex.Message);
            }
        }


        #endregion END OF USING SINGLE SELECTORS


        // ************ DATE 10/16/2020 ************
        // All the possible Selectors to search for a child element till date.
        // ************ --------------- ************
        #region USING CHILD SELECTORS


        /// <summary>
        /// Finds the first element in the screen that matches the UiAutomator criteria using a Child UiSelector and then simulates typing text into the element.
        /// </summary>
        /// <param name="inputText">The text to type into the element.</param>
        /// <param name="selector"> Represents the Enum in Share class </param>
        /// <param name="value"> the boolean value of an element to be found </param>
        /// <param name="text"> text to found the element</param>
        /// <param name="position"> position of an object on the layout hierarchy </param>
        public static void ByUiAutomatorChildSelector(string inputText, Share.Selector selector, bool value, string text, int position = 0)
        {
            try
            {
                var element = GetControl.ByUiAutomatorChildSelector(selector, value, position);
                element.Clear();
                element.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("InputByUiAutomatorChildSelector threw an exception: " + ex.Message);
            }
        }


        /// <summary>
        /// Finds the first element in the screen that matches the UiAutomator criteria using a Child UiSelector and then simulates typing text into the element.
        /// </summary>
        /// <param name="inputText">The text to type into the element.</param>
        /// <param name="selector"> Represents the Enum in Share class </param>
        /// <param name="text"> the partial/complete text of an element to be found </param>
        /// <param name="position"> position of an object on the layout hierarchy </param>
        public static void ByUiAutomatorChildSelector(string inputText, Share.Selector selector, string text, int position = 0)
        {
            try
            {
                var element = GetControl.ByUiAutomatorChildSelector(selector, text, position);
                element.Clear();
                element.SendKeys(inputText);
            }
            catch (Exception ex)
            {
                Assert.Fail("InputByUiAutomatorChildSelector threw an exception: " + ex.Message);
            }
        }


        /// <summary>
        /// Finds a collection of elements in the screen that matches the UiAutomator criteria using a Child UiSelector.
        /// </summary>
        /// <param name="inputText">The text to type into the element.</param>
        /// <param name="selector"> Represents the Enum in Share class </param>
        /// <param name="value"> the boolean value of an element to be found </param>
        /// <param name="text"> text to found the element to be Input</param>
        /// <param name="position"> position of an object on the layout hierarchy </param>
        public static void CollectionByUiAutomatorChildSelector(string inputText, Share.Selector selector, bool value, string text, int position = 0)
        {
            try
            {
                var elements = GetControl.CollectionByUiAutomatorChildSelector(selector, value, position);
                foreach (var element in elements)
                {
                    if (element.Text.Contains(text))
                    {
                        element.Clear();
                        element.SendKeys(inputText);
                    }
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("InputCollectionByUiAutomatorChildSelector threw an exception: " + ex.Message);
            }
        }


        #endregion END OF USING CHILD SELECTORS


        // ************ DATE 10/16/2020 ************
        // All the possible Selectors to search for a parent element till date.
        // ************ --------------- ************
        #region USING PARENT SELECTORS


        /// <summary>
        /// Finds the first element in the screen that matches the UiAutomator criteria using a Parent UiSelector and then simulates typing text into the element.
        /// </summary>
        /// <param name="inputText">The text to type into the element.</param>
        /// <param name="selector"> Represents the Enum in Share class </param>
        /// <param name="value"> the boolean value of an element to be found </param>
        /// <param name="position"> position of an object on the layout hierarchy </param>
        public static void ByUiAutomatorParentSelector(string inputText, Share.Selector selector, bool value, int position = 0)
        {
            try
            {
                var element = GetControl.ByUiAutomatorParentSelector(selector, value, position);
                element.Clear();
                element.SendKeys(inputText);
            }
            catch (Exception ex)
            {
                Assert.Fail("InputByUiAutomatorParentSelector threw an exception: " + ex.Message);
            }
        }


        /// <summary>
        /// Finds the first element in the screen that matches the UiAutomator criteria using a Parent UiSelector and then simulates typing text into the element.
        /// </summary>
        /// <param name="inputText">The text to type into the element.</param>
        /// <param name="selector"> Represents the Enum in Share class </param>
        /// <param name="text"> the partial/complete text of an element to be found </param>
        /// <param name="position"> position of an object on the layout hierarchy </param>
        public static void ByUiAutomatorParentSelector(string inputText, Share.Selector selector, string text, int position = 0)
        {
            try
            {
                var element = GetControl.ByUiAutomatorParentSelector(selector, text, position);
                element.Clear();
                element.SendKeys(inputText);
            }
            catch (Exception ex)
            {
                Assert.Fail("InputByUiAutomatorParentSelector threw an exception: " + ex.Message);
            }
        }


        /// <summary>
        /// Finds a collection of elements in the screen that matches the UiAutomator criteria using a Parent UiSelector.
        /// </summary>
        /// <param name="inputText">The text to type into the element.</param>
        /// <param name="selector"> Represents the Enum in Share class </param>
        /// <param name="value"> the boolean value of an element to be found </param>
        /// <param name="position"> position of an object on the layout hierarchy </param>
        public static void CollectionByUiAutomatorParentSelector(string inputText, Share.Selector selector, bool value, string text, int position = 0)
        {
            try
            {
                var elements = GetControl.CollectionByUiAutomatorParentSelector(selector, value, position);
                foreach (var element in elements)
                {
                    if (element.Text.Contains(text))
                    {
                        element.Clear();
                        element.SendKeys(inputText);
                    }
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("InputsCollectionByUiAutomatorParentSelector threw an exception: " + ex.Message);
            }
        }


        #endregion END OF USING PARENT SELECTORS


        #endregion END OF BY UIAUTOMATOR


    }
}
