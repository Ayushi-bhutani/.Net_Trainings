namespace online{
    public abstract class Course{


        public string Title{get; set;}
        public int Duration{get; set;}

        protected Course(string title,int duration){
            Title = title;
            Duration = duration;
        }
        public abstract double CalculateFee();
    }

    public class SelfPacedCourse : Course{
        public SelfPacedCourse(string title,int duration) : base( title, duration) {}
        public override double CalculateFee(){
            return duration*100;

        }

    }

    public class InstructorLedCourse : Course{
        public InstructorLedCourse(string title,int duration) : base( title, duration) {}
        public override double CalculateFee(){
            return duration*150;
        }
        
    }
}