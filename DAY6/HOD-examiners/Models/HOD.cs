namespace Management;

public class HOD
{
    public string Name { get; set; }
    public string Dept { get; set; }
    public string HodId { get; set; }

    public HOD(string name, string dept, string hodId)
    {
        Name = name;
        Dept = dept;
        HodId = hodId;
    }
}
