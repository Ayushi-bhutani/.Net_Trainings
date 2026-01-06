using System;
using System.Text.Json;
namespace serial{
   

public class Student
{
    required public int Id { get; set; }
    required public string Name { get; set; }
    required public string Course { get; set; }
}

class Program11
{
    static void Main11()
    {
        Student s = new Student
        {
            Id = 1,
            Name = "Ayushi",
            Course = "C# .NET"
        };


        var options = new JsonSerializerOptions{
            WriteIndented = true,
        };

        // Serialize (Object -> JSON string)
        string json = JsonSerializer.Serialize(s);
        Console.WriteLine(json, options);

        File.WriteAllText("sachin.json",json);
        Console.WriteLine("json created");


        
      

        // Deserialize (JSON string -> Object)
        Student obj = JsonSerializer.Deserialize<Student>(json);
        Console.WriteLine(obj.Name);
    }
}

}