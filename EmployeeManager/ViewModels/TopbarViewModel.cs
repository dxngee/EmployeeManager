using System;
using System.Linq;
using System.Reactive;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using EmployeeManager.Models;
using ReactiveUI;

namespace EmployeeManager.ViewModels;

public class TopbarViewModel : ViewModelBase
{
    public ReactiveCommand<Unit, Unit> CloseButtonPressed { get; }
    public ReactiveCommand<Unit, Unit> ExpandButtonPressed { get; }
    public ReactiveCommand<Unit, Unit> MinimiseButtonPressed { get; }

    private bool _isvisible = true;

    public bool IsVisible
    {
        get { return _isvisible; }
        set
        {
            this.RaiseAndSetIfChanged(ref _isvisible, value);
        }
    }
    public TopbarViewModel()
    {
        CloseButtonPressed = ReactiveCommand.Create(CloseEvent);
        ExpandButtonPressed = ReactiveCommand.Create(ExpandEvent);
        MinimiseButtonPressed = ReactiveCommand.Create(MinimiseEvent);
    }
    
    private void CloseEvent()
    {
        var windowList = WindowsManager.WindowList;
        var window = windowList.FirstOrDefault(x => x.Name == "TheMainWindow");
        if (window != null)
        {
            window.Close();
        }
    }

    private void ExpandEvent()
    {
        var windowList = WindowsManager.WindowList;
        var window = windowList.FirstOrDefault(x => x.Name == "TheMainWindow");
        if (window != null)
        {
            if (window.WindowState == WindowState.FullScreen)
            {
                window.WindowState = WindowState.Normal;
            }
            else
            {
                window.WindowState = WindowState.FullScreen;
            }

            IsVisible = !IsVisible;
        }
    }

    private void MinimiseEvent()
    {
        var windowList = WindowsManager.WindowList;
        var window = windowList.FirstOrDefault(x => x.Name == "TheMainWindow");
        if (window != null)
        {
            window.WindowState = WindowState.Minimized;
        }
    }
}