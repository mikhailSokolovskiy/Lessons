using Lesson_DependencyInjection.Services;

namespace Lesson_DependencyInjection.ViewModels;

public class ViewModel2 : ViewModelBase
{
    public ViewModel2(ILogger logger)
    {
        Logger = logger;
    }

    public ILogger Logger { get; set; }
}