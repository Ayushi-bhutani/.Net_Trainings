using System;
using System.Xml.Serialization;
using System.IO;   // 👈 required

public class Book
{
    required public string Title { get; set; }
    required public string Author { get; set; }
    public int Copies { get; set; }

    public Book() { }
}

public class Program1
{
    public static void Main1(string[] args)
    {
        Book book = new Book
        {
            Title = "C# Basics",
            Author = "Ayushi",
            Copies = 5
        };

        XmlSerializer serializer = new XmlSerializer(typeof(Book));

        using (FileStream fs = new FileStream("book.xml", FileMode.Create))
        {
            serializer.Serialize(fs, book);
        }

        Console.WriteLine("XML file created successfully!");
    }
}
