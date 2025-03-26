using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AvaloniaApplication1.DB;
using AvaloniaApplication1.Models;
using AvaloniaApplication1.Service;
using AvaloniaApplication1.Service.Realizations;
using AvaloniaApplication1.ViewModels;
using AvaloniaApplication1.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AvaloniaApplication1;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    /*
     * ILoggerService, IUserService, IAuthService, IConfigService
     */

    public override void OnFrameworkInitializationCompleted()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddSingleton<ITaskService, TaskService>()
            .AddSingleton<IStorageService<TaskDTO>, TaskStorageService>()
            .AddSingleton<IStorageService<UserDTO>, UserStorageService>()
            .AddSingleton<IAuthService, AuthService>()
            .AddSingleton<IConfigService, ConfigService>()
            .AddSingleton<IUserService, UserService>()
            .AddSingleton<ILoggerService, LoggerService>()
            .AddDbContext<ApplicationContext>();

        
        serviceCollection.AddSingleton<MainWindowViewModel>();

        var serviceProvider = serviceCollection.BuildServiceProvider();
        var vm = serviceProvider.GetRequiredService<MainWindowViewModel>();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = vm
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}