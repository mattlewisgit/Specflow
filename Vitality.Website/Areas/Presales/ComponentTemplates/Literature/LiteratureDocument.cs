namespace Vitality.Website.Areas.Presales.ComponentTemplates.Literature
{
    using System;

    using Glass.Mapper.Sc.Fields;

    public class LiteratureDocument
    {
        public string Title { get; set; }

        public Image Thumbnail { get; set; }

        public Link Document { get; set; }

        public string Description { get; set; }

        public DateTime PublishDate { get; set; }

        public string Code { get; set; }
    }
}