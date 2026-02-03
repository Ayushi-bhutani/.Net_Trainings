using System;
using System.IO;

class FileReader
{
    static void Main()
    {
        string filePath = "data.txt";
        StreamReader reader = null;
        try
        {

            reader = new StreamReader(filePath);
            string content = reader.ReadToEnd();
            Console.WriteLine(content);
            

        }
        catch(FileNotFoundException)
        {
            Console.WriteLine("File not found");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Unauthroised access");
        }
        finally
        {
            if(reader != null)
            {
                reader.Close();
            }
        }
        

        
    }
}