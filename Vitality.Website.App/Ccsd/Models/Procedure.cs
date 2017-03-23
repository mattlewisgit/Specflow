namespace Vitality.Website.App.Ccsd.Models
{
    public class Procedure
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string HospitalComplexity { get; set; }
        public decimal? SurgeonFee { get; set; }
        public decimal? AnaesthetistFee { get; set; }
    }
}
