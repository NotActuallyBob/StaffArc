using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using StaffArcCore.Models;
using StaffArcCore.Services;

namespace StaffArcApp.ViewModels
{
    internal class OverviewViewModel : BaseViewModel
    {

        private IEmployeeService employeeService;

        public ObservableCollection<Employee> Employees { get; set; }

        public OverviewViewModel(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;

            Employees = new ObservableCollection<Employee>();

            LoadData();
        }

        private void LoadData()
        {
            Employees = new ObservableCollection<Employee>(employeeService.GetEmployees());
        }
    }
}
