class Program
{
    static void Main()
    {
        SchoolManager manager = new SchoolManager();

        // Add Students
        manager.AddStudent("Ayushi", "10th");
        manager.AddStudent("Rahul", "10th");
        manager.AddStudent("Sneha", "11th");

        // Add Grades
        manager.AddGrade(1, "Math", 95);
        manager.AddGrade(1, "Science", 90);

        manager.AddGrade(2, "Math", 70);
        manager.AddGrade(2, "Science", 75);

        manager.AddGrade(3, "Math", 88);
        manager.AddGrade(3, "Science", 92);

        // Display Students
        Console.WriteLine("All Students:");
        manager.DisplayAllStudents();

        // Group by Grade
        Console.WriteLine("\nGrouped By Grade:");
        var grouped = manager.GroupStudentsByGradeLevel();
        foreach (var grade in grouped)
        {
            Console.WriteLine($"Grade: {grade.Key}");
            foreach (var s in grade.Value)
                Console.WriteLine($"  {s.Name}");
        }

        // Subject Averages
        Console.WriteLine("\nSubject Averages:");
        var subAvg = manager.CalculateSubjectAverages();
        foreach (var s in subAvg)
            Console.WriteLine($"{s.Key}: {s.Value:F2}");

        // Top Performers
        Console.WriteLine("\nTop Performer:");
        var top = manager.GetTopPerformers(1);
        foreach (var s in top)
            Console.WriteLine($"{s.Name} Avg: {s.GetAverage():F2}");
    }
}
