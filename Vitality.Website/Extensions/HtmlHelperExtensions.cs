namespace Vitality.Website.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Web.Mvc;

    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString CheckBoxList
            (this HtmlHelper helper, string name, IEnumerable<SelectListItem> items)
        {
            return InputList("checkbox", name, items);
        }

        public static MvcHtmlString RadioButtonList
            (this HtmlHelper helper, string name, IEnumerable<SelectListItem> items)
        {
            return InputList("radio", name, items);
        }

        private static MvcHtmlString InputList
            (string inputType, string name, IEnumerable<SelectListItem> items)
        {
            var output = new StringBuilder("<fieldset>");

            foreach (var item in items)
            {
                output.Append("<div class=\"form__field__input form__field__input--checkbox\">");

                var inputLabel = string.Format(
                    "<input type=\"{0}\" name=\"{1}\" value=\"{2}\" {3} id=\"{4}\" /><label for=\"{4}\">{5}</label>",
                    inputType, name, item.Value, (item.Selected) ? "checked" : string.Empty, Guid.NewGuid(), item.Text);

                output.Append(inputLabel).Append("</div>");
            }

            output.Append("</fieldset>");
            return new MvcHtmlString(output.ToString());
        }

        public static MvcHtmlString WffmHeader(this HtmlHelper helper, string headerText, string tag)
        {
            return new MvcHtmlString(string.Format(@"<{0}>{1}</{0}>", tag, headerText));
        }
    }
}
