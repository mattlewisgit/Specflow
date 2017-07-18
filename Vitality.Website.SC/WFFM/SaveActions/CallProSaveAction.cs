namespace Vitality.Website.SC.WFFM.SaveActions
{
    using System;
    using System.Linq;
    using Sitecore.Data;
    using Sitecore.Diagnostics;
    using Sitecore.WFFM.Abstractions.Actions;
    using Core;
    using Helpers;
    using Utilities;

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

            Assert.ArgumentNotNull(item.Fields["Xml"], "Call Pro Schema Xml");
            var xmlTemplate = item.Fields["Xml"].Value;

            var requestXml = string.Empty;

            try
            {
                // Transform XML.
                requestXml = xmlTemplate.Replace(formFields);
            }
            catch (Exception ex)
            {
                Log.Error(
                    $"Error Transforming Call Pro XML Data: Error:{ex.Message}. InnerException: {(ex.InnerException != null ? ex.InnerException.Message : string.Empty)}"
                    , this);
            }

            try
            {
                PresalesLog.Log.Info(requestXml);
                // Execute request.
                CallProConnector.Send(requestXml);
            }
            catch (Exception ex)
            {
                Log.Error(
                    $"Failed to submit form to Call Pro. SchemaId:{SchemaId}. Error:{ex.Message}. InnerException:{(ex.InnerException != null ? ex.InnerException.Message : string.Empty)}."
                    , this);
            }

        }

        public ActionState QueryState(ActionQueryContext queryContext)
        {
            return ActionState.Enabled;
        }
    }
}
