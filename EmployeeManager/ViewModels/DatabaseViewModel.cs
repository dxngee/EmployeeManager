using System;
using System.Reactive;
using ReactiveUI;

namespace EmployeeManager.ViewModels;

public class DatabaseViewModel : ViewModelBase
{
    public ReactiveCommand<Unit, Unit> ButtonPressed { get; }
    public DatabaseViewModel()
    {
        ButtonPressed = ReactiveCommand.Create(Pressed);
    }
    
    private void Pressed()
    {
        Console.WriteLine("Pressed!");
    }
}