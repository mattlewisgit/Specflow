namespace Vitality.Website.Areas.Presales.Models.FeatureBlocks
{
    using Glass.Mapper.Sc.Fields;

    using Global.Models;

    public class ProductHero : SitecoreItem
    {
        public ProductHero()
        {
            this.Image = new Image();
            this.VitalityLogo = new Image();
        }

        public string Headline { get; set; }

        public string Body { get; set; }

        public Link CallToAction { get; set; }

        public Image Image { get; set; }

        public Image VitalityLogo { get; set; }
    }
}
