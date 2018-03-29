using System.Configuration;

namespace Kingfisher.Website.IntegrationTests
{
    public static class AppSettings
    {
        public static class Paths
        {
            public static string Firefox => GetValue("Paths.Firefox");
            public static string Firefox64 => GetValue("Paths.Firefox64");
            public static string PhantomJS => GetValue("Paths.PhantomJS");
        }

        public static class Links
        {
            public static string DIYBaseUrl => GetValue("Links.DIYBaseUrl");
            public static string StockEndpointUrl => GetValue("Links.StockEndpointUrl");
            public static string RiversandBaseUrl => GetValue("Links.RiversandBaseUrl");
        }
        private static string GetValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
