using System;
using System.Linq;
using Sitecore.Data;
using Sitecore.Diagnostics;
using Sitecore.WFFM.Abstractions.Actions;
using Vitality.Website.App.CallPro;
using Vitality.Website.SC.Extensions;
using Vitality.Website.SC.WFFM.Helpers;

namespace Vitality.Website.SC.WFFM.SaveActions
{
    public class CallProSaveAction : ISaveAction
    {
        public ID ActionID { get; set; }
        public ActionType ActionType { get; private set; }
        public string SchemaId { get; set; }
        public string UniqueKey { get; set; }

        public void Execute(ID formId, AdaptedResultList adaptedFields, ActionCallContext actionCallContext = null, params object[] data)
        {
            Log.Info("SchemaId:" + SchemaId, this);
            Log.Info("FormFields:" + adaptedFields.Count(), this);

            Assert.ArgumentNotNull(SchemaId, "SchemaId");
            Assert.ArgumentNotNull(adaptedFields, "Form Fields");

            // Extract form fields.
            var formFields = FormFieldsHelper.ExtractFormFields(adaptedFields);

            // Extract XML template.
            var item = Sitecore.Context.Database.GetItem(new ID(SchemaId));
            Assert.ArgumentNotNull(item, "Call Pro Schema");
            Assert.AreEqual(item.TemplateID.ToString(), WffmConstants.XmlSchemaTemplateId, string.Empty);

            var xmlTemplate = item.Fields["Xml"].Value;

            // Transform XML.
            var requestXml = xmlTemplate.Replace(formFields);

            try
            {
                // Execute request.
                CallProConnector.Send(requestXml);
            }
            catch (Exception ex)
            {
                Log.Error(
                    string.Format("Failed to submit form to Call Pro. SchemaId:{0}. Error:{1}. InnerException:{2}.", 
                    SchemaId, 
                    ex.Message, 
                    ex.InnerException != null ? ex.InnerException.Message : string.Empty)
                    , this);
            }
            
        }

        public ActionState QueryState(ActionQueryContext queryContext)
        {
            return ActionState.Enabled;
        }
    }
}
