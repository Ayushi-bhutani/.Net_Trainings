using System;
using System.Collections;
namespace collections
{


public class Collections
{
    public void Sample1()
    {
        ArrayList myList = new ArrayList(16);
        myList.Add(10);
        myList.Add(10.5);
        myList.Add("Ayushi");

        // Print items from ArrayList
        foreach (var item in myList)
        {
            Console.WriteLine(item);
        }

        // Stack outside the loop
        Stack myStack = new Stack();
        myStack.Push(100);
        myStack.Push("Bhutani");
        myStack.Push(30.5);

        // Check and display stack items
        if (myStack.Count > 0)
        {
            Console.WriteLine("\nStack elements (LIFO):");
            while (myStack.Count > 0)
            {
                Console.WriteLine(myStack.Pop());
            }
        }
    }
}

class Program
{
    
    static void Main()
        {
            Collections obj = new Collections();
            obj.Sample1();
            GenericContainer<int> intContainer = new GenericContainer<int>();
            intContainer.Add(10);
            Console.WriteLine($"Integer Value: {intContainer.Get()}");

            GenericContainer<string> stringContainer = new GenericContainer<string>();
            stringContainer.Add("Hello Generics");
            Console.WriteLine($"String Value: {stringContainer.Get()}");
        }
}
}
