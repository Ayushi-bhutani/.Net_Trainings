using System;
class LoginAttemptsExceededException : Exception
{
    public LoginAttemptsExceededException(string message) : base(message)
    {
    }
}
class LoginSystem
{
    public 
    static void Main()
    {
        int attempts = 0;
        const int maxAttempts = 3;

        try
        {
            while (true)
            {
                Console.WriteLine("Enter password:");
                string password = Console.ReadLine();
                attempts++;

                // Assume correct password is "admin"
                if (password == "admin")
                {
                    Console.WriteLine("Login successful.");
                    break;
                }

                Console.WriteLine("Invalid password.");

                // 2. Throw custom exception after limit
                if (attempts >= maxAttempts)
                {
                    throw new LoginAttemptsExceededException(
                        "Login failed: Maximum attempts exceeded.");
                }
            }
        

        // TODO:
        // 1. Allow only 3 login attempts
        // 2. Create and throw custom exception after limit
        // 3. Handle exception and terminate application
        }
        catch (LoginAttemptsExceededException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Application terminated.");
        }
    }
}