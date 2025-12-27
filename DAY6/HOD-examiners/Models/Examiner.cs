namespace Management;

public class Examiner
{
    public string Name { get; set; }
    public string Dept { get; set; }
    public string ExaminerId { get; set; }

    public Examiner(string name, string dept, string examinerId)
    {
        Name = name;
        Dept = dept;
        ExaminerId = examinerId;
    }

    public override string ToString()
    {
        return $"{Name} ({Dept}) - {ExaminerId}";
    }
}
