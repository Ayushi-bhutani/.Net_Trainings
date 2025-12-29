namespace partial{

    //partial keyword is used to make one class part of other so that two developers work on same class but need not neccesary to ionclude their code in the final project 
    public partial class Student{

        //constructor defined but member variables were defined in other class can be accessed here also
        public Student(string Name, int Roll){
            this.Name = Name;
            this.Roll = Roll;
            
        }

        
    }
}