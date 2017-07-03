namespace Vitality.Website.Areas.Presales.ComponentTemplates.Navigation
{
    using System.Collections.Generic;

    using Glass.Mapper.Sc.Configuration.Attributes;

    using Global.Models;

    public class FooterSection : SitecoreItem
    {
        public string Heading { get; set; }

        [SitecoreChildren]
        public IEnumerable<LinkItem> FooterLinks { get; set; }
    }

    public class FooterSocialSection : SitecoreItem
    {
        public string Heading { get; set; }

        [SitecoreChildren]
        public IEnumerable<ImageLink> SocialLinks { get; set; }
    }
}
