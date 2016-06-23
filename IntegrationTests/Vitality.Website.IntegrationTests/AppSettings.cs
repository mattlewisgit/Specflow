using System.Configuration;

namespace Vitality.Website.IntegrationTests
{
    public static class AppSettings
    {
        public static class Paths
        {
            public static string Firefox
            {
                get
                {
                    return GetValue("Paths.Firefox");
                }
            }

            public static string Firefox64
            {
                get
                {
                    return GetValue("Paths.Firefox64");
                }
            }

            public static string Chrome
            {
                get
                {
                    return GetValue("Paths.Chrome");
                }
            }
        }

        public static class Links
        {
            public static string VitalityBaseUrl
            {
                get
                {
                    return GetValue("Links.VitalityBaseUrl");
                }
            }
        }
        private static string GetValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
