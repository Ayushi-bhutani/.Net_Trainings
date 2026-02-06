using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var learningManager = new LearningManager();

        // 1. Add Courses
        learningManager.AddCourse("CS101", "C# Basics", "John Doe", 6, 199.99, new List<string> { "Variables", "Loops", "OOP" });
        learningManager.AddCourse("CS102", "Advanced C#", "John Doe", 8, 299.99, new List<string> { "Delegates", "Events", "LINQ" });
        learningManager.AddCourse("JS101", "JavaScript Basics", "Jane Smith", 4, 149.99, new List<string> { "Syntax", "DOM", "ES6" });

        // 2. Enroll Students
        learningManager.EnrollStudent("S001", "CS101");
        learningManager.EnrollStudent("S002", "CS101");
        learningManager.EnrollStudent("S001", "JS101");

        // 3. Update Progress
        learningManager.UpdateProgress("S001", "CS101", "Variables", 100);
        learningManager.UpdateProgress("S001", "CS101", "Loops", 80);
        learningManager.UpdateProgress("S001", "CS101", "OOP", 90);

        // 4. Group Courses by Instructor
        var coursesByInstructor = learningManager.GroupCoursesByInstructor();
        Console.WriteLine("Courses by Instructor:");
        foreach (var entry in coursesByInstructor)
        {
            Console.WriteLine($"{entry.Key}: {string.Join(", ", entry.Value.ConvertAll(c => c.CourseName))}");
        }

        // 5. Top Performing Students
        var topStudents = learningManager.GetTopPerformingStudents("CS101", 1);
        Console.WriteLine("\nTop Student in CS101:");
        foreach (var e in topStudents)
        {
            Console.WriteLine($"StudentId: {e.StudentId}, Progress: {e.ProgressPercentage}%");
        }
    }
}
