using System.Collections.Generic;
using CIBDigitalTechAssessment.ResponseModels.PhoneBookEntry;

namespace CIBDigitalTechAssessment.ResponseModels.PhoneBook
{
    public class PhoneBookResponseModel
    {
        public PhoneBookResponseModel()
        {
            this.Entries = new List<PhoneBookEntryResponseModel>();
        }
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public List<PhoneBookEntryResponseModel> Entries { get; set; }
    }
}