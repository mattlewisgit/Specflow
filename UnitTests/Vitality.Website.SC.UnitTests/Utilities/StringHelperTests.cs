namespace Vitality.Website.SC.UnitTests.Utilities
{
    using Shouldly;

    using Vitality.Website.SC.Utilities;

    using Xunit;

    public class StringHelperTests
    {
        public class SplitCamelCaseTests
        {
            [Fact]
            public void Camel_case_string_with_no_spaces_should_be_split_with_single_spaces()
            {
                var input = "TheQuickBrownFoxJumpsOverTheLazyDog";
                var expected = "The Quick Brown Fox Jumps Over The Lazy Dog";

                StringHelper.SplitCamelCase(input).ShouldBe(expected);
            }

            [Fact]
            public void Split_samel_case_string_with_single_spaces_should_not_change()
            {
                var input = "The Quick Brown Fox Jumps Over The Lazy Dog";

                StringHelper.SplitCamelCase(input).ShouldBe(input);
            }

            [Fact]
            public void Split_samel_case_string_with_multiple_spaces_should_be_split_with_single_spaces()
            {
                var input = "The   Quick   Brown   Fox   Jumps   Over   The   Lazy   Dog";
                var expected = "The Quick Brown Fox Jumps Over The Lazy Dog";

                StringHelper.SplitCamelCase(input).ShouldBe(expected);
            }
        }

        public class HyphenatedWordsTests
        {
            [Fact]
            public void Spaces_in_words_should_be_replaced_with_hyphens()
            {
                var input = "The Quick Brown Fox Jumps Over The Lazy Dog";
                var expected = "The-Quick-Brown-Fox-Jumps-Over-The-Lazy-Dog";

                StringHelper.HyphenatedWords(input).ShouldBe(expected);
            }

            [Fact]
            public void Multiple_consecutive_spaces_should_be_replaced_with_single_hyphen()
            {
                var input = "The     Quick";
                var expected = "The-Quick";

                StringHelper.HyphenatedWords(input).ShouldBe(expected);
            }
        }
    }
}
