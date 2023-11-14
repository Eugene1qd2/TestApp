using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace TestApp.Models
{
    public class СontactViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Name")]
        public string CName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\+?\d{1,4}?[-.\s]?\(?\d{1,3}?\)?[-.\s]?\d{1,4}[-.\s]?\d{1,4}[-.\s]?\d{1,9}$", ErrorMessage = "The PhoneNumber field is not a valid phone number")]
        [DisplayName("Mobile phone")]
        public string CMobilePhone { get; set; }
        [DisplayName("Job title")]
        public string CJobTitle { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Birth date")]
        public DateTime CBirthDate { get; set; }
    }
}
