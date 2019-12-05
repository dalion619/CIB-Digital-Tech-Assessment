using System.Collections.Generic;

namespace CIBDigitalTechAssessment.ResponseModels.Common
{
    public class NumericPaginationMetaResponseModel:PaginationMetaResponseModel
    {
            public NumericPaginationMetaResponseModel()
        {
            this.PageSize = 10;
            this.PageNumber = 1;
            this.TotalItems = 0; 
        }

        private List<int> Groupings
        {
            get
            {
                int bases = TotalPages / 10;
                var temp = new List<int>();
                for (int i = 1; i <= bases; i++)
                {
                    var calc = i * 10;
                    if (calc != TotalPages)
                    {
                        temp.Add(calc);
                    }
                }

                return temp;
            }
        }

        public new List<int> PageListings
        {
            get
            {
                int currentBase = PageNumber /10;
                var max = 9;
                if (TotalPages <=9)
                {
                    max = TotalPages-1;
                }
                var temp = new List<int>();
                if (currentBase == 0)
                {
                   
                    for (int i = 2; i <= max; i++)
                    {
                        temp.Add(i);
                    }
                }
                else
                {
                    var calc = currentBase * 10;
                    if ((TotalPages - calc)<=9)
                    {
                        max = (TotalPages - calc)-1;
                    }
                    for (int i = 1; i <= max; i++)
                    {
                        temp.Add((calc+i));
                    }
                }
                return temp;
            }
        }

        public new List<int> PrevPageGroupings => Groupings.FindAll(w => w <= PageNumber);
        public new List<int> NextPageGroupings => Groupings.FindAll(w => w > PageNumber);
        public new int PageNumber { get; set; }
        public new int PageSize { get; set; }

        public new int TotalPages
        {
            get
            {
                return TotalItems / PageSize;
            }
        }

        public int TotalItems { get; set; }
      
         
    }
}