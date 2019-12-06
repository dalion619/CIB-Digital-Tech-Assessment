using System.Linq;
using System.Threading.Tasks;
using CIBDigitalTechAssessment.RequestModels.PhoneBook;
using CIBDigitalTechAssessment.Utilities;
using CIBDigitalTechAssessment.Utilities.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CIBDigitalTechAssessment.Web.Pages.PhoneBook
{
    public class AddPerson : PageModel
    {
        [BindProperty]
        public AddPhoneBookPersonRequestModel AddPhoneBookPerson { get; set; }
        
        public async Task<IActionResult> OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var phoneNumber = AddPhoneBookPerson.PhoneNumber.RemoveNonDigits();
            if (phoneNumber.Length != 10)
            {
                return Page();
            }
            var firstName = AddPhoneBookPerson.FirstName.Normalise().FirstCharToUpper();
            var lastName = AddPhoneBookPerson.LastName.Normalise().FirstCharToUpper();
            var description = AddPhoneBookPerson.Description.Normalise().FirstCharToUpper();
            
            
            return Redirect($"~/?page={AlphaPagination.LettersToPageNumber(lastName.Substring(0,2))}");  
        }
    }
}