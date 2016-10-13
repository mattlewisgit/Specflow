using Sitecore.WFFM.Abstractions.Actions;
using System;
using System.Collections.Generic;
using Sitecore;

namespace Vitality.Website.SC.WFFM.Helpers
{
    internal static class FormFieldsHelper
    {
        internal static Dictionary<string, string> ExtractFormFields(AdaptedResultList formFields)
        {
            Dictionary<string, string> fieldsCollection = new Dictionary<string, string>();

            foreach (AdaptedControlResult field in formFields)
            {
                fieldsCollection.Add(FormatFieldName(field.FieldName), FormatFieldValue(field.FieldID, field.Value));
            }

            // Add custom fields.
            fieldsCollection.Add("{TODAY}", DateTime.Today.ToShortDateString());
            fieldsCollection.Add("{NEXTMONTH}", DateTime.Today.AddMonths(1).ToShortDateString());
            fieldsCollection.Add("{NEXTYEAR}", DateTime.Today.AddYears(1).ToShortDateString());

            return fieldsCollection;
        }

        private static string FormatFieldName(string fieldName)
        {
            return string.Format("{{{0}}}", fieldName.Replace(" ", "").ToUpperInvariant());
        }

        private static string FormatFieldValue(string fieldId, string fieldValue)
        {
            Guid fieldIdGuid = Guid.Parse(fieldId);
            string formattedValue = fieldValue;

            if (WffmConstants.FieldTypes.Date == fieldIdGuid || WffmConstants.FieldTypes.DatePicker == fieldIdGuid)
            {
                formattedValue = fieldValue.ToDateTime().ToShortDateString();
            }
            else if (WffmConstants.FieldTypes.Checkbox == fieldIdGuid)
            {
                formattedValue = fieldValue.ToBoolean().ToString();
            }

            return formattedValue;
        }


        /// <summary>
        /// The to date time.
        /// </summary>
        /// <param name="string"> The string. </param>
        /// <returns> The <see cref="DateTime"/>. </returns>
        private static DateTime ToDateTime(this string @string)
        {
            return DateUtil.IsoDateToDateTime(@string, DateTime.MinValue);
        }

        /// <summary>
        /// The to boolean.
        /// </summary>
        /// <param name="string"> The string. </param>
        /// <returns> The <see cref="bool"/> value. </returns>
        private static bool ToBoolean(this string @string)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(@string, "yes"))
            {
                return true;
            }

            return false;
        }
    }
}
