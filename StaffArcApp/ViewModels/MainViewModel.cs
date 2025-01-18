using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffArcApp.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        private string applicationName;
        private string version;
        public string FooterText { get; set; }

        public BaseViewModel CurrentViewModel { get; private set; }

        //public RelayCommand NavigateCommand { get; }

        public MainViewModel(OverviewViewModel employeeViewModel)
        {
            applicationName = "StaffArc";
            version = "0.0.0";
            FooterText = applicationName + " " + version;
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
