using System.Collections.Generic;

namespace CIBDigitalTechAssessment.ResponseModels.Common
{
    public class AlphaPaginationMetaResponseModel:PaginationMetaResponseModel
    {
        public AlphaPaginationMetaResponseModel()
        {
            
        }
        public AlphaPaginationMetaResponseModel(List<int> groupings, List<int> pageListings)
        {
            this.PageSize = 10;
            this.PageNumber = 100;
            this.TotalItems = 0;
            this.Groupings = groupings;
            this.PageListings = pageListings;
        }

        private List<int> Groupings { get; set; }
        public new List<int> PageListings{ get; private set; }
        
        public new List<int> PrevPageGroupings => Groupings.FindAll(w => w <= PageNumber);
        public new List<int> NextPageGroupings => Groupings.FindAll(w => w > PageNumber);
    }
}