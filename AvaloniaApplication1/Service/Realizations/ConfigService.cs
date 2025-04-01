using Avalonia.Media;

namespace AvaloniaApplication1.Service.Realizations;

public class ConfigService : IConfigService
{
    private readonly ILoggerService _logger;

    public ConfigService(ILoggerService logger)
    {
        _logger = logger;
    }
    public string GetConnectionString()
    {
        return "Data Source=tasks4.db";
    }

    public IBrush GetTheme()
    {
        return new SolidColorBrush(Colors.Black);
    }
}

