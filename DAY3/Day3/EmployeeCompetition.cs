using System;
namespace EmployeeCompetitions;

//creating Employee class 
public class Employee{

    // #Region Declaration
    public string Name{get; set;}
    public int EmployeeId{get; set;}
    // #endregion 


    // #region Constructor 
    public Employee(int employeeId, string name){
        EmployeeId = employeeId;
        Name = name;
    }
    // #endregion
 
}


//creating competitions class
public class Competitions{

    // #Region Declaration
    public int CompetitionId { get; set; }
    public string CompetitionName{get; set;}
    // #endregion 


    #region Constructor 
    public Competitions(int competitionId, string competitionName){
        CompetitionId = competitionId;
        CompetitionName = competitionName;
    }
    #endregion



}
public class Participation
{
    public int EmployeeId{get; set; }
    public int CompetitionId{get; set;}

}

//creating finaldetails class containing winner results and id info
public class FinalDetails{
    public static void Main(String[] args){
        Employee e1 = new Employee(1, "Ayushi");
        Employee e2 = new Employee(2, "Akram");
        Employee e3 = new Employee(3, "Anuska");






    }
}
