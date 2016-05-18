namespace Vitality.Website.UnitTests.Extensions.Views
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Glass.Mapper.Sc.Web.Mvc;

    using Shouldly;

    using Vitality.Website.Areas.Global.Models;
    using Vitality.Website.Areas.Presales.Models.Rewards;
    using Vitality.Website.Extensions;
    using Vitality.Website.Extensions.Views;

    using Xunit;

    public class RewardsLeaderExtensionsTests
    {
        public class GroupedRowIconsTests
        {
            private readonly RewardsLeaderViewStubBuilder builder = new RewardsLeaderViewStubBuilder();

            [Fact]
            public void Model_has_no_icons_should_return_empty()
            {
                var view = this.builder.Build();

                view.GroupedRewardsIconRows(5).ShouldBeEmpty();
            }

            [Fact]
            public void Model_has_icons_should_return_all_icons()
            {
                this.builder.AddIcons(10);
                var view = this.builder.Build();

                view.GroupedRewardsIconRows(10).SelectMany(links => links).Count().ShouldBe(10);
            }

            [Fact]
            public void Icons_per_group_should_not_exceed_icons_per_row()
            {
                this.builder.AddIcons(10);
                var view = this.builder.Build();

                view.GroupedRewardsIconRows(9).First().Count().ShouldBe(9);
            }

            private class RewardsLeaderViewStubBuilder
            {
                private readonly List<ImageLink> icons = new List<ImageLink>();

                public RewardsLeaderViewStub Build()
                {
                    return new RewardsLeaderViewStub(new RewardsLeader { Rewards = this.icons });
                }

                public void AddIcons(int count)
                {
                    count.Times(() => this.icons.Add(new ImageLink()));
                }
            }

            private class RewardsLeaderViewStub : GlassView<RewardsLeader>
            {
                public RewardsLeaderViewStub(RewardsLeader model)
                {
                    this.ViewData = new ViewDataDictionary<RewardsLeader>(model);
                }

                public override void Execute()
                {
                    throw new System.NotImplementedException();
                }
            }
        }
    }
}
