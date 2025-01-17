using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using StaffArcCore.Logs;
using StaffArcCore.Models;

namespace StaffArcCore.Services
{
    public class FileEmployeeService : IEmployeeService
    {
        private MyLogger myLogger;

        private string basePath;

        private List<Employee> Employees { get; set; }

        public FileEmployeeService(string basePath, MyLogger myLogger)
        {
            this.myLogger = myLogger;
            this.basePath = Path.Combine(basePath, "employees");

            Employees = new List<Employee>();

            Initialize();
        }

        private void Initialize()
        {
            if (!Directory.Exists(basePath))
            {
                myLogger.Log("Start create basefolder");
                Directory.CreateDirectory(basePath);
                myLogger.Log("Finish create basefolder");
            }
            else
            {
                myLogger.Log("Basefolder exists");
            }
        }

        private void LoadData()
        {
            Employees.Clear();
            string[] files = Directory.GetFiles(basePath, "*.json");
            foreach (string file in files)
            {
                var fileText = File.ReadAllText(file);
                try
                {
                    Employee? employee = JsonSerializer.Deserialize<Employee>(fileText);
                    if (employee != null)
                    {
                        Employees.Add(employee);
                        myLogger.Log("Successfully loaded employee: ");
                    }
                } catch (Exception ex) {
                    myLogger.Warning("Failed to deserialize emplyee. Path: " + file);
                }
            }
        }

        public List<Employee> GetEmployees()
        {
            LoadData();
            return Employees;
        }

        private string GetFileName(Employee employee)
        {
            return @$"{employee.Id}_{employee.FirstName}_{employee.LastName}.json";
        }

        public void AddEmployee(Employee employee)
        {
            if (employee == null)
            {
                return;
            }

            employee.Id = Employees.Count;

            string fileName = GetFileName(employee);
            string filePath = Path.Combine(basePath, fileName);
            if (File.Exists(filePath))
            {
                myLogger.Warning($"Employee {GetFileName(employee)} alread exists");
                return;
            }

            string text = JsonSerializer.Serialize(employee);
            File.WriteAllText(filePath, text);
        }
    }
}
