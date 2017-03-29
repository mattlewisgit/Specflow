namespace Vitality.Website.SC.ContentSearch.ComputedFields
{
    using System;
    using System.Xml;

    using Sitecore.ContentSearch;
    using Sitecore.ContentSearch.ComputedFields;
    using Sitecore.Diagnostics;
    using Sitecore.Xml;

    public class AncestorField : AbstractComputedIndexField
    {
        private readonly string _ancestorFieldName;
        private readonly int _recursionLevel;

        public AncestorField(XmlNode xmlNode)
            : base(xmlNode)
        {
            int.TryParse(XmlUtil.GetAttribute("recursionLevel", xmlNode), out _recursionLevel);
            _ancestorFieldName = XmlUtil.GetAttribute("ancestorFieldName", xmlNode);
        }

        public override object ComputeFieldValue(IIndexable indexable)
        {
            Assert.ArgumentNotNull(indexable, "indexable");
            var indexableItem = indexable as SitecoreIndexableItem;

            if (indexableItem == null)
            {
                Log.Warn(string.Format("{0} : unsupported IIndexable type : {1}", this, indexable.GetType()), this);
                return null;
            }

            var ancestor = indexableItem.Item;

            for (var i = 0; i < _recursionLevel; i++)
            {
                ancestor = ancestor.Parent;
            }

            if (_ancestorFieldName.Equals("name", StringComparison.OrdinalIgnoreCase))
            {
                return ancestor.Name;
            }

            return ancestor[_ancestorFieldName];
        }
    }
}
