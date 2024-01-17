using Microsoft.EntityFrameworkCore;
using SpecificationPattern.Abstracts;

namespace SpecificationPattern;

public class SpecificationEvaluator
{
    public static IQueryable<TEntity> Query<TEntity>(
        IQueryable<TEntity> inputQueryable,
        Specification<TEntity> specification) where TEntity : class
    {
        var queryable = inputQueryable;
        if (specification.Criteria is not null) queryable = queryable.Where(specification.Criteria);

        specification.IncludeExpressions.Aggregate(
            queryable,
            (current, includeExpression) => current.Include(includeExpression));

        if (specification.OrderByExpression is not null)
            queryable = queryable.OrderBy(specification.OrderByExpression);
        else if (specification.OrderByDescendingExpression is not null)
            queryable = queryable.OrderByDescending(specification.OrderByDescendingExpression);

        return queryable;
    }
}