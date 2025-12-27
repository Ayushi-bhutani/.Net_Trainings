namespace Management;

public class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public string ClassName { get; set; }

    public Student(int studentId, string name, string className)
    {
        StudentId = studentId;
        Name = name;
        ClassName = className;
    }

    public override string ToString()
    {
        return $"{StudentId} - {Name} ({ClassName})";
    }
}
