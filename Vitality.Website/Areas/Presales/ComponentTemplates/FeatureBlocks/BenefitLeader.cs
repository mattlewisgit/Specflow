namespace Vitality.Website.Areas.Presales.ComponentTemplates.FeatureBlocks
{
    using Glass.Mapper.Sc.Fields;

    using Global.Models;

    public class BenefitLeader : SitecoreItem
    {
        public BenefitLeader()
        {
            BackgroundImage = new Image();
        }

        public string LeadIn { get; set; }

        public string Headline { get; set; }

        public string Body { get; set; }

        public Link CallToAction { get; set; }

        public Image BackgroundImage { get; set; }
    }
}
