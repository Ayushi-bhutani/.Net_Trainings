using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public string GradeLevel { get; set; } // 9th–12th
    public Dictionary<string, double> Subjects { get; set; }

    public Student(int id, string name, string gradeLevel)
    {
        StudentId = id;
        Name = name;
        GradeLevel = gradeLevel;
        Subjects = new Dictionary<string, double>();
    }

    // Calculate Average
    public double GetAverage()
    {
        if (Subjects.Count == 0) return 0;
        return Subjects.Values.Average();
    }
}
