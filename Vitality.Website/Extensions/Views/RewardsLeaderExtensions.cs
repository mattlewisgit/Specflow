namespace Vitality.Website.Extensions.Views
{
    using Glass.Mapper.Sc.Web.Mvc;

    using Vitality.Website.Areas.Presales.Models.Rewards;
    using Vitality.Website.Areas.Presales.RenderingModels;

    public static class RewardsLeaderExtensions
    {
        public static string BackgroundColour(this GlassView<RewardsLeader> view)
        {
            if (view.GetRenderingParameters<BenefitLeaderRendering>().BackgroundColour != null)
            {
                return view.GetRenderingParameters<BenefitLeaderRendering>().BackgroundColour.Value;
            }
            return "dark";
        }
        public static int IconsPerRow(this GlassView<RewardsLeader> view)
        {
            return 5.TryParseOrDefault(view.GetRenderingParameters<RewardsLeaderRendering>().IconsPerRow.Value);
        }
    }
}