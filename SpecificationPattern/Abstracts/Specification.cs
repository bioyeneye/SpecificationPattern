using System.Linq.Expressions;
using SpecificationPattern.Extensions;

namespace SpecificationPattern.Abstracts;

public abstract class Specification<TEntity> : ISpecification<TEntity> where TEntity : class
{
    protected Specification(Expression<Func<TEntity, bool>>? criteria)
    {
        Criteria = criteria;
    }

    public virtual Expression<Func<TEntity, bool>>? Criteria { get; }
    public virtual List<Expression<Func<TEntity, object>>> IncludeExpressions { get; } = [];
    public virtual Expression<Func<TEntity, object>>? OrderByExpression { get; private set; }
    public virtual Expression<Func<TEntity, object>>? OrderByDescendingExpression { get; private set; }

    protected void AddInclude(Expression<Func<TEntity, object>> includeExpression)
    {
        IncludeExpressions.Add(includeExpression);
    }

    protected void AddOrderBy(Expression<Func<TEntity, object>> orderByExpression)
    {
        OrderByExpression = orderByExpression;
    }

    protected void AddOrderByDescending(Expression<Func<TEntity, object>> orderByExpression)
    {
        OrderByDescendingExpression = orderByExpression;
    }
    
    public Specification<TEntity> And(Specification<TEntity> specification)
    {
        return new AndSpecification<TEntity>(this, specification);
    }
    
    public Specification<TEntity> Or(Specification<TEntity> specification)
    {
        return new OrSpecification<TEntity>(this, specification);
    }
    
    public Specification<TEntity> Not()
    {
        return new NotSpecification<TEntity>(this);
    }
    
    private sealed class AndSpecification<TEntity> : Specification<TEntity> where TEntity : class
    {
        public AndSpecification(ISpecification<TEntity> left, ISpecification<TEntity> right)
            : base(left.Criteria!.And(right.Criteria!))
        {
            ArgumentNullException.ThrowIfNull(left);
            ArgumentNullException.ThrowIfNull(right);
            IncludeExpressions.AddRange(left.IncludeExpressions);
            IncludeExpressions.AddRange(right.IncludeExpressions);
        }
    }
    
    private sealed class OrSpecification<TEntity> : Specification<TEntity> where TEntity : class
    {
        public OrSpecification(ISpecification<TEntity> left, ISpecification<TEntity> right)
            : base(left.Criteria!.Or(right.Criteria!))
        {
            ArgumentNullException.ThrowIfNull(left);
            ArgumentNullException.ThrowIfNull(right);
            IncludeExpressions.AddRange(left.IncludeExpressions);
            IncludeExpressions.AddRange(right.IncludeExpressions);
        }
    }
    
    private sealed class NotSpecification<TEntity> : Specification<TEntity> where TEntity : class
    {
        public NotSpecification(ISpecification<TEntity> specification)
            : base(specification.Criteria!.Not())
        {
            ArgumentNullException.ThrowIfNull(specification);
            IncludeExpressions.AddRange(specification.IncludeExpressions);
        }
    }
}