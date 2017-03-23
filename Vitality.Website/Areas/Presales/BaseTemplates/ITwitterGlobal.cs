using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vitality.Website.Areas.Presales.BaseTemplates
{
    public interface ITwitterGlobal
    {
        string TwitterCard { get; set; }
        string TwitterAppIPhoneId { get; set; }
        string TwitterAppIPhoneName { get; set; }
    }
}
