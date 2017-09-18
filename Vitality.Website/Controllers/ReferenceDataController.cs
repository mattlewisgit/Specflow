using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Mvc.Helpers;
using Vitality.Website.Areas.AppManifests;
using Vitality.Website.Areas.AppManifests.Models;
using Vitality.Website.SC.Utilities;
using Log = Sitecore.Diagnostics.Log;

namespace Vitality.Website.Controllers
{
    public class ReferenceDataController : Controller
    {
        public ContentResult Get()
        {
            try
            {
                var item = Sitecore.Context.Item;

                // Get the reference data.
                var referenceData = GetReferenceData(item);

                var serializedReferenceData = JsonConvert.SerializeObject(
                    referenceData,
                    Formatting.None,
                    AppManifestsConstants.JsonSerializerSetting
                    );
                return this.Content(
                    serializedReferenceData,
                    "application/json");
            }
            catch (Exception ex)
            {
                var item = Sitecore.Context.Item;
                Log.Error($"Error serializing app mainfest reference data {item.Name} ({item.ID}): Error:{ex.Message}. InnerException: {ex.InnerException?.Message ?? string.Empty}", "ManifestController");
                return null;
            }
        }

        /// <summary>
        /// Gets the reference data model.
        /// </summary>
        /// <param name="item">The SITECORE item.</param>
        /// <returns>ReferenceData model containing model required for corresponding entity.</returns>
        private static ReferenceData GetReferenceData(Item item)
        {
            var referenceData = new ReferenceData();

            var dataList = ((MultilistField)item.Fields[AppManifestsConstants.DataField]).GetItems().ToList();
            referenceData.Data = new List<IDictionary<string, object>>();

            foreach (var dataItem in dataList)
            {
                var fields = dataItem.Fields.ToList();
                var data = new Dictionary<string, object>();

                foreach (var field in fields)
                {
                    // Check if the field is Standard field. If not get the field name and value.
                    if (field.Name.StartsWith("__", StringComparison.CurrentCultureIgnoreCase) == false)
                    {
                        AppContent content = null;
                        CtaData ctaData = null;
                        switch (field.Type)
                        {
                            case AppManifestsConstants.FieldTypeSingleLineText:
                            case AppManifestsConstants.FieldTypeMultiLineText:
                            case AppManifestsConstants.FieldTypeRichText:
                            case AppManifestsConstants.FieldTypeDroplist:
                                content = GetSimpleText(field);
                                break;
                            case AppManifestsConstants.FieldTypeGeneralLink:
                                content = GetLinkInformation(field);
                                break;
                            case AppManifestsConstants.FieldTypeImage:
                                content = GetImage(field);
                                break;
                            case AppManifestsConstants.FieldTypeCheckbox:
                                content = GetCheckbox(field);
                                break;
                            case AppManifestsConstants.FieldTypeMultilist:
                                ctaData = GetMultilist(field);
                                break;
                            default:
                                break;
                        }

                        if (content != null)
                        {
                            data.Add(
                                content.FieldName,
                                content.Value);
                        }

                        if (ctaData != null)
                        {
                            data.Add(
                                field.Name,
                                ctaData);
                        }
                    }
                }

                referenceData.Data.Add(data);
            }

            return referenceData;
        }

        /// <summary>
        /// Get the image field information.
        /// </summary>
        /// <param name="field">The SITECORE field.</param>
        /// <returns>Content having field name and value.</returns>
        private static AppContent GetImage(Field field)
        {
            ImageField image = field;
            //var source = image.Src;
            var source = "";

            return new AppContent
            {
                FieldName = field.Name,
                Value = !string.IsNullOrWhiteSpace(source) ? SitecoreDataItemHelper.BuildUrl(source) : string.Empty
            };
        }

        /// <summary>
        /// Get the Link field information.
        /// </summary>
        /// <param name="field">The SITECORE field.</param>
        /// <returns>Content having field name and value.</returns>
        private static AppContent GetLinkInformation(Field field)
        {
            LinkField link = field;
            var content = new AppContent
            {
                FieldName = field.Name,
            };

            if (link.LinkType.ToLower(CultureInfo.CurrentCulture).Equals(AppManifestsConstants.Internal))
            {
                content.Value = !string.IsNullOrWhiteSpace(link.Url) ? SitecoreDataItemHelper.BuildUrl(link.Url) : string.Empty;
            }
            else
            {
                content.Value = link.Url;
            }

            return content;
        }

        /// <summary>
        /// Get the image field information.
        /// </summary>
        /// <param name="field">The SITECORE field.</param>
        /// <returns>Content having field name and value.</returns>
        private static AppContent GetSimpleText(Field field)
        {
            return new AppContent
            {
                FieldName = field.Name,
                Value = field.Value,
            };
        }

        private static AppContent GetCheckbox(Field field)
        {
            return new AppContent
            {
                FieldName = field.Name,
                Value = !string.IsNullOrWhiteSpace(field.Value) && field.Value == "1" ? "true" : "false",
            };
        }

        private static CtaData GetMultilist(Field multilistField)
        {
            var dataList = ((MultilistField)multilistField).GetItems().ToList();
            var ctaData = new CtaData();
            ctaData.Data = new List<IDictionary<string, string>>();

            foreach (var dataItem in dataList)
            {
                var fields = dataItem.Fields.ToList();
                var data = new Dictionary<string, string>();

                foreach (var field in fields)
                {
                    // Check if the field is Standard field. If not get the field name and value.
                    if (field.Name.StartsWith("__", StringComparison.CurrentCultureIgnoreCase) == false)
                    {
                        AppContent content;
                        switch (field.Type)
                        {
                            case AppManifestsConstants.FieldTypeSingleLineText:
                            case AppManifestsConstants.FieldTypeMultiLineText:
                            case AppManifestsConstants.FieldTypeRichText:
                            case AppManifestsConstants.FieldTypeDroplist:
                                content = GetSimpleText(field);
                                break;
                            case AppManifestsConstants.FieldTypeGeneralLink:
                                content = GetLinkInformation(field);
                                break;
                            case AppManifestsConstants.FieldTypeImage:
                                content = GetImage(field);
                                break;
                            case AppManifestsConstants.FieldTypeCheckbox:
                                content = GetCheckbox(field);
                                break;
                            default:
                                content = null;
                                break;
                        }

                        if (content != null)
                        {
                            data.Add(
                                content.FieldName,
                                content.Value);
                        }
                    }
                }

                ctaData.Data.Add(data);
            }

            return ctaData;
        }
    }
}
