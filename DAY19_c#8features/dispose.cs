using System;

class MyResource : IDisposable
{
    private bool _isDisposed = false;
    private int _value;

    public MyResource(int value)
    {
        _value = value;
        Console.WriteLine("Resource created with value: " + _value);
    }

    public int GetValue()
    {
        if (_isDisposed)
            throw new ObjectDisposedException("MyResource");

        return _value;
    }

    public void Dispose()
    {
        _isDisposed = true;
        Console.WriteLine("Resource disposed");
    }
}

class Program
{
    static void Main()
    {
        MyResource r = new MyResource(50);

        // Use it
        Console.WriteLine("Value before dispose: " + r.GetValue());

        // Dispose it
        r.Dispose();

        // Try using after dispose
        try
        {
            Console.WriteLine("Value after dispose: " + r.GetValue());
        }
        catch (ObjectDisposedException e)
        {
            Console.WriteLine("Cannot use after dispose: " + e.Message);
        }
    }
}
