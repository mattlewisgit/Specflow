using System.Collections.Generic;
using Glass.Mapper.Sc.Fields;
using Sitecore.Configuration;
using Sitecore.Resources.Media;

namespace Vitality.Website.Areas.Presales.Handlers.Literature
{
    using System;
    using System.ComponentModel;

    using Sitecore.ContentSearch;
    using Sitecore.ContentSearch.Converters;

    public class LiteratureDocumentSearchResult
    {
        [IndexField("title")]
        public virtual string Title { get; set; }

        [IndexField("description")]
        public virtual string Description { get; set; }

        [IndexField("thumbnail")]
        public virtual string Thumbnail { get; set; }

        [IndexField("document")]
        public virtual string Document { get; set; }

        [IndexField("code")]
        public virtual string Code { get; set; }

        [IndexField("publishdate")]
        public virtual DateTime PublishDate { get; set; }

        [IndexField("library")]
        public virtual string Library { get; set; }

        [IndexField("category")]
        public virtual string Category { get; set; }

        [IndexField("effectiveplandate")]
        public virtual DateTime EffectivePlanDate { get; set; }

        [IndexField("plantype")]
        public virtual string PlanType { get; set; }

        [IndexField("plannumber")]
        public virtual int PlanNumber { get; set; }

        [IndexField("documentsize")]
        public virtual long DocumentSize { get; set; }

        [IndexField("_template")]
        [TypeConverter(typeof(IndexFieldGuidValueConverter))]
        public virtual Guid TemplateId { get; set; }
    }
}
