namespace CIBDigitalTechAssessment.ResponseModels.Common
{
    public class GenericResponseModel<TData, TMeta>  where TMeta : PaginationMetaResponseModel
    {
        public GenericResponseModel(TData data, TMeta meta)
        {
            Data = data;
            Meta = meta;
        }
        public TData Data { get; set; }
        public TMeta Meta { get; set; }
    }
}