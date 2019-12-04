using System.Collections.Generic;
using System.Threading.Tasks;

namespace CIBDigitalTechAssessment.Abstractions.Interfaces
{
    public interface IViewRepository<TView> where TView : IViewBase
    {
        
        Task<TView> GetAsync(IViewSpecification<TView> spec); 
        Task<IReadOnlyList<TView>> ListAsync();
        Task<IReadOnlyList<TView>> ListAsync(IViewSpecification<TView> spec); 
        Task<int> CountAsync();
        Task<int> CountAsync(IViewSpecification<TView> spec);
    }
}