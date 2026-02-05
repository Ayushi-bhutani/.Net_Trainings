public class GymManager
{
    private List<Member> members = new List<Member>();
    private List<FitnessClass> classes = new List<FitnessClass>();

    private int memberCounter = 1;

    // Add Member
    public void AddMember(string name,
                          string membershipType,
                          int months)
    {
        var member = new Member
        {
            MemberId = memberCounter++,
            Name = name,
            MembershipType = membershipType,
            JoinDate = DateTime.Now,
            ExpiryDate = DateTime.Now.AddMonths(months)
        };

        members.Add(member);
    }

    // Add Fitness Class
    public void AddClass(string className,
                         string instructor,
                         DateTime schedule,
                         int maxParticipants)
    {
        classes.Add(new FitnessClass
        {
            ClassName = className,
            Instructor = instructor,
            Schedule = schedule,
            MaxParticipants = maxParticipants
        });
    }

    // Register for Class
    public bool RegisterForClass(int memberId,
                                 string className)
    {
        var member = members
            .FirstOrDefault(m => m.MemberId == memberId);

        if (member == null)
        {
            Console.WriteLine("Member not found.");
            return false;
        }

        if (member.ExpiryDate < DateTime.Now)
        {
            Console.WriteLine("Membership expired.");
            return false;
        }

        var fitnessClass = classes
            .FirstOrDefault(c =>
                c.ClassName.Equals(className,
                StringComparison.OrdinalIgnoreCase));

        if (fitnessClass == null)
        {
            Console.WriteLine("Class not found.");
            return false;
        }

        if (fitnessClass.AvailableSlots <= 0)
        {
            Console.WriteLine("Class full.");
            return false;
        }

        fitnessClass.RegisteredMembers.Add(memberId);
        return true;
    }

    // Group Members by Membership
    public Dictionary<string, List<Member>>
        GroupMembersByMembershipType()
    {
        return members
            .GroupBy(m => m.MembershipType)
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    // Upcoming Classes (Next 7 Days)
    public List<FitnessClass> GetUpcomingClasses()
    {
        DateTime today = DateTime.Now;
        DateTime nextWeek = today.AddDays(7);

        return classes
            .Where(c => c.Schedule >= today &&
                        c.Schedule <= nextWeek)
            .OrderBy(c => c.Schedule)
            .ToList();
    }

    // Display Helpers
    public void DisplayMembers()
    {
        foreach (var m in members)
        {
            Console.WriteLine(
                $"{m.MemberId} - {m.Name} | {m.MembershipType} | Exp: {m.ExpiryDate:d}");
        }
    }

    public void DisplayClasses()
    {
        foreach (var c in classes)
        {
            Console.WriteLine(
                $"{c.ClassName} | {c.Schedule} | Slots Left: {c.AvailableSlots}");
        }
    }
}
