
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
        
        if(student == null || course == null)   
            return false;
        
        if(!_enrollments.ContainsKey(course))
        {
            _enrollments[course] = new List<TStudent>();
        }
        
        if(_enrollments[course].Count >= course.MaxCapacity) 
            return false;
        
        if(_enrollments[course]
                .Any(s=>s.StudentId == student.StudentId))
            return false;
            
        if(course is LabCourse lab){
            if(student.Semester < lab.RequiredSemester){
                return false;
            }
        }
        
        _enrollments[course].Add(student);
        return true;
    }
    
    // TODO: Get students for course
    public IReadOnlyList<TStudent> GetEnrolledStudents(TCourse course)
    {
        // Return immutable list
        if(_enrollments.ContainsKey(course)){
            return _enrollments[course].AsReadOnly();
        }
        return new List<TStudent>().AsReadOnly();
    }
    
    // TODO: Get courses for student
    public IEnumerable<TCourse> GetStudentCourses(TStudent student)
    {
        // Return courses student is enrolled in
        if(student == null) return Enumerable.Empty<TCourse>();
        return _enrollments
            .Where(kvp => kvp.Value
                .Any(s=>s.StudentId == student.StudentId))
            .Select(kvp => kvp.Key);
    }
    
    // TODO: Calculate student workload
    public int CalculateStudentWorkload(TStudent student)
    {
        // Sum credits of all enrolled courses
        if(student == null) return 0;
        int sum = 0 ;
        foreach( var item in _enrollments){
            if(item.Value
                .Any(s=>s.StudentId == student.StudentId)){
                    sum += item.Key.Credits;
                }
        }
        return sum;
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
where TStudent : IStudent
where TCourse : ICourse
{
    
    private readonly EnrollmentSystem<TStudent, TCourse> _enrollmentSystem;

    private Dictionary<(TStudent, TCourse), double> _grades = new();

    public GradeBook(
        EnrollmentSystem<TStudent, TCourse> enrollmentSystem)
    {
        _enrollmentSystem = enrollmentSystem;
    }
    // TODO: Add grade with validation
    public void AddGrade(TStudent student, TCourse course, double grade)
    {
        // Grade must be between 0 and 100
        // Student must be enrolled in course
        if(student == null ) 
                throw new ArgumentNullException(nameof(student));
        if(course == null) 
                throw new ArgumentNullException(nameof(course));        
                
        if(grade < 0 || grade > 100 ){
            throw new ArgumentOutOfRangeException(nameof(grade), 
                "Grade must be between 0 and 100");
        }
        var courses =
        _enrollmentSystem.GetStudentCourses(student);

    if (!courses.Contains(course))
        throw new InvalidOperationException(
            "Student is not enrolled in this course");
        _grades[(student, course)] = grade;
    }
    
    // TODO: Calculate GPA for student
    public double? CalculateGPA(TStudent student)
    {
        // Weighted by course credits
        // Return null if no grades
        if(student == null) throw new ArgumentNullException(nameof(student));
        
        double totalWeightedScore = 0;
        int totalCredits = 0;
        foreach(var item in _grades){
            var enrolledStudent = item.Key.Item1;
            var course = item.Key.Item2;
            var grade = item.Value;
            
            if(EqualityComparer<TStudent>.Default.Equals(enrolledStudent, student)){
                totalWeightedScore += grade*course.Credits;
                totalCredits += course.Credits;
            }
        }
        if(totalCredits == 0){
            return null;
        }
        return  totalWeightedScore/totalCredits;
        
    }
    
    // TODO: Find top student in course
    public (TStudent student, double grade)? GetTopStudent(TCourse course)
    {
        // Return student with highest grade
        if(course == null) 
            throw new ArgumentNullException(nameof(course));
            
        var result =  _grades
                .Where(g=> EqualityComparer<TCourse>.Default
                    .Equals(g.Key.Item2, course))
                .OrderByDescending(g=>g.Value)
                .Select(g=> (student: g.Key.Item1, grade: g.Value))
                .FirstOrDefault();
                
        if(EqualityComparer<TStudent>.Default.Equals(result.student , default))
            return null;
            
        return result;
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

