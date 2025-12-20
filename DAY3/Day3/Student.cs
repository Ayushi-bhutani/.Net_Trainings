using System;
public class Prac12{

    public class Student{

        public string name;
        public int rollNo;
        public int marks;
        public int section;
    


        //contructor
        public Student(string n, int r, int m, int s){
            name=n;
            rollNo=r;
            marks=m;
            section=s;
        }
        

        //function to get student Details
        public string GetDetails(){
            return "Id " + rollNo + "Name" +name;
        }
    }
    
}