using System;
/// <summary>
/// declaring Interface if a bird can sing or not 
/// </summary>
public interface ISing
{
    bool CanSing(bool canDo);
}
/// <summary>
/// declaring Interface if a bird can dance or not 
/// </summary>
public interface IDance
{
    bool CanDance(bool canDo);
}
/// <summary>
/// declaring Interface if a bird can fly or not 
/// </summary>
public interface IFly
{
    bool CanFly(bool canDo);
}
/// <summary>
/// defining class bird to create objects and call Interface - Multiple Inheritance
/// </summary>
public class Bird : ISing, IDance, IFly
{
    /// <summary>
    /// defining function canDo from Interface ISing
    /// </summary>
    /// <param name="canDo"></param>
    /// <returns>canDo</returns>
    public bool CanSing(bool canDo)
    {
        return canDo;
    }

    /// <summary>
    /// defining function canDo from Interface IDance
    /// </summary>
    /// <param name="canDo"></param>
    /// <returns></returns>
    public bool CanDance(bool canDo)
    {
        return canDo;
    }

    /// <summary>
    /// defining function canDo from Interface IFly
    /// </summary>
    /// <param name="canDo"></param>
    /// <returns></returns>
    public bool CanFly(bool canDo)
    {
        return canDo;
    }


    /// <summary>
    /// entry point of execution 
    /// </summary>
    /// <param name="args"></param>
    
    public static void Main(string[] args)
    {
        // creating an object for Class Bird
        Bird b1 = new Bird();
        Bird b2 = new Bird();

        //printing b1 properties using interface inheritance
        Console.WriteLine(b1.CanSing(true));
        Console.WriteLine(b1.CanFly(true));
        Console.WriteLine(b1.CanDance(false));

        //printing b2 properties using interface inheritance
        Console.WriteLine(b2.CanSing(true));
        Console.WriteLine(b2.CanFly(true));
        Console.WriteLine(b2.CanDance(false));
    }
}
