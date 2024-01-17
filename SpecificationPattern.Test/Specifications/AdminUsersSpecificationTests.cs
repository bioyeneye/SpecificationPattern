using SpecificationPattern.Example.Entities;
using SpecificationPattern.Example.Specifications.UserSpecifications;

namespace SpecificationPattern.Test.Specifications;

public class AdminUsersSpecificationTests
{
    [Fact]
    public void AdminUsersSpecification_ReturnsOnlyAdminUsers()
    {
        // Arrange
        var users = new[]
        {
            User.CreateInstance("Bolaji", true, false),
            User.CreateInstance("Simi", false, false),
            User.CreateInstance("Eniola", true, true)
        }.AsQueryable();

        var specification = new AdminUsersSpecification(true);

        // Act
        var filteredUsers = SpecificationEvaluator.Query(users, specification);

        // Assert
        Assert.All(filteredUsers, user => Assert.True(user.IsAdmin));
    }
}