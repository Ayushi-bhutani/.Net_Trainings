namespace hazard{
    
    public class Program{
            // entry point of execution
            public static void Main(String[] args){

                //using try catch block to handle exceptions
                try{
                Console.WriteLine("Enter arm precision (0.0- 1.0)");
                double armPrecision = Double.Parse(Console.ReadLine());

                Console.WriteLine("Enter worker density (1- 20)");
                int workerDensity = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter machinery state (Worn/faulty/critical)");
                string machineryState = Console.ReadLine();

                //creating object for RobotHazardAuditor class 
                RobotHazardAuditor auditor = new RobotHazardAuditor();
                double result = auditor.calculateHazardRisk(armPrecision, workerDensity, machineryState);

                Console.WriteLine($"Robot Hazard Risk Score: {result}");
            }
            catch(Exception ex){
            Console.WriteLine(ex.Message);
        }
        }
        
    }
}