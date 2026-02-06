using System;

class BonusCalculator
{
    static void Main()
    {
        int[] salaries = { 5000, 0, 7000 };
        int bonus = 1000;
        foreach(int i in salaries)
        {
            try
        {
            int bonusPerSalary = bonus/salaries[i];
            Console.WriteLine($" Employee {i+1} Bonus per salary: {bonusPerSalary}");

        }
            catch (DivideByZeroException)
        {
            Console.WriteLine($"Employee {i+1} Cannot divide by zero");
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine($"Employee {i+1} Cannot divide by zero");
        }

        finally
            {
                Console.WriteLine($"Employee {i+1} processed");
            }


        }
        
        

        // TODO:
        // 1. Loop through salaries
        // 2. Divide bonus by salary
        // 3. Handle DivideByZeroException
        // 4. Continue processing remaining employees
    }
}