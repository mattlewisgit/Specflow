using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Vitality.Website.Areas.AppManifests
{
    public class AppManifestsConstants
    {
        public static JsonSerializerSettings JsonSerializerSetting
        {
            get
            {
                return new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore,
                    Converters = new List<JsonConverter>
                    {
                        new KeyValuePairConverter()
                    }
                };
            }
        }

        public const string ReferenceDataTemplateId = "{C69A1DEB-F2E9-413F-9CD2-12F7CC123043}";

        /// <summary>
        /// Sitecore content root path.
        /// </summary>
        public const string SitecoreContentRootPath = "/sitecore/content/presales/home";

        /// <summary>
        /// Sitecore field Version.
        /// </summary>
        public const string VersionField = "Version";

        /// <summary>
        /// Sitecore field Cacheable.
        /// </summary>
        public const string CacheableField = "Cacheable";

        /// <summary>
        /// Sitecore field Data.
        /// </summary>
        public const string DataField = "Data";

        public const string Internal = "internal";

        /// <summary>
        /// Sitecore Field type Single-Line Text.
        /// </summary>
        public const string FieldTypeSingleLineText = "Single-Line Text";

        /// <summary>
        /// Sitecore Field type Multi-Line Text.
        /// </summary>
        public const string FieldTypeMultiLineText = "Multi-Line Text";

        /// <summary>
        /// Sitecore Field type Rich Text.
        /// </summary>
        public const string FieldTypeRichText = "Rich Text";

        /// <summary>
        /// Sitecore Field type Drop list.
        /// </summary>
        public const string FieldTypeDroplist = "Droplist";

        /// <summary>
        /// Sitecore Field type General Link.
        /// </summary>
        public const string FieldTypeGeneralLink = "General Link";

        /// <summary>
        /// Sitecore Field type Image.
        /// </summary>
        public const string FieldTypeImage = "Image";

        /// <summary>
        /// Sitecore Field type Checkbox.
        /// </summary>
        public const string FieldTypeCheckbox = "Checkbox";

        /// <summary>
        /// Sitecore Field type Checkbox.
        /// </summary>
        public const string FieldTypeMultilist = "Multilist";
    }
}
