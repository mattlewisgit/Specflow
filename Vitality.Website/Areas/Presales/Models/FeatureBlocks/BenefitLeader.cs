namespace Vitality.Website.Areas.Presales.Models.FeatureBlocks
{
    using Glass.Mapper.Sc.Fields;

    using Vitality.Website.Areas.Global.Models;

    public class BenefitLeader : SitecoreItem
    {
        public string LeadIn { get; set; }

        public string Headline { get; set; }

        public string Body { get; set; }

        public Link CallToAction { get; set; }

        public Image BackgroundImage { get; set; }
    }
}