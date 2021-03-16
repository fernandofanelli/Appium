using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Core.Internal;
using Framework.Utility.Core;
using NUnit.Framework;
using OpenQA.Selenium.Appium;

namespace Framework.Utility.Activity
{
    public static class Verify
    {

        public static void CheckBox(string id, string text, bool check = true)
        {
            try
            {
                var checkbox = text.IsNullOrEmpty() ? GetControl.ById(id) : GetControl.ById(id, text);

                if (!checkbox.GetAttribute("checked").Contains("true"))
                    checkbox.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("VerifyCheckBox threw an exception: " + ex.Message);
            }
        }

        public static void Message(string id, string text)
        {
            try
            {
                var messageBox = GetControl.ById(id);
                if (messageBox.Text.Contains(text))
                    return;

                Assert.Fail("The message was not found");
            }
            catch (Exception ex)
            {
                Assert.Fail("VerifyMessage threw an exception: " + ex.Message);
            }
        }

        public static void Title(string className, string text, bool isBold = true)
        {
            try
            {
                var elements = GetControl.CollectionByClass(className);
                foreach (var elem in elements)
                {
                    if (isBold)
                    { // && elem.GetCssValue("font-weight").ToLower().Equals("bold")
                        if (elem.Text.Equals(text))
                            return;
                    }
                    else
                    {
                        if (elem.Text.Equals(text))
                            return;
                    }
                }
                Assert.Fail("The text was not found or isn't bold");
            }
            catch (Exception ex)
            {
                Assert.Fail("VerifyTitle threw an exception: " + ex.Message);
            }
        }

        public static void Images()
        {
            try
            {
                var images = GetControl.CollectionByClass("widget.ImageView");
                var firstImg = images.ElementAt(2);
                var secondImg = images.ElementAt(3);

                if (firstImg.Location.Y != secondImg.Location.Y)
                    Assert.Fail("Images hasn't the same vertical alignment");
                else if (firstImg.Location.X > secondImg.Location.X)
                    Assert.Fail("The images are not in the right order");
            }
            catch (Exception ex)
            {
                Assert.Fail("VerifyImage threw an exception: " + ex.Message);
            }
        }

    }
}
