using System;

class MenuSystem
{
    static void Main()
    {
        /*
         * MENU-DRIVEN PROGRAM
         * -------------------
         * - do-while keeps the menu running
         * - switch executes user-selected option
         * - exits only when user chooses Exit
         */

        int choice;

        do
        {
            Console.WriteLine("\n====== MAIN MENU ======");
            Console.WriteLine("1. Say Hello");
            Console.WriteLine("2. Add Two Numbers");
            Console.WriteLine("3. Check Even or Odd");
            Console.WriteLine("4. Display Current Date & Time");
            Console.WriteLine("0. Exit");
            Console.Write("Enter your choice: ");

            bool isValid = int.TryParse(Console.ReadLine(), out choice);

            if (!isValid)
            {
                Console.WriteLine("Invalid input! Enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Hello! Welcome to the Menu System.");
                    break;

                case 2:
                    Console.Write("Enter first number: ");
                    int a = int.Parse(Console.ReadLine());

                    Console.Write("Enter second number: ");
                    int b = int.Parse(Console.ReadLine());

                    Console.WriteLine("Sum = " + (a + b));
                    break;

                case 3:
                    Console.Write("Enter a number: ");
                    int num = int.Parse(Console.ReadLine());

                    Console.WriteLine(num % 2 == 0 ? "Even Number" : "Odd Number");
                    break;

                case 4:
                    Console.WriteLine("Current Date & Time: " + DateTime.Now);
                    break;

                case 0:
                    Console.WriteLine("Exiting Program...");
                    break;

                default:
                    Console.WriteLine("Invalid choice! Try again.");
                    break;
            }

        } while (choice != 0);
    }
}
