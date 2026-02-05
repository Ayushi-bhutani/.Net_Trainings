using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagementSystem.Managers
{
    public class HRManager
    {
        private readonly List<Employee> _employees = new();
        private int _idCounter = 0;

        // Add Employee
        public void AddEmployee(string name, string dept, double salary)
        {
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(dept))
                throw new ArgumentException("Invalid employee details.");

            if (salary <= 0)
                throw new ArgumentException("Salary must be greater than zero.");

            _employees.Add(new Employee
            {
                EmployeeId = $"E{(++_idCounter).ToString("D3")}",
                Name = name,
                Department = dept,
                Salary = salary,
                JoiningDate = DateTime.Now
            });
        }

        // Group Employees By Department
        public SortedDictionary<string, List<Employee>> GroupEmployeesByDepartment()
        {
            return new SortedDictionary<string, List<Employee>>(
                _employees
                .GroupBy(e => e.Department)
                .ToDictionary(g => g.Key, g => g.ToList())
            );
        }

        // Calculate Department Salary
        public double CalculateDepartmentSalary(string department)
        {
            return _employees
                .Where(e => e.Department.Equals(department, StringComparison.OrdinalIgnoreCase))
                .Sum(e => e.Salary);
        }

        // Employees Joined After Date
        public List<Employee> GetEmployeesJoinedAfter(DateTime date)
        {
            return _employees
                .Where(e => e.JoiningDate > date)
                .OrderBy(e => e.JoiningDate)
                .ToList();
        }

        // Helper
        public List<Employee> GetAllEmployees() => _employees;
    }
}
