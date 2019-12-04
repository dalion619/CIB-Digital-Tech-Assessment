using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIBDigitalTechAssessment.Abstractions.Bases;
using CIBDigitalTechAssessment.Abstractions.Interfaces;
using CIBDigitalTechAssessment.Abstractions.Specifications;
using Microsoft.EntityFrameworkCore;

namespace CIBDigitalTechAssessment.EntityFramework
{
    public class ViewRepository<TView> : IViewRepository<TView> where TView : ViewBase
    {
        protected readonly DbContext _dbContext;

        public ViewRepository(PhoneBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual Task<TView> GetAsync(IViewSpecification<TView> spec)
        {
            return ApplySpecification(spec).FirstOrDefaultAsync();
        } 
        
        public virtual async Task<IReadOnlyList<TView>> ListAsync()
        {
            return await _dbContext.Set<TView>().ToListAsync();
        }

        public virtual async Task<IReadOnlyList<TView>> ListAsync(IViewSpecification<TView> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public virtual Task<int> CountAsync()
        {
            return _dbContext.Set<TView>().CountAsync();
        }

        public virtual Task<int> CountAsync(IViewSpecification<TView> spec)
        {
            return ApplySpecification(spec).CountAsync();
        }

        private IQueryable<TView> ApplySpecification(IViewSpecification<TView> spec)
        {
            return ViewSpecificationEvaluator<TView>.GetQuery(_dbContext.Set<TView>().AsQueryable(), spec);
        }
    }
}