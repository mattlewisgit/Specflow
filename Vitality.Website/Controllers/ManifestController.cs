using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Mvc.Helpers;
using Vitality.Website.Areas.AppManifests;
using Vitality.Website.Areas.AppManifests.Models;
using Vitality.Website.SC.Utilities;

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

                // In case of exception set Error object with code and description.
                //WebExceptionManager.HandleException(
                    //ex,
                    //ASSEMBLY_NAME,
                    //METHOD_NAME);
                //Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return null;
            }
        }

        /// <summary>
        /// Initializes the manifest model.
        /// </summary>
        /// <returns>Manifest model containing reference data information.</returns>
        private static Manifest InitializeManifest()
        {
            Item item = Sitecore.Context.Item;
            var manifestItems = item.Axes.GetDescendants().Where(p => p.TemplateID == ID.Parse(AppManifestsConstants.ReferenceDataTemplateId));

            var manifest = new Manifest
            {
                Data = new List<Entity>()
            };

            // This loop iterates through all the item in the list and reads the necessary information from corrosponding item to build the manifest.
            foreach (var manifestItem in manifestItems)
            {
                if (manifestItem.Paths != null)
                {
                    var data = new Entity
                    {
                        EntityName = manifestItem.Name,
                        Href = SitecoreDataItemHelper.BuildUrl(manifestItem.Paths.Path.ToLowerInvariant().Replace(AppManifestsConstants.SitecoreContentRootPath, string.Empty)),
                        Version = manifestItem.Fields[AppManifestsConstants.VersionField].Value,
                        Cacheable = ((CheckboxField)manifestItem.Fields[AppManifestsConstants.CacheableField]).Checked
                    };

                    manifest.Data.Add(data);
                }
            }

            return manifest;
        }
    }
}
