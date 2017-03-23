namespace Vitality.Website.Extensions.Views
{
    using Glass.Mapper.Sc.Web.Mvc;

    using Vitality.Website.Areas.Presales.ComponentTemplates.Rewards;
    using Vitality.Website.Areas.Presales.RenderingTemplates;

    public static class RewardsLeaderExtensions
    {
        public static string BackgroundColour(this GlassView<RewardsLeader> view)
        {
            if (view.GetRenderingParameters<RewardsLeaderRendering>().BackgroundColour != null)
            {
                return view.GetRenderingParameters<RewardsLeaderRendering>().BackgroundColour.Value;
            }
            return "dark";
        }
        public static int IconsPerRow(this GlassView<RewardsLeader> view)
        {
            return 5.TryParseOrDefault(view.GetRenderingParameters<RewardsLeaderRendering>().IconsPerRow.Value);
        }
    }
}
