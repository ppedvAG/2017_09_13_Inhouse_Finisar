using System;
using System.Windows.Input;

namespace UI.Infrastructure
{
    public class RelayCommand : ICommand
    {
        private readonly Action _executeHandler;
        private readonly Func<bool> _canExecuteHandler;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action execute)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute), $"Execute must not be null!");

            _executeHandler = execute;
        }
        public RelayCommand(Action execute, Func<bool> canExecute)
            : this(execute)
        {
            _canExecuteHandler = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecuteHandler != null ? _canExecuteHandler() : true;

        public void Execute(object parameter) => _executeHandler();
    }
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _executeHandler;
        private readonly Func<T, bool> _canExecuteHandler;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<T> execute)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute), $"Execute must not be null!");

            _executeHandler = execute;
        }
        public RelayCommand(Action<T> execute, Func<T, bool> canExecute)
            : this(execute)
        {
            _canExecuteHandler = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecuteHandler != null ? _canExecuteHandler((T)parameter) : true;

        public void Execute(object parameter) => _executeHandler((T)parameter);
    }
}
