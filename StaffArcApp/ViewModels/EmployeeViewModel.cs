using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using StaffArcApp.Models;
using StaffArcApp.Services;

namespace StaffArcApp.ViewModels
{
    internal class EmployeeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private EmployeeService employeeService;
        
        public RelayCommand AddEmployeeCommand { get; }

        public ObservableCollection<Employee> Employees { get; set; }
        public Employee Employee { get; set; }

        public EmployeeViewModel(EmployeeService employeeService)
        {
            this.employeeService = employeeService;

            AddEmployeeCommand = new RelayCommand(AddEmployee);

            Employee = new Employee();
            Employees = new ObservableCollection<Employee>();

            LoadData();
        }

        private void LoadData()
        {
            Employees = new ObservableCollection<Employee>(employeeService.GetEmployees());
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddEmployee()
        {
            employeeService.AddEmployee(new Employee(Employee.Name, Employee.Role));
            LoadData();
            Employee.Name = string.Empty;
            Employee.Role = string.Empty;
        }
    }
}
