namespace employee{
    public class Program {

        public Employee CalculateBonus(int empId, string name, double salary){
            Employee employee = new Employee();
            if(salary <= 0){
                throw new InvalidSalaryException("Invalid salary");
            }
            employee.EmpId= empId;
            employee.Name= name;
            employee.Salary= salary + (salary * 0.10);

            
            return employee;
        }
 
        public static void Main(String[] args){
            Program p = new Program();
            int empId = int.Parse(Console.ReadLine());
            string name = Console.ReadLine();
            double salary = double.Parse(Console.ReadLine());
            
            try{
                Employee employee = p.CalculateBonus(empId, name, salary);
                Console.WriteLine("Bonus calculated successfully");

            }catch(InvalidSalaryException ex){
                Console.WriteLine(ex.Message);
            }
        }
    }
}