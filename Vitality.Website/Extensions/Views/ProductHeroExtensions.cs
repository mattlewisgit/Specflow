namespace Vitality.Website.Extensions.Views
{
    using Areas.Presales.Models.FeatureBlocks;
    using Glass.Mapper.Sc.Fields;
    using Glass.Mapper.Sc.Web.Mvc;

    public static class ProductHeroExtensions
    {
        public static string ButtonClass(this GlassView<ProductHero> view)
        {
            return view.Model.CallToAction.Type == LinkType.Anchor
                ? "button-internal scroll-to-el" : "button-cta";
        }
    }
}
