using System;
using Sitecore.Web.UI.Pages;
using Sitecore.Data.Items;
using Sitecore.Web.UI.Sheer;
using Sitecore.Web.UI.XmlControls;
using Sitecore.Web.UI.HtmlControls;
using System.Collections.Specialized;
using Sitecore.Form.Core.Utility;

namespace Vitality.Website.SC.WFFM.SaveActions
{
    public class CallProSchema : DialogForm
    {
        protected GenericControl CurrentPlaceholder;
        protected XmlControl Dialog;
        protected DataContext ItemDataContext;
        protected DataTreeview ItemTreeView;

        protected NameValueCollection nvc = new NameValueCollection();

        public string Params
        {
            get
            {
                return (System.Web.HttpContext.Current.Session[Sitecore.Web.WebUtil.GetQueryString("params")] as string);
            }
        }

        protected override void OnLoad(EventArgs e)
        {

            base.OnLoad(e);

            if (!Sitecore.Context.ClientPage.IsEvent)
            {
                //this.Localize();

                nvc = ParametersUtil.XmlToNameValueCollection(Params);

                SchemaId = nvc["SchemaId"];

                if (!string.IsNullOrEmpty(this.SchemaId) && Sitecore.Data.ID.IsID(this.SchemaId))
                {
                    this.ItemDataContext.DefaultItem = this.SchemaId;
                }
                this.OnNodeSelected(this, EventArgs.Empty);
            }
            this.ItemTreeView.OnClick += new EventHandler(this.OnNodeSelected);
        }

        private void OnNodeSelected(object sender, EventArgs e)
        {
            if (this.ItemDataContext.CurrentItem != null)
            {
                string str = this.ItemDataContext.CurrentItem.ID.ToString();
                nvc.Add("SchemaId", str);
            }
        }

        protected override void OnOK(object sender, EventArgs args)
        {
            Item selectionItem = this.ItemTreeView.GetSelectionItem();
            if (selectionItem == null)
            {
                SheerResponse.Alert("Choose an item", new string[0]);
            }
            else
            {
                nvc.Add("SchemaId", selectionItem.ID.ToString());
                string str = ParametersUtil.NameValueCollectionToXml(nvc);
                if (str.Length == 0)
                {
                    str = "-";
                }
                SheerResponse.SetDialogValue(str);
                base.OnOK(sender, args);
            }
        }

        public string SchemaId { get; set; }
    }
}
