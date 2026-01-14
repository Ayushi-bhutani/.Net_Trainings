using System;
using System.Collections.Generic;

namespace MyLocalNameSpace
{
    public class Student
    {
        public int Id { get; set; }
    }

    public class UGStudent : Student
    {
        public int HighSchoolMark { get; set; }
    }

    public class PGStudent : UGStudent
    {
        public int UGMark { get; set; }
    }
}

namespace LearningCSharp
{
    using MyLocalNameSpace;

    public class CallerClass
    {
        public static void Main1(string[] args)
        {
            // Action delegate that points to a method returning a behavior
            Action<string> logger = NewMethod();

            // Runtime decision – which behavior to use?
            if (DateTime.Now.Hour < 12)
            {
                logger = GoodMorning();
            }
            else
            {
                logger = GoodDay();
            }

            logger("First Call");

            // Change behavior again at runtime
            logger = Method2();
            logger("Application Started");

            Console.ReadLine();
        }

        private static Action<string> NewMethod()
        {
            return message =>
            {
                Console.WriteLine($"[LOG]: {message} at {DateTime.Now}");
            };
        }

        private static Action<string> GoodMorning()
        {
            return message =>
            {
                Console.WriteLine("Good Morning");
            };
        }

        private static Action<string> GoodDay()
        {
            return message =>
            {
                Console.WriteLine("Good Day to you");
            };
        }

        private static Action<string> Method1()
        {
            return message =>
            {
                Console.WriteLine($"[LOG]: {message.ToUpper()} at {DateTime.Now}");
            };
        }

        private static Action<string> Method2()
        {
            return message =>
            {
                Console.WriteLine("Welcome to Programming");
            };
        }
    }

    // Generic class with constraint
    public class MyGlobalType<T> where T : Student
    {
        public List<T> MyCollection { get; set; } = new List<T>();

        public string GetDataType(T t)
        {
            return t.GetType().ToString();
        }

        public void AddItem(T t)
        {
            MyCollection.Add(t);
        }

        public List<T> GetCollection()
        {
            return MyCollection;
        }

        public string ActBasedOnType(T t)
        {
            if (t is PGStudent)
                return "Type is PGStudent";

            if (t is UGStudent)
                return "Type is UGStudent";

            return "Student";
        }
    }

    public class MyGlobalType2<T, K>
    {
        public void MyGlobalFunction(T t, K k)
        {
            // Generic method with two types
        }
    }
}
