using SpecificationPattern.Abstracts;
using SpecificationPattern.Example.Entities;

namespace SpecificationPattern.Example.Specifications.UserSpecifications;

public class ActiveUsersSpecification : Specification<User>
{
    public ActiveUsersSpecification(bool active) : base(
        user => user.IsActive == active)
    {
    }

    
}