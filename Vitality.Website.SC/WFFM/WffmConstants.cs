using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitality.Website.SC.WFFM
{
    public static class WffmConstants
    {
        public static class FieldTypes
        {
            public static Guid SingleLineText = new Guid("{6353E864-D3AE-4FF9-88DD-60B0F779A44A}");
            public static Guid MultiLineText = new Guid("{42DB4C51-5A19-4BD3-9632-CB488DD63849}");
            public static Guid Password = new Guid("{1F09D460-200C-4C94-9673-488667FF75D1}");
            public static Guid Email = new Guid("{84ABDA34-F9B1-4D3A-A69B-E28F39697069}");
            public static Guid Telephone = new Guid("{F3A4D32A-0DD1-4613-8B0F-AC4C40E5D583}");
            public static Guid SmsMmsTelephone = new Guid("{5A45591E-2FDC-444F-AB2C-AD814788928F}");
            public static Guid Number = new Guid("{002E5FD5-8B12-4913-BA52-BCC5FEAD2785}");
            public static Guid Date = new Guid("{95DD3FCF-2E03-4064-9968-614D1452F20B}");
            public static Guid DatePicker = new Guid("{09BF916E-79FB-4AE3-B799-659E63C75EA5}");
            public static Guid Checkbox = new Guid("{E079EE36-8620-4D3C-B9BF-010D7A58311F}");
            public static Guid FileUpload = new Guid("{827BDF4A-D886-4B36-9D32-C443EBCA1806}");
            public static Guid DropList = new Guid("{C6D97C39-23B5-4B7E-AFC7-9F41795533C6}");
            public static Guid ListBox = new Guid("{CDD533E2-918A-4BE3-A12F-83A8580363F7}");
            public static Guid RadioList = new Guid("{0FAE4DE2-5C37-45A6-B474-9E3AB95FF452}");
            public static Guid CheckboxList = new Guid("{E994EAE0-EDB0-4D89-B545-FEBEF07DD7CD}");
            public static readonly Guid Captcha = new Guid("{7FB270BE-FEFC-49C3-8CB4-947878C099E5}");
            public static Guid PasswordConfirmation = new Guid("{1AD5CA6E-8A92-49F0-889C-D082F2849FBD}");
            public static Guid CreditCard = new Guid("{CBB8A16B-A726-4445-99E8-4D835AE1F735}");            
        }

        public const string XmlSchemaTemplateId = "{8AE60F3E-4350-4973-BAAB-720EAEB6543D}";
    }
}
