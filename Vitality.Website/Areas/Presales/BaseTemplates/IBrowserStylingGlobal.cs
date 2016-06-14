using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitality.Website.Areas.Presales.BaseTemplates
{
    public interface IBrowserStylingGlobal
    {
        string IeNavButtonColour { get; set; }
        string ApplicationName { get; set; }
    }
}
