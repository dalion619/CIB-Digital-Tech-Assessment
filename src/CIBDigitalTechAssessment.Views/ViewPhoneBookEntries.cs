using System;
using CIBDigitalTechAssessment.Abstractions.Bases;

namespace CIBDigitalTechAssessment.Views
{
    public class ViewPhoneBookEntries:ViewBase
    {
        public string EntryId { get; set; }
        public string PersonId { get; set; }
        public string PersonFirstName { get; set; }
        public string PersonLastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
    }
}