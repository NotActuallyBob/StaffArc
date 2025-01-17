using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffArcCore.Models
{
    public class Employee : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }

        public Employee()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Role = string.Empty;
        }

        public Employee(string firstName, string lastName, string role)
        {
            FirstName = firstName;
            LastName = lastName;
            Role = role;
        }

        public override string ToString()
        {
            return $"{Id}_{FirstName}_{LastName}";
        }
    }
}
