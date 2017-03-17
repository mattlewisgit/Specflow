using System;
using RestSharp.Deserializers;

namespace Vitality.Website.App.Vacancies.Models
{
    [DeserializeAs(Name = "item")]
    public class Vacancy
    {
        public int Advertid { get; set; }
        public string ClosingDate { get; set; }
        public string Description { get; set; }
        public string EmploymentType { get; set; }
        public string Joblocation { get; set; }
        public string Jobsalary { get; set; }
        public string Jobtitle { get; set; }
        public string Location { get; set; }
        public string Salary { get; set; }
        public string Title { get; set; }
    }
}
