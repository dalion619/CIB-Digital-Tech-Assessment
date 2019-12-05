using System.Collections.Generic;

namespace CIBDigitalTechAssessment.ResponseModels.Common
{
    public abstract class PaginationMetaResponseModel
    {
        public List<int> PageListings { get; set; }

        public List<int> PrevPageGroupings { get; set; }
        public List<int> NextPageGroupings { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public int TotalPages { get; private set; }

        public int TotalItems { get; set; }

        public bool HasNextPage
        {
            get { return PageNumber != TotalPages; }
        }

        public bool HasPrevPage
        {
            get { return PageNumber != 1; }
        }
    }
}