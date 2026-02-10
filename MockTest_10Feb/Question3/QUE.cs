// // Scenario 3: Hospital Patient Management System
// // Problem: Create a type-safe medical records system with different patient types and treatments.
// // csharp
// public interface IPatient
// {
//     int PatientId { get; }
//     string Name { get; }
//     DateTime DateOfBirth { get; }
//     BloodType BloodType { get; }
// }

// public enum BloodType { A, B, AB, O }
// public enum Condition { Stable, Critical, Recovering }

// // 1. Generic patient queue with priority
// public class PriorityQueue<T> where T : IPatient
// {
//     private SortedDictionary<int, Queue<T>> _queues = new();
    
//     // TODO: Enqueue patient with priority (1=highest, 5=lowest)
//     public void Enqueue(T patient, int priority)
//     {
//         // Validate priority range
//         // Create queue if doesn't exist for priority
//     }
    
//     // TODO: Dequeue highest priority patient
//     public T Dequeue()
//     {
//         // Return patient from highest non-empty priority
//         // Throw if empty
//     }
    
//     // TODO: Peek without removing
//     public T Peek()
//     {
//         // Look at next patient
//     }
    
//     // TODO: Get count by priority
//     public int GetCountByPriority(int priority)
//     {
//         // Return count for specific priority
//     }
// }

// // 2. Generic medical record
// public class MedicalRecord<T> where T : IPatient
// {
//     private T _patient;
//     private List<string> _diagnoses = new();
//     private Dictionary<DateTime, string> _treatments = new();
    
//     // TODO: Add diagnosis with date
//     public void AddDiagnosis(string diagnosis, DateTime date)
//     {
//         // Add to diagnoses list
//     }
    
//     // TODO: Add treatment
//     public void AddTreatment(string treatment, DateTime date)
//     {
//         // Add to treatments dictionary
//     }
    
//     // TODO: Get treatment history
//     public IEnumerable<KeyValuePair<DateTime, string>> GetTreatmentHistory()
//     {
//         // Return sorted by date
//     }
// }

// // 3. Specialized patient types
// public class PediatricPatient : IPatient
// {
//     public int PatientId { get; set; }
//     public string Name { get; set; }
//     public DateTime DateOfBirth { get; set; }
//     public BloodType BloodType { get; set; }
//     public string GuardianName { get; set; }
//     public double Weight { get; set; } // in kg
// }

// public class GeriatricPatient : IPatient
// {
//     public int PatientId { get; set; }
//     public string Name { get; set; }
//     public DateTime DateOfBirth { get; set; }
//     public BloodType BloodType { get; set; }
//     public List<string> ChronicConditions { get; } = new();
//     public int MobilityScore { get; set; } // 1-10
// }

// // 4. Generic medication system
// public class MedicationSystem<T> where T : IPatient
// {
//     private Dictionary<T, List<(string medication, DateTime time)>> _medications = new();
    
//     // TODO: Prescribe medication with dosage validation
//     public void PrescribeMedication(T patient, string medication, 
//         Func<T, bool> dosageValidator)
//     {
//         // Check if dosage is valid for patient type
//         // Pediatric: weight-based validation
//         // Geriatric: kidney function consideration
//     }
    
//     // TODO: Check for drug interactions
//     public bool CheckInteractions(T patient, string newMedication)
//     {
//         // Return true if interaction with existing medications
//     }
// }


// public class Program
// {
//     public static void Main()
//     {
//         // =========================================
//         // 1️⃣ Create Patients
//         // =========================================
//         var p1 = new PediatricPatient
//         {
//             PatientId = 1,
//             Name = "Aarav",
//             DateOfBirth = new DateTime(2018, 5, 10),
//             BloodType = BloodType.O,
//             GuardianName = "Mr. Sharma",
//             Weight = 18.5
//         };

//         var p2 = new PediatricPatient
//         {
//             PatientId = 2,
//             Name = "Anaya",
//             DateOfBirth = new DateTime(2020, 3, 22),
//             BloodType = BloodType.A,
//             GuardianName = "Mrs. Verma",
//             Weight = 14.2
//         };

//         var g1 = new GeriatricPatient
//         {
//             PatientId = 3,
//             Name = "Mr. Mehta",
//             DateOfBirth = new DateTime(1950, 7, 1),
//             BloodType = BloodType.B,
//             MobilityScore = 4
//         };
//         g1.ChronicConditions.Add("Diabetes");

//         var g2 = new GeriatricPatient
//         {
//             PatientId = 4,
//             Name = "Mrs. Kaur",
//             DateOfBirth = new DateTime(1945, 11, 12),
//             BloodType = BloodType.AB,
//             MobilityScore = 6
//         };
//         g2.ChronicConditions.Add("Hypertension");

//         // =========================================
//         // 2️⃣ Priority Queue
//         // =========================================
//         var queue = new PriorityQueue<IPatient>();

//         queue.Enqueue(p1, 2);
//         queue.Enqueue(p2, 1); // highest priority
//         queue.Enqueue(g1, 3);
//         queue.Enqueue(g2, 2);

//         Console.WriteLine("=== PRIORITY PROCESSING ===");

//         Console.WriteLine("Next Patient: " +
//             queue.Peek().Name);

//         while (true)
//         {
//             try
//             {
//                 var patient = queue.Dequeue();
//                 Console.WriteLine(
//                     $"Processing: {patient.Name}");
//             }
//             catch
//             {
//                 break; // queue empty
//             }
//         }

//         // =========================================
//         // 3️⃣ Medical Records
//         // =========================================
//         var record1 = new MedicalRecord<PediatricPatient>(p1);
//         var record2 = new MedicalRecord<GeriatricPatient>(g1);

//         record1.AddDiagnosis(
//             "Viral Fever", DateTime.Now.AddDays(-3));

//         record1.AddTreatment(
//             "Paracetamol Syrup", DateTime.Now.AddDays(-2));

//         record2.AddDiagnosis(
//             "High Blood Pressure", DateTime.Now.AddDays(-5));

//         record2.AddTreatment(
//             "BP Medication", DateTime.Now.AddDays(-4));

//         Console.WriteLine("\n=== TREATMENT HISTORY ===");

//         foreach (var t in record1.GetTreatmentHistory())
//             Console.WriteLine(
//                 $"{t.Key} → {t.Value}");

//         // =========================================
//         // 4️⃣ Medication System
//         // =========================================
//         var pedMedSystem =
//             new MedicationSystem<PediatricPatient>();

//         var gerMedSystem =
//             new MedicationSystem<GeriatricPatient>();

//         Console.WriteLine("\n=== MEDICATION PRESCRIPTION ===");

//         // Pediatric dosage validation (weight > 10 kg)
//         pedMedSystem.PrescribeMedication(
//             p1,
//             "Amoxicillin",
//             patient => patient.Weight > 10);

//         // Geriatric validation (mobility > 3)
//         gerMedSystem.PrescribeMedication(
//             g1,
//             "Metformin",
//             patient => patient.MobilityScore > 3);

//         Console.WriteLine("Medications prescribed successfully.");

//         // =========================================
//         // 5️⃣ Drug Interaction Check
//         // =========================================
//         Console.WriteLine("\n=== INTERACTION CHECK ===");

//         bool interaction =
//             pedMedSystem.CheckInteractions(
//                 p1,
//                 "Ibuprofen");

//         Console.WriteLine(
//             $"Interaction Found: {interaction}");

//         // =========================================
//         // END
//         // =========================================
//         Console.WriteLine("\n=== WORKFLOW COMPLETE ===");
//     }
// }



// // 5. TEST SCENARIO: Simulate hospital workflow
// // a) Create 2 PediatricPatient and 2 GeriatricPatient
// // b) Add them to priority queue with different priorities
// // c) Create medical records with diagnoses/treatments
// // d) Prescribe medications with type-specific validation
// // e) Demonstrate:
// //    - Priority-based patient processing
// //    - Age-specific medication validation
// //    - Treatment history retrieval
// //    - Drug interaction checking
