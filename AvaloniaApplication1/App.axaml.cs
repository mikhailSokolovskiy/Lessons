using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AvaloniaApplication1.DB;
using AvaloniaApplication1.Mediators;
using AvaloniaApplication1.Models;
using AvaloniaApplication1.Repository;
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
            .AddSingleton<IRepository<TaskDTO>, TaskRepository>()
            .AddSingleton<IRepository<UserDTO>, UserRepository>()
            .AddSingleton<IAuthService, AuthService>()
            .AddSingleton<IConfigService, ConfigService>()
            .AddSingleton<IUserService, UserService>()
            .AddSingleton<ILoggerService, LoggerService>()
            .AddSingleton<Mediator>()
            .AddSingleton<FirstViewModel>()
            .AddSingleton<SecondViewModel>()
            .AddDbContext<ApplicationContext>();

        
        serviceCollection.AddSingleton<MainWindowViewModel>();

        var serviceProvider = serviceCollection.BuildServiceProvider();
        var vm = serviceProvider.GetRequiredService<MainWindowViewModel>();
        var vm1 = serviceProvider.GetRequiredService<FirstViewModel>();
        var vm2 = serviceProvider.GetRequiredService<SecondViewModel>();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = vm
            };
            new FirstWindowView(vm1).Show();
            new SecondWindowView(vm2).Show();
        }

        base.OnFrameworkInitializationCompleted();
    }
}