using System;

class Controller
{
    static void Main()
    {
        // TODO:
        // Call Service method
        // Handle exception here

        try
        {
            Service.Process();  //static class and method 
        }
        catch (Exception ex)
        {
            Console.WriteLine("Controller caught Excepion");
            Console.WriteLine(ex.Message);
        } 
    }
}

class Service
{
    public static void Process()
    {
        // TODO:
        // Call Repository method
        // Catch, log and rethrow exception
        
        try
        { 
            Repository.GetData();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Service level Exception");
            Console.WriteLine(ex.Message);
            throw ;
        }
    }
}

class Repository
{
    public static void GetData()
    {
        // TODO:
        // Throw an exception here
        throw new InvalidOperationException("Database connection failed");


    }
}