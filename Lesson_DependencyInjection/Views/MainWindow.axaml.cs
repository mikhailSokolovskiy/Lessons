using Avalonia.Controls;
using Lesson_DependencyInjection.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Lesson_DependencyInjection.Views;

public partial class MainWindow : Window
{
    public MainWindow(ServiceProvider services)
    {
        InitializeComponent();
        var w = services.GetService<View2>();
        w.Show();
    }
}