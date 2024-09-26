using System;
using System.Windows.Input;

namespace ToolKit
{
    public class CommandPersonnal<T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Func<T, bool> _canExecute;

        public event EventHandler CanExecuteChanged;

        public CommandPersonnal(Action<T> execute, Func<T, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute ?? (_ => true);
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }

        public void RefreshCommand() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

    public class CommandPersonnal : CommandPersonnal<object>
    {
        public CommandPersonnal(Action execute, Func<bool> canExecute = null)
            : base(
                new Action<object>(o => execute()),
                canExecute != null ? new Func<object, bool>(o => canExecute()) : null
            ) { }
    }
}
