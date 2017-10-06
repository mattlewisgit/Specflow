using System.ComponentModel.DataAnnotations;

namespace Vitality.Website.Areas.Presales.Models
{
    public class CallBackData
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string CallBackTime { get; set; }
        public string ReferenceId { get; set; }
    }
}
