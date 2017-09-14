using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vitality.Website.Areas.AppManifests.Models
{
    public class Manifest
    {
        /// <summary>
        /// Gets or sets the manifest Data.
        /// </summary>
        public IList<Entity> Data { get; set; }
    }
}
