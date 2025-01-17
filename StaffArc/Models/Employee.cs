using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffArc.Models
{
    internal class Employee : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }

        public Employee()
        {
            Name = string.Empty;
            Role = string.Empty;
        }

        public Employee(string name, string role)
        {
            this.Name = name;
            this.Role = role;
        }
    }
}
