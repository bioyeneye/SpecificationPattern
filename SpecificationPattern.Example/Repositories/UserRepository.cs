using SpecificationPattern.Abstracts;
using SpecificationPattern.Example.Entities;

namespace SpecificationPattern.Example.Repositories;

public class UserRepository : ContextSpecification<User>
{
    private readonly IQueryable<User> _users;

    public UserRepository(IQueryable<User> users)
    {
        _users = users;
    }

    protected override IQueryable<User?> ApplySpecification(Specification<User> specification)
    {
        return SpecificationEvaluator.Query(_users, specification);
    }
}