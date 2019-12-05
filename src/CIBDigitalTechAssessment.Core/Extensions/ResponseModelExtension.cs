using CIBDigitalTechAssessment.ResponseModels.PhoneBook;
using CIBDigitalTechAssessment.ResponseModels.PhoneBookEntry;
using CIBDigitalTechAssessment.Views;

namespace CIBDigitalTechAssessment.Core.Extensions
{
    public static partial class ResponseModelExtension
    {
        public static PhoneBookResponseModel ToPhoneBookResponseModel(this ViewPhoneBookEntries phoneBookEntry)
        {
            return new PhoneBookResponseModel()
                   {
                       Id = phoneBookEntry.PersonId,
                       FirstName = phoneBookEntry.PersonFirstName,
                       LastName = phoneBookEntry.PersonLastName
                   };
        }
        
        public static PhoneBookEntryResponseModel ToPhoneBookEntryResponseModel(this ViewPhoneBookEntries phoneBookEntry)
        {
           return new PhoneBookEntryResponseModel()
                        {
                            Id = phoneBookEntry.EntryId,
                            Description = phoneBookEntry.Description,
                            PhoneNumber = phoneBookEntry.PhoneNumber
                        };
        }
    }
}