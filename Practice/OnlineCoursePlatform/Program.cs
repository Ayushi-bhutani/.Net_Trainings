using System.Collections.Generic;

namespace online{
    public class Program{
        public static void Main(String[] args){
            var courses = new List<Course>{
                new SelfPacedCourse("DSA", 10),
                new InstructorLedCourse("C#", 12)
            };

            foreach (var c in courses){
                Console.WriteLine($"{c.Title} - Fee: {c.CalculateFee()}");
            }
        }
    }
}