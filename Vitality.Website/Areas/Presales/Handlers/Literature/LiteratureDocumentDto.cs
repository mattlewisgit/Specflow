namespace Vitality.Website.Areas.Presales.Handlers.Literature
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core;

    public class LiteratureDocumentDto
    {
        public string Title { get; set; }

        public string Description { get;set; }

        public DateTime PublishDate { get; set; }

        public string Document { get; set; }

        public string Thumbnail { get; set; }

        public string Code { get; set; }

        public string Category { get; set; }

        public string Key { get; set; }

        public DateTime EffectivePlanDate { get; set; }

        public string PlanType { get; set; }

        public int PlanNumber { get; set; }

        public long DocumentSize { get; set; }

        public LiteratureDocumentSummaryDto[] AvailableLiterature { get; set; }

        public static IEnumerable<LiteratureDocumentDto> From
            (IEnumerable<LiteratureDocumentSearchResult> searchResult1) =>
                searchResult1.Select(searchResult => new LiteratureDocumentDto
                {
                    Title = searchResult.Title,
                    Description = searchResult.Description,
                    Code = searchResult.Code,
                    Document = searchResult.Document,
                    Thumbnail = searchResult.Thumbnail,
                    PublishDate = searchResult.PublishDate,
                    Category = searchResult.Category,
                    Key = searchResult.Title.ToLowerHyphenatedWords(),
                    EffectivePlanDate = searchResult.EffectivePlanDate,
                    PlanType = searchResult.PlanType,
                    PlanNumber = searchResult.PlanNumber,
                    DocumentSize = searchResult.DocumentSize,
                    AvailableLiterature = new LiteratureDocumentSummaryDto[0]
                }).ToList();
    }
}
