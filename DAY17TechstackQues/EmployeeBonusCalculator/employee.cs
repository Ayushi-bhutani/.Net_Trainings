namespace employee{

    public class InvalidSalaryException : Exception{
        public InvalidSalaryException(string message): base(message){
            
        }
    }
    public class Employee{
        public int EmpId{get; set;}
        public string Name{get; set;}
        public double Salary{get; set;}



    }
}