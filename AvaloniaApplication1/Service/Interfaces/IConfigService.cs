using Avalonia.Media;

namespace AvaloniaApplication1.Service;

public interface IConfigService
{
    string GetConnectionString();
    IBrush GetTheme();
}