
using CIBDigitalTechAssessment.Utilities.Extensions;

namespace CIBDigitalTechAssessment.ViewModels.BogusData
{
    public class BogusPersonViewModel
    {
        private string _phoneNumber;
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string PhoneNumber
        {
            get => _phoneNumber.RemoveNonDigits().Substring(0,10);
            set => _phoneNumber = value;
        }

        public string FullName
        {
            get => $"{FirstName} {LastName}";
        }
    }
}