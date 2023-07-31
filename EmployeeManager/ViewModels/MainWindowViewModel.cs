using System;
using Avalonia.Automation.Peers;
using Avalonia.Controls;
using EmployeeManager.Views;
using ReactiveUI;
using System.Reactive;
using System.Threading;


namespace EmployeeManager.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ReactiveCommand<Unit, Unit> DoTheThing { get; }

    public MainWindowViewModel()
    {
        DoTheThing = ReactiveCommand.Create(RunTheThing);   
    }
    
    private void RunTheThing()
    {
        Console.WriteLine("Clicked!");
        
    }
}