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
        private readonly int recursionLevel;
        private readonly string ancestorFieldName;

        public AncestorField(XmlNode xmlNode)
            : base(xmlNode)
        {
            this.recursionLevel = 0;
            int.TryParse(XmlUtil.GetAttribute("recursionLevel", xmlNode), out this.recursionLevel);
            this.ancestorFieldName = XmlUtil.GetAttribute("ancestorFieldName", xmlNode);
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
            for (var i = 0; i < this.recursionLevel; i++)
            {
                ancestor = ancestor.Parent;
            }
            if (this.ancestorFieldName.Equals("name", StringComparison.OrdinalIgnoreCase))
            {
                return ancestor.Name;
            }
            return ancestor[this.ancestorFieldName];
        }
    }
}
