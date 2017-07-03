using System.IO;
using System.IO.Compression;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace Vitality.Website.SC.Agents.Sitemaps
{
    public class SitemapHelper<T>
    {
        private const string SiteMapLocation = "sitemaps";

        public static void SaveSitemapToDisk(T model, string sitemapName, bool compress)
        {
            var serializer = new XmlSerializer(typeof (T));

            var xmlWriterSetting = new XmlWriterSettings()
            {
                Encoding = System.Text.Encoding.UTF8,
                Indent = true,
                OmitXmlDeclaration = false,
                ConformanceLevel = ConformanceLevel.Auto
            };

            var xmlFile = $"{HttpRuntime.AppDomainAppPath}{SiteMapLocation}\\{sitemapName}";

            using (var writer = XmlWriter.Create(xmlFile, xmlWriterSetting))
            {
                serializer.Serialize(writer, model);
            }

            if (compress)
            {
                using (var fs = File.OpenRead(xmlFile))
                {
                    using (var compressedFileStream = File.Create(xmlFile + ".gz"))
                    {
                        using (var compressionStream = new GZipStream(compressedFileStream,
                            CompressionMode.Compress))
                        {
                            fs.CopyTo(compressionStream);

                        }
                    }
                }
            }
        }

        public static T ReadSitemapFromDisk(string sitemapName)
        {
            T model = default(T);
            
            var xmlFile = $"{HttpRuntime.AppDomainAppPath}{SiteMapLocation}\\{sitemapName}";

            if (File.Exists(xmlFile))
            {
                XmlSerializer serializer = new XmlSerializer(typeof (T));

                using (XmlReader reader = XmlReader.Create(xmlFile))
                {
                    model = (T) serializer.Deserialize(reader);
                }
            }

            return model;
        }
    }
}
