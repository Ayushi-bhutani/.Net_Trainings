class Program
{
    static void Main()
    {
        HospitalManager hm = new HospitalManager();

        // Add Patients
        hm.AddPatient("Ayushi", 21, "B+");
        hm.AddPatient("Rahul", 30, "O+");

        // Add Doctors
        hm.AddDoctor("Dr. Mehta", "Cardiology");
        hm.AddDoctor("Dr. Sharma", "Dermatology");

        // Add Slots
        hm.AddDoctorSlot(1, DateTime.Today.AddHours(10));
        hm.AddDoctorSlot(1, DateTime.Today.AddHours(12));

        // Schedule Appointment
        hm.ScheduleAppointment(
            1,
            1,
            DateTime.Today.AddHours(10));

        // Display Data
        Console.WriteLine("Patients:");
        hm.DisplayPatients();

        Console.WriteLine("\nDoctors:");
        hm.DisplayDoctors();

        Console.WriteLine("\nAppointments:");
        hm.DisplayAppointments();

        // Group Doctors
        Console.WriteLine("\nDoctors by Specialization:");
        var grouped = hm.GroupDoctorsBySpecialization();

        foreach (var g in grouped)
        {
            Console.WriteLine(g.Key);
            foreach (var d in g.Value)
                Console.WriteLine($"  {d.Name}");
        }

        // Today Appointments
        Console.WriteLine("\nToday's Appointments:");
        var today = hm.GetTodayAppointments();

        foreach (var a in today)
            Console.WriteLine($"ApptID: {a.AppointmentId}");
    }
}
