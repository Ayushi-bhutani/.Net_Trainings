using System;
using System.Linq;

namespace LinqExample
{
    class LinqExample
    {

        /// <summary>
        /// Entry point of program
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            string[] names = { "A", "B", "C", "D" };

            foreach (var item in names)
            {
                if (item == "B")
                {
                    Console.WriteLine("B is present");
                }
            }

            var findNames = from name in names
                            orderby name descending
                            select IsPalindrome(name);

            foreach (var item in findNames)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        /// <summary>
        /// function IsPalindrome which returns if string is palindrome or not
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string IsPalindrome(string name)
        {
            string reversed = new string(name.Reverse().ToArray());

            if (reversed == name)
            {
                return "Palindrome " + name;
            }

            return "Not a palindrome " + name;
        }
    }
}
