namespace Vitality.Website.UnitTests.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Web.Routing;

    using Shouldly;

    using Vitality.Website.Extensions;
    using Xunit;

    public class IDictionaryExtensionsTests
    {
        [Fact]
        public void NullThrows()
        {
            Should.Throw<ArgumentNullException>
                (() => IDictionaryExtensions.AddOrOverwrite(null, "key", "value"));
        }

        [Fact]
        public void NonExistantKeyIsSet()
        {
            const char key = 'k';
            const int value = 1;

            new Dictionary<char, int>()
                .AddOrOverwrite(key, value)
                .ShouldContainKeyAndValue(key, value);
        }

        [Fact]
        public void ExistingKeyValueIsOverwritten()
        {
            // Setup.
            const string key = "key";
            const string newValue = "new value";

            new RouteValueDictionary
            {
                { key, "initial value" }
            }
            .AddOrOverwrite(key, newValue)
            .ShouldContainKeyAndValue(key, newValue);
        }
    }
}
