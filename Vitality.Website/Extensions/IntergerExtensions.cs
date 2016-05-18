namespace Vitality.Website.Extensions
{
    using System;

    public static class IntergerExtensions
    {
        public static int TryParseOrDefault(this int @default, string value)
        {
            int parsedValue;
            if (int.TryParse(value, out parsedValue))
            {
                return parsedValue;
            }
            return @default;
        }

        public static void Times(this int numberOfTimes, Action action)
        {
            for (int i = 0; i < numberOfTimes; i++)
            {
                action();
            }
        }
    }
}