using System.Collections.Generic;
using System.Threading.Tasks;

namespace CIBDigitalTechAssessment.Abstractions.Interfaces
{
    public interface IEntityRepository<TEntity> where TEntity : IEntityBase
    {
        Task<bool> Exists(string id);

        Task<bool> Exists(IEntitySpecification<TEntity> spec);

        Task<TEntity> GetByIdAsync(string id);

        Task<TEntity> GetAsync(IEntitySpecification<TEntity> spec); 
       
        Task<IReadOnlyList<TEntity>> ListAllAsync();
        Task<IReadOnlyList<string>> ListAllIdsAsync();

        Task<IReadOnlyList<TEntity>> ListAsync(IEntitySpecification<TEntity> spec); 
        Task<IReadOnlyList<string>> ListIdsAsync(IEntitySpecification<TEntity> spec); 
       
        Task<TEntity> AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);

        Task<int> CountAsync();

        Task<int> CountAsync(IEntitySpecification<TEntity> spec);
    }
}