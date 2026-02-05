public class SchoolManager
{
    private List<Student> students = new List<Student>();
    private int studentCounter = 1;

    // Add Student
    public void AddStudent(string name, string gradeLevel)
    {
        var student = new Student(studentCounter++, name, gradeLevel);
        students.Add(student);
    }

    // Add Grade
    public void AddGrade(int studentId, string subject, double grade)
    {
        if (grade < 0 || grade > 100)
        {
            Console.WriteLine("Invalid grade. Must be 0–100.");
            return;
        }

        var student = students.FirstOrDefault(s => s.StudentId == studentId);

        if (student == null)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        student.Subjects[subject] = grade;
    }

    // Group by Grade Level
    public SortedDictionary<string, List<Student>> GroupStudentsByGradeLevel()
    {
        return new SortedDictionary<string, List<Student>>(
            students.GroupBy(s => s.GradeLevel)
                    .ToDictionary(g => g.Key, g => g.ToList())
        );
    }

    // Student Average
    public double CalculateStudentAverage(int studentId)
    {
        var student = students.FirstOrDefault(s => s.StudentId == studentId);
        if (student == null) return 0;
        return student.GetAverage();
    }

    // Subject Averages
    public Dictionary<string, double> CalculateSubjectAverages()
    {
        var subjectDict = new Dictionary<string, List<double>>();

        foreach (var student in students)
        {
            foreach (var sub in student.Subjects)
            {
                if (!subjectDict.ContainsKey(sub.Key))
                    subjectDict[sub.Key] = new List<double>();

                subjectDict[sub.Key].Add(sub.Value);
            }
        }

        return subjectDict.ToDictionary(
            s => s.Key,
            s => s.Value.Average()
        );
    }

    // Top Performers
    public List<Student> GetTopPerformers(int count)
    {
        return students
            .OrderByDescending(s => s.GetAverage())
            .Take(count)
            .ToList();
    }

    // Helper: Display All Students
    public void DisplayAllStudents()
    {
        foreach (var s in students)
        {
            Console.WriteLine($"{s.StudentId} - {s.Name} ({s.GradeLevel}) Avg: {s.GetAverage():F2}");
        }
    }
}
