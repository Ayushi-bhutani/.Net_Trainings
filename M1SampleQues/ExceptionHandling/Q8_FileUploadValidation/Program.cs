using System;

class FileUpload
{
    static void Main()
    {
        string fileName = "report.exe";
        int fileSize = 8; // MB

        // TODO:
        // 1. Validate file extension
        // 2. Validate file size
        // 3. Throw and handle appropriate exceptions
        try
        {
            ValidateFile(fileName, filesize);
            Console.WriteLine("File upload successful!");
        }
        catch(InvalidFileExtensionException ex)
        {
            Console.WriteLine($"Extension Error: {ex.Message}");

        }
        catch(FileTooLargeException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    static void ValidateFile(string fileName, int fileSize)
    {
        string[] allowedExtensions = {".txt", ".pdf", ".docx"};
        string extension = Path.GetExtension(filename);
        if(Array.IndexOf(allowedExtensions, extension) < 0)
        {
            throw new InvalidFileExtensionException($"'{extension}' is not allowed.");
        }
        if(fileSize > 5)
        {
            throw new FileTooLargeException($"{filesize}MB exceeds maximum allowed size of 5MB.");
        }
    }

    public class InvalidFileExtensionException : Exception
    {
        public InvalidFileExtensionException(string message) : base(message) {}

    }
    public class FileTooLargeException : Exception
    {
        public FileTooLargeException ( string message) : base(message) {}
    }
}