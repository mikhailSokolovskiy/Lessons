using System.Collections.Generic;
using System.Linq;
using AvaloniaApplication1.Models;

namespace AvaloniaApplication1.Service.Realizations;

public class UserService : IUserService
{
    private readonly IStorageService<UserDTO> _userStorage;
    private readonly ILoggerService _logger;
    private IList<UserDTO> _usersList;
    public UserService(IStorageService<UserDTO> userStorage, ILoggerService logger)
    {
        _userStorage = userStorage;
        _logger = logger;
        _usersList = _userStorage.Load();
    }
    public UserDTO GetUserById(int id)
    {
        return _usersList.First(x => x.UserId == id);
    }

    public void EditUser(int id)
    {
        throw new System.NotImplementedException();
    }

    public void RemoveUser(int id)
    {
        throw new System.NotImplementedException();
    }

    public void AddUser(UserDTO user)
    {
        throw new System.NotImplementedException();
    }

    public int GetUsersByCredentials(string username, string password)
    {
        return _usersList.First(x => x.UserName == username && x.Password == password).UserId;
    }
}