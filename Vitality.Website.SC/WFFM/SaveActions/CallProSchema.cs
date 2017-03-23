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
                this.Collection = ParametersUtil.XmlToNameValueCollection(Params);

                SchemaId = this.Collection["SchemaId"];

                if (!string.IsNullOrEmpty(this.SchemaId) && Sitecore.Data.ID.IsID(this.SchemaId))
                {
                    this.ItemDataContext.DefaultItem = this.SchemaId;
                }

                this.OnNodeSelected(this, EventArgs.Empty);
            }

            this.ItemTreeView.OnClick += this.OnNodeSelected;
        }

        private void OnNodeSelected(object sender, EventArgs e)
        {
            if (this.ItemDataContext.CurrentItem == null)
            {
                return;
            }

            var str = this.ItemDataContext.CurrentItem.ID.ToString();
            this.Collection.Add("SchemaId", str);
        }

        protected override void OnOK(object sender, EventArgs args)
        {
            var selectionItem = this.ItemTreeView.GetSelectionItem();

            if (selectionItem == null)
            {
                SheerResponse.Alert("Choose an item", new string[0]);
                return;
            }

            this.Collection.Add("SchemaId", selectionItem.ID.ToString());

            var str = ParametersUtil.NameValueCollectionToXml(this.Collection);

            if (str.Length == 0)
            {
                str = "-";
            }

            SheerResponse.SetDialogValue(str);
            base.OnOK(sender, args);
        }
    }
}
