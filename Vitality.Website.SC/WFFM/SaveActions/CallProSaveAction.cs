using System.Collections.Generic;
using Sitecore.Data;
using Sitecore.WFFM.Abstractions.Actions;
using Vitality.Website.App.CallPro;
using Vitality.Website.SC.WFFM.Helpers;

namespace Vitality.Website.SC.WFFM.SaveActions
{
    public class CallProSaveAction : ISaveAction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CallProSaveAction"/> class.
        /// </summary>
        public CallProSaveAction()
        {
        }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="formId">
        /// The form id.
        /// </param>
        /// <param name="adaptedFields">
        /// The adapted fields.
        /// </param>
        /// <param name="actionCallContext">
        /// The action call context.
        /// </param>
        /// <param name="data">
        /// The data.
        /// </param>
        public void Execute(ID formId, AdaptedResultList adaptedFields, ActionCallContext actionCallContext = null, params object[] data)
        {
            // Extract form fields.
            Dictionary<string, string> formFields = FormFieldsHelper.ExtractFormFields(adaptedFields);

            // Extract XML template.
            var item = Sitecore.Context.Database.GetItem(new ID(SchemaId));
            var xmlTemplate = item.Fields["Xml"].Value;

            // Transform XML.
            var requestXml = XmlTransformer.TransformXml(xmlTemplate, formFields);

            // Execute request.
            var response = CallProConnector.Send(requestXml);
        }

        /// <summary>
        /// Gets or sets the SchemaId field.
        /// </summary>
        public string SchemaId { get; set; }
        public string TestCheckBox { get; set; }

        public ID ActionID { get; set; }
        public string UniqueKey { get; set; }
        public ActionType ActionType { get; private set; }
        public ActionState QueryState(ActionQueryContext queryContext)
        {
            return ActionState.Enabled;
        }
    }
}
