namespace Vitality.Website.UnitTests.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    using Shouldly;

    using Vitality.Website.Areas.Presales.ComponentTemplates.Summary;
    using Vitality.Website.Extensions;
    using Vitality.Website.SC;

    using Xunit;

    public class EnumerableExtensionsTests
    {
        public class GroupIntoRowsTests
        {
            [Fact]
            public void Enumerable_has_no_elements_should_return_empty()
            {
                Enumerable.Empty<int>().GroupIntoRows(5).ShouldBeEmpty();
            }

            [Fact]
            public void Enumerable_has_elements_should_return_all_elements()
            {
                Enumerable.Range(0, 10).GroupIntoRows(10).SelectMany(links => links).Count().ShouldBe(10);
            }

            [Fact]
            public void Elements_per_group_should_not_exceed_elements_per_row()
            {
                Enumerable.Range(0, 10).GroupIntoRows(9).First().Count().ShouldBe(9);
            }
        }

        public class GroupConsecutiveMatchesTests
        {
            private readonly SummaryListItemsBuilder builder;

            public GroupConsecutiveMatchesTests()
            {
                this.builder = new SummaryListItemsBuilder();
            }

            [Fact]
            public void Should_be_empty_when_no_elements()
            {
                var summaryListItems = this.builder.Build();

                summaryListItems.GroupConsecutiveMatches((item => item.TemplateId)).ShouldBeEmpty();
            }

            [Fact]
            public void Should_not_be_empty_when_one_element()
            {
                this.builder.Add("1");

                var summaryListItems = this.builder.Build();

                summaryListItems.GroupConsecutiveMatches(item => item.TemplateId).ShouldNotBeEmpty();
            }

            [Fact]
            public void Should_group_elements_using_key_selector()
            {
                this.builder.Add("1");
                this.builder.Add("2", true);
                this.builder.Add("3", true);

                var summaryListItems = this.builder.Build();

                summaryListItems.GroupConsecutiveMatches(item => item.TemplateId).Count().ShouldBe(2);
            }

            [Fact]
            public void Should_not_group_non_consecutive_matches()
            {
                this.builder.Add("1");
                this.builder.Add("2", true);
                this.builder.Add("3", true);
                this.builder.Add("4");
                this.builder.Add("5");
                this.builder.Add("6", true);
                this.builder.Add("7", true);

                var summaryListItems = this.builder.Build();

                summaryListItems.GroupConsecutiveMatches(item => item.TemplateId).Count().ShouldBe(4);
            }

            [Fact]
            public void Should_have_same_number_of_elements()
            {
                this.builder.Add("1");

                var summaryListItems = this.builder.Build();

                summaryListItems.GroupConsecutiveMatches(item => item.TemplateId).SelectMany(g => g).Count().ShouldBe(1);
            }

            private class SummaryListItemsBuilder
            {
                private readonly List<SummaryListItem> summaryListItems = new List<SummaryListItem>();

                public void Add(string title, bool listItemShort = false)
                {
                    this.summaryListItems.Add(new SummaryListItem
                    {
                        Title = title,
                        TemplateId = listItemShort
                            ? ItemConstants.Presales.Templates.Summary.SummaryListItemShort.Id
                            : ItemConstants.Presales.Templates.Summary.SummaryListItem.Id
                    });
                }

                public IEnumerable<SummaryListItem> Build()
                {
                    return this.summaryListItems;
                }
            }
        }
    }
}
