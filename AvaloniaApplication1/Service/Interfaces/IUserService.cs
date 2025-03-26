using AvaloniaApplication1.Models;

namespace AvaloniaApplication1.Service;

public interface IUserService
{
    UserDTO GetUserById(int id);
    void EditUser(int id);
    void RemoveUser(int id);
    void AddUser(UserDTO user);
    int GetUsersByCredentials(string username, string password);
}