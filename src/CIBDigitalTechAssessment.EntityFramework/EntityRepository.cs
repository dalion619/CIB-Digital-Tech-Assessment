using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIBDigitalTechAssessment.Abstractions.Bases;
using CIBDigitalTechAssessment.Abstractions.Interfaces;
using CIBDigitalTechAssessment.Abstractions.Specifications;
using Microsoft.EntityFrameworkCore;

namespace CIBDigitalTechAssessment.EntityFramework
{
    public class EntityRepository<TEntity> : IEntityRepository<TEntity> where TEntity : EntityBase
    {
        protected readonly DbContext _dbContext;

        public EntityRepository(PhoneBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual Task<bool> Exists(string id)
        {
            return _dbContext.Set<TEntity>().AnyAsync(a => string.Equals(a.Id.ToLower(), id.ToLower()));
        }

        public virtual Task<bool> Exists(IEntitySpecification<TEntity> spec)
        {
            return ApplySpecification(spec).AnyAsync();
        }

        public virtual Task<TEntity> GetByIdAsync(string id)
        {
            return _dbContext.Set<TEntity>().FindAsync(id).AsTask();
        }

        public virtual Task<TEntity> GetAsync(IEntitySpecification<TEntity> spec)
        {
            return ApplySpecification(spec).FirstOrDefaultAsync();
        } 

        public virtual async Task<IReadOnlyList<TEntity>> ListAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }
        
        public virtual async Task<IReadOnlyList<string>> ListAllIdsAsync()
        {
            return await _dbContext.Set<TEntity>().Select(s=>s.Id).ToListAsync();
        }

        public virtual async Task<IReadOnlyList<TEntity>> ListAsync(IEntitySpecification<TEntity> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        } 
        public virtual async Task<IReadOnlyList<string>> ListIdsAsync(IEntitySpecification<TEntity> spec)
        {
            return await ApplySpecification(spec).Select(s=>s.Id).ToListAsync();
        } 


        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public virtual Task UpdateAsync(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return _dbContext.SaveChangesAsync();
        }

        public virtual Task DeleteAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            return _dbContext.SaveChangesAsync();
        }

        public virtual Task<int> CountAsync()
        {
            return _dbContext.Set<TEntity>().CountAsync();
        }

        public virtual Task<int> CountAsync(IEntitySpecification<TEntity> spec)
        {
            return ApplySpecification(spec).CountAsync();
        }

        private IQueryable<TEntity> ApplySpecification(IEntitySpecification<TEntity> spec)
        {
            return EntitySpecificationEvaluator<TEntity>.GetQuery(_dbContext.Set<TEntity>().AsQueryable(), spec);
        }
    }
}