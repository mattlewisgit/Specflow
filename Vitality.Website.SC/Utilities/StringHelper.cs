namespace Vitality.Website.SC.Utilities
{
    using System.Text.RegularExpressions;

    public class StringHelper
    {
        public static string HyphenatedWords(string input)
        {
            return Regex.Replace(input, @"([\s]+)", "-", RegexOptions.Compiled);
        }

        public static string SplitCamelCase(string input)
        {
            return Regex.Replace(input, @"([a-z])(\s*)([A-Z])", "$1 $3", RegexOptions.Compiled).Trim();
        }
    }
}
