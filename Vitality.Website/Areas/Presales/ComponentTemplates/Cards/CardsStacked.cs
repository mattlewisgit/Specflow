namespace Vitality.Website.Areas.Presales.ComponentTemplates.Cards
{
    using System.Collections.Generic;

    using Glass.Mapper.Sc.Configuration.Attributes;
    using Glass.Mapper.Sc.Fields;

    using Global.Models;

    public class CardsStacked : SitecoreItem
    {
        public CardsStacked()
        {
            BackgroundImage = new Image();
        }

        public string Headline { get; set; }

        public string OpeningParagraph { get; set; }

        public Image BackgroundImage { get; set; }

        [SitecoreChildren]
        public IEnumerable<Card> Cards { get; set; }
    }
}
