using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CIBDigitalTechAssessment.Abstractions.Interfaces
{
    public interface IEntitySpecification<TEntity>
    {
        Expression<Func<TEntity, bool>> Criteria { get; }
        List<Expression<Func<TEntity, object>>> Includes { get; }
        List<string> IncludeStrings { get; }
        Expression<Func<TEntity, object>> OrderBy { get; }
        Expression<Func<TEntity, object>> OrderByDescending { get; }

        int Take { get; }
        int Skip { get; }
        bool IsPagingEnabled { get; }

        void ApplyPaging(int skip, int take);

        void ApplyOrderBy(Expression<Func<TEntity, object>> orderByExpression);

        void ApplyOrderByDescending(Expression<Func<TEntity, object>> orderByDescendingExpression);
    }
}