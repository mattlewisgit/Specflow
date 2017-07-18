namespace Vitality.Website.Areas.Presales.BaseTemplates
{
    using Glass.Mapper.Sc.Configuration;
    using Glass.Mapper.Sc.Configuration.Attributes;

    using Global.Models;

    public interface ISitemap
    {
        bool InheritSitemapSettings { get; set; }

        bool HideFromSitemap { get; set; }

        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        LinkItem Sitemap { get; set; }

        string ChangeFrequency { get; set; }

        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        LinkItem Priority { get; set; }
    }
}
