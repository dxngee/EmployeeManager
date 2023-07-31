using System;
using System.Linq;
using System.Reactive;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using EmployeeManager.Models;
using EmployeeManager.Views;
using ReactiveUI;

namespace EmployeeManager.ViewModels;

public class TopbarViewModel : ViewModelBase
{
    public ReactiveCommand<Unit, Unit> CloseButtonPressed { get; }
    public ReactiveCommand<Unit, Unit> ExpandButtonPressed { get; }
    public ReactiveCommand<Unit, Unit> MinimiseButtonPressed { get; }
    public ReactiveCommand<Unit, Unit> HomeButtonPressed { get; }
    public ReactiveCommand<Unit, Unit> DatabaseButtonPressed { get; }

    private bool _isvisible = true;

    public bool IsVisible
    {
        get { return _isvisible; }
        set
        {
            this.RaiseAndSetIfChanged(ref _isvisible, value);
        }
    }

    private static HomeViewModel HomeVM { get; set; }
    private static DatabaseViewModel DatabaseVM { get; set; }
    
    private object _currentview = new HomeViewModel();
    public object CurrentView
    {
        get { return _currentview; }
        set
        {
            this.RaiseAndSetIfChanged(ref _currentview, value);
        }
    }
    
    public TopbarViewModel()
    {
        CloseButtonPressed = ReactiveCommand.Create(CloseEvent);
        ExpandButtonPressed = ReactiveCommand.Create(ExpandEvent);
        MinimiseButtonPressed = ReactiveCommand.Create(MinimiseEvent);
        HomeButtonPressed = ReactiveCommand.Create(SetHomeView);
        DatabaseButtonPressed = ReactiveCommand.Create(SetDatabaseView);
    }
    
    private void CloseEvent()
    {
        var windowList = RecoursesManager.WindowList;
        var window = windowList.FirstOrDefault(x => x.Name == "TheMainWindow");
        if (window != null)
        {
            window.Close();
        }
    }
    private void ExpandEvent()
    {
        var windowList = RecoursesManager.WindowList;
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
        var windowList = RecoursesManager.WindowList;
        var window = windowList.FirstOrDefault(x => x.Name == "TheMainWindow");
        if (window != null)
        {
            window.WindowState = WindowState.Minimized;
        }
    }
    
    
    private void SetHomeView()
    {
        var window = RecoursesManager.WindowList.FirstOrDefault(x => x.Name == "TheMainWindow");
        if (window != null)
        {
            window.DataContext = ViewModelManager.ViewModelList.FirstOrDefault(x => x.Key == "TopbarViewModel").Value;
            HomeVM = new HomeViewModel();
            CurrentView = HomeVM;
            window.DataContext = new MainWindowViewModel();
        }
    }
    private void SetDatabaseView()
    {
        var window = RecoursesManager.WindowList.FirstOrDefault(x => x.Name == "TheMainWindow");
        if (window != null)
        {
            window.DataContext = ViewModelManager.ViewModelList.FirstOrDefault(x => x.Key == "TopbarViewModel").Value;
            DatabaseVM = new DatabaseViewModel();
            CurrentView = DatabaseVM;
            window.DataContext = new MainWindowViewModel();
        }
    }
}