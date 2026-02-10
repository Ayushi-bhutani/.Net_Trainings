using System.Reflection;

namespace reflection
{
    public class Employee
    {
        public void PublicMethod()
        {
            Console.WriteLine("public");
        }
        private void PrivateMethod()
        {
            Console.WriteLine("private");
        }
        public void Add(int a, int b)
        {
            Console.WriteLine(a+b);
        }
        private string SecretMessage()
        {
            return "Confidential data";
        }
        public void Multiply(int a , int b)
        {
            Console.WriteLine( a*b);
        }
        private void Divide(int a, int b)
        {
            if (a > b)
            {
                Console.WriteLine( a/b);
            }
          
            
        }

    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Employee emp = new Employee();
            Type t = typeof(Employee);


            MethodInfo multiply = typeof(Employee).GetMethod(
                "Multiply",
                BindingFlags.Instance | BindingFlags.Public
            );

            multiply.Invoke(emp, new object[] {1,2});

            MethodInfo divide = typeof(Employee).GetMethod(
                "Divide",
                BindingFlags.Instance | BindingFlags.NonPublic
            );
            divide.Invoke(emp, new object[] {2,1});


            //public method
            emp.PublicMethod();
            //or
            MethodInfo m1 = typeof(Employee).GetMethod(
                "PublicMethod",
                BindingFlags.Instance | BindingFlags.Public
            );

            //for invoking - methodInfo.Invoke(objectInstance, parameters);
            m1.Invoke(emp, null);


            //private method
            MethodInfo m2 = typeof(Employee).GetMethod(
                "PrivateMethod",
                BindingFlags.Instance | BindingFlags.NonPublic 
            );

            m2.Invoke(emp, null);




        }
    }
}