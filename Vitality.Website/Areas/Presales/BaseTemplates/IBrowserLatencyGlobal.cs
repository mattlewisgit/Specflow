using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.ContentSearch.Extracters.IFilterTextExtraction;

namespace Vitality.Website.Areas.Presales.BaseTemplates
{
    public interface IBrowserLatencyGlobal
    {
        string[] DnsPrefetch { get; set; }
    }
}