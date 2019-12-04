using System.ComponentModel.DataAnnotations;
using CIBDigitalTechAssessment.Abstractions.Bases;

namespace CIBDigitalTechAssessment.Entities
{
    public class PhoneBookEntry:EntityBase
    {
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public virtual Person Person { get; set; }
    }
}