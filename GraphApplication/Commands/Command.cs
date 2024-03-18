using System;
using System.Windows.Input;

namespace GraphApplication.Commands
{
    public abstract class Command : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public virtual bool CanExecute(object? parameter)
        {
            // by default you can always execute command
            return true;
        }

        public abstract void Execute(object? parameter);
    }
}
