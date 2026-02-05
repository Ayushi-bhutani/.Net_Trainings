using EmployeeManagementSystem.Managers;
using System;

class Program
{
    static void Main()
    {
        var hr = new HRManager();

        // 1️⃣ Add Employees
        hr.AddEmployee("Ayushi", "IT", 60000);
        hr.AddEmployee("Rahul", "HR", 45000);
        hr.AddEmployee("Neha", "IT", 70000);
        hr.AddEmployee("Amit", "Sales", 50000);

        // 2️⃣ Group By Department
        Console.WriteLine("👥 Employees Grouped By Department:\n");

        var grouped = hr.GroupEmployeesByDepartment();

        foreach (var dept in grouped)
        {
            Console.WriteLine($"--- {dept.Key} ---");
            dept.Value.ForEach(e => Console.WriteLine(e));
            Console.WriteLine();
        }

        // 3️⃣ Department Salary
        Console.WriteLine($"💰 Total IT Department Salary: ₹{hr.CalculateDepartmentSalary("IT")}");

        // 4️⃣ Joined Recently
        Console.WriteLine("\n🆕 Employees Joined After Today:\n");

        var recent = hr.GetEmployeesJoinedAfter(DateTime.Today.AddDays(-1));

        recent.ForEach(e => Console.WriteLine(e));
    }
}
