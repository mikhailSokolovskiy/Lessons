using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Lesson_DependencyInjection.ViewModels;

namespace Lesson_DependencyInjection.Views;

public partial class View2 : Window
{
    public View2(ViewModel2 vm)
    {
        InitializeComponent();
        DataContext = vm;
    }
}