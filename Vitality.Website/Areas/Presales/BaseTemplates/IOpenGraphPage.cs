using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Fields;

namespace Vitality.Website.Areas.Presales.BaseTemplates
{
    public interface IOpenGraphPage
    {
        string OpenGraphTitle { get; set; }
        string OpenGraphType { get; set; }
        string OpenGraphUrl { get; set; }
        Image OpenGraphImage { get; set; }
        string OpenGraphSiteName { get; set; }
        string OpenGraphDescription { get; set; }
    }
}