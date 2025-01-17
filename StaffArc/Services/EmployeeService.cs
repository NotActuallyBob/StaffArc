using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StaffArc.Models;

namespace StaffArc.Services
{
    internal class EmployeeService
    {
        private List<Employee> Employees { get; set; }

        public EmployeeService()
        {
            Employees = new List<Employee>();
            Employees.Add(new Employee("Ville", "Softare Engineer"));
            Employees.Add(new Employee("Heikki", "Scrum Master"));
            Employees.Add(new Employee("Anni", "Team Lead"));
        }

        public List<Employee> GetEmployees()
        {
            return Employees;
        }

        public void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
        }
    }
}
