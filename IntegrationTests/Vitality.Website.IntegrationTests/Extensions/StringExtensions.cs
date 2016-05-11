namespace Vitality.Website.IntegrationTests.Extensions
{
    public static class StringExtensions
    {
        public static string FormatWith(this string @string, params object[] values)
        {
            return string.Format(@string, values);
        }
    }
}
