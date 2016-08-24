using System.Web;
using Sitecore;

namespace Vitality.Website.SC
{
    using Sitecore.Data;
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
            public static string GetItemFullPath(string itemRelativePath)
            {
                return Sitecore.Context.Site.ContentStartPath + itemRelativePath;
            }

            public static class Content
            {
                public static class Home
                {
                    public static string Path => Context.Site.StartPath;
                }

                public static class ContentFolder
                {
                    public static string RelativePath = "/Content";
                }

                public static class Configuration
                {
                    public static class QuoteFooter
                    {
                        public static string Path => GetItemFullPath("/Configuration/Quote Footer");
                    }

                    public static class SiteSettings
                    {
                        public static string Path => GetItemFullPath("/Configuration/Site Settings");
                    }

                    public static class CookieSettings
                    {
                        public static string Path => GetItemFullPath("/Configuration/Cookie Settings");
                    }

                    public static class Sitemaps
                    {
                        public static string Path => GetItemFullPath("/Configuration/Sitemaps");
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
            }

            public static class Templates
            {
                public static class NavigationSection
                {
                    public const string Id = "{EDCF6697-B4B9-48CC-BAC2-2DDE182DC317}";
                    public static string Path => GetItemFullPath("/Component Templates/Navigation/Navigation Section");
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