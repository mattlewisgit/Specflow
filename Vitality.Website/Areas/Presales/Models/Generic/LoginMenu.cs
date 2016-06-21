using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Fields;
using Vitality.Website.Areas.Global.Models;

namespace Vitality.Website.Areas.Presales.Models.Generic
{
    public class LoginMenu : SitecoreItem
    {
        public Link MemberLink { get; set; }
        public Link LifeAdviserLink { get; set; }
        public Link HealthAdviserLink { get; set; }
        public Link EmployerLink { get; set; }
        public Link HealthcarePractitionerLink { get; set; }
    }
}
