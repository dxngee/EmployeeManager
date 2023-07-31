using System;
using System.Threading;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using EmployeeManager.ViewModels;
using EmployeeManager.Views;
using Splat;

namespace EmployeeManager;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow();
            {
                DataContext = new MainWindowViewModel();
            }
        }

        base.OnFrameworkInitializationCompleted();
    }
}