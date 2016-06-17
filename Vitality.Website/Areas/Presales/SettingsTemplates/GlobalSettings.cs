using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Fields;
using Glass.Mapper.Sc.Maps;
using Sitecore.Data;
using Sitecore.Data.Items;
using Vitality.Website.Areas.Global.Models;
using Vitality.Website.Areas.Presales.BaseTemplates;
using Vitality.Website.SC;

namespace Vitality.Website.Areas.Presales.SettingsTemplates
{
    public class GlobalSettings : SitecoreItem, IAppReferenceGlobal, IBrowserLatencyGlobal, IBrowserStylingGlobal, IDuplicateContentPage, IGoogleAuthorshipGlobal, IGoogleTagManagerGlobal, 
        IIndexationPage, IOpenGraphGlobal, IOpenGraphPage, IQubitOpenTagGlobal, IResponseTapGlobal, ISerpAppearancePage, ITwitterGlobal, ITwitterPage, IWebmasterToolsGlobal
    {
        public string AppleITunesApp { get; set; }
        public string[] DnsPrefetch { get; set; }
        public string ApplicationName { get; set; }
        public string Canonical { get; set; }
        public string Publisher { get; set; }
        public string GoogleTagManagerScript { get; set; }
        public string Robots { get; set; }
        public string OpenGraphArticlePublisher { get; set; }
        public string OpenGraphIosAppId { get; set; }
        public string OpenGraphIosAppName { get; set; }
        public string OpenGraphTitle { get; set; }
        public string OpenGraphType { get; set; }
        public string OpenGraphUrl { get; set; }
        public Image OpenGraphImage { get; set; }
        public string OpenGraphSiteName { get; set; }
        public string OpenGraphDescription { get; set; }
        public string QubitOpenTagScript { get; set; }
        public string ResponseTapScript { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TwitterCard { get; set; }
        public string TwitterAppIPhoneId { get; set; }
        public string TwitterAppIPhoneName { get; set; }
        public string TwitterSite { get; set; }
        public string TwitterTitle { get; set; }
        public string TwitterDescription { get; set; }
        public Image TwitterImage { get; set; }
        public string GoogleSiteVerification { get; set; }
        public string BingSiteVerification { get; set; }
    }

    public class GlobalSettingsConfig : SitecoreGlassMap<GlobalSettings>
    {
        public override void Configure()
        {
            // Retrieve all public properties from GlobalSettings class
            var properties = typeof(GlobalSettings).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            // Create lambda expression parameter (i.e 'x' of x => x.FieldName)
            var globalSettings = Expression.Parameter(typeof (GlobalSettings), "globalSettings");

            // Perform default glass mapping of GlobalSettings class
            Map(x => x.AutoMap());
           
            // Iterate through GlobalSettings properties creating lambda expression that passes property to FallBack method (x => x.Title)
            foreach (var property in properties)    
            {
                if (property.PropertyType == typeof (string))
                {
                    var propertyAccess = Expression.Property(globalSettings, property);
                    var convertToObject = Expression.Convert(propertyAccess, typeof(object));
                    var lambda = Expression.Lambda<Func<GlobalSettings, object>>(convertToObject, globalSettings);
                    string fieldName = property.Name;
                    Func<GlobalSettings, object> func = lambda.Compile();
                    Map(x => x.Delegate(lambda).GetValue(context => GetFallbackValue(context, item => item[fieldName], func)));
                }
            }
        }

        private object GetFallbackValue(SitecoreDataMappingContext context, Func<Item, string> getFieldValue, Func<GlobalSettings, object> getFallbackValue)
        {
            // Return the current field value if it is populated or we are already inspecting the GlobalSettings item
            if (!string.IsNullOrWhiteSpace(getFieldValue(context.Item)) || context.Item.ID == new ID(ItemConstants.Presales.Content.Configuration.GlobalSettings.Id))
            {
                return getFieldValue(context.Item);
            }

            // Otherwise attempt to retrive the property from GlobalSettings item (fallback)
            var fallbackSettings = context.Service.GetItem<GlobalSettings>(ItemConstants.Presales.Content.Configuration.GlobalSettings.Id);
            return getFallbackValue(fallbackSettings);
        }
    }
}