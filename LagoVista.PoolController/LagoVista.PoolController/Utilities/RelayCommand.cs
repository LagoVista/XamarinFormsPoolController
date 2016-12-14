using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LagoVista.PoolController.Utilities
{
    public class RelayCommand : ICommand
    {
        Action<object> _action;
        Action _nullAction;

        public event EventHandler CanExecuteChanged;

        public RelayCommand()
        {
            _enabled = true;
        }
    
        private bool _enabled;
        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                if (_enabled != value)
                {
                    _enabled = value;
                    CanExecuteChanged?.Invoke(this, null);
                }
            }
        }

        public bool CanExecute(object parameter)
        {
            return Enabled;
        }

        public void Execute(object parameter)
        {
            if (_nullAction != null)
            {
                if (parameter != null)
                    throw new Exception("Wrong action type mapping, parameter passed to null command handler.");

                _nullAction();
            }

            if (_action != null)
            {
                _action(parameter);
            }
        }

        public static RelayCommand Create(Action<object> action)
        {
            return new RelayCommand() { _action = action };
        }

        public static RelayCommand Create(Action action)
        {
            return new RelayCommand() { _nullAction = action };
        }
    }
}
