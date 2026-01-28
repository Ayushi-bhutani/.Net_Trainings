namespace hotel
{
    public class UserInterface
    {
        
        public static void Main(String[] args)
        {
                     
            Console.WriteLine("Enter Deluxe Room Details:");
            Console.Write("Guest Name: ");
            string deluxeGuest = Console.ReadLine();

            Console.Write("Rate per Night: ");
            double deluxeRate = double.Parse(Console.ReadLine());

            Console.Write("Nights Stayed: ");
            int deluxeNights = int.Parse(Console.ReadLine());

            Console.Write("Joining Year: ");
            int deluxeJoinYear = int.Parse(Console.ReadLine());

            HotelRoom deluxeRoom = new HotelRoom("Deluxe", deluxeRate, deluxeGuest);

            int deluxeMembership = deluxeRoom.calculateMembershipYears(deluxeJoinYear);
            double deluxeBill = deluxeRoom.calculateTotalBill(deluxeNights,deluxeJoinYear );


            Console.WriteLine("Enter Suite Room Details: ");
            
            Console.Write("Guest Name: ");
            string suiteGuest = Console.ReadLine();

            Console.Write("Rate per Night: ");
            double suiteRate = double.Parse(Console.ReadLine());

            Console.Write("Nights Stayed: ");
            int suiteNights = int.Parse(Console.ReadLine());

            Console.Write("Joining Year: ");
            int suiteJoinYear = int.Parse(Console.ReadLine());

            HotelRoom suiteRoom = new HotelRoom("Suite", suiteRate, suiteGuest);

            int suiteMembership = suiteRoom.calculateMembershipYears(suiteJoinYear);
            double suiteBill = suiteRoom.calculateTotalBill(suiteNights,suiteJoinYear );


            Console.WriteLine("Room Summary: ");
            Console.WriteLine($"Deluxe Room: {deluxeGuest}, {deluxeRate} per night, Membership: {deluxeJoinYear} years");
            Console.WriteLine($"Suite Room: {suiteGuest}, {suiteRate} per night, Membership: {suiteJoinYear} years");
            
            Console.WriteLine("Total Bill: ");

            Console.WriteLine($"For {deluxeGuest} (Deluxe): {deluxeBill}");
            Console.WriteLine($"For {suiteGuest} (Suite): {suiteBill}");

        }
    }
}