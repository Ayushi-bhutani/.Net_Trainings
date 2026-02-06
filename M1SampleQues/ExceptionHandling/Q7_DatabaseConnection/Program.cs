using System;

class DatabaseConnection
{
    static void Main()
    {
        // TODO:
        // 1. Open connection
        // 2. Simulate operation failure
        // 3. Ensure connection is closed properly

        bool isConnected = false;

        try
        {
            // 1. Open connection
            Console.WriteLine("Opening databas  e connection...");
            isConnected = true;

            // 2. Simulate operation failure
            throw new Exception("Database operation failed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            // 3. Ensure connection is closed properly
            if (isConnected)
            {
                Console.WriteLine("Closing database connection...");
                isConnected = false;
            }

            Console.WriteLine("Database connection closed safely.");
        }




    }
}