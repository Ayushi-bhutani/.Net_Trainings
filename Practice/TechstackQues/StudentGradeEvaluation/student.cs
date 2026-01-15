namespace student{

    public class InvalidMarksException: Exception {
        public InvalidMarksException (string message): base(message){
            
        }
    }
    public class Student{
        public int Id{get; set;}
        public string Name{get; set;}
        public double Marks{get; set;}

        

    }
}