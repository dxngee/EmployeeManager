using System;
using System.Reactive;
using ReactiveUI;

namespace EmployeeManager.ViewModels;

public class HomeViewModel : ViewModelBase
{
    public ReactiveCommand<Unit, Unit> ButtonPressed { get; }
    public HomeViewModel()
    {
        ButtonPressed = ReactiveCommand.Create(Pressed);
    }

    private void Pressed()
    {
        Console.WriteLine("Pressed!");
    }
}