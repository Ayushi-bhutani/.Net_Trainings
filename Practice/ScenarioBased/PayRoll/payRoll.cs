using System;
using System.Collections.Generic;
using System.Linq;

namespace payroll
{   
    //defining abstract class
    public abstract class EmployeeRecord
    {
        public string EmployeeName { get; set; }
        public double[] WeeklyHours { get; set; }

        public abstract double GetMonthlyPay();
    }

    //one class inheriting properties of other class
    public class FullTimeEmployee : EmployeeRecord
    {
        public double HourlyRate { get; set; }
        public double MonthlyBonus { get; set; }

        public override double GetMonthlyPay()
        {
            return WeeklyHours.Sum() * HourlyRate + MonthlyBonus;
        }
    }
    //one class inheriting properties of other class
    public class ContractEmployee : EmployeeRecord
    {
        public double HourlyRate { get; set; }

        public override double GetMonthlyPay()
        {
            return WeeklyHours.Sum() * HourlyRate;
        }
    }
}
