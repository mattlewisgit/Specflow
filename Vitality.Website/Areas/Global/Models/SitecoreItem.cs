namespace Vitality.Website.Areas.Global.Models
{
    using System;

    using Glass.Mapper.Sc.Configuration.Attributes;

    public class SitecoreItem
    {
        [
        SitecoreId]
        public Guid Id { get; set; }
    }
}