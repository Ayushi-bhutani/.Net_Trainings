using System;

class Employee
{
    // Attributes (Fields)
    public int? Id{get; set;}
    public string? Name{get; set;}

    // Constructor
    public Employee(int id, string name)
    {
        Id = id;
        Name = name;
    }

    // Method to display employee details
    public void Display()
    {
        Console.WriteLine("Employee Id: " + Id);
        Console.WriteLine("Employee Name: " + Name);
    }
}

class Program
{
    
    public static void Main()
    {
        // object initializer
        Employee emp1 = new Employee
        {
            Id = 101,
            Name = "Ayushi"
        };
        // Displaying details
        emp1.Display();
      
        
    }
}
