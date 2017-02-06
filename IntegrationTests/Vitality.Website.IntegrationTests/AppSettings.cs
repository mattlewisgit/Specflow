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

            public static string PhantomJS
            {
                get
                {
                    return GetValue("Paths.PhantomJS");
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
            public static string VitalityAdvisersUrl
            {
                get
                {
                    return GetValue("Links.VitalityAdvisersUrl");
                }
            }
            public static string VitalityPresalesUrl
            {
                get
                {
                    return GetValue("Links.VitalityPresalesUrl");
                }
            }


            public static string VitalityAdvisersProductionUrl
            {
                get
                {
                    return GetValue("Links.VitalityAdvisersProductionUrl");
                }
            }
            public static string VitalityPresalesProductionUrl
            {
                get
                {
                    return GetValue("Links.VitalityPresalesProductionUrl");
                }
            }

        }
        private static string GetValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
