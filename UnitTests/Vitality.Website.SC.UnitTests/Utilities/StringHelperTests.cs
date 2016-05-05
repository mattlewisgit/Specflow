namespace Vitality.Website.SC.UnitTests.Utilities
{
    using Shouldly;

    using Vitality.Website.SC.Utilities;

    using Xunit;

    public class StringHelperTests
    {
        public class HyphenatedWordsTests
        {
            [Fact]
            public void Spaces_in_words_should_be_replaced_with_hyphens()
            {
                var input = "The Quick Brown Fox Jumps Over The Lazy Dog";
                var expected = "The-Quick-Brown-Fox-Jumps-Over-The-Lazy-Dog";

                var result = StringHelper.HyphenatedWords(input);

                result.ShouldBe(expected);
            }

            [Fact]
            public void Multiple_consecutive_spaces_should_be_replaced_with_single_hyphen()
            {
                var input = "The     Quick";
                var expected = "The-Quick";

                var result = StringHelper.HyphenatedWords(input);

                result.ShouldBe(expected);
            }
        }
    }
}
