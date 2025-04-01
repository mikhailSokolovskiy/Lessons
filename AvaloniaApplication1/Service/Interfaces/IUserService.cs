using System.Collections.Generic;
using AvaloniaApplication1.Models;

namespace AvaloniaApplication1.Service;

public interface IUserService
{
    void EditUser(UserDTO userDTO);
    void DeleteUser(UserDTO userDTO);
    void AddUser(UserDTO user);
    UserDTO GetUsersByCredentials(string username, string password);
    IList<UserDTO> GetAllUsers();
}