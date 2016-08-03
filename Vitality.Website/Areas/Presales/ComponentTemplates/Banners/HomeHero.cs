using System;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.Banners
{
    using Glass.Mapper.Sc.Fields;

    using Vitality.Website.Areas.Global.Models;

    public class HomeHero : SitecoreItem
    {
        public HomeHero()
        {
            this.PosterImage = new Image();
        }

        public Image PosterImage { get; set; }

        public string Headline { get; set; }

        public string SecondHeadline { get; set; }

        public string OpeningParagraph { get; set; }

        public string VideoId { get; set; }
    }
}