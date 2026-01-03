namespace payroll{

    public abstract class Employee{
        public string? Id {get; set;}
        public string? name{get; set;}
        public abstract decimal CalculateSalary();
    }

    public class FullTimeEmployee: Employee{

        public decimal MonthlySalary{get; set;}
        public decimal Bonus{get; set;}

        public override decimal CalculateSalary(){
            return MonthlySalary + Bonus;
        }

    }
    public class ContractEmployee: Employee{
        public decimal hourlyRate{get; set;}
        public decimal totalHours{get; set;}

        public override decimal CalculateSalary(){
            return hourlyRate*totalHours;
        }
    }

}