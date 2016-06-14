using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vitality.Website.Areas.Presales.BaseTemplates
{
    public interface IAnalyticsGlobal
    {
        string Referrer { get; set; }
    }
}