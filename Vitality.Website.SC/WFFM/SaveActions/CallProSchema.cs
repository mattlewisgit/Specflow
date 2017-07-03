using System;
using Sitecore.Web.UI.Pages;
using Sitecore.Web.UI.Sheer;
using Sitecore.Web.UI.XmlControls;
using Sitecore.Web.UI.HtmlControls;
using System.Collections.Specialized;
using Sitecore.Form.Core.Utility;

namespace Vitality.Website.SC.WFFM.SaveActions
{
    public class CallProSchema : DialogForm
    {
        public string Params
        {
            get
            {
                return (System.Web.HttpContext.Current.Session[Sitecore.Web.WebUtil.GetQueryString("params")] as string);
            }
        }

        public string SchemaId { get; set; }

        protected NameValueCollection Collection = new NameValueCollection();
        protected GenericControl CurrentPlaceholder;
        protected XmlControl Dialog;
        protected DataContext ItemDataContext;
        protected DataTreeview ItemTreeView;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!Sitecore.Context.ClientPage.IsEvent)
            {
                Collection = ParametersUtil.XmlToNameValueCollection(Params);

                SchemaId = Collection["SchemaId"];

                if (!string.IsNullOrEmpty(SchemaId) && Sitecore.Data.ID.IsID(SchemaId))
                {
                    ItemDataContext.DefaultItem = SchemaId;
                }

                OnNodeSelected(this, EventArgs.Empty);
            }

            ItemTreeView.OnClick += OnNodeSelected;
        }

        private void OnNodeSelected(object sender, EventArgs e)
        {
            if (ItemDataContext.CurrentItem == null)
            {
                return;
            }

            var str = ItemDataContext.CurrentItem.ID.ToString();
            Collection.Add("SchemaId", str);
        }

        protected override void OnOK(object sender, EventArgs args)
        {
            var selectionItem = ItemTreeView.GetSelectionItem();

            if (selectionItem == null)
            {
                SheerResponse.Alert("Choose an item", new string[0]);
                return;
            }

            Collection.Add("SchemaId", selectionItem.ID.ToString());

            var str = ParametersUtil.NameValueCollectionToXml(Collection);

            if (str.Length == 0)
            {
                str = "-";
            }

            SheerResponse.SetDialogValue(str);
            base.OnOK(sender, args);
        }
    }
}
