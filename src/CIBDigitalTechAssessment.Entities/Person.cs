using System.Collections.Generic;
using CIBDigitalTechAssessment.Abstractions.Bases;

namespace CIBDigitalTechAssessment.Entities
{
    public class Person:EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual List<PhoneBookEntry> PhoneBookEntries { get; set; }
    }
}