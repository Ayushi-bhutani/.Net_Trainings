
namespace Management
{
public static class DataBank
{
    public static List<Student> students;
    
    static DataBank()
    {
       students=new List<Student>();
        students.Add(new Student(){ StudentId=1, Name="Ayushi", ClassName="First Yaer BE CSC" });
        students.Add(new Student(){ StudentId=1, Name="Akram", ClassName="First Yaer BE CSC" });
        students.Add(new Student(){ StudentId=1, Name="Sachin", ClassName="First Yaer BE CSC" });
        students.Add(new Student(){ StudentId=1, Name="Devanshi", ClassName="First Yaer BE CSC" });
        students.Add(new Student(){ StudentId=1, Name="Sanvi", ClassName="First Yaer BE CSC" });
        students.Add(new Student(){ StudentId=1, Name="Riyanshi", ClassName="First Yaer BE CSC" });
    }

    public static List<Student> GetStudents(){
        return students;
    }
    
}
}