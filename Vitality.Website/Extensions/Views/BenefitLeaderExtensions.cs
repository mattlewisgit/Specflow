namespace Vitality.Website.Extensions.Views
{
    using Glass.Mapper.Sc.Web.Mvc;

    using Vitality.Website.Areas.Presales.ComponentTemplates.FeatureBlocks;
    using Vitality.Website.Areas.Presales.RenderingTemplates;

    public static class BenefitLeaderExtensions
    {
        public static string BackgroundColour(this GlassView<BenefitLeader> view)
        {
            if (!string.IsNullOrWhiteSpace(view.GetRenderingParameters<BenefitLeaderRendering>().BackgroundColour.Value))
            {
                return view.GetRenderingParameters<BenefitLeaderRendering>().BackgroundColour.Value;
            }
            return "light";
        }

        public static string ContentAlignment(this GlassView<BenefitLeader> view)
        {
            return string.Format("feature-block{0}--{1}", ApplyGradient(view), view.GetRenderingParameters<BenefitLeaderRendering>().ContentAlignment != null ? view.GetRenderingParameters<BenefitLeaderRendering>().ContentAlignment.Value : string.Empty);
        }

        public static string ImageRelativePosition(this GlassView<BenefitLeader> view)
        {
            if (view.GetRenderingParameters<BenefitLeaderRendering>().ImageRelativePosition  != null)
            {
                return view.GetRenderingParameters<BenefitLeaderRendering>().ImageRelativePosition.Value;
            }
            return string.Empty;
        }

        public static string ApplyGradient(this GlassView<BenefitLeader> view)
        {
            return view.GetRenderingParameters<BenefitLeaderRendering>().ApplyGradient ? "-gradient" : string.Empty;
        }

        public static string ButtonStyle(this GlassView<BenefitLeader> view)
        {
            const string baseClasses = "box-button box-button--rounded";
            var value = view.GetRenderingParameters<BenefitLeaderRendering>().BackgroundColour != null
                ? view.GetRenderingParameters<BenefitLeaderRendering>().BackgroundColour.Value
                : string.Empty;
            
            return !string.IsNullOrWhiteSpace(value)
                ? baseClasses + " box-button--light" : baseClasses;
        }
   }
}
