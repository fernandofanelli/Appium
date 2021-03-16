using System;
using System.Collections.Generic;
using System.Text;
using Framework.Utility.Core;
using NUnit.Framework;
using static Framework.Utility.Share;

namespace Framework.Utility.Activity
{
    public static class CheckBox
    {

        #region CHECKBOX CLICK

        // ************ DATE 10/16/2020 ************
        // ***** IMPORTANT: All CHECKBOX Click by CLASSNAME will search an element and then click it.
        // ************ --------------- ************
        #region BY CLASSNAME


        /// <summary>
        /// Finds the first element in the screen that matches the className criteria and clicks it.
        /// </summary>
        /// <param name="className">ClassName to find the object. Most of the time will be widget.CheckBox.</param>
        public static void ClickByClassName(string className)
        {
            try
            {
                Click.ByClassName(className);
            }
            catch (Exception ex)
            {
                Assert.Fail("CheckboxClickByClassName threw an exception: " + ex.Message);
            }
        }


        /// <summary>
        /// Finds a collection of elements and then iterates every element till the text matches (completely or partial) and clicks it.
        /// </summary>
        /// <param name="className">ClassName to find the object. Most of the time will be widget.CheckBox.</param>
        /// <param name="text">Text to match a specific element</param>
        public static void ClickByClassName(string className, string text)
        {
            try
            {
                Click.ByClassName(className, text);
            }
            catch (Exception ex)
            {
                Assert.Fail("CheckboxClickByClassName threw an exception: " + ex.Message);
            }
        }


        #endregion END OF BY CLASSNAME

        #region BY ID

        public static void ClickById(string id, string deviceType)
        {
            try
            {
                var linearLayoutList = GlobalVar.AndroidDriver.FindElementById("list");
                var elements = linearLayoutList.FindElementsByClassName("android.widget.LinearLayout");
                foreach (var elem in elements)
                {
                    var name = elem.FindElementById("platformId").Text;
                    if (name.Contains(deviceType))
                    {
                        elem.FindElementById(id).Click();
                        return;
                    }
                }
                Assert.Fail("ClickById could not found the checkbox to be clicked");
            }
            catch (Exception ex)
            {
                Assert.Fail("ClickById threw an exception: " + ex.Message);
            }
        }

        #endregion BY ID

        #region BY DEVICE

        public static void ClickByDevice(string element, int position, MobileDriver deviceType = MobileDriver.Android)
        {
            try
            {
                var elements = GlobalVar.AndroidDriver.FindElementsById(element);
                switch (deviceType)
                {
                    case MobileDriver.Android:
                        elements[position].Click();
                        break;
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("ClickCheckBoxByDevice threw an exception: " + ex.Message);
            }
        }

        #endregion BY DEVICE

        #endregion CHECKBOX CLICK
    }
}
