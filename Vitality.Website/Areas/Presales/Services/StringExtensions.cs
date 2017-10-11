using System;

namespace Vitality.Website.Areas.Presales.Services
{
    public static class StringExtensions
    {
        public static DateTime? ToDateTime(this string @string)
        {
            return DateTime.TryParse(@string, out DateTime dt) ? dt : (DateTime?)null;
        }
    }
}
