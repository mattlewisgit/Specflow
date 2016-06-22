namespace Vitality.Website.Areas.Presales.ComponentTemplates.FeatureBlocks
{
    using Glass.Mapper.Sc.Fields;

    using Vitality.Website.Areas.Global.Models;

    public class BenefitLeader : SitecoreItem
    {
        public BenefitLeader()
        {
            this.BackgroundImage = new Image();
        }

        public string LeadIn { get; set; }

        public string Headline { get; set; }

        public string Body { get; set; }

        public Link CallToAction { get; set; }

        public Image BackgroundImage { get; set; }
    }
}
