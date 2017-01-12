using System.Collections.Generic;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.ContentCollection
{
    /// <summary>
    /// Social Media Items and Image Links items are rendered as groups 
    /// Use this class to create a single object using the list of items and assign to ContentItem object
    /// </summary>
    public class GroupedItem<T>
    {
        public IEnumerable<T> Items { get; set; }
    }
}