﻿namespace Vitality.Website.Areas.Presales.ComponentTemplates.Literature
{
    using System.Collections.Generic;

    using Vitality.Website.Areas.Global.Models;

    public class LiteratureCategory : SitecoreItem
    {
        public string Headline { get; set; }

        public IEnumerable<LiteratureDocument> Documents { get; set; }
    }
}