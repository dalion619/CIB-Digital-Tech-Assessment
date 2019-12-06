using System.Threading.Tasks;
using CIBDigitalTechAssessment.ResponseModels.Common;
using CIBDigitalTechAssessment.ResponseModels.PhoneBook;

namespace CIBDigitalTechAssessment.Core.Interfaces
{
    public interface IPhoneBookService
    {
        Task<PaginationResponseModel<PhoneBookResponseModel,AlphaPaginationMetaResponseModel>> ListPhoneBook(int currentPageNumber);
        Task AddPerson(string firstName, string lastName, string phoneNumber, string description);
        Task<PaginationResponseModel<PhoneBookResponseModel, NumericPaginationMetaResponseModel>> SearchPhoneBook(string term);
    }
}