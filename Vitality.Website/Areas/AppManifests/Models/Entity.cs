using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vitality.Website.Areas.AppManifests.Models
{
    public class Entity
    {
        /// <summary>
        /// Gets or sets the HREF.
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        /// Gets or sets the EntityName in the Reference data.
        /// </summary>
        public string EntityName { get; set; }

        /// <summary>
        /// Gets or sets the Version of reference data.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Cacheable is set or not. Indicating that,
        /// the reference data can be made as cacheable or not.
        /// </summary>
        public bool Cacheable { get; set; }
    }
}
