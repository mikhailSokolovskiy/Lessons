using AvaloniaApplication1.Models;

namespace AvaloniaApplication1.Service;

public interface IAuthService
{
    UserDTO Authenticate(string username, string password);
}