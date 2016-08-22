using Sitecore;
using Sitecore.Diagnostics;
using System;
using Sitecore.Shell.Applications.ContentEditor;

namespace Vitality.Website.SC.Fields
{
    public class QueryableGeneralLink : Link
    {
        private const string QueryStartText = "query:";
        private string _itemId;

        public string ItemId
        {
            get { return StringUtil.GetString(new[] {_itemId}); }
            set
            {
                Assert.ArgumentNotNull(value, "value");
                _itemId = value;
            }
        }

        public new string Source
        {
            get { return base.Source; }
            set
            {
                var dataSource = StringUtil
                    .ExtractParameter("DataSource", value).Trim();
                if (dataSource.StartsWith(QueryStartText, StringComparison.InvariantCultureIgnoreCase))
                {
                    base.Source = value.Replace(dataSource, ResolveQuery(dataSource));
                }
                else
                {
                    base.Source = value.StartsWith(QueryStartText) ? ResolveQuery(value) : value;
                }
            }
        }

        private string ResolveQuery(string query)
        {
            query = query.Substring(QueryStartText.Length);
            var contextItem = Sitecore.Context.ContentDatabase.Items[ItemId];
            var queryItem = contextItem.Axes.SelectSingleItem(query);
            return queryItem != null ? queryItem.Paths.FullPath : string.Empty;
        }
    }
}