using System.Threading.Tasks;
using CIBDigitalTechAssessment.ResponseModels.Common;
using CIBDigitalTechAssessment.ResponseModels.PhoneBook;

namespace CIBDigitalTechAssessment.Core.Interfaces
{
    public interface IPhoneBookService
    {
        Task<PaginationResponseModel<PhoneBookResponseModel,AlphaPaginationMetaResponseModel>> ListPhoneBook(int currentPageNumber);
    }
}