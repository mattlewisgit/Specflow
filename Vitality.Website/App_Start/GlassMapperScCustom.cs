namespace Vitality.Website.App_Start
{
    using Areas.Presales.PageTemplates;
    using Glass.Mapper.Configuration;
    using Glass.Mapper.IoC;
    using Glass.Mapper.Maps;
    using Glass.Mapper.Sc;
    using Glass.Mapper.Sc.IoC;
    using Areas.Presales.SettingsTemplates;
    using IDependencyResolver = Glass.Mapper.Sc.IoC.IDependencyResolver;

    public static  class GlassMapperScCustom
    {
        public static IDependencyResolver CreateResolver()
        {
            return new DependencyResolver(new Config());
        }

        public static IConfigurationLoader[] GlassLoaders()
        {

            // Add fluent configuration loaders here.
            // If you are using Attribute Configuration or
            // automapping /on-demand mapping, you don't need to do anything!
            return new IConfigurationLoader[]{};
        }

        public static void PostLoad()
        {
            // Method intentionally left empty.
        }

        public static void AddMaps(IConfigFactory<IGlassMap> mapsConfigFactory)
        {
            mapsConfigFactory.Add(() => new BasePageConfig());
            mapsConfigFactory.Add(() => new SiteSettingsConfig());
        }
    }
}
