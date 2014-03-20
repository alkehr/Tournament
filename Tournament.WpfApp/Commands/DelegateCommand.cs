using System;
using System.Windows.Input;

namespace Tournament.WpfApp.Commands
{
    /// <summary>
    ///     This API supports the Entity Framework infrastructure and is not intended to be used directly from your code.
    /// </summary>
    public sealed class DelegateCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute; 

        /// <summary>
        ///     This API supports the Entity Framework infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        ///     This API supports the Entity Framework infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="execute"></param>
        /// /// <param name="canExecute"></param>
        public DelegateCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        ///     This API supports the Entity Framework infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="parameter">This API supports the Entity Framework infrastructure and is not intended to be used directly from your code.</param>
        public void Execute(object parameter)
        {
            _execute();
        }

        /// <summary>
        ///     This API supports the Entity Framework infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="parameter">This API supports the Entity Framework infrastructure and is not intended to be used directly from your code.</param>
        /// <returns>This API supports the Entity Framework infrastructure and is not intended to be used directly from your code.</returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        //public void RaiseCanExecuteChanged()
        //{
        //    if (CanExecuteChanged != null)
        //    {
        //        CanExecuteChanged(this, EventArgs.Empty);
        //    }
        //}
    }
}