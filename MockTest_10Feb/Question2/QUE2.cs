public interface IStudent
{
    int StudentId { get; }
    string Name { get; }
    int Semester { get; }
}

public interface ICourse
{
    string CourseCode { get; }
    string Title { get; }
    int MaxCapacity { get; }
    int Credits { get; }
}

// 1. Generic enrollment system
public class EnrollmentSystem<TStudent, TCourse>
    where TStudent : IStudent
    where TCourse : ICourse
{
    private Dictionary<TCourse, List<TStudent>> _enrollments = new();
    
    // TODO: Enroll student with constraints
    public bool EnrollStudent(TStudent student, TCourse course)
    {
        // Rules:
        // - Course not at capacity
        // - Student not already enrolled
        // - Student semester >= course prerequisite (if any)
        // - Return success/failure with reason
    }
    
    // TODO: Get students for course
    public IReadOnlyList<TStudent> GetEnrolledStudents(TCourse course)
    {
        // Return immutable list
    }
    
    // TODO: Get courses for student
    public IEnumerable<TCourse> GetStudentCourses(TStudent student)
    {
        // Return courses student is enrolled in
    }
    
    // TODO: Calculate student workload
    public int CalculateStudentWorkload(TStudent student)
    {
        // Sum credits of all enrolled courses
    }
}

// 2. Specialized implementations
public class EngineeringStudent : IStudent
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public int Semester { get; set; }
    public string Specialization { get; set; }
}

public class LabCourse : ICourse
{
    public string CourseCode { get; set; }
    public string Title { get; set; }
    public int MaxCapacity { get; set; }
    public int Credits { get; set; }
    public string LabEquipment { get; set; }
    public int RequiredSemester { get; set; } // Prerequisite
}

// 3. Generic gradebook
public class GradeBook<TStudent, TCourse>
{
    private Dictionary<(TStudent, TCourse), double> _grades = new();
    
    // TODO: Add grade with validation
    public void AddGrade(TStudent student, TCourse course, double grade)
    {
        // Grade must be between 0 and 100
        // Student must be enrolled in course
    }
    
    // TODO: Calculate GPA for student
    public double? CalculateGPA(TStudent student)
    {
        // Weighted by course credits
        // Return null if no grades
    }
    
    // TODO: Find top student in course
    public (TStudent student, double grade)? GetTopStudent(TCourse course)
    {
        // Return student with highest grade
    }
}



public class Program
{
    public static void Main()
    {
        // ================================
        // 1️⃣ Create Students
        // ================================
        var s1 = new EngineeringStudent
        {
            StudentId = 1,
            Name = "Ayushi",
            Semester = 5,
            Specialization = "CSE"
        };

        var s2 = new EngineeringStudent
        {
            StudentId = 2,
            Name = "Rahul",
            Semester = 3,
            Specialization = "ECE"
        };

        var s3 = new EngineeringStudent
        {
            StudentId = 3,
            Name = "Simran",
            Semester = 6,
            Specialization = "IT"
        };

        // ================================
        // 2️⃣ Create Courses
        // ================================
        var c1 = new LabCourse
        {
            CourseCode = "CSL501",
            Title = "Advanced Programming Lab",
            MaxCapacity = 2,
            Credits = 4,
            LabEquipment = "High-End PCs",
            RequiredSemester = 4
        };

        var c2 = new LabCourse
        {
            CourseCode = "CSL601",
            Title = "AI Lab",
            MaxCapacity = 2,
            Credits = 5,
            LabEquipment = "GPU Systems",
            RequiredSemester = 6
        };

        // ================================
        // 3️⃣ Enrollment System
        // ================================
        var enrollmentSystem =
            new EnrollmentSystem<EngineeringStudent, LabCourse>();

        Console.WriteLine("=== ENROLLMENT TESTS ===");

        // Successful enrollment
        Console.WriteLine(
            enrollmentSystem.EnrollStudent(s1, c1));

        Console.WriteLine(
            enrollmentSystem.EnrollStudent(s3, c1));

        // ❌ Capacity failure
        Console.WriteLine(
            enrollmentSystem.EnrollStudent(s2, c1));

        // ❌ Prerequisite failure
        Console.WriteLine(
            enrollmentSystem.EnrollStudent(s2, c2));

        // Successful
        Console.WriteLine(
            enrollmentSystem.EnrollStudent(s3, c2));

        // ================================
        // 4️⃣ View Students per Course
        // ================================
        Console.WriteLine("\n=== STUDENTS IN CSL501 ===");

        var studentsInC1 =
            enrollmentSystem.GetEnrolledStudents(c1);

        foreach (var s in studentsInC1)
            Console.WriteLine($"{s.Name} - Sem {s.Semester}");

        // ================================
        // 5️⃣ Courses per Student
        // ================================
        Console.WriteLine("\n=== COURSES FOR SIMRAN ===");

        var simranCourses =
            enrollmentSystem.GetStudentCourses(s3);

        foreach (var c in simranCourses)
            Console.WriteLine(c.Title);

        // ================================
        // 6️⃣ Workload Calculation
        // ================================
        Console.WriteLine("\n=== WORKLOAD ===");

        Console.WriteLine(
            $"Simran Credits: " +
            enrollmentSystem.CalculateStudentWorkload(s3));

        // ================================
        // 7️⃣ GradeBook Testing
        // ================================
        var gradeBook =
    new GradeBook<EngineeringStudent, LabCourse>(
        enrollmentSystem);


        Console.WriteLine("\n=== GRADE ASSIGNMENT ===");

        gradeBook.AddGrade(s1, c1, 85);
        gradeBook.AddGrade(s3, c1, 92);
        gradeBook.AddGrade(s3, c2, 88);

        // ================================
        // 8️⃣ GPA Calculation
        // ================================
        Console.WriteLine("\n=== GPA ===");

        var gpa1 = gradeBook.CalculateGPA(s1);
        var gpa3 = gradeBook.CalculateGPA(s3);

        Console.WriteLine($"Ayushi GPA: {gpa1}");
        Console.WriteLine($"Simran GPA: {gpa3}");

        // ================================
        // 9️⃣ Topper Per Course
        // ================================
        Console.WriteLine("\n=== TOP STUDENT ===");

        var topper = gradeBook.GetTopStudent(c1);

        if (topper != null)
        {
            Console.WriteLine(
                $"{topper.Value.student.Name} - {topper.Value.grade}");
        }

        Console.WriteLine("\n=== TEST COMPLETE ===");
    }
}

