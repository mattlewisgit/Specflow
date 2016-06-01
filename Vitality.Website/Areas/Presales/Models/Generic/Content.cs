using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vitality.Website.Areas.Global.Models;

namespace Vitality.Website.Areas.Presales.Models.Generic
{
    public class Content : SitecoreItem
    {
        public Content()
        {
            
        }

        public string RichText { get; set; }
    }
}