using System;
using System.Collections.Generic;
namespace library{
public class LibraryUtility
{
    private static int idCounter = 0;

    // Stores all books
    private static SortedDictionary<int, Book> books =
        new SortedDictionary<int, Book>();

    // Add book with auto-incremented ID
    public void AddBook(string title, string author, string genre, int year)
    {
        Book book = new Book
        {
            Id = ++idCounter,
            Title = title,
            Author = author,
            Genre = genre,
            PublicationYear = year
        };

        books.Add(book.Id, book);
    }

    // Group books by genre (alphabetically)
    public SortedDictionary<string, List<Book>> GroupBooksByGenre()
    {
        SortedDictionary<string, List<Book>> result =
            new SortedDictionary<string, List<Book>>();

        foreach (var item in books.Values)
        {
            if (!result.ContainsKey(item.Genre))
            {
                result[item.Genre] = new List<Book>();
            }
            result[item.Genre].Add(item);
        }

        return result;
    }

    // Get books by a specific author
    public List<Book> GetBooksByAuthor(string author)
    {
        List<Book> result = new List<Book>();

        foreach (var book in books.Values)
        {
            if (book.Author.Equals(author, StringComparison.OrdinalIgnoreCase))
            {
                result.Add(book);
            }
        }

        return result;
    }

    // Get total books count
    public int GetTotalBooksCount()
    {
        return books.Count;
    }
}
}