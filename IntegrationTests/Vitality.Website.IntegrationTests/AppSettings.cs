using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitality.Website.IntegrationTests
{
    public static class AppSettings
    {
        public static string GetValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public static class Paths
        {
            public static string Firefox
            {
                get
                {
                    return GetValue("Paths.Firefox");
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
    }
}
