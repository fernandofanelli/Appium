using System.Text;
using static Framework.Utility.Share;

namespace Framework.Android
{
    /// <summary>
    /// Wrap an Android UiSelector method call
    /// </summary>
    /// <remarks>
    /// Documentation: https://developer.android.com/reference/androidx/test/uiautomator/UiSelector
    /// </remarks>
    public class UiSelector
    {
        private readonly StringBuilder _stringBuilder;


        // ************ DATE 10/16/2020 ************
        // All the possible Constructors till date.
        // ************ --------------- ************
        #region CONSTRUCTORS


        /// <summary>
        /// Creates a new selector builder mostly to be used to search with UiAutomator.
        /// </summary>
        public UiSelector()
        {
            _stringBuilder = new StringBuilder("new UiSelector()");
        }


        /// <summary>
        /// Creates a new selector builder with a specific text mostly to be used to search with UiAutomator.
        /// </summary>
        /// <param name="text"></param>
        public UiSelector(string text)
        {
            _stringBuilder = new StringBuilder(text);
        }


        #endregion END OF CONSTRUCTORS


        // ************ DATE 10/16/2020 ************
        // All the possible Builders till date.
        // ***** IMPORTANT: All Builders return a complete UiSelector to be used mostly with UiAutomator searcher 
        // ************ --------------- ************
        #region BUILDERS


        #region SINGLE BUILDERS


        /// <summary>
        /// Creates a new UiSelector builder by copying all existing data from the given selector
        /// </summary>
        /// <param name="selector"> Represents the Enum in Share class </param>
        /// <param name="text"> the partial/complete text of an element to be found </param>
        /// <param name="position"> position of an object on the layout hierarchy </param>
        public string Build(Selector selector, string text, int position = 0)
        {
            BuildSelector(selector, text);
            Instance(position);
            return _stringBuilder.ToString();
        }


        /// <summary>
        /// This make possible the build above.
        /// DO NOT TRY TO MODIFY THIS.
        /// </summary>
        private void BuildSelector(Selector selector, string text)
        {
            switch (selector)
            {
                case Selector.ClassName:
                    ClassName(text);
                    break;
                case Selector.ClassNameMatches:
                    ClassNameMatches(text);
                    break;
                case Selector.Description:
                    Description(text);
                    break;
                case Selector.DescriptionContains:
                    DescriptionContains(text);
                    break;
                case Selector.DescriptionMatches:
                    DescriptionMatches(text);
                    break;
                case Selector.DescriptionStartsWith:
                    DescriptionStartsWith(text);
                    break;
                case Selector.PackageName:
                    PackageName(text);
                    break;
                case Selector.PackageNameMatches:
                    PackageNameMatches(text);
                    break;
                case Selector.ResourceId:
                    ResourceId(text);
                    break;
                case Selector.ResourceIdMatches:
                    ResourceIdMatches(text);
                    break;
                case Selector.Text:
                    Text(text);
                    break;
                case Selector.TextContains:
                    TextContains(text);
                    break;
                case Selector.TextMatches:
                    TextMatches(text);
                    break;
                case Selector.TextStartsWith:
                    TextStartsWith(text);
                    break;
            }
        }


        /// <summary>
        /// Creates a new UiSelector builder by copying all existing data from the given selector
        /// </summary>
        /// <param name="selector"> Represents the Enum in Share class </param>
        /// <param name="value"> the boolean value of an element to be found </param>
        /// <param name="position"> position of an object on the layout hierarchy </param>
        public string Build(Selector selector, bool value, int position = 0)
        {
            BuildSelector(selector, value);
            Instance(position);
            return _stringBuilder.ToString();
        }


        /// <summary>
        /// This make possible the build above.
        /// DO NOT TRY TO MODIFY THIS.
        /// </summary>
        private void BuildSelector(Selector selector, bool value)
        {
            switch (selector)
            {
                case Selector.Checkable:
                    IsCheckable(value);
                    break;
                case Selector.Checked:
                    IsChecked(value);
                    break;
                case Selector.Clickable:
                    IsClickable(value);
                    break;
                case Selector.Enable:
                    IsEnable(value);
                    break;
                case Selector.Focusable:
                    IsFocusable(value);
                    break;
                case Selector.Focused:
                    IsFocused(value);
                    break;
                case Selector.LongClickable:
                    IsLongClickable(value);
                    break;
                case Selector.Scrollable:
                    IsScrollable(value);
                    break;
                case Selector.Selected:
                    IsSelected(value);
                    break;
            }
        }


        #endregion END OF SINGLE BUILDERS


        #region CHILD/PARENT BUILDERS


        /// <summary>
        /// Builds a string concatenation of UiSelector Type based on an other UiSelector that tries to match the child of this selector in a widget
        /// </summary>
        /// <param name="selector"> Represents the Enum in Share class </param>
        /// <param name="value"> the boolean value of an element to be found </param>
        /// <param name="position"> position of an object on the layout hierarchy </param>
        public string BuildChildSelector(Selector selector, bool value, int position = 0)
        {
            ChildSelector(selector, value, position);
            return _stringBuilder.ToString();
        }


        /// <summary>
        /// Builds a string concatenation of UiSelector Type based on an other UiSelector that tries to match the child of this selector in a widget
        /// </summary>
        /// <param name="selector"> Represents the Enum in Share class </param>
        /// <param name="text"> the partial/complete text of an element to be found </param>
        /// <param name="position"> position of an object on the layout hierarchy </param>
        public string BuildChildSelector(Selector selector, string text, int position = 0)
        {
            ChildSelector(selector, text, position);
            return _stringBuilder.ToString();
        }


        /// <summary>
        /// Builds a string concatenation of UiSelector Type based on an other UiSelector that tries to match the parent of this selector in a widget
        /// </summary>
        /// <param name="selector"> Represents the Enum in Share class </param>
        /// <param name="value"> the boolean value of an element to be found </param>
        /// <param name="position"> position of an object on the layout hierarchy </param>
        public string BuildParentSelector(Selector selector, bool value, int position = 0)
        {
            FromParent(selector, value, position);
            return _stringBuilder.ToString();
        }


        /// <summary>
        /// Builds a string concatenation of UiSelector Type based on an other UiSelector that tries to match the parent of this selector in a widget
        /// </summary>
        /// <param name="selector"> Represents the Enum in Share class </param>
        /// <param name="text"> the partial/complete text of an element to be found </param>
        /// <param name="position"> position of an object on the layout hierarchy </param>
        public string BuildParentSelector(Selector selector, string text, int position = 0)
        {
            FromParent(selector, text, position);
            return _stringBuilder.ToString();
        }


        #endregion END OF CHILD/PARENT BUILDERS


        #endregion END OF BUILDERS


        // ************ DATE 10/16/2020 ************
        // All the possible builds of Selectors for child or single elements till date.
        // ************ --------------- ************
        #region BUILDS OF SELECTOR CLASSES


        // ************ DATE 10/16/2020 ************
        // All the possible Selectos to search for a child & parent element till date.
        // ************ --------------- ************
        #region CONCATENATIONS OF SELECTORS CHILD & PARENT


        /// <summary>
        /// Adds a child UiSelector criteria to this selector. Use this selector to narrow the search scope to child widgets under a specific parent widget.
        /// Maps to: UiSelector.childSelector(UiSelector selector) method (see remarks).
        /// </summary>
        /// <param name="selector"> Represents the Enum in Share class </param>
        /// <param name="value"> the boolean value of an element to be found </param>
        /// <param name="position"> position of an object on the layout hierarchy </param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiSelector#childSelector(androidx.test.uiautomator.UiSelector)</remarks>
        private void ChildSelector(Selector selector, bool value, int position)
        {
            _stringBuilder.Append(".childSelector(new UiSelector()");
            BuildSelector(selector, value);
            Instance(position);
            _stringBuilder.Append(")");
        }


        /// <summary>
        /// Adds a child UiSelector criteria to this selector. Use this selector to narrow the search scope to child widgets under a specific parent widget.
        /// Maps to: UiSelector.childSelector(UiSelector selector) method (see remarks).
        /// </summary>
        /// <param name="selector"> Represents the Enum in Share class </param>
        /// <param name="text"> the partial/complete text of an element to be found </param>
        /// <param name="position"> position of an object on the layout hierarchy </param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiSelector#childSelector(androidx.test.uiautomator.UiSelector)</remarks>
        private void ChildSelector(Selector selector, string text, int position)
        {
            _stringBuilder.Append(".childSelector(new UiSelector()");
            BuildSelector(selector, text);
            Instance(position);
            _stringBuilder.Append(")");
        }


        /// <summary>
        /// Adds a child UiSelector criteria to this selector which is used to start search from the parent widget. Use this selector to narrow the search
        /// scope to sibling widgets as well all child widgets under a parent.
        /// Maps to: UiSelector.fromParent(UiSelector selector) method (see remarks).
        /// </summary>
        /// <param name="selector"> Represents the Enum in Share class </param>
        /// <param name="value"> the boolean value of an element to be found </param>
        /// <param name="position"> position of an object on the layout hierarchy </param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiSelector#fromParent(androidx.test.uiautomator.UiSelector)</remarks>
        private void FromParent(Selector selector, bool value, int position)
        {
            _stringBuilder.Append(".fromParent(new UiSelector()");
            BuildSelector(selector, value);
            Instance(position);
            _stringBuilder.Append(")");
        }


        /// <summary>
        /// Adds a child UiSelector criteria to this selector which is used to start search from the parent widget. Use this selector to narrow the search
        /// scope to sibling widgets as well all child widgets under a parent.
        /// Maps to: UiSelector.childSelector(UiSelector selector) method (see remarks).
        /// </summary>
        /// <param name="selector"> Represents the Enum in Share class </param>
        /// <param name="text"> the partial/complete text of an element to be found </param>
        /// <param name="position"> position of an object on the layout hierarchy </param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiSelector#fromParent(androidx.test.uiautomator.UiSelector)</remarks>
        private void FromParent(Selector selector, string text, int position)
        {
            _stringBuilder.Append(".fromParent(new UiSelector()");
            BuildSelector(selector, text);
            Instance(position);
            _stringBuilder.Append(")");
        }


        #endregion END OF CONCATENATIONS OF SELECTORS CHILD & PARENT


        // ************ DATE 10/16/2020 ************
        // All the possible Selectors to search for a single element till date.
        // ************ --------------- ************
        #region SINGLE SELECTORS


        /// <summary>
        /// Set the search criteria to match widgets that are checkable. Typically, using this search criteria alone is not useful.
        /// You should also include additional criteria, such as text, content-description, or the class name for a widget.
        /// If no other search criteria is specified, and there is more than one matching widget, the first widget in the tree is selected.
        /// Maps to: UiSelector.checkable(boolean val) method (see remarks).
        /// </summary>
        /// <param name="value"> Value to match </param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiSelector#checkable(boolean)</remarks>
        private void IsCheckable(bool value)
        {
            _stringBuilder.Append(".checkable(");
            _stringBuilder.Append(value.ToString().ToLowerInvariant());
            _stringBuilder.Append(")");
        }


        /// <summary>
        /// Set the search criteria to match widgets that are currently checked (usually for checkboxes). Typically, using this search
        /// criteria alone is not useful. You should also include additional criteria, such as text, content-description, or the class name
        /// for a widget. If no other search criteria is specified, and there is more than one matching widget, the first widget in the tree is selected.
        /// Maps to: UiSelector.checked(boolean val) method (see remarks).
        /// </summary>
        /// <param name="value"> Value to match </param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiSelector#checked(boolean)</remarks>
        private void IsChecked(bool value)
        {
            _stringBuilder.Append(".checked(");
            _stringBuilder.Append(value.ToString().ToLowerInvariant());
            _stringBuilder.Append(")");
        }


        /// <summary>
        /// Set the search criteria to match the class property for a widget (for example, "android.widget.Button").
        /// Maps to: UiSelector.className(String className) method (see remarks).
        /// </summary>
        /// <param name="className"> Value to match </param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiSelector#className(java.lang.String)</remarks>
        private void ClassName(string className)
        {
            _stringBuilder.Append(".className(\"");
            _stringBuilder.Append(className);
            _stringBuilder.Append("\")");
        }


        /// <summary>
        /// Set the search criteria to match the class property for a widget, using a regular expression.
        /// Maps to: UiSelector.classNameMatches(String regex) method (see remarks).
        /// </summary>
        /// <param name="regex"> a regular expression </param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiSelector#classNameMatches(java.lang.String)</remarks>
        private void ClassNameMatches(string regex)
        {
            _stringBuilder.Append(".classNameMatches(\"");
            _stringBuilder.Append(regex);
            _stringBuilder.Append("\")");
        }


        /// <summary>
        /// Set the search criteria to match widgets that are clickable. Typically, using this search criteria alone is not useful.
        /// You should also include additional criteria, such as text, content-description, or the class name for a widget.
        /// If no other search criteria is specified, and there is more than one matching widget, the first widget in the tree is selected.
        /// Maps to: UiSelector.clickable(boolean val) method (see remarks).
        /// </summary>
        /// <param name="value"> Value to match </param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiSelector#clickable(boolean)</remarks>
        private void IsClickable(bool value)
        {
            _stringBuilder.Append(".clickable(");
            _stringBuilder.Append(value.ToString().ToLowerInvariant());
            _stringBuilder.Append(")");
        }


        /// <summary>
        /// Set the search criteria to match the content-description property for a widget. The content-description is typically used by
        /// the Android Accessibility framework to provide an audio prompt for the widget when the widget is selected.
        /// The content-description for the widget must match exactly with the string in your input argument. Matching is case-sensitive.
        /// Maps to: UiSelector.description(String desc) method (see remarks).
        /// </summary>
        /// <param name="description"> Value to match </param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiSelector#description(java.lang.String)</remarks>
        private void Description(string description)
        {
            _stringBuilder.Append(".description(\"");
            _stringBuilder.Append(description);
            _stringBuilder.Append("\")");
        }


        /// <summary>
        /// Set the search criteria to match the content-description property for a widget. The content-description is typically used by
        /// the Android Accessibility framework to provide an audio prompt for the widget when the widget is selected.
        /// The content-description for the widget must match exactly with the string in your input argument. Matching is case-sensitive.
        /// Maps to: UiSelector.descriptionContains(String desc) method (see remarks).
        /// </summary>
        /// <param name="description"> Value to match </param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiSelector#descriptionContains(java.lang.String)</remarks>
        private void DescriptionContains(string description)
        {
            _stringBuilder.Append(".descriptionContains(\"");
            _stringBuilder.Append(description);
            _stringBuilder.Append("\")");
        }


        /// <summary>
        /// Set the search criteria to match the content-description property for a widget. The content-description is typically used by
        /// the Android Accessibility framework to provide an audio prompt for the widget when the widget is selected.
        /// The content-description for the widget must match exactly with the string in your input argument. Matching is case-sensitive.
        /// Maps to: UiSelector.descriptionMatches(String desc) method (see remarks).
        /// </summary>
        /// <param name="description"> a regular expression </param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiSelector#descriptionMatches(java.lang.String)</remarks>
        private void DescriptionMatches(string description)
        {
            _stringBuilder.Append(".descriptionMatches(\"");
            _stringBuilder.Append(description);
            _stringBuilder.Append("\")");
        }


        /// <summary>
        /// Set the search criteria to match the content-description property for a widget. The content-description is typically used by
        /// the Android Accessibility framework to provide an audio prompt for the widget when the widget is selected.
        /// The content-description for the widget must match exactly with the string in your input argument. Matching is case-sensitive.
        /// Maps to: UiSelector.descriptionStartsWith(String desc) method (see remarks).
        /// </summary>
        /// <param name="description"> Value to match </param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiSelector#descriptionStartsWith(java.lang.String)</remarks>
        private void DescriptionStartsWith(string description)
        {
            _stringBuilder.Append(".descriptionStartsWith(\"");
            _stringBuilder.Append(description);
            _stringBuilder.Append("\")");
        }


        /// <summary>
        /// Set the search criteria to match widgets that are enabled. Typically, using this search criteria alone is not useful.
        /// You should also include additional criteria, such as text, content-description, or the class name for a widget.
        /// If no other search criteria is specified, and there is more than one matching widget, the first widget in the tree is selected.
        /// Maps to: UiSelector.enabled(boolean val) method (see remarks).
        /// </summary>
        /// <param name="value"> Value to match </param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiSelector#enabled(boolean))</remarks>
        private void IsEnable(bool value)
        {
            _stringBuilder.Append(".enabled(");
            _stringBuilder.Append(value.ToString().ToLowerInvariant());
            _stringBuilder.Append(")");
        }


        /// <summary>
        /// Set the search criteria to match widgets that are focusable. Typically, using this search criteria alone is not useful.
        /// You should also include additional criteria, such as text, content-description, or the class name for a widget.
        /// If no other search criteria is specified, and there is more than one matching widget, the first widget in the tree is selected.
        /// Maps to: UiSelector.focusable(boolean val) method (see remarks).
        /// </summary>
        /// <param name="value"> Value to match </param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiSelector#focusable(boolean)</remarks>
        private void IsFocusable(bool value)
        {
            _stringBuilder.Append(".focusable(");
            _stringBuilder.Append(value.ToString().ToLowerInvariant());
            _stringBuilder.Append(")");
        }


        /// <summary>
        /// Set the search criteria to match widgets that have focus. Typically, using this search criteria alone is not useful.
        /// You should also include additional criteria, such as text, content-description, or the class name for a widget.
        /// If no other search criteria is specified, and there is more than one matching widget, the first widget in the tree is selected.
        /// Maps to: UiSelector.focused(boolean val) method (see remarks).
        /// </summary>
        /// <param name="value"> Value to match </param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiSelector#focused(boolean)</remarks>
        private void IsFocused(bool value)
        {
            _stringBuilder.Append(".focused(");
            _stringBuilder.Append(value.ToString().ToLowerInvariant());
            _stringBuilder.Append(")");
        }


        /// <summary>
        /// Set the search criteria to match widgets that are long-clickable. Typically, using this search criteria alone is not useful.
        /// You should also include additional criteria, such as text, content-description, or the class name for a widget.
        /// If no other search criteria is specified, and there is more than one matching widget, the first widget in the tree is selected.
        /// Maps to: UiSelector.longClickable(boolean val) method (see remarks).
        /// </summary>
        /// <param name="value"> Value to match </param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiSelector#longClickable(boolean)</remarks>
        private void IsLongClickable(bool value)
        {
            _stringBuilder.Append(".longClickable(");
            _stringBuilder.Append(value.ToString().ToLowerInvariant());
            _stringBuilder.Append(")");
        }


        /// <summary>
        /// Set the search criteria to match the package name of the application that contains the widget.
        /// Maps to: UiSelector.packageName(String name) method (see remarks).
        /// </summary>
        /// <param name="packageName"> Value to match </param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiSelector#packageName(java.lang.String)</remarks>
        private void PackageName(string packageName)
        {
            _stringBuilder.Append(".packageName(\"");
            _stringBuilder.Append(packageName);
            _stringBuilder.Append("\")");
        }


        /// <summary>
        /// Set the search criteria to match the package name of the application that contains the widget.
        /// Maps to: UiSelector.packageNameMatches(String regex) method (see remarks).
        /// </summary>
        /// <param name="regex"> a regular expression </param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiSelector#packageNameMatches(java.lang.String)</remarks>
        private void PackageNameMatches(string regex)
        {
            _stringBuilder.Append(".packageNameMatches(\"");
            _stringBuilder.Append(regex);
            _stringBuilder.Append("\")");
        }


        /// <summary>
        /// Set the search criteria to match the given resource ID.
        /// Maps to: UiSelector.resourceId(String id) method (see remarks).
        /// </summary>
        /// <param name="id"> Value to match </param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiSelector#resourceId(java.lang.String)</remarks>
        private void ResourceId(string id)
        {
            _stringBuilder.Append(".resourceId(\"");
            _stringBuilder.Append(id);
            _stringBuilder.Append("\")");
        }


        /// <summary>
        /// Set the search criteria to match the resource ID of the widget, using a regular expression.
        /// Maps to: UiSelector.resourceIdMatches(String regex) method (see remarks).
        /// </summary>
        /// <param name="regex"> a regular expression </param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiSelector#resourceIdMatches(java.lang.String)</remarks>
        private void ResourceIdMatches(string regex)
        {
            _stringBuilder.Append(".resourceIdMatches(\"");
            _stringBuilder.Append(regex);
            _stringBuilder.Append("\")");
        }


        /// <summary>
        /// Set the search criteria to match widgets that are scrollable. Typically, using this search criteria alone is not useful.
        /// You should also include additional criteria, such as text, content-description, or the class name for a widget.
        /// If no other search criteria is specified, and there is more than one matching widget, the first widget in the tree is selected.
        /// Maps to: UiSelector.scrollable(boolean val) method (see remarks).
        /// </summary>
        /// <param name="value"> Value to match </param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiSelector#scrollable(boolean)</remarks>
        private void IsScrollable(bool value)
        {
            _stringBuilder.Append(".scrollable(");
            _stringBuilder.Append(value.ToString().ToLowerInvariant());
            _stringBuilder.Append(")");
        }


        /// <summary>
        /// Set the search criteria to match widgets that are currently selected. Typically, using this search criteria alone is not useful.
        /// You should also include additional criteria, such as text, content-description, or the class name for a widget.
        /// If no other search criteria is specified, and there is more than one matching widget, the first widget in the tree is selected.
        /// Maps to: UiSelector.selected(boolean val) method (see remarks).
        /// </summary>
        /// <param name="value"> Value to match </param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiSelector#selected(boolean)</remarks>
        private void IsSelected(bool value)
        {
            _stringBuilder.Append(".selected(");
            _stringBuilder.Append(value.ToString().ToLowerInvariant());
            _stringBuilder.Append(")");
        }


        /// <summary>
        /// Set the search criteria to match the visible text displayed in a widget (for example, the text label to launch an app)
        /// The text for the element must match exactly with the string in your input argument. Matching is case-sensitive.
        /// Maps to: UiSelector.text(String text) method (see remarks).
        /// </summary>
        /// <param name="text"> Value to match </param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiSelector#text(java.lang.String)</remarks>
        private void Text(string text)
        {
            _stringBuilder.Append(".text(\"");
            _stringBuilder.Append(text);
            _stringBuilder.Append("\")");
        }


        /// <summary>
        /// Set the search criteria to match the visible text in a widget where the visible text must contain the string in your input argument.
        /// The matching is case-sensitive.
        /// Maps to: UiSelector.textContains(String text) method (see remarks).
        /// </summary>
        /// <param name="text"> Value to match </param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiSelector#textContains(java.lang.String)</remarks>
        private void TextContains(string text)
        {
            _stringBuilder.Append(".textContains(\"");
            _stringBuilder.Append(text);
            _stringBuilder.Append("\")");
        }


        /// <summary>
        /// Set the search criteria to match the visible text displayed in a layout element, using a regular expression.
        /// The text in the widget must match exactly with the string in your input argument.
        /// Maps to: UiSelector.textMatches(String regex) method (see remarks).
        /// </summary>
        /// <param name="regex"> a regular expression </param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiSelector#textMatches(java.lang.String)</remarks>
        private void TextMatches(string regex)
        {
            _stringBuilder.Append(".textMatches(\"");
            _stringBuilder.Append(regex);
            _stringBuilder.Append("\")");
        }


        /// <summary>
        /// Set the search criteria to match visible text in a widget that is prefixed by the text parameter. The matching is case-insensitive.
        /// Maps to: UiSelector.textStartsWith(String text) method (see remarks).
        /// </summary>
        /// <param name="text"> Value to match </param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiSelector#textStartsWith(java.lang.String)</remarks>
        private void TextStartsWith(string text)
        {
            _stringBuilder.Append(".textStartsWith(\"");
            _stringBuilder.Append(text);
            _stringBuilder.Append("\")");
        }


        #endregion END OF SINGLE SELECTORS


        #endregion END OF BUILDS OF SELECTOR CLASSES


        // ************ DATE 10/16/2020 ************
        // All the possible builds of Selectors for the position of elements till date.
        // ************ --------------- ************
        #region BUILDS OF POSITION


        /// <summary>
        /// Set the search criteria to match the widget by its instance number. The instance value must be 0 or greater, where the first instance is 0.
        /// For example, to simulate a user click on the third image that is enabled in a UI screen, you could specify a a search criteria where
        /// the instance is 2, the className(String) matches the image widget class, and enabled(boolean) is true.
        /// The code would look like this: new UiSelector().className("android.widget.ImageView") .enabled(true).instance(2);
        /// Maps to: UiSelector.instance(int index) method (see remarks).
        /// </summary>
        /// <param name="position"> Value to match </param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiSelector#instance(int)</remarks>
        private void Instance(int position)
        {
            _stringBuilder.Append(".instance(");
            _stringBuilder.Append(position.ToString().ToLowerInvariant());
            _stringBuilder.Append(")");
        }


        /// <summary>
        /// Set the search criteria to match the widget by its node index in the layout hierarchy. The index value must be 0 or greater.
        /// Using the index can be unreliable and should only be used as a last resort for matching.
        /// Instead, consider using the instance(int) method.
        /// Maps to: UiSelector.index(int index) method (see remarks).
        /// </summary>
        /// <param name="position"> Value to match </param>
        /// <remarks>https://developer.android.com/reference/androidx/test/uiautomator/UiSelector#index(int)</remarks>
        private void Index(int position)
        {
            _stringBuilder.Append(".index(");
            _stringBuilder.Append(position.ToString().ToLowerInvariant());
            _stringBuilder.Append(")");
        }


        #endregion END OF BUILDS OF POSITION
    }
}
