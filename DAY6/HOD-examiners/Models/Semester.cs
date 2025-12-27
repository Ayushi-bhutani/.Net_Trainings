namespace Management;

public class Semester
{
    public string SemId { get; set; }

    public Semester(string semId)
    {
        SemId = semId;
    }

    public override string ToString()
    {
        return $"Semester {SemId}";
    }
}
