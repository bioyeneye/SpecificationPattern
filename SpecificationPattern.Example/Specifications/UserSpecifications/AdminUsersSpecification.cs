using SpecificationPattern.Abstracts;
using SpecificationPattern.Example.Entities;

namespace SpecificationPattern.Example.Specifications.UserSpecifications;

public class AdminUsersSpecification : Specification<User>
{
    public AdminUsersSpecification(bool isAdmin) : base(
        user => user.IsAdmin == isAdmin)
    {
    }
}