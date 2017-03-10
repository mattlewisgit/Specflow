using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Globalization;

namespace Vitality.Website.SC.Models
{
    public class DictionaryReferenceObject
    {
        public DictionaryReferenceObject(string guid)
        {
            Guid = guid;

            var db = Sitecore.Context.Database;
            if (db.Name.ToLower() == "core")
            {
                db = Database.GetDatabase("web");
            }

            var item = db.GetItem(guid);
            if (item == null)
            {
                return;
            }

            InnerItem = item;
        }

        /// <summary>
        /// Sitecore dictionary item
        /// </summary>
        public Item InnerItem { get; private set; }

        /// <summary>
        /// ID of the dictionary item
        /// </summary>
        public string Guid { get; private set; }

        /// <summary>
        /// Dictionary Key
        /// </summary>
        public string Key
        {
            get
            {
                if (InnerItem == null)
                {
                    return string.Empty;
                }

                return InnerItem["Key"];
            }
        }

        /// <summary>
        /// Translated Dictionary Phrase
        /// </summary>
        public string Phrase
        {
            get
            {
                if (string.IsNullOrEmpty(Key))
                {
                    return string.Empty;
                }

                return Translate.Text(InnerItem["Phrase"]);
            }
        }
    }
}
