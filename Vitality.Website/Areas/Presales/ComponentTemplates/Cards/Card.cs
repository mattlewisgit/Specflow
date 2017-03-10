namespace Vitality.Website.Areas.Presales.ComponentTemplates.Cards
{
    using Glass.Mapper.Sc.Fields;

    using Vitality.Website.Areas.Global.Models;

    public class Card : SitecoreItem
    {
        public string Title { get; set; }

        public string Text { get; set; }

        public Image Icon { get; set; }

        public Link CallToAction { get; set; }
    }
}
