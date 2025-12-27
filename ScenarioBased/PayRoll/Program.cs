using System;
using System.Collections.Generic;
using System.Linq;

namespace payroll
{
    public class Program
    {   
        //defining a list to maintain record
        public static List<EmployeeRecord> PayrollBoard = new List<EmployeeRecord>();

        public void RegisterEmployee(EmployeeRecord record)
        {
            PayrollBoard.Add(record);
        }
        //dictionary to GetOvertimeWeekCounts
        public Dictionary<string, int> GetOvertimeWeekCounts(List<EmployeeRecord> records, double hoursThreshold)
        {
            Dictionary<string, int> map = new Dictionary<string, int>();

            foreach (var emp in records)
            {
                int weeks = emp.WeeklyHours.Count(h => h >= hoursThreshold);

                if (weeks > 0)
                    map[emp.EmployeeName] = weeks;
            }

            return map;
        }
        //method to CalculateAverageMonthlyPay
        public double CalculateAverageMonthlyPay()
        {
            if (PayrollBoard.Count == 0)
                return 0;

            return PayrollBoard.Average(e => e.GetMonthlyPay());
        }

        //entry point 
        public static void Main(string[] args)
        {
            Program p = new Program();
            int choice;

            do
            {
                Console.WriteLine("1. Register Employee");
                Console.WriteLine("2. Show Overtime Summary");
                Console.WriteLine("3. Calculate Average Monthly Pay");
                Console.WriteLine("4. Exit\n");

                Console.WriteLine("Enter your choice:");
                choice = int.Parse(Console.ReadLine());

                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Select Employee Type (1-Full Time, 2-Contract):");
                        int type = int.Parse(Console.ReadLine());

                        Console.WriteLine("\nEnter Employee Name:");
                        string name = Console.ReadLine();

                        double[] hours = new double[4];
                        Console.WriteLine("\nEnter weekly hours (Week 1 to 4):");
                        for (int i = 0; i < 4; i++)
                            hours[i] = double.Parse(Console.ReadLine());

                        if (type == 1)
                        {
                            Console.WriteLine("\nEnter Hourly Rate:");
                            double rate = double.Parse(Console.ReadLine());

                            Console.WriteLine("\nEnter Monthly Bonus:");
                            double bonus = double.Parse(Console.ReadLine());

                            p.RegisterEmployee(new FullTimeEmployee
                            {
                                EmployeeName = name,
                                WeeklyHours = hours,
                                HourlyRate = rate,
                                MonthlyBonus = bonus
                            });
                        }
                        else
                        {
                            Console.WriteLine("\nEnter Hourly Rate:");
                            double rate = double.Parse(Console.ReadLine());

                            p.RegisterEmployee(new ContractEmployee
                            {
                                EmployeeName = name,
                                WeeklyHours = hours,
                                HourlyRate = rate
                            });
                        }

                        Console.WriteLine("\nEmployee registered successfully\n");
                        Console.WriteLine("---\n");
                        break;

                    case 2:
                        Console.WriteLine("Enter hours threshold:");
                        double t = double.Parse(Console.ReadLine());

                        var result = p.GetOvertimeWeekCounts(PayrollBoard, t);

                        Console.WriteLine();
                        if (result.Count == 0)
                            Console.WriteLine("No overtime recorded this month\n");
                        else
                            foreach (var kv in result)
                                Console.WriteLine($"{kv.Key} - {kv.Value}");

                        Console.WriteLine("\n---\n");
                        break;

                    case 3:
                        Console.WriteLine($"Overall average monthly pay: {p.CalculateAverageMonthlyPay()}\n");
                        Console.WriteLine("---\n");
                        break;

                    case 4:
                        Console.WriteLine("Logging off — Payroll processed successfully!");
                        break;
                }

            } while (choice != 4);
        }
    }
}
