using System.IO;
using System.IO.Compression;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace Vitality.Website.SC.Utilities.Sitemap
{
    public class SitemapHelper<T>
    {
        public static void SaveSitemapToDisk(T model, string sitemapName, bool compress)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            var xmlWriterSetting = new XmlWriterSettings()
            {
                Encoding = System.Text.Encoding.UTF8,
                Indent = true,
                OmitXmlDeclaration = false,
                ConformanceLevel = ConformanceLevel.Auto
            };

            string xmlFile = string.Format("{0}{1}", HttpRuntime.AppDomainAppPath, sitemapName);

            if (compress)
            {
                using (StringWriter textWriter = new StringWriter())
                {
                    serializer.Serialize(textWriter, model);
                    string xmlContent = textWriter.ToString();

                    using (var fs = File.Create(xmlFile))
                    {
                        using (var gz = new GZipStream(fs, CompressionMode.Compress))
                        {
                            using (var writer = XmlWriter.Create(gz, xmlWriterSetting))
                            {
                                writer.WriteString(xmlContent);
                                fs.Flush();
                            }
                        }
                    }
                }
            }
            else
            {
                using (XmlWriter writer = XmlWriter.Create(xmlFile, xmlWriterSetting))
                {
                    serializer.Serialize(writer, model);
                }
            }
        }

        public static T ReadSitemapFromDisk(string sitemapName)
        {
            T model = default(T);

            string xmlFile = string.Format("{0}{1}", HttpRuntime.AppDomainAppPath, sitemapName);

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
