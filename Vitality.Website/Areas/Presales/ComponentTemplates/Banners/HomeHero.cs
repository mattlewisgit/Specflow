namespace Vitality.Website.Areas.Presales.ComponentTemplates.Banners
{
    using Glass.Mapper.Sc.Fields;

    using Global.Models;

    public class HomeHero : SitecoreItem
    {
        public HomeHero()
        {
            PosterImage = new Image();
        }

        public Image PosterImage { get; set; }

        public string Headline { get; set; }

        public string SecondHeadline { get; set; }

        public string OpeningParagraph { get; set; }

        public string VideoId { get; set; }
    }
}
