using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StaffArcCore.Models;

namespace StaffArcCore.Services
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees();
        void AddEmployee(Employee employee);
    }
}
