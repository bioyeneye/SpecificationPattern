namespace SpecificationPattern.Example.Entities;

public class User
{
    public long Id { get; set; }
    public string Name { get; private set; }
    public bool IsAdmin { get; private set; }
    public bool IsActive { get; private set; }

    public static User CreateInstance(string name, bool active, bool isAdmin)
    {
        return new User
        {
            Name = name,
            IsActive = active,
            IsAdmin = isAdmin
        };
    }
}