using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StaffArcApp
{
    internal class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private Action doWork;

        public RelayCommand(Action doWork)
        {
            this.doWork = doWork;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            doWork();
        }
    }
}
