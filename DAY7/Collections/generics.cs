using System;

namespace collections
{
    class GenericContainer<T>        // <-- declare T here
    {
        private T item;

        public void Add(T value)
        {
            item = value;
        }

        public T Get()
        {
            return item;
        }
    }

    class Generics
    {
        static void Main()
        {
            GenericContainer<int> intContainer = new GenericContainer<int>();
            intContainer.Add(10);
            Console.WriteLine($"Integer Value: {intContainer.Get()}");

            GenericContainer<string> stringContainer = new GenericContainer<string>();
            stringContainer.Add("Hello Generics");
            Console.WriteLine($"String Value: {stringContainer.Get()}");

            
        }
    }
}
