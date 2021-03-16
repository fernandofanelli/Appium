using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Framework.Utility.Activity;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = Framework.Utility.Activity.ExpectedConditions;

namespace Framework.Utility.Helper 
{

    /// <summary>
    /// Use this class whenever you need to be sure that certain elements behave in a specific way. This class uses the
    /// CUSTOM ExpectedCondition class created on this project based on the deprecated one of Selenium.
    /// *** IMPORTANT: you MUST first instantiate this class to create a by locator for you, to use this methods.
    /// </summary>
    public static class Helpers

    {


        /// <summary>
        /// Check if the given parameter is the same as the app title.
        /// </summary>
        /// <param name="title">Title of the app to be match.</param>
        /// <returns><see langword="true"/> when the screen Title matches the given title, otherwise <see langword="false"/>.</returns>
        public static bool AppTitleMatch(string title)
        {
            var wait = new WebDriverWait(GlobalVar.AndroidDriver, TimeSpan.FromSeconds(GlobalVar.TimeSpan));
            try
            {
                return wait.Until(driver => ExpectedConditions.TitleIs(title));
            }
            catch (Exception ex)
            {
                Assert.Fail("AppTitleMatch threw an exception: " + ex.Message);
                return false;
            }
        }


        /// <summary>
        /// Check if the given parameter is contain in the app title.
        /// </summary>
        /// <param name="title">Title of the app to be contain.</param>
        /// <returns><see langword="true"/> when the screen Title contains the given title, otherwise <see langword="false"/>.</returns>
        public static bool AppTitleContains(string title)
        {
            var wait = new WebDriverWait(GlobalVar.AndroidDriver, TimeSpan.FromSeconds(GlobalVar.TimeSpan));
            try
            {
                return wait.Until(driver => ExpectedConditions.TitleContains(title));
            }
            catch (Exception ex)
            {
                Assert.Fail("AppTitleContains threw an exception: " + ex.Message);
                return false;
            }
        }


        /// <summary>
        /// Check if the given parameter is contain in an element.
        /// </summary>
        /// <param name="by">Searcher of type By.</param>
        /// <param name="text">Text of the element to be contain.</param>
        /// <returns><see langword="true"/> when the element contains the given text, otherwise <see langword="false"/>.</returns>
        public static bool CompareElementText(By by, string text)
        {
            var wait = new WebDriverWait(GlobalVar.AndroidDriver, TimeSpan.FromSeconds(GlobalVar.TimeSpan));
            try
            {
                return wait.Until(driver => ExpectedConditions.TextPresent(by, text));
            }
            catch (Exception ex)
            {
                Assert.Fail("CompareElementText threw an exception: " + ex.Message);
                return false;
            }
        }


        /// <summary>
        /// Click a visible element.
        /// </summary>
        /// <param name="by">Searcher of type By.</param>
        public static void Click(By by)
        {
            var wait = new WebDriverWait(GlobalVar.AndroidDriver, TimeSpan.FromSeconds(GlobalVar.TimeSpan));
            try
            {
                var element = wait.Until(driver => ExpectedConditions.ElementToBeClickable(by));
                element.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Click threw an exception: " + ex.Message);
            }
        }


        /// <summary>
        /// Finds all the element that are present on a screen, this does not validate that they are visible.
        /// </summary>
        /// <param name="by">Searcher of type By.</param>
        /// <returns>The list of <see cref="AppiumWebElement"/> once it is located.</returns>
        public static IEnumerable<AppiumWebElement> GetElements(By by)
        {
            var wait = new WebDriverWait(GlobalVar.AndroidDriver, TimeSpan.FromSeconds(GlobalVar.TimeSpan));
            try
            {
                return wait.Until(driver => ExpectedConditions.PresenceOfAllElements(by));
            }
            catch (Exception ex)
            {
                Assert.Fail("GetElements threw an exception: " + ex.Message);
                return null;
            }
        }


        /// <summary>
        /// Get the text of a specific element.
        /// </summary>
        /// <param name="by">Searcher of type By.</param>
        /// <returns>The text <see cref="string"/> of an element once it is located.</returns>
        public static string GetElementText(By by)
        {
            var wait = new WebDriverWait(GlobalVar.AndroidDriver, TimeSpan.FromSeconds(GlobalVar.TimeSpan));
            try
            {
                var element = wait.Until(driver => ExpectedConditions.ElementIsVisible(by));
                return element.Text;
            }
            catch (Exception ex)
            {
                Assert.Fail("GetElementText threw an exception: " + ex.Message);
                return null;
            }
        }


        /// <summary>
        /// Get the Location of a specific element.
        /// </summary>
        /// <param name="by">Searcher of type By.</param>
        /// <returns>The <see cref="Point"/> of an element once it is located.</returns>
        public static Point GetElementLocation(By by)
        {
            var wait = new WebDriverWait(GlobalVar.AndroidDriver, TimeSpan.FromSeconds(GlobalVar.TimeSpan));
            try
            {
                var element = wait.Until(driver => ExpectedConditions.ElementIsVisible(by));
                return element.Location;
            }
            catch (Exception ex)
            {
                Assert.Fail("GetElementLocation threw an exception: " + ex.Message);
                return Point.Empty;
            }
        }


        /// <summary>
        /// Get the Size of a specific element.
        /// </summary>
        /// <param name="by">Searcher of type By.</param>
        /// <returns>The <see cref="Size"/> of an element once it is located.</returns>
        public static Size GetElementSize(By by)
        {
            var wait = new WebDriverWait(GlobalVar.AndroidDriver, TimeSpan.FromSeconds(GlobalVar.TimeSpan));
            try
            {
                var element = wait.Until(driver => ExpectedConditions.ElementIsVisible(by));
                return element.Size;
            }
            catch (Exception ex)
            {
                Assert.Fail("GetElementSize threw an exception: " + ex.Message);
                return Size.Empty;
            }
        }


        /// <summary>
        /// Get the Rectangle of a specific element.
        /// </summary>
        /// <param name="by">Searcher of type By.</param>
        /// <returns>The <see cref="Rectangle"/> of an element once it is located.</returns>
        public static Rectangle GetElementRect(By by)
        {
            var wait = new WebDriverWait(GlobalVar.AndroidDriver, TimeSpan.FromSeconds(GlobalVar.TimeSpan));
            try
            {
                var element = wait.Until(driver => ExpectedConditions.ElementIsVisible(by));
                return element.Rect;
            }
            catch (Exception ex)
            {
                Assert.Fail("GetElementRect threw an exception: " + ex.Message);
                return Rectangle.Empty;
            }
        }


        /// <summary>
        /// Finds all the element that are visible on a screen.
        /// </summary>
        /// <param name="by">Searcher of type By.</param>
        /// <returns>The list of <see cref="AppiumWebElement"/> once it is located.</returns>
        public static IEnumerable<AppiumWebElement> GetVisibleElements(By by)
        {
            var wait = new WebDriverWait(GlobalVar.AndroidDriver, TimeSpan.FromSeconds(GlobalVar.TimeSpan));
            try
            {
                return wait.Until(driver => ExpectedConditions.VisibilityOfAllElements(by));
            }
            catch (Exception ex)
            {
                Assert.Fail("GetVisibleElements threw an exception: " + ex.Message);
                return null;
            }
        }


        /// <summary>
        /// Checks if an element is displayed.
        /// </summary>
        /// <param name="by">Searcher of type By.</param>
        /// <returns><see langword="true"/> when the element is displayed, otherwise <see langword="false"/>.</returns>
        public static bool IsElementDisplayed(By by)
        {
            var wait = new WebDriverWait(GlobalVar.AndroidDriver, TimeSpan.FromSeconds(GlobalVar.TimeSpan));
            try
            {
                var element = wait.Until(driver => ExpectedConditions.ElementExists(by));
                return element.Displayed;
            }
            catch (Exception ex)
            {
                Assert.Fail("IsElementDisplayed threw an exception: " + ex.Message);
                return false;
            }
        }


        /// <summary>
        /// Checks if an element is enabled.
        /// </summary>
        /// <param name="by">Searcher of type By.</param>
        /// <returns><see langword="true"/> when the element is enabled, otherwise <see langword="false"/>.</returns>
        public static bool IsElementEnabled(By by)
        {
            var wait = new WebDriverWait(GlobalVar.AndroidDriver, TimeSpan.FromSeconds(GlobalVar.TimeSpan));
            try
            {
                var element = wait.Until(driver => ExpectedConditions.ElementExists(by));
                return element.Enabled;
            }
            catch (Exception ex)
            {
                Assert.Fail("IsElementEnabled threw an exception: " + ex.Message);
                return false;
            }
        }


        /// <summary>
        /// Checks if an element is not displayed.
        /// </summary>
        /// <param name="by">Searcher of type By.</param>
        /// <returns><see langword="true"/> when the element is not displayed, otherwise <see langword="false"/>.</returns>
        public static bool IsElementNotDisplayed(By by)
        {
            var wait = new WebDriverWait(GlobalVar.AndroidDriver, TimeSpan.FromSeconds(GlobalVar.TimeSpan));
            try
            {
                return wait.Until(driver => ExpectedConditions.InvisibilityOfElement(by));
            }
            catch (Exception ex)
            {
                Assert.Fail("IsElementNotDisplayed threw an exception: " + ex.Message);
                return false;
            }
        }


        /// <summary>
        /// Checks if an element is not displayed using the text of an element.
        /// </summary>
        /// <param name="by">Searcher of type By.</param>
        /// <param name="text">text to match an element.</param>
        /// <returns><see langword="true"/> when the element is displayed, otherwise <see langword="false"/>.</returns>
        public static bool IsElementNotDisplayed(By by, string text)
        {
            var wait = new WebDriverWait(GlobalVar.AndroidDriver, TimeSpan.FromSeconds(GlobalVar.TimeSpan));
            try
            {
                return wait.Until(driver => ExpectedConditions.InvisibilityOfElementWithText(by, text));
            }
            catch (Exception ex)
            {
                Assert.Fail("IsElementNotDisplayed threw an exception: " + ex.Message);
                return false;
            }
        }


        /// <summary>
        /// Checks the selected property of an element using the given parameter.
        /// </summary>
        /// <param name="by">Searcher of type By.</param>
        /// <param name="selected">Represents the selected property of an element.</param>
        /// <returns><see langword="true"/> if the element is selected property equals the given parameter, otherwise <see langword="false"/>.</returns>
        public static bool IsElementSelected(By by, bool selected = true)
        {
            var wait = new WebDriverWait(GlobalVar.AndroidDriver, TimeSpan.FromSeconds(GlobalVar.TimeSpan));
            try
            {
                return wait.Until(driver => ExpectedConditions.ElementSelected(by, selected));
            }
            catch (Exception ex)
            {
                Assert.Fail("IsElementSelected threw an exception: " + ex.Message);
                return false;
            }
        }


        /// <summary>
        /// Checks the selected property of an element using the given parameters.
        /// </summary>
        /// <returns><see langword="true"/> if the element selected property equals the given parameter, otherwise <see langword="false"/>.</returns>
        public static bool IsElementSelected(AppiumWebElement element, bool selected = true)
        {
            var wait = new WebDriverWait(GlobalVar.AndroidDriver, TimeSpan.FromSeconds(GlobalVar.TimeSpan));
            try
            {
                return wait.Until(driver => ExpectedConditions.ElementSelected(element, selected));
            }
            catch (Exception ex)
            {
                Assert.Fail("IsElementSelected threw an exception: " + ex.Message);
                return false;
            }
        }


        /// <summary>
        /// Send the input text to a corresponding element.
        /// </summary>
        /// <param name="by">Searcher of type By.</param>
        /// <param name="inputText">Text to be input over an element.</param>
        /// <returns><see langword="true"/> if the element selected property equals the given parameter, otherwise <see langword="false"/>.</returns>
        public static void SendKeys(By by, string inputText)
        {
            var wait = new WebDriverWait(GlobalVar.AndroidDriver, TimeSpan.FromSeconds(GlobalVar.TimeSpan));
            try
            {
                var element = wait.Until(driver => ExpectedConditions.ElementToBeClickable(by));
                element.Clear();
                element.SendKeys(inputText);
            }
            catch (Exception ex)
            {
                Assert.Fail("SendKeys threw an exception: " + ex.Message);
            }
        }


    }
}
