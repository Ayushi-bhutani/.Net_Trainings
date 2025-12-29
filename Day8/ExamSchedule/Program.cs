namespace Management{
    public class Program{
        public static void Main(String[] args){

            //DataBank is static class so we can call its method directly with classname or else we need to create object if that is not static
            var localStudents = DataBank.GetStudents();
            Console.WriteLine($"\n Student Names:");
            foreach(var s in localStudents){
                Console.WriteLine($"{s.Name}|");
            }

        }
    }
}