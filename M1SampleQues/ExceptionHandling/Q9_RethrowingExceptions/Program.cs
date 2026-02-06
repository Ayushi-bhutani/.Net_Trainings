using System;

class ExceptionRethrow
{
    static void Main()
    {
        try
        {
            ProcessData();
        }
        catch (Exception ex)
        {
            // TODO:
            // Handle final exception
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
        }
    }

    static void ProcessData()
    {
        try
        {
            int.Parse("ABC");
        }
        catch (Exception ex)
        {
            // TODO:
            // Log exception
            // Rethrow while preserving stack trace
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}