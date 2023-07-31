using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using EmployeeManager.Models;
using EmployeeManager.ViewModels;

namespace EmployeeManager.Views;

public partial class TopbarView : UserControl
{
    public TopbarView()
    {
        DataContext = new TopbarViewModel();
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private bool _mouseDownForWindowMoving = false;
    private PointerPoint _originalPoint;

    private void InputElement_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        //if (WindowState == WindowState.Maximized || WindowState == WindowState.FullScreen) return;

        _mouseDownForWindowMoving = true;
        _originalPoint = e.GetCurrentPoint(this);
    }
    
    private void InputElement_OnPointerMoved(object? sender, PointerEventArgs e)
    {
        if (!_mouseDownForWindowMoving) return;

        var windowsManager = WindowsManager.AllWindows;
        var currentWindow = windowsManager.FirstOrDefault(x => x.Name == "TheMainWindow");
        
        PointerPoint currentPoint = e.GetCurrentPoint(this);
        currentWindow.Position = new PixelPoint(currentWindow.Position.X + (int)(currentPoint.Position.X - _originalPoint.Position.X),
            currentWindow.Position.Y + (int)(currentPoint.Position.Y - _originalPoint.Position.Y));
    }
    
    private void InputElement_OnPointerReleased(object? sender, PointerReleasedEventArgs e)
    {
        _mouseDownForWindowMoving = false;
    }
    
}
