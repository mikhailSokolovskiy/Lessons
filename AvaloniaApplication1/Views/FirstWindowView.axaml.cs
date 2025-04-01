using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaApplication1.ViewModels;

namespace AvaloniaApplication1.Views;

public partial class FirstWindowView : Window
{
    public FirstWindowView(FirstViewModel vm)
    {
        InitializeComponent();
        DataContext = vm;
    }
}