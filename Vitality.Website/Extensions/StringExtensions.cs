namespace Vitality.Website.Extensions
{
    using Vitality.Website.SC.Utilities;

    public static class StringExtensions
    {
        public static string FormatWith(this string @string, params object[] values)
        {
            return string.Format(@string, values);
        }

        public static string ToLowerHyphenatedString(this string @string)
        {
            return StringHelper.HyphenatedWords(@string).ToLower();
        }
    }
}