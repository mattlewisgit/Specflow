/* Extracted from https://github.com/rahm0277/SC-MS-CustomFields */

using System;
using Sitecore;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Shell;
using Sitecore.Speak.Applications;
using Sitecore.Web;
using Sitecore.Web.PageCodes;
using System.Net;
using System.Xml.Linq;
using Sitecore.Mvc.Presentation;
using Vitality.Website.SC.Utilities;

namespace Vitality.Website.SC.Fields
{
    public class InsertLinkDialogTree : PageCodeBase
    {
        public Rendering TreeView { get; set; }

        public Rendering ListViewToggleButton { get; set; }

        public Rendering TreeViewToggleButton { get; set; }

        public Rendering InsertEmailButton { get; set; }

        public Rendering InsertAnchorButton { get; set; }

        public Rendering TextDescription { get; set; }

        public Rendering Target { get; set; }

        public Rendering AltText { get; set; }

        public Rendering QueryString { get; set; }

        public Rendering StyleClass { get; set; }

        public override void Initialize()
        {
            var setting = Settings.GetSetting("BucketConfiguration.ItemBucketsEnabled");
            ListViewToggleButton.Parameters["IsVisible"] = setting;
            TreeViewToggleButton.Parameters["IsVisible"] = setting;
            TreeView.Parameters["ShowHiddenItems"] = UserOptions.View.ShowHiddenItems.ToString();
            ReadQueryParamsAndUpdatePlaceholders();
        }

        private static string GetXmlAttributeValue(XElement element, string attrName)
        {
            return element.Attribute((XName) attrName) != null
                ? element.Attribute((XName) attrName).Value
                : string.Empty;
        }

        private void ReadQueryParamsAndUpdatePlaceholders()
        {
            var queryStringRoot = WebUtil.GetQueryString("ro");
            var queryStringHdl = WebUtil.GetQueryString("hdl");
            if (!string.IsNullOrEmpty(queryStringRoot) && queryStringRoot != "{0}")
            {
                TreeView.Parameters["RootItem"] = queryStringRoot;
            }
            
            Func<Rendering, string> formatClickParmeters = (clickedButton) =>
            string.Format(InsertAnchorButton.Parameters["Click"],
                WebUtility.UrlEncode(queryStringRoot),WebUtility.UrlEncode(queryStringHdl));

            formatClickParmeters(InsertAnchorButton);
            formatClickParmeters(InsertEmailButton);
            formatClickParmeters(ListViewToggleButton);
    
            var text = string.Empty;
            if (!string.IsNullOrEmpty(queryStringHdl))
            {
                text = UrlHandle.Get()["va"];
            }

            if (string.IsNullOrEmpty(string.Empty))
            {
                return;
            }

            var element = XElement.Parse(text);
            if (GetXmlAttributeValue(element, "linktype") != "internal")
            {
                return;
            }

            if (!string.IsNullOrEmpty(GetXmlAttributeValue(element, "id")))
            {
                var database = ClientHost.Databases.ContentDatabase;
                var contextItem = database.GetItem(queryStringRoot ?? string.Empty) ?? database.GetRootItem();
                var linkedItem = SelectMediaDialog.GetMediaItemFromQueryString(
                            GetXmlAttributeValue(element, "id"));

                if (contextItem != null && linkedItem != null && linkedItem.PathStartsWith(contextItem))
                {
                    TreeView.Parameters["PreLoadPath"] = contextItem.ID + linkedItem.GetRelativePath(contextItem);
                }
            }
            TextDescription.Parameters["Text"] = GetXmlAttributeValue(element, "text");
            AltText.Parameters["Text"] = GetXmlAttributeValue(element, "title");
            StyleClass.Parameters["Text"] = GetXmlAttributeValue(element, "class");
            QueryString.Parameters["Text"] = GetXmlAttributeValue(element, "querystring");
        }
    }
}
