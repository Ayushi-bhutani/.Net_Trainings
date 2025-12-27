public interface IVegEater
{
    string EatVeg(string message);
    string getTaste();
}

public interface INonVegEater  //should always start with I
{
    string EatNonVeg(string message);
    string getTaste();
}

public class Final : IVegEater, INonVegEater
{
    public string EatVeg(string message)
    {
        return "I eat veg: " + message;
    }

    public string EatNonVeg(string message)
    {
        return "I eat non-veg: " + message;
    }
    public string getTaste(){
        return "Don't know taste";
    }
    }

