using System;
using System.Windows.Input;

namespace WPFMVVMHelper
{
    /// <summary>
    /// потом с этим побалуюсь
    /// </summary>
    /// <typeparam name="T">чо хочешь пиши заебал</typeparam>
    public class lamdaCommand<T> : ICommand
    {
        private Func<T, bool> action;
        private readonly Action<T> f_Execute;

        public lamdaCommand(Action<T> Execute, Func<T, bool> CenExecute = null)
        {
            f_Execute = Execute;
            action = CenExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
        {
            return action?.Invoke((T)parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            f_Execute((T)parameter);
        }
    }

    /// <summary>
    /// необходимо для выполнения команд
    /// </summary>
    public class lamdaCommand : ICommand
    {
        private Func<bool> action;
        private readonly Action f_Execute;

        public lamdaCommand(Action Execute, Func<bool> CenExecute = null)
        {
            f_Execute = Execute;
            action = CenExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
        {
            return action?.Invoke() ?? true;
        }

        public void Execute(object parameter)
        {
            f_Execute();
        }
    }
}