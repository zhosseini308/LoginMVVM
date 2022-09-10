using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
namespace MVVMLogin.ViewModel
{
    public class ViewModelCommand : ICommand
    {
        
        private readonly Action<object> _executeAction;
        private readonly Predicate<object> _canExecuteAction;

        
        #region constructors
        public ViewModelCommand(Action<object> executeAction, Predicate<object> canExecuteAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = canExecuteAction;
        }
        public ViewModelCommand(Action<object> executeAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = null;
        }
        #endregion

        //events
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }

        }

        //methods
        public bool CanExecute(object parameter)
        {
            if (_canExecuteAction != null)
                return _canExecuteAction(parameter);
            else return true;
            
        }

        public void Execute(object parameter)
        {
            _canExecuteAction(parameter);
        }
    }
}
