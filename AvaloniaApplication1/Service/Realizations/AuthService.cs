using AvaloniaApplication1.Models;

namespace AvaloniaApplication1.Service.Realizations;

public class AuthService : IAuthService
{
    private readonly IUserService _userService;
    private readonly ILoggerService _logger;

    public AuthService(IUserService userService, ILoggerService logger)
    {
        _userService = userService;
        _logger = logger;
    }

    public UserDTO Authenticate(string username, string password)
    {
        return _userService.GetUsersByCredentials(username, password);
    }
}