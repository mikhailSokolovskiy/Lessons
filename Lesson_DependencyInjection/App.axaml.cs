using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Lesson_DependencyInjection.Services;
using Lesson_DependencyInjection.ViewModels;
using Lesson_DependencyInjection.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Lesson_DependencyInjection;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var serviceCollection = new ServiceCollection();
        
        serviceCollection.AddSingleton<ILogger, ConsoleLogger>();
        serviceCollection.AddScoped<IReader, TextFileReader>();
        serviceCollection.AddTransient<IRepository, FileRepository>();
        
        serviceCollection.AddSingleton<MainWindowViewModel>();
        serviceCollection.AddSingleton<ViewModel2>();
        serviceCollection.AddSingleton<View2>();
        
        var services = serviceCollection.BuildServiceProvider();
        
        var vm = services.GetService<MainWindowViewModel>();
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow(services)
            {
                DataContext = vm,
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}