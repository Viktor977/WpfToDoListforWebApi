using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfToDoListforWebApi.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class RellayCommand : ICommand
    {
        private Action<object> _execute;
        private Func<object, bool> _canExecute;
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Execute"></param>
        /// <param name="CanExecute"></param>
        public RellayCommand(Action<object> Execute, Func<object, bool> CanExecute=null)
        {
            _execute = Execute;
            _canExecute = CanExecute;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
