using System.Collections.Generic;

namespace CIBDigitalTechAssessment.ResponseModels.Common
{
    public class PaginationResponseModel<T, TU> : GenericResponseModel<IList<T>, TU> where TU : PaginationMetaResponseModel, new()
    {
        public PaginationResponseModel() : base(new List<T>(), new TU())
        {
        }
    }
}