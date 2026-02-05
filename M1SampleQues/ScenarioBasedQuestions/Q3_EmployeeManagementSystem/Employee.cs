using System;

namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        public string EmployeeId { get; set; }     // E001, E002...
        public string Name { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }
        public DateTime JoiningDate { get; set; }

        public override string ToString()
        {
            return $"{EmployeeId} | {Name} | {Department} | ₹{Salary} | Joined: {JoiningDate:dd-MM-yyyy}";
        }
    }
}
