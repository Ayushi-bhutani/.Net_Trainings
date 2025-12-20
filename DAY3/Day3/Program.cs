namespace OopsSessions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Program2 service = new Program2();

            Person p1 = new Person { Id = 1, Name = "Arul", Age = 20 };
            Person p2 = new Man { Id = 2, Name = "Kumar", Age = 24, Playing = "Football" };
            Person p3 = new Woman { Id = 3, Name = "Kumari", Age = 23, PlayManage = "Home & Rugby" };
            Person p4 = new Child { Id = 4, Name = "Anki", Age = 5, WatchingCartoon = "Chota Bheem" };

            Console.WriteLine(service.GetDetails(p1));
            Console.WriteLine(service.GetDetails(p2));
            Console.WriteLine(service.GetDetails(p3));
            Console.WriteLine(service.GetDetails(p4));
        }
    }
}
