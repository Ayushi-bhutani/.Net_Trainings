using System;

public ref struct TempBuffer
{
    public void Dispose()
    {
        Console.WriteLine("TempBuffer disposed");
    }
}

class Program
{
    public static void UseBuffer()
    {
        // C# 8.0+: pattern-based using works with ref struct
        using var buf = new TempBuffer();
        Console.WriteLine("Working with TempBuffer...");
    }

    static void Main()
    {
        UseBuffer();
        Console.WriteLine("Method finished");
    }
}
