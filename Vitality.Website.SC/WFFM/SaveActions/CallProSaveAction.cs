using Sitecore.Data;
using Sitecore.Diagnostics;
using Sitecore.Forms.Core.Wrappers;
using Sitecore.Security.Authentication;
using Sitecore.WFFM.Abstractions.Actions;

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
            string xmlData = data[0].ToString();
            Assert.ArgumentNotNullOrEmpty(xmlData, "Missing CallPro XML schema.");

            // Call pro integration
            var item = Sitecore.Context.Database.GetItem(new ID(SchemaId));
            var xml = item.Fields["Xml"].Value;
        }

        /// <summary>
        /// Gets or sets the SchemaId field.
        /// </summary>
        public string SchemaId { get; set; }

        public ID ActionID { get; set; }
        public string UniqueKey { get; set; }
        public ActionType ActionType { get; private set; }
        public ActionState QueryState(ActionQueryContext queryContext)
        {
            return ActionState.Enabled;
        }
    }
}
