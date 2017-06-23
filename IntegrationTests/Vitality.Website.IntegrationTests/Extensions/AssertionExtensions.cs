namespace Vitality.Website.IntegrationTests.Extensions
{
    using System.Collections.Generic;

    using Shouldly;

    public static class AssertionExtensions
    {
        public static void ShouldContainAll(this string actual, IEnumerable<string> expected)
        {
            foreach (var @string in expected)
            {
                actual.ShouldContain(@string);
            }
        }

        public static void ShouldNotContainAll(this string actual, IEnumerable<string> expected)
        {
            foreach (var @string in expected)
            {
                actual.ShouldNotContain(@string);
            }
        }
    }
}
