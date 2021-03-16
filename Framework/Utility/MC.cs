using System;
using System.Collections.Generic;
using System.Text;
using Framework.Utility.Activity;
using OpenQA.Selenium.Appium;

namespace Framework.Utility
{
    public static class MC
    {

        //public static void SetCommunicationConfig()
        //{

        //    Activity.ClickBy.ClassName("widget.ImageView");
        //    Activity.Misc.Sleep(2000);
        //    Activity.InputById("editTextCommConfigDeviceName", "AN0HHE5044");
        //    Activity.Misc.Sleep(500);
        //    Activity.InputById("editTextCommConfigHostTCPIP", "ciplatformdev.dsicloud.com");
        //    Activity.Misc.Sleep(500);
        //    Activity.InputById("editTextCommConfigPort", "4003");
        //    Activity.Misc.Sleep(500);
        //    Activity.InputById("editTextCommConfigHttpPort", "9003");
        //    Activity.Misc.Sleep(500);
        //    Activity.VerifyCheckBox("checkBoxCommConfigHttpsActive", "HTTPS Active");
        //    Activity.Misc.Sleep(500);
        //    Activity.HideKeyboard();
        //    Activity.Misc.Sleep(500);
        //    Activity.InputById("editTextCommConfigCommTimeOutShort", "60");
        //    Activity.Misc.Sleep(500);
        //    Activity.HideKeyboard();
        //    Activity.Misc.Sleep(500);
        //    Activity.InputById("editTextCommConfigCommTimeOut", "60");
        //    Activity.Misc.Sleep(500);
        //    Activity.HideKeyboard();
        //    Activity.Misc.Sleep(500);
        //    Activity.VerifyCheckBox("checkBoxCommConfigCommActive", "Communications active");
        //    Activity.Misc.Sleep(500);
        //    Activity.HideKeyboard();
        //    Activity.Misc.Sleep(500);
        //    Activity.ClickByClassName("widget.Button", "ok");
        //}

        //public static void Login(string user = "FF", string password = "FF")
        //{
        //    user += GlobalVar.UserId;
        //    Activity.InputById("editTextTCLoginUserId", user);
        //    Activity.InputById("editTextTCLoginPassword", password);
        //    Activity.ClickById("buttonTCLoginOK");
        //    Activity.Misc.Sleep(1000);
        //}

        //public static void SearchApp(string name)
        //{
        //    AppiumWebElement app = null;

        //    while (app == null)
        //    {
        //        app = Activity.ClickByClassName("widget.TextView", name);
        //        if (app == null)
        //            Activity.MoveScreen();
        //    }
        //}

        public static void SetCommunicationConfig()
        {

            Activity.Click.ByClassName("widget.ImageView");
            Activity.Misc.Sleep(2000);
            Activity.Input.ById("editTextCommConfigDeviceName", "AN0HHE5044");
            Activity.Misc.Sleep(500);
            Activity.Input.ById("editTextCommConfigHostTCPIP", "********");
            Activity.Misc.Sleep(500);
            Activity.Input.ById("editTextCommConfigPort", "4003");
            Activity.Misc.Sleep(500);
            Activity.Input.ById("editTextCommConfigHttpPort", "9003");
            Activity.Misc.Sleep(500);
            Activity.Verify.CheckBox("checkBoxCommConfigHttpsActive", "HTTPS Active");
            Activity.Misc.Sleep(500);
            Activity.Misc.HideKeyboard();
            Activity.Misc.Sleep(500);
            Activity.Input.ById("editTextCommConfigCommTimeOutShort", "60");
            Activity.Misc.Sleep(500);
            Activity.Misc.HideKeyboard();
            Activity.Misc.Sleep(500);
            Activity.Input.ById("editTextCommConfigCommTimeOut", "60");
            Activity.Misc.Sleep(500);
            Activity.Misc.HideKeyboard();
            Activity.Misc.Sleep(500);
            Activity.Verify.CheckBox("checkBoxCommConfigCommActive", "Communications active");
            Activity.Misc.Sleep(500);
            Activity.Misc.HideKeyboard();
            Activity.Misc.Sleep(500);
            Activity.Click.ByClassName("widget.Button", "OK");
        }

        public static void Login(string user = "FF", string password = "****")
        {
            user += GlobalVar.UserId;
            Activity.Input.ById("editTextTCLoginUserId", user);
            Activity.Input.ById("editTextTCLoginPassword", password);
            Activity.Click.ById("buttonTCLoginOK");
            Activity.Misc.Sleep(1000);
        }

        public static void SelectPlatform(string id, Share.Platform platform)
        {
            Activity.CheckBox.ClickById(id, platform.ToString());
        }

        public static void SearchApp(string name)
        {
            //Activity.Misc.ScrollToPartialView(Share.Selector.TextContains, name, true);
            Activity.Misc.ScrollToFullView(Share.Selector.ResourceId, "com.dsiglobal.mobileclient:id/appNameText", Share.Selector.TextContains, name, true);
            Activity.Misc.ScrollToPartialView(Share.Selector.TextContains, name, false);
        }
    }
}
