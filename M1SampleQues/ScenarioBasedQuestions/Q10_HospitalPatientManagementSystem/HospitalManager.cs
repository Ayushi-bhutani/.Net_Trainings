public class HospitalManager
{
    private List<Patient> patients = new List<Patient>();
    private List<Doctor> doctors = new List<Doctor>();
    private List<Appointment> appointments = new List<Appointment>();

    private int patientCounter = 1;
    private int doctorCounter = 1;
    private int appointmentCounter = 1;

    // Add Patient
    public void AddPatient(string name, int age, string bloodGroup)
    {
        patients.Add(new Patient
        {
            PatientId = patientCounter++,
            Name = name,
            Age = age,
            BloodGroup = bloodGroup
        });
    }

    // Add Doctor
    public void AddDoctor(string name, string specialization)
    {
        doctors.Add(new Doctor
        {
            DoctorId = doctorCounter++,
            Name = name,
            Specialization = specialization
        });
    }

    // Add Doctor Availability
    public void AddDoctorSlot(int doctorId, DateTime slot)
    {
        var doctor = doctors.FirstOrDefault(d => d.DoctorId == doctorId);
        if (doctor != null)
            doctor.AvailableSlots.Add(slot);
    }

    // Schedule Appointment
    public bool ScheduleAppointment(int patientId,
                                    int doctorId,
                                    DateTime time)
    {
        var doctor = doctors.FirstOrDefault(d => d.DoctorId == doctorId);
        var patient = patients.FirstOrDefault(p => p.PatientId == patientId);

        if (doctor == null || patient == null)
        {
            Console.WriteLine("Doctor or Patient not found.");
            return false;
        }

        if (!doctor.AvailableSlots.Contains(time))
        {
            Console.WriteLine("Slot not available.");
            return false;
        }

        appointments.Add(new Appointment
        {
            AppointmentId = appointmentCounter++,
            PatientId = patientId,
            DoctorId = doctorId,
            AppointmentTime = time,
            Status = "Scheduled"
        });

        doctor.AvailableSlots.Remove(time);
        return true;
    }

    // Group Doctors by Specialization
    public Dictionary<string, List<Doctor>>
        GroupDoctorsBySpecialization()
    {
        return doctors
            .GroupBy(d => d.Specialization)
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    // Today Appointments
    public List<Appointment> GetTodayAppointments()
    {
        DateTime today = DateTime.Today;

        return appointments
            .Where(a => a.AppointmentTime.Date == today)
            .ToList();
    }

    // Display Helpers
    public void DisplayPatients()
    {
        foreach (var p in patients)
            Console.WriteLine($"{p.PatientId} - {p.Name}");
    }

    public void DisplayDoctors()
    {
        foreach (var d in doctors)
            Console.WriteLine($"{d.DoctorId} - {d.Name} ({d.Specialization})");
    }

    public void DisplayAppointments()
    {
        foreach (var a in appointments)
        {
            Console.WriteLine(
                $"ApptID:{a.AppointmentId} | Patient:{a.PatientId} | " +
                $"Doctor:{a.DoctorId} | {a.AppointmentTime} | {a.Status}");
        }
    }
}
