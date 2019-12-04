using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CIBDigitalTechAssessment.Abstractions.Interfaces;

namespace CIBDigitalTechAssessment.Abstractions.Bases
{
    public abstract class ViewSpecificationBase<TView> : IViewSpecification<TView>
    {
        protected ViewSpecificationBase(Expression<Func<TView, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<TView, bool>> Criteria { get; }
        public List<Expression<Func<TView, object>>> Includes { get; } = new List<Expression<Func<TView, object>>>();
        public List<string> IncludeStrings { get; } = new List<string>();
        public Expression<Func<TView, object>> OrderBy { get; private set; }
        public Expression<Func<TView, object>> OrderByDescending { get; private set; }

        public int Take { get; private set; }
        public int Skip { get; private set; }
        public bool IsPagingEnabled { get; private set; } = false;

        public virtual void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }

        public virtual void ApplyOrderBy(Expression<Func<TView, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        public virtual void ApplyOrderByDescending(Expression<Func<TView, object>> orderByDescendingExpression)
        {
            OrderByDescending = orderByDescendingExpression;
        }

        protected virtual void AddInclude(Expression<Func<TView, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected virtual void AddInclude(string includeString)
        {
            IncludeStrings.Add(includeString);
        }

    }
}