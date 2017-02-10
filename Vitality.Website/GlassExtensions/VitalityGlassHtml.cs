//using Glass.Mapper;
//using Glass.Mapper.Configuration;
//using Glass.Mapper.Pipelines.ConfigurationResolver.Tasks.OnDemandResolver;
//using Glass.Mapper.Sc;
//using Glass.Mapper.Sc.Configuration;
//using Glass.Mapper.Sc.Fields;
//using Glass.Mapper.Sc.Web.Ui;
//using Sitecore.Collections;
//using Sitecore.Data;
//using Sitecore.Data.Events;
//using Sitecore.Data.Items;
//using Sitecore.Diagnostics;
//using Sitecore.Globalization;
//using Sitecore.Pipelines;
//using Sitecore.Pipelines.RenderField;
//using Sitecore.Resources.Media;
//using Sitecore.SecurityModel;
//using Sitecore.Text;
//using Sitecore.Web;
//using System;
//using System.Collections;
//using System.Collections.Concurrent;
//using System.Collections.Generic;
//using System.Collections.Specialized;
//using System.Drawing;
//using System.Globalization;
//using System.IO;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Web;

//namespace Vitality.Website.GlassExtensions
//{
//    public class VitalityGlassHtml : GlassHtml
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="T:Glass.Mapper.Sc.GlassHtml"/> class.
//        ///
//        /// </summary>
//        /// <param name="sitecoreContext">The service that will be used to load and save data</param>
//        public VitalityGlassHtml(ISitecoreContext sitecoreContext)
//            : base(sitecoreContext)
//        {

//        }

//        public override string RenderImage(Glass.Mapper.Sc.Fields.Image image, SafeDictionary<string> attributes, bool outputHeightWidth = false)
//        {
//            if (image == null)
//                return string.Empty;
//            if (attributes == null)
//                attributes = new SafeDictionary<string>();
//            List<string> origionalKeys = Enumerable.ToList<string>(attributes.Keys);
//            GlassHtml.AttributeCheck(attributes, "class", image.Class);
//            if (!attributes.ContainsKey("alt"))
//                attributes["alt"] = image.Alt;
//            GlassHtml.AttributeCheck(attributes, "border", image.Border);
//            if (image.HSpace > 0)
//                GlassHtml.AttributeCheck(attributes, "hspace", image.HSpace.ToString((IFormatProvider)CultureInfo.InvariantCulture));
//            if (image.VSpace > 0)
//                GlassHtml.AttributeCheck(attributes, "vspace", image.VSpace.ToString((IFormatProvider)CultureInfo.InvariantCulture));
//            if (image.Width > 0)
//                GlassHtml.AttributeCheck(attributes, "width", image.Width.ToString((IFormatProvider)CultureInfo.InvariantCulture));
//            if (image.Height > 0)
//                GlassHtml.AttributeCheck(attributes, "height", image.Height.ToString((IFormatProvider)CultureInfo.InvariantCulture));
//            SafeDictionary<string> urlParams = new SafeDictionary<string>();
//            SafeDictionary<string> htmlParams = new SafeDictionary<string>();
//            if (image == null || Glass.Mapper.ExtensionMethods.IsNullOrWhiteSpace(image.Src))
//                return string.Empty;
//            if (attributes == null)
//                attributes = new SafeDictionary<string>();
//            Action<string> remove = (Action<string>)(key => attributes.Remove(key));
//            Action<string> action1 = (Action<string>)(key =>
//            {
//                urlParams.Add(key, attributes[key]);
//                remove(key);
//            });
//            Action<string> action2 = (Action<string>)(key =>
//            {
//                htmlParams.Add(key, attributes[key]);
//                remove(key);
//            });
//            Action<string> action3 = (Action<string>)(key =>
//            {
//                htmlParams.Add(key, attributes[key]);
//                urlParams.Add(key, attributes[key]);
//                remove(key);
//            });
//            foreach (string str in Enumerable.ToList<string>(attributes.Keys))
//            {
//                if (this.SitecoreContext.Config == null)
//                {
//                    action3(str);
//                }
//                else
//                {
//                    bool flag = false;
//                    if (this.SitecoreContext.Config.ImageAttributes.Contains(str))
//                    {
//                        action2(str);
//                        flag = true;
//                    }
//                    if (this.SitecoreContext.Config.ImageQueryString.Contains(str))
//                    {
//                        action1(str);
//                        flag = true;
//                    }
//                    if (!flag)
//                        action2(str);
//                }
//            }
//            if (!urlParams.ContainsKey("w") && !urlParams.ContainsKey("h"))
//            {
//                if (origionalKeys.Contains("width"))
//                    urlParams["w"] = htmlParams["width"];
//                if (origionalKeys.Contains("height"))
//                    urlParams["h"] = htmlParams["height"];
//            }
//            if (!urlParams.ContainsKey("la") && image.Language != (Language)null)
//                urlParams["la"] = image.Language.Name;
//            Size size = Glass.Mapper.Sc.Utilities.ResizeImage(image.Width, image.Height, Glass.Mapper.ExtensionMethods.ToFlaot(urlParams["sc"]), Glass.Mapper.ExtensionMethods.ToInt(urlParams["w"]), Glass.Mapper.ExtensionMethods.ToInt(urlParams["h"]), Glass.Mapper.ExtensionMethods.ToInt(urlParams["mw"]), Glass.Mapper.ExtensionMethods.ToInt(urlParams["mh"]));
//            if (size.Height > 0)
//                urlParams["h"] = size.Height.ToString();
//            if (size.Width > 0)
//                urlParams["w"] = size.Width.ToString();
//            Action<string, string> action4 = (Action<string, string>)((exists, missing) =>
//            {
//                if (!origionalKeys.Contains(exists) || origionalKeys.Contains(missing))
//                    return;
//                urlParams.Remove(missing);
//                htmlParams.Remove(missing);
//            });
//            action4("width", "height");
//            action4("height", "width");
//            if (!outputHeightWidth)
//            {
//                htmlParams.Remove("width");
//                htmlParams.Remove("height");
//            }
//            Glass.Mapper.UrlBuilder urlBuilder = new Glass.Mapper.UrlBuilder(image.Src);
//            foreach (string key in urlParams.Keys)
//                urlBuilder.AddToQueryString(key, urlParams[key]);
//            string str1 = HttpUtility.HtmlEncode(this.ProtectMediaUrl(urlBuilder.ToString()));

//            urlParams["w"] = "20";
//            foreach (string key in urlParams.Keys)
//            urlBuilder.AddToQueryString(key, urlParams[key]);
//            string str2 = HttpUtility.HtmlEncode(this.ProtectMediaUrl(urlBuilder.ToString()));

//            return Glass.Mapper.ExtensionMethods.Formatted(GlassHtml.ImageTagFormat, (object)str1, (object)Glass.Mapper.Sc.Utilities.ConvertAttributes(htmlParams, GlassHtml.QuotationMark), (object)GlassHtml.QuotationMark, (object)str2);
//        }
//    }
//}
