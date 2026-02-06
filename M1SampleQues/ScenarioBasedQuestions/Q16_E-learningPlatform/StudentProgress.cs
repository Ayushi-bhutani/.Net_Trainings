using System;
using System.Collections.Generic;

public class StudentProgress
{
    public string StudentId { get; set; }
    public string CourseCode { get; set; }
    public Dictionary<string, double> ModuleScores { get; set; } = new Dictionary<string, double>();
    public DateTime LastAccessed { get; set; }
}
