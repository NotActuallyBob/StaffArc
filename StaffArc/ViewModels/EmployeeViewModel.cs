using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using StaffArc.Models;
using StaffArc.Services;

namespace StaffArc.ViewModels
{
    internal class EmployeeViewModel : INotifyPropertyChanged
    {
        private EmployeeService employeeService;
        
        public EmployeeViewModel(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
            Employee = new Employee();
            LoadData();
            AddEmployeeCommand = new RelayCommand(AddEmployee);
        }

        private void LoadData()
        {
            Employees = new ObservableCollection<Employee>(employeeService.GetEmployees());
        }

        public RelayCommand AddEmployeeCommand { get; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<Employee> Employees;
        public Employee Employee { get; set; }

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
