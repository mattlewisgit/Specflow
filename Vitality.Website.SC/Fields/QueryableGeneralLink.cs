using Sitecore;
using Sitecore.Diagnostics;
using System;
using Sitecore.Shell.Applications.ContentEditor;
using Vitality.Website.SC.Utilities;

namespace Vitality.Website.SC.Fields
{
    public class QueryableGeneralLink : Link
    {
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

                if (dataSource.StartsWith(QueryHelper.QueryStartText, StringComparison.InvariantCultureIgnoreCase))
                {
                    base.Source = value.Replace(dataSource, ResolveQuery(dataSource));
                }
                else
                {
                    base.Source = value.StartsWith(QueryHelper.QueryStartText) ? ResolveQuery(value) : value;
                }
            }
        }

        public string ResolveQuery(string query)
        {
            var contextItem = Sitecore.Context.ContentDatabase.Items[ItemId];
            return query.ResolveQuery(contextItem.Axes);
        }
    }
}