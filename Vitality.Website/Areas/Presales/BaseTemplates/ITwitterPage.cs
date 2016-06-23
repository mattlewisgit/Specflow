using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Fields;

namespace Vitality.Website.Areas.Presales.BaseTemplates
{
    public interface ITwitterPage
    {
        string TwitterSite { get; set; }
        string TwitterTitle { get; set; }
        string TwitterDescription { get; set; }
        Image TwitterImage { get; set; }
    }
}