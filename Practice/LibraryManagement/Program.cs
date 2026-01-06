namespace library
{
    public class Program
    {
        public static void Main(String[] args)
        {
            Book b = new Book(5);
            Console.WriteLine("How many copies are available");
            int availableCopies = Console.ReadLine();
            b.borrow();
            b.ReturnBook();
        }
    }
}