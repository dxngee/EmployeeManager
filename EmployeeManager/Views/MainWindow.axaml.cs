using System;
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
        DataContext = new MainWindowViewModel();
        InitializeComponent();
        WindowsManager.WindowList.Add(this);
    }
    
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
    
    private void MinimiseButton_OnClick(object? sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }
    private void ExpandButton_OnClick(object? sender, RoutedEventArgs e)
    {
        if (WindowState == WindowState.Normal)
        {
            WindowState = WindowState.FullScreen;
        }
        else
        {
            WindowState = WindowState.Normal;
        }
        //DisExpandButton.IsVisible = WindowState == WindowState.FullScreen;
        //ExpandButton.IsVisible = !(WindowState == WindowState.FullScreen);
    }

    private void CloseButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
    
}