using System;
namespace family{

    public class Holiday{

        public virtual string holidays(){
            return "Holi, Diwali";
        }
        

    }
    public class USHoliday : Holiday{
        public override string holidays(){
            return "New Year, Christmas";
        }
    }
    public class Program{
        public static void Main(String[] args){
            USHoliday ans= new USHoliday();
            string result = ans.holidays();
            Console.WriteLine(result);
    }
    }
    
    
}