using System;
using System.Windows.Input;

namespace Full_Arch_UWP_Autofac.Helpers
{
    public class MyICommand<T> : ICommand
    {

        Action<T> _TargetExecuteMethod;
        Func<T, bool> _TargetCanExecuteMethod;

        public MyICommand(Action<T> executeMethod)
        {
            _TargetExecuteMethod = executeMethod;
        }
        public MyICommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
        {
            _TargetExecuteMethod = executeMethod;
            _TargetCanExecuteMethod = canExecuteMethod;
        }
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        #region ICommand Members
        /*      CanExecute will determine whether the command can be executed or not
         */
        bool ICommand.CanExecute(object parameter)
        {

            if (_TargetCanExecuteMethod != null)
            {
                T tparm = (T)parameter;
                return _TargetCanExecuteMethod(tparm);
            }

            if (_TargetExecuteMethod != null)
            {
                return true;
            }

            return false;
        }
        /*
         * Beware - should use weak references if command instance lifetime is
         * longer than lifetime of UI objects that get hooked up to command
         */
        // 
        // Prism commands solve this in their implementation 
        public event EventHandler CanExecuteChanged = delegate { };

        /*  Runs the command logic
         */
        void ICommand.Execute(object parameter)
        {
            if (_TargetExecuteMethod != null)
            {
                _TargetExecuteMethod((T)parameter);
            }
        }
        #endregion
    }


    /*  *************************************
     *  Parameterless ICommand
     *  *************************************
     *  https://stackoverflow.com/questions/19360452/how-to-implement-icommand-without-parameters
     */
    public class MyICommand : ICommand
    {
        Action _TargetExecuteMethod;
        Func<bool> _TargetCanExecuteMethod;

        public MyICommand(Action executeMethod)
        {
            _TargetExecuteMethod = executeMethod;
        }
        public MyICommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            _TargetExecuteMethod = executeMethod;
            _TargetCanExecuteMethod = canExecuteMethod;
        }
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        #region ICommand Members
        /*      CanExecute will determine whether the command can be executed or not
         */
        bool ICommand.CanExecute(object parameter)
        {

            if (_TargetCanExecuteMethod != null)
            {
                return _TargetCanExecuteMethod();
            }

            if (_TargetExecuteMethod != null)
            {
                return true;
            }

            return false;
        }
        /*
         * Beware - should use weak references if command instance lifetime is
         * longer than lifetime of UI objects that get hooked up to command
         */
        // 
        // Prism commands solve this in their implementation 
        public event EventHandler CanExecuteChanged = delegate { };

        /*  Runs the command logic
         */
        void ICommand.Execute(object parameter)
        {
            if (_TargetExecuteMethod != null)
            {
                _TargetExecuteMethod();
            }
        }
        #endregion
    }
}