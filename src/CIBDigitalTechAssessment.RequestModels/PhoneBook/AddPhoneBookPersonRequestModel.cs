using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CIBDigitalTechAssessment.RequestModels.PhoneBook
{
    public class AddPhoneBookPersonRequestModel
    {
        [DisplayName("Phone Number")]
        [Required]
        [StringLength(maximumLength: 10, MinimumLength = 10)]
        [RegularExpression(pattern: @"^[0-9]+$")]
        public string PhoneNumber { get; set; }

        [DisplayName("First Name")] [Required] public string FirstName { get; set; }

        [DisplayName("Last Name")] [Required] public string LastName { get; set; }
        public string Description { get; set; }
    }
}