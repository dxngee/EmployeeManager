using System;
using System.Reactive;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using EmployeeManager.Models;
using ReactiveUI;

namespace EmployeeManager.ViewModels;

public class TopbarViewModel : ViewModelBase
{
    public ReactiveCommand<Unit, Unit> DoTheThing { get; }

    public TopbarViewModel()
    {
        DoTheThing = ReactiveCommand.Create(RunTheThing);   
    }
    
    private void RunTheThing()
    {
        Console.WriteLine("Clocked!");
    }
}