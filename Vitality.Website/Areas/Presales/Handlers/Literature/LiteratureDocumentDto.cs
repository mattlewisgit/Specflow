﻿using System.Collections.Generic;
using System.Linq;

namespace Vitality.Website.Areas.Presales.Handlers.Literature
{
    using System;

    public class LiteratureDocumentDto
    {
        public string Title { get; set; }

        public string Description { get;set; }

        public DateTime PublishDate { get; set; }

        public string Document { get; set; }

        public string Thumbnail { get; set; }

        public string Code { get; set; }

        public string Category { get; set; }

        public LiteratureDocumentSummaryDto[] AvailableLiterature { get; set; }
        
        public static IEnumerable<LiteratureDocumentDto> From(IEnumerable<LiteratureDocumentSearchResult> searchResult1)
        {
            var results = searchResult1.Select(searchResult => new LiteratureDocumentDto
            {
                Title = searchResult.Title,
                Description = searchResult.Description,
                Code = searchResult.Code,
                Document = searchResult.Document,
                Thumbnail = searchResult.Thumbnail,
                PublishDate = searchResult.PublishDate,
                Category = searchResult.Category,
                AvailableLiterature = new LiteratureDocumentSummaryDto[0]
            }).ToList();

            return results;
        }
    }
}