using Glass.Mapper.Configuration;
using Glass.Mapper.IoC;
using Glass.Mapper.Maps;
using Glass.Mapper.Sc;
using Glass.Mapper.Sc.IoC;
using Vitality.Website.Areas.Presales.SettingsTemplates;
using IDependencyResolver = Glass.Mapper.Sc.IoC.IDependencyResolver;

namespace Vitality.Website.App_Start
{
    using Vitality.Website.Areas.Presales.PageTemplates;

    public static  class GlassMapperScCustom
    {
		public static IDependencyResolver CreateResolver()
		{
            // Set default images to be lazyload
			var config = new Config();

			var dependencyResolver = new DependencyResolver(config);
			// add any changes to the standard resolver here
			return dependencyResolver;
		}

		public static IConfigurationLoader[] GlassLoaders(){

			/* USE THIS AREA TO ADD FLUENT CONFIGURATION LOADERS
             *
             * If you are using Attribute Configuration or automapping/on-demand mapping you don't need to do anything!
             *
             */

			return new IConfigurationLoader[]{};
		}
		public static void PostLoad(){
			//Remove the comments to activate CodeFist
			/* CODE FIRST START
            var dbs = Sitecore.Configuration.Factory.GetDatabases();
            foreach (var db in dbs)
            {
                var provider = db.GetDataProviders().FirstOrDefault(x => x is GlassDataProvider) as GlassDataProvider;
                if (provider != null)
                {
                    using (new SecurityDisabler())
                    {
                        provider.Initialise(db);
                    }
                }
            }
             * CODE FIRST END
             */
		}
		public static void AddMaps(IConfigFactory<IGlassMap> mapsConfigFactory)
        {
			// Add maps here
            // mapsConfigFactory.Add(() => new SeoMap());
            mapsConfigFactory.Add(() => new BasePageConfig());
            mapsConfigFactory.Add(() => new SiteSettingsConfig());
        }
    }
}
