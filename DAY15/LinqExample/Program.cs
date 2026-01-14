using System;
using System.Linq;

namespace LinqExample
{
    class LinqExample
    {
        /// <summary>
        /// Entry point of program
        /// </summary>
        public static void Main(string[] args)
        {
            // LinqExample1();
            // LinqExample2();
            // LinqExample3();
            LinqExample4();

            Console.ReadLine();
        }

        /// <summary>
        /// LINQ example on string collection
        /// </summary>
        private static void LinqExample1()
        {
            string[] names = { "A", "B", "C", "D" };

            foreach (var item in names)
            {
                if (item == "B")
                {
                    Console.WriteLine("B is present");
                }
            }

            // Dynamic LINQ collection
            var findNames = from name in names
                            orderby name descending
                            select IsPalindrome(name);


            foreach (var item in findNames)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// LINQ example on system processes
        /// </summary>
        private static void LinqExample2()
        {
            var procCollection =
                from p in System.Diagnostics.Process.GetProcesses()
                select new MyProcess()
                {
                    Name = p.ProcessName,
                    Id = p.Id
                };

            foreach (var proc in procCollection)
            {
                Console.WriteLine($"Process Name : {proc.Name}  Id : {proc.Id}");
            }
        }

        /// <summary>
        /// Function to check palindrome
        /// </summary>
        public static string IsPalindrome(string name)
        {
            string reversed = new string(name.Reverse().ToArray());

            if (reversed == name)
            {
                return "Palindrome " + name;
            }

            return "Not a palindrome " + name;
        }

        private static void LinqExample3()
{
    string[] names = { "A", "B", "C", "D" };

    var findNames = from name in names
                    orderby name descending
                    select new MyProcess() { Name = name };

    foreach (var item in findNames)
    {
        Console.WriteLine(item.Name);   // Accessing property
    }
}
    private static void LinqExample4()
        {

            var procCollection =
                from p in System.Diagnostics.Process.GetProcesses()
                //no defined class objects (datatype) microsoft creates own class and keep values inside property
                //anonymus datatypes cant be accessed outside scope 
                select new 
                {
                    Name = p.ProcessName,
                    Id = p.Id
                };

            foreach (var proc in procCollection)
            {
                Console.WriteLine($"Process Name : {proc.Name}  Id : {proc.Id}");
            }

            // var procCollection = from p in System.Diagnostics.Process.GetProcesses()
            //                      select Math.Max(0, p.Id);

            var maxProcess = System.Diagnostics.Process.GetProcesses().Max(p=>p.Id);
            var AverageProcess = System.Diagnostics.Process.GetProcesses().Average(p=>p.Id);

            Console.WriteLine($"Max process: {maxProcess}");
            Console.WriteLine($"AverageProcess: {AverageProcess}");




        }


        
    }

    /// <summary>
    /// Custom class used in LINQ projection
    /// </summary>
    class MyProcess
    {
        public string? Name { get; set; }
        public int Id { get; set; }

        public override string ToString()
        {
            return $"Process Name : {Name}  Id : {Id}";
        }
    }
}
