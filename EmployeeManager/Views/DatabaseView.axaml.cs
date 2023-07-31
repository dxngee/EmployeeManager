using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using EmployeeManager.ViewModels;

namespace EmployeeManager.Views;

public partial class DatabaseView : UserControl
{
    public DatabaseView()
    {
        DataContext = new DatabaseViewModel();
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}