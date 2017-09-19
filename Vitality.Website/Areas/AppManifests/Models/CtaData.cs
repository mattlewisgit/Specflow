using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vitality.Website.Areas.AppManifests.Models
{
    public class CtaData
    {
        /// <summary>
        /// Gets or sets the Data. This property will be used to dynamically build Model to store SITECORE fields and value.
        /// </summary>
        public IList<IDictionary<string, string>> Data { get; set; }
    }
}
