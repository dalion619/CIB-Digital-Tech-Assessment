using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CIBDigitalTechAssessment.Abstractions.Interfaces
{
    public interface IViewSpecification<TView>
    {
        Expression<Func<TView, bool>> Criteria { get; }
        List<Expression<Func<TView, object>>> Includes { get; }
        List<string> IncludeStrings { get; }
        Expression<Func<TView, object>> OrderBy { get; }
        Expression<Func<TView, object>> OrderByDescending { get; }

        int Take { get; }
        int Skip { get; }
        bool IsPagingEnabled { get; }

        void ApplyPaging(int skip, int take);

        void ApplyOrderBy(Expression<Func<TView, object>> orderByExpression);

        void ApplyOrderByDescending(Expression<Func<TView, object>> orderByDescendingExpression);
    }
}