using System.Configuration;

namespace Vitality.Website.IntegrationTests
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
            public static string VitalityBaseUrl => GetValue("Links.VitalityBaseUrl");

            public static string VitalityAdvisersUrl => GetValue("Links.VitalityAdvisersUrl");

            public static string VitalityPresalesUrl => GetValue("Links.VitalityPresalesUrl");


            public static string VitalityAdvisersProductionUrl => GetValue("Links.VitalityAdvisersProductionUrl");
            public static string VitalityPresalesProductionUrl => GetValue("Links.VitalityPresalesProductionUrl");
        }
        private static string GetValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
