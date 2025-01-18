using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffArcApp.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        public string ApplicationName { get; set; } = "StaffArc";

        public BaseViewModel CurrentViewModel { get; private set; }

        //public RelayCommand NavigateCommand { get; }

        public MainViewModel(EmployeeViewModel employeeViewModel)
        {
            CurrentViewModel = employeeViewModel;
            //NavigateCommand = new RelayCommand(NavigateTo);
        }

        //private void NavigateTo(object? viewModel)
        //{
        //    if (viewModel == null) {
        //        return;
        //    }

        //    CurrentViewModel = EmployeeViewModel();
        //}
    }
}
