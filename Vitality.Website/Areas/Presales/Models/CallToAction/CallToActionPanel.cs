namespace Vitality.Website.Areas.Presales.Models.CallToAction
{
    using Glass.Mapper.Sc.Fields;

    using Vitality.Website.Areas.Global.Models;

    public class CallToActionPanel : SitecoreItem
    {
        public Image Icon { get; set; }

        public string Headline { get; set; }

        public string OpeningParagraph { get; set; }

        public Link CallToAction { get; set; }

        public Link SecondaryCallToAction { get; set; }
    }
}