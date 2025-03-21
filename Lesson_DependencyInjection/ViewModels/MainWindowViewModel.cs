using Lesson_DependencyInjection.Services;

namespace Lesson_DependencyInjection.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public string Greeting { get; } = "Welcome to Avalonia!";
    
    public ILogger Logger { get; }

    public MainWindowViewModel(ILogger logger, IReader reader, IRepository repository)
    {
        Logger = logger;
        Reader = reader;
        Repository = repository;
    }

    public IRepository Repository { get; set; }

    public IReader Reader { get; set; }

    void LOG()
    {
        // var log = new ConsoleLogger();
        // log.Log("privet");
        Logger.Log("privet");
    }
}