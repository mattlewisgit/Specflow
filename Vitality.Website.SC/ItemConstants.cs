namespace Vitality.Website.SC
{
    using System;

    public static class ItemConstants
    {
        public static class Global
        {
            public static class Templates
            {
                public static class Subfolder
                {
                    public static readonly Guid Id = Guid.Parse("{4902517E-93B7-41B5-BCC4-387E1D0304A7}");
                }
            }
        }

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

                public static class Configuration
                {
                    public static class QuoteFooter
                    {
                        public static readonly Guid Id = Guid.Parse("{5F2E1820-3907-400D-B0F4-3C8D6DDB0989}");
                    }

                    public static class GlobalSettings
                    {
                        public static readonly Guid Id = Guid.Parse("{578F19B0-CEF6-4B29-AB9F-45BF82417DF4}");
                    }
                }
            }

            public static class Layout
            {
                public static class Renderings
                {
                    public static class QuoteFooter
                    {
                        public static readonly Guid Id = Guid.Parse("{F643ED45-4AC0-4751-AF89-4F31755527B5}");
                    }
                }

                public static class Configuration
                {
                     public static class GlobalSettings
                     {
                         public static readonly Guid Id = Guid.Parse("{578F19B0-CEF6-4B29-AB9F-45BF82417DF4}");
                     }
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