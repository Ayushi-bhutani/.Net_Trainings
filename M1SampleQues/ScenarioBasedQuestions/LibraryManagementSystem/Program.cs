using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        LibraryUtility utility = new LibraryUtility();
        int choice;

        do
        {
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Group Books By Genre");
            Console.WriteLine("3. Search Books By Author");
            Console.WriteLine("4. Show Statistics");
            Console.WriteLine("5. Exit");
            Console.WriteLine("Enter your choice");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter Title");
                    string title = Console.ReadLine();

                    Console.WriteLine("Enter Author");
                    string author = Console.ReadLine();

                    Console.WriteLine("Enter Genre");
                    string genre = Console.ReadLine();

                    Console.WriteLine("Enter Publication Year");
                    int year = int.Parse(Console.ReadLine());

                    utility.AddBook(title, author, genre, year);
                    Console.WriteLine("Book added successfully\n");
                    break;

                case 2:
                    var grouped = utility.GroupBooksByGenre();
                    foreach (var g in grouped)
                    {
                        Console.WriteLine(g.Key);
                        foreach (var b in g.Value)
                        {
                            Console.WriteLine($"{b.Title} - {b.Author}");
                        }
                        Console.WriteLine();
                    }
                    break;

                case 3:
                    Console.WriteLine("Enter Author Name");
                    string searchAuthor = Console.ReadLine();

                    List<Book> booksByAuthor =
                        utility.GetBooksByAuthor(searchAuthor);

                    if (booksByAuthor.Count == 0)
                        Console.WriteLine("No books found\n");
                    else
                    {
                        foreach (var b in booksByAuthor)
                        {
                            Console.WriteLine($"{b.Title} ({b.Genre})");
                        }
                        Console.WriteLine();
                    }
                    break;

                case 4:
                    Console.WriteLine("Total Books: " +
                        utility.GetTotalBooksCount());

                    var genreStats = utility.GroupBooksByGenre();
                    foreach (var g in genreStats)
                    {
                        Console.WriteLine($"{g.Key}: {g.Value.Count}");
                    }
                    Console.WriteLine();
                    break;
            }

        } while (choice != 5);
    }
}
