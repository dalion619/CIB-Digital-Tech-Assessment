using System.Threading.Tasks;
using CIBDigitalTechAssessment.Core.Interfaces;
using CIBDigitalTechAssessment.ResponseModels.Common;
using CIBDigitalTechAssessment.ResponseModels.PhoneBook;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CIBDigitalTechAssessment.Web.Pages.PhoneBook
{
    public class List : PageModel
    {
        private readonly IPhoneBookService _phoneBookService;
        public List(IPhoneBookService phoneBookService)
        {
            _phoneBookService = phoneBookService;
        }
        
        [BindProperty]
        public PaginationResponseModel<PhoneBookResponseModel,AlphaPaginationMetaResponseModel> PaginatedPhoneBook { get; set; }
        
        public async Task<IActionResult> OnGet([FromQuery] int page = 100)
        {
           

            PaginatedPhoneBook = await _phoneBookService.ListPhoneBook(page);
           
            return Page();
        }
    }
}