using Glass.Mapper.Sc.Fields;
using Vitality.Website.Areas.Global.Models;

namespace Vitality.Website.Areas.Presales.Models.Partners
{
    public class PartnerHero : SitecoreItem
    {
        public PartnerHero()
        {
            this.PartnerIcon = new Image();
            this.Image = new Image();
        }

        public Image Image { get; set; }
        public string Headline { get; set; }

        public string OpeningParagraph { get; set; }

        public Image PartnerIcon { get; set; }

        public string PartnerName { get; set; }

        public string Line { get; set; }

        public string Benefits { get; set; }
    }
}



