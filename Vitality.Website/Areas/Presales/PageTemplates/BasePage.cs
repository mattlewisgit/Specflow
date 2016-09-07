using System.Collections.Generic;
using Glass.Mapper.Sc.Fields;
using Vitality.Website.Areas.Global.Models;

namespace Vitality.Website.Areas.Presales.PageTemplates
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    using Glass.Mapper.Sc.Configuration.Attributes;
    using Glass.Mapper.Sc;
    using Glass.Mapper.Sc.Maps;

    using Sitecore.Data.Fields;

    using Vitality.Website.Areas.Presales.BaseTemplates;
    using Vitality.Website.Areas.Presales.SettingsTemplates;
    using Vitality.Website.SC;

    public class BasePage : SitecoreItem, IQuoteFooter, IAppReferenceGlobal, IBrowserLatencyGlobal, IBrowserStylingGlobal, IDuplicateContentPage, IGoogleAuthorshipGlobal, IGoogleTagManagerGlobal,
        IIndexationPage, IOpenGraphGlobal, IOpenGraphPage, IQubitOpenTagGlobal, ISerpAppearancePage, ITwitterGlobal, ITwitterPage, IWebmasterToolsGlobal, IJsonSchemaGlobal, ISitemap
    {
        public bool ShowQuoteFooter { get; set; }
        public IEnumerable<LinkItem> QuoteFooterLinks { get; set; }
        public string Headline { get; set; }
        public bool InheritQuoteFooterSettings { get; set; }

        [SitecoreParent]
        public BasePage Parent { get; set; }

        public string AppleITunesApp { get; set; }
        public string[] DnsPrefetch { get; set; }
        public string ApplicationName { get; set; }
        public string Canonical { get; set; }
        public string Publisher { get; set; }
        public string GoogleTagManagerId { get; set; }
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
        public string QubitOpenTagId { get; set; }
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
        public string JsonSchemaScript { get; set; }
        public bool InheritSitemapSettings { get; set; }
        public bool HideFromSitemap { get; set; }
        public LinkItem Sitemap { get; set; }
        public string ChangeFrequency { get; set; }
        public LinkItem Priority { get; set; }        
    }

    public class BasePageConfig : SitecoreGlassMap<BasePage>
    {
        public override void Configure()
        {
            this.Map(
                x => x.AutoMap(),
                x => x.Delegate(footer => footer.Headline).GetValue(
                    context => context.Service.GetItem<QuoteFooter>(ItemConstants.Presales.Content.Configuration.QuoteFooter.Id).Headline)
                );

            var properties = typeof(BasePage).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            foreach (var property in properties)
            {
                if (typeof(GlobalSettings).GetProperty(property.Name) == null)
                {
                    continue;
                }

                string fieldName = property.Name;
                var basePageProperty = this.BuildPropertyAccess<BasePage>(fieldName);
                var globalSettingsProperty = this.BuildPropertyAccess<GlobalSettings>(fieldName).Compile();

                if (property.PropertyType == typeof(string))
                {
                    this.Map(x => x.Delegate(basePageProperty).GetValue(context => this.StringWithFallback(context, fieldName, globalSettingsProperty)));
                }
                else if (property.PropertyType == typeof(string[]))
                {
                    this.Map(x => x.Delegate(basePageProperty).GetValue(context => this.StringArrayWithFallback(context, fieldName, globalSettingsProperty)));
                }
                else if (property.PropertyType == typeof(Image))
                {
                    this.Map(x => x.Delegate(basePageProperty).GetValue(context => this.ImageWithFallback(context, fieldName, globalSettingsProperty)));
                }
            }
        }

        private Expression<Func<T, object>> BuildPropertyAccess<T>(string property)
        {
            var basePage = Expression.Parameter(typeof(T));

            var propertyAccess = Expression.Property(basePage, property);
            var convertToObject = Expression.Convert(propertyAccess, typeof(object));
            return Expression.Lambda<Func<T, object>>(convertToObject, basePage);
        }

        private object StringWithFallback(SitecoreDataMappingContext context, string property, Func<GlobalSettings, object> globalSettingsProperty)
        {
            if (!string.IsNullOrWhiteSpace(context.Item[property]))
            {
                return context.Item[property];
            }
            return this.GetFallbackValue(context.Service, globalSettingsProperty);
        }

        private object StringArrayWithFallback(SitecoreDataMappingContext context, string property, Func<GlobalSettings, object> globalSettingsProperty)
        {
            if (!string.IsNullOrWhiteSpace(context.Item[property]))
            {
                return context.Item[property].Split('|');
            }
            return this.GetFallbackValue(context.Service, globalSettingsProperty);
        }

        private object ImageWithFallback(SitecoreDataMappingContext context, string property, Func<GlobalSettings, object> globalSettingsProperty)
        {
            ImageField field = context.Item.Fields[property];
            var image = new Image();
            if (field.InnerField.HasValue)
            {
                Glass.Mapper.Sc.DataMappers.SitecoreFieldImageMapper.MapToImage(image, field);
            }
            return this.GetFallbackValue(context.Service, globalSettingsProperty) ?? image;
        }

        private object GetFallbackValue(ISitecoreService service, Func<GlobalSettings, object> getFallbackValue)
        {
            var fallbackSettings = service.GetItem<GlobalSettings>(ItemConstants.Presales.Content.Configuration.GlobalSettings.Id);
            return getFallbackValue(fallbackSettings);
        }
    }
}
