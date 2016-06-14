﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vitality.Website.Areas.Presales.BaseTemplates
{
    public interface IOpenGraphGlobal
    {
        string OpenGraphLocale { get; set; }
        string OpenGraphArticlePublisher { get; set; }
        string OpenGraphIosAppId { get; set; }
        string OpenGraphIosAppName { get; set; }
    }
}