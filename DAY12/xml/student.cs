using System.Xml.Serialization;
using System.Text.Json;
// ================= STUDENT ===================
public class Student
{
    public string? Name { get; set; }
    required public List<string> Subjects { get; set; }
    required public List<int> Marks { get; set; }
}

// ================= COLLECTION =================
public class Students
{
    required public Student[] Items { get; set; }
}

// ================= PROGRAM ====================
public class Program11
{
    public static void Main(string[] args)
    {
        Student s1 = new Student
        {
            Name = "Ayushi",
            Subjects = new List<string> { "Maths", "Physics", "CS" },
            Marks = new List<int> {90, 90, 90}
        };

        Student s2 = new Student
        {
            Name = "Akram",
            Subjects = new List<string> { "Maths", "Chemistry", "CS" },
            Marks = new List<int> { 88, 92, 91 }
        };

        Students students = new Students
        {
            Items = new Student[] { s1, s2 }
        };

        XmlSerializer serializer = new XmlSerializer(typeof(Students));

        using (TextWriter writer = new StreamWriter("students.xml"))
        {
            serializer.Serialize(writer, students);
        }

        Console.WriteLine("students.xml created successfully");

        string json = JsonSerializer.Serialize(students);
        Console.WriteLine(json);



    }
}