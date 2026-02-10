using System.Collections.Concurrent;
using System.Linq.Expressions;
using System.Net;
using System.Runtime.Intrinsics.X86;
using System.Xml;

namespace library
{
    public class Program
    {
        public static void Main(string[] args){
            Author a1 = new Author("Ayushi", "USA");
            Author a2 = new Author("Akru", "USA");
            Book b1 = new Book("C# Basics", 500, a1);
            Book b2 = new Book("OOP Mastery", 700, a2);

            PrintBook(b1);
            PrintBook(b2);

        }
        static void PrintBook(Book b)
        {
            Console.WriteLine(b.Title);
            Console.WriteLine(b.price);
            Console.WriteLine(b.Author.AuthorName);
            Console.WriteLine(b.Author.Country);
            

        }
    }
}