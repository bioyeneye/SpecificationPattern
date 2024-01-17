using SpecificationPattern.Example.Entities;
using SpecificationPattern.Example.Specifications.UserSpecifications;

namespace SpecificationPattern.Test.Specifications;

public class ActiveUsersSpecificationTests
{
    [Fact]
    public void ActiveUsersSpecification_ReturnsOnlyActiveUsers()
    {
        // Arrange
        var users = new[]
        {
            User.CreateInstance("Bolaji", true, false),
            User.CreateInstance("Simi", false, false),
            User.CreateInstance("Eniola", true, false)
        }.AsQueryable();

        var specification = new ActiveUsersSpecification(true);

        // Act
        var filteredUsers = SpecificationEvaluator.Query(users, specification);

        // Assert
        Assert.All(filteredUsers, user => Assert.True(user.IsActive));
    }
}