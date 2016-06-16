using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitality.Website.Areas.Presales.BaseTemplates
{
    public interface IWebmasterToolsGlobal
    {
        string GoogleSiteVerification { get; set; }
        string BingSiteVerification { get; set; }
    }
}
