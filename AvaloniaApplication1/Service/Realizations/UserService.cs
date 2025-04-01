using System.Collections.Generic;
using System.Linq;
using AvaloniaApplication1.Models;
using AvaloniaApplication1.Repository;

namespace AvaloniaApplication1.Service.Realizations;

public class UserService : IUserService
{
    private readonly IRepository<UserDTO> _repository;
    private readonly ILoggerService _logger;

    public UserService(IRepository<UserDTO> repository, ILoggerService logger)
    {
        _repository = repository;
        _logger = logger;
    }

    // public UserDTO GetUserById(int id)
    // {
    //     return _repository.GetById(id);
    // }

    public void EditUser(UserDTO userDto)
    {
        _repository.Update(userDto);
    }

    public void DeleteUser(UserDTO userDto)
    {
        _repository.Delete(userDto);
    }

    public void AddUser(UserDTO user)
    {
        _repository.Add(user);
    }

    public UserDTO GetUsersByCredentials(string username, string password)
    {
        var allUsers = _repository.GetAll();
        return allUsers.First(x => x.UserName == username && x.Password == password);
    }

    public IList<UserDTO> GetAllUsers()
    {
        return _repository.GetAll();
    }
}