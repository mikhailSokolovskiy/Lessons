namespace AvaloniaApplication1.Models;

public class UserDTO
{
    public int UserId {get;}
    public string UserName { get; }
    public string Password { get; }
    public string Email { get; }
    public UserRoles Role { get; }
}

public enum UserRoles
{
    Manager,
    Admin
}