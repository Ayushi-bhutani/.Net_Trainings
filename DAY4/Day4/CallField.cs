namespace OopsSessions{
    public class CallField{


        //entry point of execution 
        public static void Main(String[] args){

            //creating employee object of Employee class 
            Employee employee = new Employee();


            
            // Assigning value to Employee Id using setter property
            employee.Id1 = 100;
            string result = employee.DisplayEmpDetails();
            Console.WriteLine(result);
            

        }
    }
}