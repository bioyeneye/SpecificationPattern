using SpecificationPattern.Example.Entities;
using SpecificationPattern.Example.Specifications.UserSpecifications;

namespace SpecificationPattern.Test.Specifications;

public class ActiveAdminUsersSpecificationTests
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

        var activeUsersSpecification = new ActiveUsersSpecification(true)
            .And(new AdminUsersSpecification(true).Not());

        // Act
        var filteredUsers = SpecificationEvaluator.Query(users, activeUsersSpecification);

        // Assert
        Assert.Equal(1, filteredUsers.Count());
    }
}