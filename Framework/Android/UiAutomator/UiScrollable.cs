using System.Globalization;
using System.Text;
using Framework.Android.UiAutomator;
using static Framework.Utility.Share;

namespace Framework.Android
{
    /// <summary>
    /// Wrap an Android UiScrollable method call
    /// </summary>
    /// <remarks>
    /// Documentation: https://developer.android.com/reference/androidx/test/uiautomator/UiScrollable
    /// </remarks>
    public class UiScrollable
    {
        private readonly StringBuilder _stringBuilder;

        // ************ DATE 10/16/2020 ************
        // All the possible Constructors till date.
        // ************ --------------- ************
        #region CONSTRUCTORS


        /// <summary>
        /// Creates a new scrollable searcher which will match the first scrollable widget in the view
        /// Automatically builds a Scrollable with a UiSelector type of Scrollable
        /// </summary>
        public UiScrollable()
        {
            _stringBuilder = new StringBuilder("new UiScrollable(");
            _stringBuilder.Append(new UiSelector().Build(Selector.Scrollable, true));
            _stringBuilder.Append(")");
        }


        /// <summary>
        /// Creates a new scrollable searcher which will match the first scrollable widget that matches with the UiSelector
        /// </summary>
        /// <param name="selector">a UiSelector used to find the scrollable container</param>
        /// <param name="text">text that belongs to the element you want to find</param>
        public UiScrollable(Selector selector, string text)
        {
            _stringBuilder = new StringBuilder("new UiScrollable(");
            _stringBuilder.Append(new UiSelector().Build(selector, text));
            _stringBuilder.Append(")");
        }


        #endregion END OF CONSTRUCTORS


        // ************ DATE 10/16/2020 ************
        // All the possible Builders till date.
        // ***** IMPORTANT: All Builders return a complete UiScrollable to be used mostly with UiAutomator searcher 
        // ************ --------------- ************
        #region BUILDERS


        #region SINGLE BUILDERS


        /// <summary>
        /// Builds a string concatenation of UiScrollable Type 
        /// </summary>
        /// <param name="scrollable">Represents the Enum in Share class, it can be:
        ///     FlingBackward/Forward ; GetMaxSearchSwipes ; GetSwipeDeadZonePercentage ; ScrollBackward/Forward
        /// </param>
        public string Build(Scrollable scrollable)
        {
            //_stringBuilder.Append(";");   verify if I need this
            BuildScrollable(scrollable);
            return _stringBuilder.ToString();
        }


        /// <summary>
        /// This make possible the build above.
        /// DO NOT TRY TO MODIFY THIS.
        /// </summary>
        private void BuildScrollable(Scrollable scrollable)
        {
            switch (scrollable)
            {
                case Scrollable.FlingBackward:
                    FlingBackward();
                    break;
                case Scrollable.FlingForward:
                    FlingForward();
                    break;
                case Scrollable.GetMaxSearchSwipes:
                    GetMaxSearchSwipes();
                    break;
                case Scrollable.GetSwipeDeadZonePercentage:
                    GetSwipeDeadZonePercentage();
                    break;
                case Scrollable.ScrollBackward:
                    ScrollBackward();
                    break;
                case Scrollable.ScrollForward:
                    ScrollForward();
                    break;
            }
        }


        /// <summary>
        /// Builds a string concatenation of UiScrollable Type based on a direction
        /// </summary>
        /// <param name="direction"> Represents the Enum in Share class, it can be:
        ///     Vertical ; Horizontal
        /// </param>
        public string Build(ListDirection direction)
        {
            //_stringBuilder.Append(";");   verify if I need this
            SetAs(direction.ToString());
            return _stringBuilder.ToString();
        }


        /// <summary>
        /// Builds a string concatenation of UiScrollable Type based on an UiSelector Type
        /// </summary>
        /// <param name="selector"> Represents the Enum in Share class </param>
        /// <param name="text"> text that belongs to the element you want to find </param>
        /// <param name="useFirst"> If one of does not work, then change the value to false </param>
        public string Build(Selector selector, string text, bool useFirst = true)
        {
            //_stringBuilder.Append(";");   verify if I need this
            if (useFirst)
                ScrollIntoView(selector, text);
            else
                ScrollIntoView2(selector, text);
            
            return _stringBuilder.ToString();
        }


        /// <summary>
        /// Builds a string concatenation of UiScrollable Type based on an UiScrollable Type that tries to match a text
        /// </summary>
        /// <param name="scrollable"> Represents the Enum in Share class </param>
        /// <param name="text"> text that belongs to the element you want to find </param>
        public string Build(Scrollable scrollable, string text)
        {
            //_stringBuilder.Append(";");   verify if I need this
            BuildScrollable(scrollable, text);
            return _stringBuilder.ToString();
        }


        /// <summary>
        /// This make possible the build above.
        /// DO NOT TRY TO MODIFY THIS.
        /// </summary>
        private void BuildScrollable(Scrollable scrollable, string text)
        {
            switch (scrollable)
            {
                case Scrollable.ScrollDescriptionIntoView:
                    ScrollDescriptionIntoView(text);
                    break;
                case Scrollable.ScrollTextIntoView:
                    ScrollTextIntoView(text);
                    break;
            }
        }


        /// <summary>
        /// Builds a string concatenation of UiScrollable Type based on a dead zone of no touch
        /// </summary>
        /// <param name="swipe"> Percentage of dead zone (no touch) when swiping</param>
        public string Build(double swipe)
        {
            //_stringBuilder.Append(";");   verify if I need this
            SetSwipeDeadZonePercentage(swipe);
            return _stringBuilder.ToString();
        }


        /// <summary>
        /// Builds a string concatenation of UiScrollable Type based on an UiScrollable Type that tries to swipe/fling
        /// </summary>
        /// <param name="scrollable"> Represents the Enum in Share class </param>
        /// <param name="value"> Amount of swipes/fling to be done </param>
        public string Build(Scrollable scrollable, int value)
        {
            //_stringBuilder.Append(";");   verify if I need this
            BuildScrollable(scrollable, value);
            return _stringBuilder.ToString();
        }


        /// <summary>
        /// This make possible the build above.
        /// DO NOT TRY TO MODIFY THIS.
        /// </summary>
        private void BuildScrollable(Scrollable scrollable, int value)
        {
            switch (scrollable)
            {
                case Scrollable.FlingToBeginning:
                    FlingToBeginning(value);
                    break;
                case Scrollable.FlingToEnd:
                    FlingToEnd(value);
                    break;
                case Scrollable.ScrollBackward:
                    ScrollBackward(value);
                    break;
                case Scrollable.ScrollForward:
                    ScrollForward(value);
                    break;
                case Scrollable.ScrollToBeginning:
                    ScrollToBeginning(value);
                    break;
                case Scrollable.ScrollToEnd:
                    ScrollToEnd(value);
                    break;
                case Scrollable.SetMaxSearchSwipes:
                    SetMaxSearchSwipes(value);
                    break;
            }
        }


        /// <summary>
        /// Builds a string concatenation of UiScrollable Type based on an UiScrollable Type that tries to swipe and move on screen
        /// </summary>
        /// <param name="scrollable"> Represents the Enum in Share class </param>
        /// <param name="steps"> number of steps. This is used to control the speed of the scroll action </param>
        /// <param name="swipes"> number of swipes on screen </param>
        public string Build(Scrollable scrollable, int steps, int swipes)
        {
            //_stringBuilder.Append(";");   verify if I need this
            BuildScrollable(scrollable, steps, swipes);
            return _stringBuilder.ToString();
        }


        /// <summary>
        /// This make possible the build above.
        /// DO NOT TRY TO MODIFY THIS.
        /// </summary>
        private void BuildScrollable(Scrollable scrollable, int steps, int swipes)
        {
            switch (scrollable)
            {
                case Scrollable.ScrollToBeginning:
                    ScrollToBeginning(swipes, steps);
                    break;
                case Scrollable.ScrollToEnd:
                    ScrollToEnd(swipes, steps);
                    break;
            }
        }


        #endregion END OF SINGLE BUILDERS


        #region CHILD BUILDERS


        /// <summary>
        /// Builds a string concatenation of UiScrollable Type based on an UiScrollable and UiSelector Type that tries to match the child of a selector in a widget
        /// </summary>
        /// <param name="scrollable"> Represents the Enum in Share class </param>
        /// <param name="selector"> Represents the Enum in Share class </param>
        /// <param name="text"> text that belongs to the element you want to find </param>
        /// <param name="allowScrollSearch"> set to true if scrolling is allow on the object </param>
        public string BuildChild(Scrollable scrollable, Selector selector, string text, bool allowScrollSearch = true)
        {
            //_stringBuilder.Append(";");   verify if I need this
            BuildScrollable(scrollable, selector, text, allowScrollSearch);
            return _stringBuilder.ToString();
        }


        /// <summary>
        /// This make possible the build above.
        /// DO NOT TRY TO MODIFY THIS.
        /// </summary>
        private void BuildScrollable(Scrollable scrollable, Selector selector, string text, bool allowScrollSearch)
        {
            switch (scrollable)
            {
                case Scrollable.GetChildByDescription:
                    GetChildByDescription(selector, text, allowScrollSearch);
                    break;
                case Scrollable.GetChildByText:
                    GetChildByText(selector, text, allowScrollSearch);
                    break;
            }
        }


        /// <summary>
        /// Builds a string concatenation of UiScrollable Type based on an UiScrollable and UiSelector Type that tries to match the child of a selector in a widget
        /// </summary>
        /// <param name="selector"> Represents the Enum in Share class </param>
        /// <param name="instance"> instance of the element you want to find, most of times is 0 </param>
        public string BuildChild(Selector selector, int instance)
        {
            //_stringBuilder.Append(";");   verify if I need this
            GetChildByInstance(selector, instance);
            return _stringBuilder.ToString();
        }


        #endregion END OF CHILD BUILDERS


        #endregion END OF BUILDERS


        // ************ DATE 10/16/2020 ************
        // All the possible builds of Scrollables for child or single elements till date.
        // ************ --------------- ************
        #region BUILDS OF SCROLLABLE CLASSES


        // ************ DATE 10/16/2020 ************
        // All the possible Scrollables to search for a child element till date.
        // ************ --------------- ************
        #region CONCATENATIONS OF SELECTORS CHILD


        /// <summary>
        /// Searches for a child element in the present scrollable container.
        /// The search first looks for a  child element that matches the selector you provided, then looks for the content-description in
        /// its children elements. If both search conditions are fulfilled, the method returns a {@ link UiObject} representing the element
        /// matching the selector (not the child element in its sub-hierarchy containing the content-description).
        /// By default, this method performs a scroll search.
        /// Maps to: UiScrollable.getChildByDescription(UiSelector, String, boolean) method (see remarks).
        /// </summary>
        /// <param name="selector"> UiSelector for a child in a scollable layout element </param>
        /// <param name="description"> Content-description to find in the children of the childPattern match </param>
        /// <param name="allowScrollSearch"> Set to true if scrolling is allowed </param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiScrollable#getChildByDescription(androidx.test.uiautomator.UiSelector,%20java.lang.String,%20boolean)</remarks>
        private void GetChildByDescription(Selector selector, string description, bool allowScrollSearch = true)
        {
            _stringBuilder.Append(".getChildByDescription(");
            _stringBuilder.Append(MiscUiAutomator.ReBuildString(selector));
            _stringBuilder.Append(", \"");
            _stringBuilder.Append(description);
            _stringBuilder.Append("\", ");
            _stringBuilder.Append(allowScrollSearch.ToString().ToLowerInvariant());
            _stringBuilder.Append(")");
        }


        /// <summary>
        /// Searches for a child element in the present scrollable container that matches the selector you provided.
        /// The search is performed without scrolling and only on visible elements.
        /// Maps to: UiScrollable.getChildByInstance (UiSelector childPattern, int instance) method (see remarks).
        /// </summary>
        /// <param name="selector"> UiSelector for a child in a scollable layout element </param>
        /// <param name="instance"> number representing the occurance of a childPattern match </param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiScrollable#getChildByInstance(androidx.test.uiautomator.UiSelector,%20int)</remarks>
        private void GetChildByInstance(Selector selector, int instance)
        {
            _stringBuilder.Append(".getChildByInstance(");
            _stringBuilder.Append(MiscUiAutomator.ReBuildString(selector));
            _stringBuilder.Append(", ");
            _stringBuilder.Append(instance.ToString());
            _stringBuilder.Append(")");
        }


        /// <summary>
        /// Searches for a child element in the present scrollable container. The search first looks for a child element that matches the
        /// selector you provided, then looks for the text in its children elements. If both search conditions are fulfilled, the method
        /// returns a {@ link UiObject} representing the element matching the selector (not the child element in its sub-hierarchy containing the text).
        /// Maps to: UiScrollable.getChildByText (UiSelector childPattern, String text, boolean allowScrollSearch) method (see remarks).
        /// </summary>
        /// <param name="selector"> UiSelector for a child in a scollable layout element </param>
        /// <param name="text"> text to find in the children of the childPattern match </param>
        /// <param name="allowScrollSearch"> Set to true if scrolling is allowed </param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiScrollable#getChildByInstance(androidx.test.uiautomator.UiSelector,%20int)</remarks>
        private void GetChildByText(Selector selector, string text, bool allowScrollSearch = true)
        {
            _stringBuilder.Append(".getChildByText(");
            _stringBuilder.Append(MiscUiAutomator.ReBuildString(selector));
            _stringBuilder.Append(", \"");
            _stringBuilder.Append(text);
            _stringBuilder.Append("\", ");
            _stringBuilder.Append(allowScrollSearch.ToString().ToLowerInvariant());
            _stringBuilder.Append(")");
        }


        #endregion END OF CONCATENATIONS OF SELECTORS CHILD


        // ************ DATE 10/16/2020 ************
        // All the possible Scrollables to search for a single element till date.
        // ************ --------------- ************
        #region SINGLE SCROLLABLES


        /// <summary>
        /// Performs a backwards fling action with the default number of fling steps (5).
        /// If the swipe direction is set to vertical, then the swipe will be performed from top to bottom. If the swipe
        /// direction is set to horizontal, then the swipes will  be performed from left to right.
        /// Make sure to take into account devices configured with right-to-left languages like Arabic and Hebrew.
        /// Maps to: UiScrollable.flingBackward() method (see remarks).
        /// </summary>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiScrollable#flingBackward()</remarks>
        private void FlingBackward()
        {
            _stringBuilder.Append(".flingBackward()");
        }


        /// <summary>
        /// Performs a forward  fling action with the default number of fling steps (5).
        /// If the swipe direction is set to vertical, then the swipe will be performed from top to bottom. If the swipe
        /// direction is set to horizontal, then the swipes will  be performed from left to right.
        /// Make sure to take into account devices configured with right-to-left languages like Arabic and Hebrew.
        /// Maps to: UiScrollable.flingForward() method (see remarks).
        /// </summary>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiScrollable#flingForward()</remarks>
        private void FlingForward()
        {
            _stringBuilder.Append(".flingForward()");
        }


        /// <summary>
        /// Performs a fling gesture to reach the beginning of a scrollable layout element.
        /// The beginning can be at the top-most edge in the case of vertical controls, or the left-most edge for horizontal controls.
        /// Make sure to take into account devices configured with right-to-left languages like Arabic and Hebrew.
        /// Maps to: UiScrollable.flingToBeginning(int maxSwipes) method (see remarks).
        /// </summary>
        /// <param name="maxSwipes"></param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiScrollable#flingToBeginning(int)</remarks>
        private void FlingToBeginning(int maxSwipes)
        {
            _stringBuilder.Append(".flingToBeginning(");
            _stringBuilder.Append(maxSwipes.ToString());
            _stringBuilder.Append(")");
        }


        /// <summary>
        /// Performs a fling gesture to reach the end of a scrollable layout element.
        /// The beginning can be at the top-most edge in the case of vertical controls, or the left-most edge for horizontal controls.
        /// Make sure to take into account devices configured with right-to-left languages like Arabic and Hebrew.
        /// Maps to: UiScrollable.flingToEnd(int maxSwipes) method (see remarks).
        /// </summary>
        /// <param name="maxSwipes"></param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiScrollable#flingToEnd(int)</remarks>
        private void FlingToEnd(int maxSwipes)
        {
            _stringBuilder.Append(".flingToEnd(");
            _stringBuilder.Append(maxSwipes.ToString());
            _stringBuilder.Append(")");
        }


        /// <summary>
        /// Gets the maximum number of scrolls allowed when performing a scroll action in search of a child element
        /// Maps to: UiScrollable.getMaxSearchSwipes() method (see remarks).
        /// </summary>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiScrollable#getMaxSearchSwipes()</remarks>
        private void GetMaxSearchSwipes()
        {
            _stringBuilder.Append(".getMaxSearchSwipes()");
        }


        /// <summary>
        /// Returns the percentage of a widget's size that's considered as a no-touch zone when swiping. The no-touch zone is set as a
        /// percentage of a widget's total width or height, denoting a margin around the swipable area of the widget. Swipes must start
        /// and end inside this margin. This is important when the widget being swiped may not respond to the swipe if started at a point
        /// too near to the edge. The default is 10% from either edge.
        /// Maps to: UiScrollable.getSwipeDeadZonePercentage() method (see remarks).
        /// </summary>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiScrollable#getSwipeDeadZonePercentage()</remarks>
        private void GetSwipeDeadZonePercentage()
        {
            _stringBuilder.Append(".getSwipeDeadZonePercentage()");
        }


        /// <summary>
        /// Performs a backward scroll with the default number of scroll steps (55). If the swipe direction is set to vertical,  then the swipes
        /// will be performed from top to bottom.If the swipe direction is set to horizontal, then the swipes will be performed from left to right.
        /// Make sure to take into account devices configured with right-to-left languages like Arabic and Hebrew.
        /// Maps to: UiScrollable.scrollBackward(int maxSwipes) method (see remarks).
        /// </summary>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiScrollable#scrollBackward()</remarks>
        private void ScrollBackward()
        {
            _stringBuilder.Append(".scrollBackward()");
        }


        /// <summary>
        /// Performs a backward scroll. If the swipe direction is set to vertical, then the swipes will be performed from top to bottom.
        /// If the swipe direction is set to horizontal, then the swipes will be performed from left to right.
        /// Make sure to take into account devices configured with right-to-left languages like Arabic and Hebrew.
        /// Maps to: UiScrollable.scrollBackward(int steps) method (see remarks).
        /// </summary>
        /// <param name="steps"> number of steps. Use this to control the speed of the scroll action. </param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiScrollable#scrollBackward(int)</remarks>
        private void ScrollBackward(int steps)
        {
            _stringBuilder.Append(".scrollBackward(");
            _stringBuilder.Append(steps.ToString());
            _stringBuilder.Append(")");
        }


        /// <summary>
        /// Performs a forward scroll action on the scrollable layout element until the content-description is found, or until swipe attempts have been exhausted.
        /// Maps to: UiScrollable.scrollDescriptionIntoView(String text) method (see remarks).
        /// </summary>
        /// <param name="description"> content-description to find within the contents of this scrollable layout element. </param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiScrollable#scrollDescriptionIntoView(java.lang.String)</remarks>
        private void ScrollDescriptionIntoView(string description)
        {
            _stringBuilder.Append(".scrollDescriptionIntoView(\"");
            _stringBuilder.Append(description);
            _stringBuilder.Append("\")");
        }


        /// <summary>
        /// Performs a forward scroll with the default number of scroll steps (55). If the swipe direction is set to vertical, then the swipes will
        /// be performed from bottom to top. If the swipe direction is set to horizontal, then the swipes will be performed from right to left.
        /// Make sure to take into account devices configured with right-to-left languages like Arabic and Hebrew.
        /// Maps to: UiScrollable.scrollForward(int steps) method (see remarks).
        /// </summary>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiScrollable#scrollForward()</remarks>
        private void ScrollForward()
        {
            _stringBuilder.Append(".scrollForward()");
        }


        /// <summary>
        /// Performs a forward scroll. If the swipe direction is set to vertical, then the swipes will be performed from bottom to top.
        /// If the swipe direction is set to horizontal, then the swipes will be performed from right to left.
        /// Make sure to take into account devices configured with right-to-left languages like Arabic and Hebrew.
        /// Maps to: UiScrollable.scrollForward(int steps) method (see remarks).
        /// </summary>
        /// <param name="maxSwipes"></param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiScrollable#scrollForward(int)</remarks>
        private void ScrollForward(int steps)
        {
            _stringBuilder.Append(".scrollForward(");
            _stringBuilder.Append(steps.ToString());
            _stringBuilder.Append(")");
        }


        /// <summary>
        /// Perform a scroll forward action to move through the scrollable layout element until a visible item that matches the selector is found.
        /// Maps to: UiScrollable.scrollIntoView(UiSelector selector) method (see remarks).
        /// </summary>
        /// <param name="selector"></param>
        /// /// <param name="text"> text to look for </param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiScrollable#scrollIntoView(androidx.test.uiautomator.UiSelector)</remarks>
        private void ScrollIntoView(Selector selector, string text)
        {
            _stringBuilder.Append(".scrollIntoView(");
            _stringBuilder.Append(new UiSelector().Build(selector, text));
            _stringBuilder.Append(")");
        }


        /// <summary>
        /// Perform a scroll forward action to move through the scrollable layout element until a visible item that matches the selector is found.
        /// Maps to: UiScrollable.scrollIntoView(UiSelector selector) method (see remarks).
        /// </summary>
        /// <param name="selector"></param>
        /// /// <param name="value"></param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiScrollable#scrollIntoView(androidx.test.uiautomator.UiSelector)</remarks>
        private void ScrollIntoView2(Selector selector, string value)
        {
            _stringBuilder.Append(".scrollIntoView(");
            _stringBuilder.Append(MiscUiAutomator.ReBuildString(selector));
            _stringBuilder.Append("(\"");
            _stringBuilder.Append(value);
            _stringBuilder.Append("\"))");
        }


        /// <summary>
        /// Performs a forward scroll action on the scrollable layout element until the text you provided is visible, or until swipe attempts have been exhausted.
        /// Maps to: UiScrollable.scrollTextIntoView(String text) method (see remarks).
        /// </summary>
        /// <param name="text"> text to look for </param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiScrollable#scrollTextIntoView(java.lang.String)</remarks>
        private void ScrollTextIntoView(string text)
        {
            _stringBuilder.Append(".scrollTextIntoView(\"");
            _stringBuilder.Append(text);
            _stringBuilder.Append("\")");
        }


        /// <summary>
        /// Scrolls to the beginning of a scrollable layout element. The beginning can be at the top-most edge in
        /// the case of vertical controls, or the left-most edge for horizontal controls.
        /// Make sure to take into account devices configured with right-to-left languages like Arabic and Hebrew.
        /// Maps to: UiScrollable.scrollToBeginning(int maxSwipes) method (see remarks).
        /// </summary>
        /// <param name="maxSwipes"></param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiScrollable#scrollToBeginning(int)</remarks>
        private void ScrollToBeginning(int maxSwipes)
        {
            _stringBuilder.Append(".scrollToBeginning(");
            _stringBuilder.Append(maxSwipes.ToString());
            _stringBuilder.Append(")");
        }


        /// <summary>
        /// Scrolls to the beginning of a scrollable layout element. The beginning can be at the top-most edge in
        /// the case of vertical controls, or the left-most edge for horizontal controls.
        /// Make sure to take into account devices configured with right-to-left languages like Arabic and Hebrew.
        /// Maps to: UiScrollable.scrollToBeginning (int maxSwipes, int steps) method (see remarks).
        /// </summary>
        /// <param name="maxSwipes"></param>
        /// <param name="steps"> use steps to control the speed, so that it may be a scroll, or fling </param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiScrollable#scrollToBeginning(int,%20int)</remarks>
        private void ScrollToBeginning(int maxSwipes, int steps)
        {
            _stringBuilder.Append(".scrollToBeginning(");
            _stringBuilder.Append(maxSwipes.ToString());
            _stringBuilder.Append(",");
            _stringBuilder.Append(steps.ToString());
            _stringBuilder.Append(")");
        }


        /// <summary>
        /// Scrolls to the end of a scrollable layout element. The end can be at the bottom-most edge in
        /// the case of vertical controls, or the right-most edge for horizontal controls.
        /// Make sure to take into account devices configured with right-to-left languages like Arabic and Hebrew.
        /// Maps to: UiScrollable.scrollToEnd(int maxSwipes) method (see remarks).
        /// </summary>
        /// <param name="maxSwipes"></param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiScrollable#scrollToEnd(int)</remarks>
        private void ScrollToEnd(int maxSwipes)
        {
            _stringBuilder.Append(".scrollToEnd(");
            _stringBuilder.Append(maxSwipes.ToString());
            _stringBuilder.Append(")");
        }


        /// <summary>
        /// Scrolls to the end of a scrollable layout element. The end can be at the bottom-most edge in
        /// the case of vertical controls, or the right-most edge for horizontal controls. 
        /// Make sure to take into account devices configured with right-to-left languages like Arabic and Hebrew.
        /// Maps to: UiScrollable.scrollToEnd(int maxSwipes, int steps) method (see remarks).
        /// </summary>
        /// <param name="maxSwipes"></param>
        /// <param name="steps"> use steps to control the speed, so that it may be a scroll, or fling </param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiScrollable#scrollToEnd(int,%20int)</remarks>
        private void ScrollToEnd(int maxSwipes, int steps)
        {
            _stringBuilder.Append(".scrollToEnd(");
            _stringBuilder.Append(maxSwipes.ToString());
            _stringBuilder.Append(",");
            _stringBuilder.Append(steps.ToString());
            _stringBuilder.Append(")");
        }


        /// <summary>
        /// Set the direction of swipes to be horizontal/vertical when performing scroll actions.
        /// Maps to: UiScrollable.setAsHorizontalList() or UiScrollable.setAsVerticalList() method (see remarks).
        /// </summary>
        /// <param name="direction"> horizontal or vertical </param>
        /// <remarks>
        /// Horizontal: https://developer.android.com/reference/androidx/test/uiautomator/UiScrollable#setAsHorizontalList()
        /// Vertical: https://developer.android.com/reference/androidx/test/uiautomator/UiScrollable#setAsVerticalList()
        /// </remarks>
        private void SetAs(string direction)
        {
            _stringBuilder.Append(".setAs");
            _stringBuilder.Append(direction);
            _stringBuilder.Append("List()");
        }


        /// <summary>
        /// Sets the maximum number of scrolls allowed when performing a scroll action in search of a child element.
        /// Maps to: UiScrollable.setMaxSearchSwipes(int swipes) method (see remarks).
        /// </summary>
        /// <param name="swipes"> the number of search swipes to perform until giving up </param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiScrollable#setMaxSearchSwipes(int)</remarks>
        private void SetMaxSearchSwipes(int swipes)
        {
            _stringBuilder.Append(".setMaxSearchSwipes(");
            _stringBuilder.Append(swipes.ToString());
            _stringBuilder.Append(")");
        }


        /// <summary>
        /// Sets the percentage of a widget's size that's considered as no-touch zone when swiping. The no-touch zone is set as percentage
        /// of a widget's total width or height, denoting a margin around the swipable area of the widget. Swipes must always start and end
        /// inside this margin. This is important when the widget being swiped may not respond to the swipe if started at a point too near
        /// to the edge. The default is 10% from either edge.
        /// Make sure to take into account devices configured with right-to-left languages like Arabic and Hebrew.
        /// Maps to: UiScrollable.setSwipeDeadZonePercentage(double swipeDeadZonePercentage) method (see remarks).
        /// </summary>
        /// <param name="swipeDeadZonePercentage"> is a value between 0 and 1 </param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiScrollable#setSwipeDeadZonePercentage(double)</remarks>
        private void SetSwipeDeadZonePercentage(double swipeDeadZonePercentage)
        {
            _stringBuilder.Append(".setSwipeDeadZonePercentage(");
            _stringBuilder.Append(swipeDeadZonePercentage.ToString(CultureInfo.InvariantCulture));
            _stringBuilder.Append(")");
        }


        #endregion END OF SINGLE SCROLLABLES


        #endregion END OF BUILDS OF SCROLLABLE CLASSES
    }
}
