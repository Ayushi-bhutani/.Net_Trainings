using System;

namespace delivery
{
    public class InvalidOrderException : Exception
    {
        public InvalidOrderException() { }

        public InvalidOrderException(string message) : base(message) { }

        
    }
}
