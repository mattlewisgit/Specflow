namespace Vitality.Website.Extensions.Views
{
    using System.Collections.Generic;
    using System.Linq;

    using Glass.Mapper.Sc.Web.Mvc;

    using Vitality.Website.Areas.Global.Models;
    using Vitality.Website.Areas.Presales.Models.Rewards;
    using Vitality.Website.Areas.Presales.RenderingModels;

    public static class RewardsLeaderExtensions
    {
        public static int IconsPerRow(this GlassView<RewardsLeader> view)
        {
            return 5.TryParseOrDefault(view.GetRenderingParameters<RewardsLeaderRendering>().IconsPerRow.Value);
        }

        public static IEnumerable<IGrouping<int, ImageLink>> GroupedRewardsIconRows(this GlassView<RewardsLeader> view, int iconsPerRow)
        {
            return view.Model.Rewards.Select((item, index) => new { Item = item, Index = index }).GroupBy(kv => kv.Index / iconsPerRow, kv => kv.Item);
        }
    }
}