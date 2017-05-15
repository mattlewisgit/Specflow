namespace Vitality.Website.Areas.Presales.BaseTemplates
{
    using System.Collections.Generic;

    using Glass.Mapper.Sc.Configuration;
    using Glass.Mapper.Sc.Configuration.Attributes;

    using Vitality.Website.Areas.Global.Models;

    public interface ISearch
    {
        bool HideFromSearch { get; set; }
    }
}
