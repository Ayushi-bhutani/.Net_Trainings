using System.ComponentModel.DataAnnotations;

namespace employee
{
    /// <summary>
    /// defining class program 
    /// </summary>
    public class Program {

        /// <summary>
        /// entry point of program
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            

                Employee e1 = new Employee(1, "Ayushi", "ayus@gmail.com", 3000000);
                Employee e2 = new Employee(2, "Akram", "akrugmail.com", 300000000);
                Employee e3 = new Employee(3, "bro", "abb@gmail.com", -1);

                if(e3.Salary <= 0)
                {
                    e3.Salary = 3000;
                }

                if (!e2.Email.Contains('@'))
                {
                    e2.Email = "unknown@company.com";
                }

                Console.WriteLine(e1.Id);
                Console.WriteLine(e1.Name);
                Console.WriteLine(e1.Salary);
                Console.WriteLine(e1.Email);

                Console.WriteLine(e2.Id);
                Console.WriteLine(e2.Name);
                Console.WriteLine(e2.Salary);
                Console.WriteLine(e2.Email);

                Console.WriteLine(e3.Id);
                Console.WriteLine(e3.Name);
                Console.WriteLine(e3.Salary);
                Console.WriteLine(e3.Email);



        }
    }
}