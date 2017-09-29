using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Mvc.Helpers;
using Vitality.Website.Areas.AppManifests;
using Vitality.Website.Areas.AppManifests.Models;
using Vitality.Website.SC.Utilities;
using Log = Sitecore.Diagnostics.Log;

namespace Vitality.Website.Controllers
{
    public class ManifestController : Controller
    {
        /// <summary>
        /// Gets the manifest data for app.
        /// </summary>
        /// <returns>Manifest data containing routing information for reference data.</returns>
        public ContentResult ReferenceDataManifest()
        {
            try
            {
                // Initializes the manifest model.
                var manifest = InitializeManifest();

                var serializedManifest = JsonConvert.SerializeObject(
                    manifest,
                    Formatting.None,
                    AppManifestsConstants.JsonSerializerSetting
                    );
                return this.Content(
                    serializedManifest,
                    "application/json");
            }
            catch (Exception ex)
            {
                var item = Context.Item;
                Log.Error($"Error serializing app mainfest {item.Name} ({item.ID}): Error:{ex.Message}. InnerException: {ex.InnerException?.Message ?? string.Empty}", "ManifestController");
                throw;
            }
        }

        /// <summary>
        /// Initializes the manifest model.
        /// </summary>
        /// <returns>Manifest model containing reference data information.</returns>
        private static Manifest InitializeManifest()
        {
            var manifest = new Manifest
            {
                Data = new List<Entity>()
            };

            Item item = Sitecore.Context.Item;
            if (item != null && item.Paths != null && !string.IsNullOrWhiteSpace(item.Paths.Path))
            {
                // Sitecore fast query to get all the children item having below mentioned template id. 
                var query = string.Format(
                    "fast:/{0}//*[@@templateid ='{1}']",
                    Sitecore.Context.Item.Paths.Path,
                    AppManifestsConstants.ReferenceDataTemplateId);

                Item[] manifestItems =
                    Context.Database.SelectItems(query);

                // This loop iterates through all the item in the list and reads the necessary information from corrosponding item to build the manifest.
                foreach (var manifestItem in manifestItems)
                {
                    if (manifestItem.Paths != null)
                    {
                        var data = new Entity
                        {
                            EntityName = manifestItem.Name,
                            Href =
                                SitecoreDataItemHelper.BuildUrl(
                                    manifestItem.Paths.Path.ToLowerInvariant()
                                        .Replace(AppManifestsConstants.SitecoreContentRootPath, string.Empty)),
                            Version = manifestItem.Fields[AppManifestsConstants.VersionField].Value,
                            Cacheable =
                                ((CheckboxField) manifestItem.Fields[AppManifestsConstants.CacheableField]).Checked
                        };

                        manifest.Data.Add(data);
                    }
                }                
            }

            return manifest;
        }
    }
}
