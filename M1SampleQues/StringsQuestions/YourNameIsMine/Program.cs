namespace name {

    public class Program {
        
        public static void Main(String[] args)
        {
            Console.WriteLine("Enter the man name");
            string man = Console.ReadLine();

            Console.WriteLine("Enter the woman name");
            string woman = Console.ReadLine();

            if (!manValid && !womanValid)
            {
                Console.WriteLine($"Both {man} and {woman} are invalid names");
                return;
            }
            if (!manValid)
            {
                Console.WriteLine($"{man} is an invalid name");
                return;
            }
            if (!womanValid)
            {
                Console.WriteLine($"{woman} is an invalid name");
                return;
            }

            if (Match.IsSubsequence(man, woman) || Match.IsSubsequence(woman, man))
            {
                Console.WriteLine($"{man} and {woman} are made for each other");

                int compatibility = Match.CompatibilityValue(man, woman);
                Console.WriteLine($"Compatibility Value is {compatibility}");
            }
            else
            {
                Console.WriteLine($"{man} and {woman} are not made for each other");
            }
        }
    }
}