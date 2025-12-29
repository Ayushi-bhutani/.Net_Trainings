namespace Static {
    public class Program {
        
        public static int RollNo{get; set;}
        //called only once because static constructor assigns a value to member variable and then constructor is never called again
        static Program(){
            RollNo = 1;
        }
        
        //everytime its called incremented by one
        public static int GetRollNo(){
            return RollNo++;
        }
        
    }
    public class Static {
        public static void Main(String[] args){
            int a = Program.GetRollNo();
            int b = Program.GetRollNo();
            Console.WriteLine(a);
            Console.WriteLine(b);

            string sent = "I am Ayushi";
            int count = sent.WordCount();
            Console.WriteLine(count);

        }
    }
}