using System.Text;

namespace Framework.Android.UiAutomator
{
    /// <summary>
    /// A class that return a string with the first char change to lowercase
    /// The output of this class is mostly used with the UiScrollable & UiSelector classes
    /// </summary>
    public static class MiscUiAutomator
    {


        /// <summary>
        /// Return a string with the first char in lowercase
        /// Mostly used to re build Enums
        /// </summary>
        /// <param name="value">TextMatches ==> textMatches</param>
        /// <returns></returns>
        public static StringBuilder ReBuildString(object value)
        {
            StringBuilder word = new StringBuilder(value.ToString());
            var letter = char.ToLower(word[0]);
            word[0] = letter;
            return word;
        }
    }
}
