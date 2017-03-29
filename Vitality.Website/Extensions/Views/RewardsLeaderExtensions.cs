namespace Vitality.Website.Extensions.Views
{
    using Glass.Mapper.Sc.Web.Mvc;
    using Areas.Presales.ComponentTemplates.Rewards;
    using Areas.Presales.RenderingTemplates;
    using Core;

    public static class RewardsLeaderExtensions
    {
        public static string BackgroundColour(this GlassView<RewardsLeader> view) =>
            view.GetRenderingParameters<RewardsLeaderRendering>().BackgroundColour?.Value ?? "dark";

        public static int IconsPerRow(this GlassView<RewardsLeader> view) =>
            5.TryParseOrDefault(view.GetRenderingParameters<RewardsLeaderRendering>().IconsPerRow.Value);
    }
}
