
namespace Management
{
public static class DataBank
{
    public static List<Student> students;
    
    static DataBank()
    {
        students=new List<Student>();
        students.Add(new Student(){ StudentId=1, Name="Ayushi", ClassName="First Year BE CSC" });
        students.Add(new Student(){ StudentId=1, Name="Akram", ClassName="First Year BE CSC" });
        students.Add(new Student(){ StudentId=1, Name="Sachin", ClassName="First Year BE CSC" });
        students.Add(new Student(){ StudentId=1, Name="Devanshi", ClassName="First Year BE CSC" });
        students.Add(new Student(){ StudentId=1, Name="Sanvi", ClassName="First Year BE CSC" });
        students.Add(new Student(){ StudentId=1, Name="Riyanshi", ClassName="First Year BE CSC" });

        sessions = new List<StudentSession>();
        sessions.Add(new StudentSession(){Id = 1, Name = "Ayushi", Description = "B.tech CSE"} );

        studentSession = new List<>();


    }

    public static List<Student> GetStudents(){
        return students;
    }
    
}
}