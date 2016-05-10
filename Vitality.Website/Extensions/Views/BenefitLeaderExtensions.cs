namespace Vitality.Website.Extensions.Views
{
    using Glass.Mapper.Sc.Web.Mvc;

    using Vitality.Website.Areas.Presales.Models.FeatureBlocks;
    using Vitality.Website.Areas.Presales.RenderingModels;

    public static class BenefitLeaderExtensions
    {
        public static string BackgroundColour(this GlassView<BenefitLeader> view)
        {
            if (view.GetRenderingParameters<BenefitLeaderRendering>().BackgroundColour != null)
            {
                return view.GetRenderingParameters<BenefitLeaderRendering>().BackgroundColour.Value;
            }
            return "light";
        }

        public static string BackgroundImageLeft(this GlassView<BenefitLeader> view)
        {
            return view.GetRenderingParameters<BenefitLeaderRendering>().BackgroundImageLeft ? "feature-block-gradient--right" : string.Empty;
        }

        public static string BackgroundPosition(this GlassView<BenefitLeader> view)
        {
            if (view.GetRenderingParameters<BenefitLeaderRendering>().BackgroundColour != null)
            {
                return view.GetRenderingParameters<BenefitLeaderRendering>().BackgroundPostion.Value;
            }
            return string.Empty;
        }
    }
}