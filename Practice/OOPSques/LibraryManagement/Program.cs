using System;

namespace library
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("How many copies are available: ");

            int copies;

            while (!int.TryParse(Console.ReadLine(), out copies) || copies < 0)
            {
                Console.Write("Enter a valid non-negative number: ");
            }

            Book b = new Book(copies);

            b.Borrow();
            Console.WriteLine($"Books left after borrowing 1 book : {b.AvailableCopies}");
            b.ReturnBook();
            Console.WriteLine($"Books left after returning 1 book {b.AvailableCopies} ");

        }
    }
}
