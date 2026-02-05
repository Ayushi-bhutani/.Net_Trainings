class Program
{
    static void Main()
    {
        GymManager gym = new GymManager();

        // Add Members
        gym.AddMember("Ayushi", "Premium", 6);
        gym.AddMember("Rahul", "Basic", 3);
        gym.AddMember("Sneha", "Platinum", 12);

        // Add Classes
        gym.AddClass(
            "Yoga",
            "Anita",
            DateTime.Now.AddDays(2),
            10);

        gym.AddClass(
            "Zumba",
            "Ravi",
            DateTime.Now.AddDays(5),
            5);

        // Register
        gym.RegisterForClass(1, "Yoga");
        gym.RegisterForClass(2, "Yoga");

        // Display Members
        Console.WriteLine("Members:");
        gym.DisplayMembers();

        // Display Classes
        Console.WriteLine("\nClasses:");
        gym.DisplayClasses();

        // Group by Membership
        Console.WriteLine("\nGrouped Members:");
        var grouped = gym.GroupMembersByMembershipType();

        foreach (var g in grouped)
        {
            Console.WriteLine(g.Key);
            foreach (var m in g.Value)
                Console.WriteLine($"  {m.Name}");
        }

        // Upcoming Classes
        Console.WriteLine("\nUpcoming Classes:");
        var upcoming = gym.GetUpcomingClasses();

        foreach (var c in upcoming)
            Console.WriteLine($"{c.ClassName} - {c.Schedule}");
    }
}
