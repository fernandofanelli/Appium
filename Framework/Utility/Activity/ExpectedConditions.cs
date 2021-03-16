using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Utility.Helper;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Framework.Utility.Activity
{
    public class ExpectedConditions
    {
        

        #region EXPECTED CONDITIONS METHODS


        /// <summary>
        /// An expectation for checking that an element is present on the screen. This doesn't mean it is visible.
        /// </summary>
        /// <returns>The <see cref="AppiumWebElement"/> once it is located.</returns>
        public static AppiumWebElement ElementExists(By by)
        {
            try
            {
                return GlobalVar.AndroidDriver.FindElement(by);
            }
            catch (Exception ex)
            {
                Assert.Fail("ElementExists threw an exception: " + ex.Message);
                return null;
            }
        }


        /// <summary>
        /// An expectation for checking that an element is present on the screen and visible. Visibility means
        /// that the element is not only displayed but also has a height and width that is greater than 0.
        /// </summary>
        /// <returns>The <see cref="AppiumWebElement"/> once it is located and visible.</returns>
        public static AppiumWebElement ElementIsVisible(By by)
        {
            try
            {
                var element = GlobalVar.AndroidDriver.FindElement(by);
                return element.Displayed ? element : null;
            }
            catch (Exception ex)
            {
                Assert.Fail("ElementIsVisible threw an exception: " + ex.Message);
                return null;
            }
        }


        /// <summary>
        /// An expectation for checking if a given element is selected.
        /// </summary>
        /// <returns><see langword="true"/> given element is selected, otherwise <see langword="false"/>.</returns>
        public static bool ElementSelected(By by, bool selected)
        {
            try
            {
                var element = GlobalVar.AndroidDriver.FindElement(by);
                return ElementSelectionState(element, selected);
            }
            catch (Exception ex)
            {
                Assert.Fail("ElementSelected threw an exception: " + ex.Message);
                return false;
            }
        }


        /// <summary>
        /// An expectation for checking an element is selected.
        /// </summary>
        /// <returns><see langword="true"/> given element is selected, otherwise <see langword="false"/>.</returns>
        public static bool ElementSelected(AppiumWebElement element, bool selected)
        {
            try
            {
                return ElementSelectionState(element, selected);
            }
            catch (Exception ex)
            {
                Assert.Fail("ElementSelected threw an exception: " + ex.Message);
                return false;
            }
        }


        /// <summary>
        /// An expectation for checking an element is visible and enabled such that you can click it.
        /// </summary>
        /// <returns>The <see cref="AppiumWebElement"/> once it is clickable (visible and enabled).</returns>
        public static AppiumWebElement ElementToBeClickable(By by)
        {
            try
            {
                var element = GlobalVar.AndroidDriver.FindElement(by);
                return (element.Displayed && element.Enabled) ? element : null;
            }
            catch (Exception ex)
            {
                Assert.Fail("ElementToBeClickable threw an exception: " + ex.Message);
                return null;
            }
        }


        /// <summary>
        /// An expectation for checking that all elements present on the web page that match the className are visible.
        /// Visibility means that the elements are not only displayed but also have a height and width that is greater than 0.
        /// </summary>
        /// <returns>The list of <see cref="AppiumWebElement"/> once it is located and visible.</returns>
        public static IEnumerable<AppiumWebElement> VisibilityOfAllElements(By by)
        {
            try
            {
                var elements = GlobalVar.AndroidDriver.FindElements(by);
                if (elements.Any(element => !element.Displayed))
                {
                    return null;
                }

                return elements.Any() ? elements : null;
            }
            catch (Exception ex)
            {
                Assert.Fail("VisibilityOfAllElements threw an exception: " + ex.Message);
                return null;
            }
        }


        /// <summary>
        /// An expectation for checking that all elements present on the web page that match the className.
        /// </summary>
        /// <returns>The list of <see cref="AppiumWebElement"/> once it is located.</returns>
        public static IEnumerable<AppiumWebElement> PresenceOfAllElements(By by)
        {
            try
            {
                var elements = GlobalVar.AndroidDriver.FindElements(by);
                return elements.Any() ? elements : null;
            }
            catch (Exception ex)
            {
                Assert.Fail("PresenceOfAllElements threw an exception: " + ex.Message);
                return null;
            }
        }


        /// <summary>
        /// An expectation for checking that an element is either invisible or not present on the screen.
        /// </summary>
        /// <returns><see langword="true"/> if the element is not displayed; otherwise, <see langword="false"/>.</returns>
        public static bool InvisibilityOfElement(By by)
        {
            try
            {
                var element = GlobalVar.AndroidDriver.FindElement(by);
                return !element.Displayed;
            }
            catch
            {
                return true;
            }
        }


        /// <summary>
        /// An expectation for checking that an element with text is either invisible or not present on the screen.
        /// </summary>
        /// <param name="text">Text of the element</param>
        /// <returns><see langword="true"/> if the element is not displayed; otherwise, <see langword="false"/>.</returns>
        public static bool InvisibilityOfElementWithText(By by, string text)
        {
            try
            {
                var element = GlobalVar.AndroidDriver.FindElement(by);
                var elementText = element.Text;
                if (string.IsNullOrEmpty(elementText))
                {
                    return true;
                }

                return !elementText.Equals(text);
            }
            catch
            {
                return true;
            }
        }


        /// <summary>
        /// An expectation for checking if the given text is present in the element that matches the given locator.
        /// </summary>
        /// <returns><see langword="true"/> when the element contains the given text, otherwise <see langword="false"/>.</returns>
        public static bool TextPresent(By by, string text)
        {
            try
            {
                var element = GlobalVar.AndroidDriver.FindElement(by);
                return element.Text.Contains(text);
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// An expectation for checking the title of a screen.
        /// </summary>
        /// <returns><see langword="true"/> when the screen Title matches the given text, otherwise <see langword="false"/>.</returns>
        public static bool TitleIs(string title)
        {
            try
            {
                return (GlobalVar.AndroidDriver.Title.Equals(title));
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// An expectation for checking that the Title of a screen contains a certain title.
        /// </summary>
        /// <returns><see langword="true"/> when the screen Title contains the given title, otherwise <see langword="false"/>.</returns>
        public static bool TitleContains(string title)
        {
            try
            {
                return (GlobalVar.AndroidDriver.Title.Contains(title));
            }
            catch
            {
                return false;
            }
        }


        private static bool ElementSelectionState(AppiumWebElement element, bool selected)
        {
            return (element.Selected == selected);
        }


        #endregion END OF EXPECTED CONDITIONS METHODS


    }
}
