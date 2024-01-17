using SpecificationPattern.Abstracts;

namespace SpecificationPattern;

public abstract class ContextSpecification<TEntity> where TEntity : class
{
    protected abstract IQueryable<TEntity?> ApplySpecification(Specification<TEntity> specification);
}