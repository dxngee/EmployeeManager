using System;
using System.Linq;
using System.Net.Mime;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using EmployeeManager.Models;
using EmployeeManager.ViewModels;
using Fizzler;
using Splat;

namespace EmployeeManager.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = ViewModelManager.ViewModelList.FirstOrDefault(x => x.Key == "TopbarViewModel").Value;
        RecoursesManager.WindowList.Add(this);
    }
    
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}