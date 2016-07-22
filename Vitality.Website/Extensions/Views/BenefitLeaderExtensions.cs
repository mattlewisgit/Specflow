namespace Vitality.Website.Extensions.Views
{
    using Glass.Mapper.Sc.Web.Mvc;

    using Vitality.Website.Areas.Presales.ComponentTemplates.FeatureBlocks;
    using Vitality.Website.Areas.Presales.RenderingTemplates;

    public static class BenefitLeaderExtensions
    {
        public static string BackgroundColour(this GlassView<BenefitLeader> view)
        {
            if (Parameters(view).BackgroundColour != null)
            {
                return string.Format("{0}--{1}", CssClass(view), Parameters(view).BackgroundColour.Value);
            }
            return CssClass(view) + "--light";
        }

        public static string ContentAlignment(this GlassView<BenefitLeader> view)
        {
            if (Parameters(view).ContentAlignment != null)
            {
                return string.Format("{0}--{1}", CssClass(view), Parameters(view).ContentAlignment.Value);
            }
            return string.Empty;
        }

        public static string ImageRelativePosition(this GlassView<BenefitLeader> view)
        {
            if (Parameters(view).ImageRelativePosition != null)
            {
                return Parameters(view).ImageRelativePosition.Value;
            }
            return string.Empty;
        }

        public static string CssClass(this GlassView<BenefitLeader> view)
        {
            if (Parameters(view).ApplyGradient)
            {
                return "feature-block-gradient";
            }
            return "feature-block";
        }

        public static string ButtonStyle(this GlassView<BenefitLeader> view)
        {
            if (BackgroundColour(view).EndsWith("light") || BackgroundColour(view).EndsWith("white"))
            {
                return "box-button box-button--rounded";
            }
            return "box-button box-button--rounded box-button--light";
        }

        public static string BackgroundImage(this GlassView<BenefitLeader> view)
        {
            return string.Format("background-image: url('{0}')", view.Model.BackgroundImage.Src);
        }

        private static BenefitLeaderRendering Parameters(this GlassView<BenefitLeader> view)
        {
            return view.GetRenderingParameters<BenefitLeaderRendering>();
        }
   }
}
