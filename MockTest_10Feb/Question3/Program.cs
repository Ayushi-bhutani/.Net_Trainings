using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalSystem
{
    // =========================================
    // INTERFACES & ENUMS
    // =========================================

    public interface IPatient
    {
        int PatientId { get; }
        string Name { get; }
        DateTime DateOfBirth { get; }
        BloodType BloodType { get; }
    }

    public enum BloodType { A, B, AB, O }
    public enum Condition { Stable, Critical, Recovering }

    // =========================================
    // 1️⃣ PRIORITY QUEUE
    // =========================================

    public class PriorityQueue<T> where T : IPatient
    {
        private SortedDictionary<int, Queue<T>> _queues = new();

        public void Enqueue(T patient, int priority)
        {
            if (patient == null)
                throw new ArgumentNullException(nameof(patient));

            if (priority < 1 || priority > 5)
                throw new ArgumentOutOfRangeException(
                    nameof(priority),
                    "Priority must be 1 (highest) to 5 (lowest)");

            if (!_queues.ContainsKey(priority))
                _queues[priority] = new Queue<T>();

            _queues[priority].Enqueue(patient);
        }

        public T Dequeue()
        {
            if (_queues.Count == 0)
                throw new InvalidOperationException("Queue is empty");

            foreach (var kvp in _queues)
            {
                if (kvp.Value.Count > 0)
                    return kvp.Value.Dequeue();
            }
            
            throw new InvalidOperationException("Queue is empty");
        }

        public T Peek()
        {
            if (_queues.Count == 0)
                throw new InvalidOperationException("Queue is empty");

            foreach (var kvp in _queues)
            {
                if (kvp.Value.Count > 0)
                    return kvp.Value.Peek();
            }

            throw new InvalidOperationException("Queue is empty");
        }

        public int GetCountByPriority(int priority)
        {
            if (priority < 1 || priority > 5)
                throw new ArgumentOutOfRangeException();

            if (_queues.ContainsKey(priority))
                return _queues[priority].Count;

            return 0;
        }
    }

    // =========================================
    // 2️⃣ MEDICAL RECORD
    // =========================================

    public class MedicalRecord<T> where T : IPatient
    {
        private T _patient;

        private List<(string Diagnosis, DateTime Date)>
            _diagnoses = new();

        private Dictionary<DateTime, string>
            _treatments = new();

        public MedicalRecord(T patient)
        {
            _patient = patient;
        }

        public void AddDiagnosis(string diagnosis, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(diagnosis))
                throw new ArgumentException("Diagnosis cannot be empty");

            _diagnoses.Add((diagnosis, date));
        }

        public void AddTreatment(string treatment, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(treatment))
                throw new ArgumentException("Treatment cannot be empty");

            _treatments[date] = treatment;
        }

        public IEnumerable<KeyValuePair<DateTime, string>>
            GetTreatmentHistory()
        {
            return _treatments.OrderBy(t => t.Key);
        }
    }

    // =========================================
    // 3️⃣ PATIENT TYPES
    // =========================================

    public class PediatricPatient : IPatient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public BloodType BloodType { get; set; }

        public string GuardianName { get; set; }
        public double Weight { get; set; }
    }

    public class GeriatricPatient : IPatient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public BloodType BloodType { get; set; }

        public List<string> ChronicConditions { get; }
            = new();

        public int MobilityScore { get; set; }
    }

    // =========================================
    // 4️⃣ MEDICATION SYSTEM
    // =========================================

    public class MedicationSystem<T> where T : IPatient
    {
        private Dictionary<T,
            List<(string medication, DateTime time)>>
            _medications = new();

        public void PrescribeMedication(
            T patient,
            string medication,
            Func<T, bool> dosageValidator)
        {
            if (patient == null)
                throw new ArgumentNullException(nameof(patient));

            if (string.IsNullOrWhiteSpace(medication))
                throw new ArgumentException(nameof(medication));

            bool isValid = dosageValidator(patient);

            if (!isValid)
                throw new InvalidOperationException(
                    "Dosage validation failed");

            if (!_medications.ContainsKey(patient))
                _medications[patient] = new();

            _medications[patient]
                .Add((medication, DateTime.Now));
        }

        public bool CheckInteractions(
            T patient,
            string newMedication)
        {
            if (!_medications.ContainsKey(patient))
                return false;

            var meds = _medications[patient];

            var interactionPairs =
                new List<(string, string)>
            {
                ("Aspirin","Warfarin"),
                ("Ibuprofen","Prednisone"),
                ("Metformin","Cimetidine")
            };

            foreach (var med in meds)
            {
                if (interactionPairs.Any(pair =>
                    (pair.Item1 == med.medication &&
                     pair.Item2 == newMedication) ||
                    (pair.Item2 == med.medication &&
                     pair.Item1 == newMedication)))
                {
                    return true;
                }
            }

            return false;
        }
    }

    // =========================================
    // 5️⃣ TEST PROGRAM
    // =========================================

    public class Program
    {
        public static void Main()
        {
            var p1 = new PediatricPatient
            {
                PatientId = 1,
                Name = "Aarav",
                DateOfBirth = new DateTime(2018, 5, 10),
                BloodType = BloodType.O,
                GuardianName = "Mr Sharma",
                Weight = 18.5
            };

            var p2 = new PediatricPatient
            {
                PatientId = 2,
                Name = "Anaya",
                DateOfBirth = new DateTime(2020, 3, 22),
                BloodType = BloodType.A,
                GuardianName = "Mrs Verma",
                Weight = 14.2
            };

            var g1 = new GeriatricPatient
            {
                PatientId = 3,
                Name = "Mr Mehta",
                DateOfBirth = new DateTime(1950, 7, 1),
                BloodType = BloodType.B,
                MobilityScore = 4
            };

            g1.ChronicConditions.Add("Diabetes");

            var queue = new PriorityQueue<IPatient>();

            queue.Enqueue(p1, 2);
            queue.Enqueue(p2, 1);
            queue.Enqueue(g1, 3);

            Console.WriteLine("Next: " +
                queue.Peek().Name);

            var record =
                new MedicalRecord<PediatricPatient>(p1);

            record.AddDiagnosis(
                "Viral Fever",
                DateTime.Now.AddDays(-3));

            record.AddTreatment(
                "Paracetamol",
                DateTime.Now.AddDays(-2));

            Console.WriteLine("\nTreatment History:");

            foreach (var t in record.GetTreatmentHistory())
                Console.WriteLine($"{t.Key} → {t.Value}");

            var medSystem =
                new MedicationSystem<PediatricPatient>();

            medSystem.PrescribeMedication(
                p1,
                "Amoxicillin",
                patient => patient.Weight > 10);

            Console.WriteLine(
                "\nMedication prescribed successfully");
        }
    }
}
