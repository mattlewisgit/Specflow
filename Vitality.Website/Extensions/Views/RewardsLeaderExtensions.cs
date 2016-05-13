namespace Vitality.Website.Extensions.Views
{
    using Glass.Mapper.Sc.Web.Mvc;

    using Vitality.Website.Areas.Presales.Models.Rewards;
    using Vitality.Website.Areas.Presales.RenderingModels;

    public static class RewardsLeaderExtensions
    {
        public static string IconsPerRow(this GlassView<RewardsLeader> view)
        {
            return view.GetRenderingParameters<RewardsLeaderRendering>().IconsPerRow.Value;
        }
    }
}