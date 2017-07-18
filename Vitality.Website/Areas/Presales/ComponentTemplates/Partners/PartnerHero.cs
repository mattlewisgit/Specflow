namespace Vitality.Website.Areas.Presales.ComponentTemplates.Partners
{
    using Glass.Mapper.Sc.Fields;

    using Global.Models;

    public class PartnerHero : SitecoreItem
    {
        public PartnerHero()
        {
            PartnerIcon = new Image();
            BackgroundImage = new Image();
        }

        public Image BackgroundImage { get; set; }
        public string Headline1 { get; set; }
        public string Headline2 { get; set; }

        public string OpeningParagraph { get; set; }

        public Image PartnerIcon { get; set; }

        public string PartnerName { get; set; }

        public string Line { get; set; }

        public string Benefits { get; set; }
    }
}



