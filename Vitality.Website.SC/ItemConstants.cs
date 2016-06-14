namespace Vitality.Website.SC
{
    using System;

    public static class ItemConstants
    {
        public static class Presales
        {
            public static class Content
            {
                public static class Home
                {
                    public static readonly Guid Id = Guid.Parse("{110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9}");
                    public const string Path = "/sitecore/content/Presales/home";
                }

                public static class ContentFolder
                {
                    public const string Path = "/sitecore/content/Presales/Content";
                }
            }

            public static class Templates
            {
                public static class NavigationSection
                {
                    public const string Id = "{EDCF6697-B4B9-48CC-BAC2-2DDE182DC317}";
                    public const string Path = "/sitecore/templates/Presales/Component Templates/Navigation/Navigation Section";
                }

                public static class Summary
                {
                    public static class SummaryListItem
                    {
                        public static readonly Guid Id = Guid.Parse("{8E0DE43E-63DF-4B76-97C9-C4DCCB4546C5}");
                    }

                    public static class SummaryListItemShort
                    {
                        public static readonly Guid Id = Guid.Parse("{428438C8-D8C7-4D8E-BA51-B4FAAE4269C5}"); 
                    }
                }
            }
        }
    }
}