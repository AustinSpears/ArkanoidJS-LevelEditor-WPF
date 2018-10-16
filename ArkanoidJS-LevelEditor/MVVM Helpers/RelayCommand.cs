using System;
using System.Windows.Input;

namespace ArkanoidJS_LevelEditor.MVVM_Helpers
{
    // If this were a production application I would use the 
    // MVVM Light Toolkit to take advantage of the weak event pattern.
    // This is good enough for our purposes here though.
    public class RelayCommand : ICommand
    {
        // Fields
        private Action<object> execute;
        private Func<object, bool> canExecute;

        // Constructor
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        // ICommand implementation
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute(parameter);
        }
    }
}
