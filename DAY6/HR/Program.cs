using System;
using System.Collections.Generic;

public interface IRecruit
{
    void Hire(Employee emp);
}

public interface IReject
{
    void Reject(Employee emp, string reason);
}

public abstract class InterviewPerformance
{
    public abstract int Score();
}

public class Employee : InterviewPerformance
{
    public string Name { get; set; }
    public string Status { get; set; } = "Pending";
    public string RejectionReason { get; set; } = "";

    public Employee(string name)
    {
        Name = name;
    }

    // simple scoring logic
    public override int Score()
    {
        return new Random().Next(1, 10);   // (1–10)
    }

    public override string ToString()
    {
        return $"Name: {Name}, Status: {Status}, Reason: {RejectionReason}";
    }
}

public class HR : IRecruit, IReject
{
    private List<Employee> employees = new List<Employee>();

    public void Hire(Employee emp)
    {
        emp.Status = "Hired";
        employees.Add(emp);
        Console.WriteLine($"{emp.Name} is Hired.");
    }

    public void Reject(Employee emp, string reason)
    {
        emp.Status = "Rejected";
        emp.RejectionReason = reason;
        employees.Add(emp);
        Console.WriteLine($"{emp.Name} is Rejected. Reason: {reason}");
    }

    public void Evaluate(Employee emp)
    {
        int score = emp.Score();
        Console.WriteLine($"{emp.Name} performance score: {score}");
    }

    public void ShowAllEmployees()
    {
        Console.WriteLine("\n--- Employee Records ---");
        foreach (var e in employees)
            Console.WriteLine(e);
    }
}

class Program
{
    static void Main()
    {
        HR hr = new HR();

        Employee e1 = new Employee("Ayushi");
        Employee e2 = new Employee("Rohan");

        hr.Hire(e1);
        hr.Reject(e2, "Did not clear technical round");

        hr.Evaluate(e1);

        hr.ShowAllEmployees();
    }
}
