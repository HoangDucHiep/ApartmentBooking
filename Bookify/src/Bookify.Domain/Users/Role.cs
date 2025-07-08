namespace Bookify.Domain.Users;

public sealed class Role
{
    public static readonly Role Registered = new(1, "Registered");
    public Role(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<User> Users { get; init; } = new List<User>();
}