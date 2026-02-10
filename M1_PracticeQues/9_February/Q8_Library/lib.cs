using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace library {
    public class Author {
        public string AuthorName{get; set;}
        public string Country{get; set;}

        public Author(string name, string c)
        {
            AuthorName = name;
            Country = c;
        }
    }
    public class Book
    {
        public string Title{get; set;}
        public double price{get; set;}
        public Author Author {get; set;}

        public Book(string Title,double price ,Author author)
        {
            this.Title= Title;
            this.price = price;
            Author = author;
        }

    }
}