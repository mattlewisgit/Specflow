using Glass.Mapper.Sc.Fields;
using Vitality.Website.Areas.Global.Models;

namespace Vitality.Website.Areas.Presales.Models.Partners
{
    public class PartnerHero : SitecoreItem
    {
        public PartnerHero()
        {
            this.PartnerIcon = new Image();
            this.BackGroundImage = new Image();
        }

        public Image BackGroundImage { get; set; }
        public string Headline1 { get; set; }
        public string Headline2 { get; set; }

        public string OpeningParagraph { get; set; }

        public Image PartnerIcon { get; set; }

        public string PartnerName { get; set; }

        public string Line { get; set; }

        public string Benefits { get; set; }
    }
}



