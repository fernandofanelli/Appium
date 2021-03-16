using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Utility
{
    public static class Share
    {
        public enum MobileDriver   
        {
            Android,
            Ios,
            Web
        }

        public enum Platform
        {
            Android,
            AndroidPhone,
            AndroidTablet_10inch,
            AndroidTablet_MOBILEApps,
            Android_Tablet,
            Android_Tablet_1280x720
        }

        public enum Browser
        {
            Chrome,
            Edge,
            Firefox,
            IE,
            Safari,
            Android,
            Ipad,
            Iphone
        }

        public enum Element
        {
            ActionMenuView,
            AdapterView,
            Button,
            CalendarView,
            CheckBox,
            DatePicker,
            EditText,
            ExpandableListView,
            ImageButton,
            ImageView,
            LinearLayout,
            ListView,
            RadioButton,
            RelativeLayout,
            ScrollView,
            TableLayout,
            TextView,
            Toast
        }

        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }

        public enum KeyCode
        {
            Back,
            Delete,
            Enter,
            Home
        }

        #region FIND ELEMENT OBJECTS

        #region EXPECTED CONDITIONS

        public enum Condition
        {
            ElementClickable,
            ElementExists,
            ElementsPresence,
            ElementIsVisible,
            ElementInvisibility,
            ElementSelected,
            ElementVisibility,
            ElementsVisibilities,
            TextPresent,
            TitleContains,
            TitleIs
        }

        #endregion

        #region BYLOCATORS

        public enum By
        {
            ClassName,
            CssSelector,
            Id,
            LinkText,
            Name,
            PartialLinkText,
            TagName,
            XPath
        }

        #endregion

        #endregion


        #region ANDROID UI

        #region UI AUTOMATOR

        public enum ListDirection
        {
            Vertical,
            Horizontal
        }

        public enum Selector
        {
            Null,
            Checkable,
            Checked,
            ChildSelector,
            ClassName,
            ClassNameMatches,
            Clickable,
            Description,
            DescriptionContains,
            DescriptionMatches,
            DescriptionStartsWith,
            Enable,
            Focusable,
            Focused,
            FromParent,
            Index,
            Instance,
            LongClickable,
            PackageName,
            PackageNameMatches,
            ResourceId,
            ResourceIdMatches,
            Scrollable,
            Selected,
            Text,
            TextContains,
            TextMatches,
            TextStartsWith
        }

        public enum Scrollable
        {
            FlingBackward,
            FlingForward,
            FlingToBeginning,
            FlingToEnd,
            GetChildByDescription,
            GetChildByInstance,
            GetChildByText,
            GetMaxSearchSwipes,
            GetSwipeDeadZonePercentage,
            ScrollBackward,
            ScrollDescriptionIntoView,
            ScrollForward,
            ScrollIntoView,
            ScrollTextIntoView,
            ScrollToBeginning,
            ScrollToEnd,
            SetAsHorizontalList,
            SetAsVerticalList,
            SetMaxSearchSwipes,
            SetSwipeDeadZonePercentage
        }

        #endregion UI AUTOMATOR

        #endregion
    }
}
