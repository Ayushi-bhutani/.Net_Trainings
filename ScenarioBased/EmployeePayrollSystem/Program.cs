namespace payroll{
    public class Program{
        public static void Main(String[] args){
            FullTimeEmployee f = new FullTimeEmployee{
                Id = "1",
                name = "Ayushi",
                MonthlySalary = 100000000000000000,
                Bonus = 10
            };
            ContractEmployee c = new ContractEmployee{
                Id = "1",
                name = "Ayushi",
                hourlyRate = 10000,
                totalHours = 100
            };

            Console.WriteLine("Full time employee");
            Console.WriteLine($"{f.name}'s salary : {f.CalculateSalary()}");

            Console.WriteLine("Contract time employee");
            Console.WriteLine($"{c.name}'s salary : {c.CalculateSalary()}");


        }

    }
}