namespace Vitality.Website.Areas.Presales.PageTemplates
{
    using Glass.Mapper.Sc.Fields;

    using Vitality.Website.Areas.Global.Models;

    public class ErrorPage : SitecoreItem
    {
        public string Headline { get; set; }

        public string OpeningParagraph { get; set; }

        public Link CallToAction1 { get; set; }
        
        public Link CallToAction2 { get; set; }

        public Image BackgroundImage { get; set; }
    }
}